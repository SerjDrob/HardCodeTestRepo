using AutoMapper;
using HardCodeData.Models;
using HardCodeTest.Data;
using HardCodeTest.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HardCodeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(HardCodeDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = _db.Set<Product>()
                .Include(p=>p.MiscFieldValues)
                .Include(p=>p.Category)
                .ToList();
            if (products is null) return NotFound();
            var productDTOs = products.Select(_mapper.Map<ProductDTO>);
            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _db.Set<Product>()
                .Include(p => p.MiscFieldValues)
                .Include(p => p.Category)
                .SingleOrDefault(p=>p.Id== id);
            if (product is null) return NotFound();
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody]ProductDTO productDTO)
        {
            var category = _db.Set<Category>().SingleOrDefault(c=>c.Id== productDTO.CategoryId);
            var miscFieldsExists = productDTO.AdditionalFields
                .Aggregate(true, (prev, cur) => prev & _db.Set<MiscField>().Any(c => c.Id == cur.Key));

            if(category is null) return BadRequest($"Category {productDTO.CategoryId} doesn't exist");
            if (!miscFieldsExists) return BadRequest("One or more additional fields are invalid");

            var product = new Product
            {
                Name = productDTO.Name,
                Category = category,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Image = productDTO.Image?.FileName,
                MiscFieldValues = null,
            };

            var newFieldsValue = productDTO.AdditionalFields.Select(f => new MiscFieldValue
            {
                FieldValue = f.Value,
                MiscFieldId = f.Key,
                Product = product
            });

            try
            {
                _db.Add(product);
                _db.AddRange(newFieldsValue);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return CreatedAtAction(nameof(AddProduct), product);
        }
        
    }
}
