using AutoMapper;
using HardCodeData.Models;
using HardCodeTest.Data;
using HardCodeTest.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HardCodeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IWebHostEnvironment _hostEnvironment;
       
        public ProductController(HardCodeDbContext db, IMapper mapper, IWebHostEnvironment hostEnvironment) : base(db, mapper)
        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = _db.Set<Product>()
                .Include(p=>p.MiscFieldValues).ThenInclude(mv=>mv.MiscField)
                .Include(p=>p.Category)
                .ToList();
            if (products is null) return NotFound();
            var productDTOs = products.Select(_mapper.Map<ProductDTO>).ToList();
            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _db.Set<Product>()
                .Include(p => p.MiscFieldValues).ThenInclude(mv => mv.MiscField)
                .Include(p => p.Category)
                .SingleOrDefault(p=>p.Id== id);
            if (product is null) return NotFound();
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductDTO productDTO)
        {
            var category = _db.Set<Category>().SingleOrDefault(c => c.Id == productDTO.CategoryId);
            var miscFieldsExists = productDTO.AdditionalFields
                .Aggregate(true, (prev, cur) => prev & _db.Set<MiscField>().Any(c => c.Id == cur.Id));

            if (category is null) return BadRequest($"Category {productDTO.CategoryId} doesn't exist");
            if (!miscFieldsExists) return BadRequest("One or more additional fields are invalid");

            var product = new Product
            {
                Name = productDTO.Name,
                Category = category,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Image = productDTO.ImageName,
                MiscFieldValues = null,
            };

            var newFieldsValue = productDTO.AdditionalFields.Select(f => new MiscFieldValue
            {
                FieldValue = f.Value,
                MiscFieldId = f.Id,
                Product = product
            });

            try
            {
                _db.Add(product);
                _db.AddRange(newFieldsValue);
                var bytes = Convert.FromBase64String(productDTO.ImageBytes);
                var path = Path.Combine(_hostEnvironment.WebRootPath, WC.IMAGES, productDTO.ImageName);
                await System.IO.File.WriteAllBytesAsync(path, bytes);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            
            return CreatedAtAction(nameof(AddProduct), product);
        }
        
    }
}
