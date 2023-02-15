using AutoMapper;
using HardCodeData.Models;
using HardCodeTest.Data;
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
                //.Include(p=>p.Category).ThenInclude(c=>c.MiscFields)
                .ToList();
            if (products is null) return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _db.Set<Product>()
                //.Include(p => p.Category).ThenInclude(c => c.MiscFields)
                .SingleOrDefault(p=>p.Id== id);
            if (product is null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody]Product product)
        {
            _db.Add(product);
            _db.SaveChanges();
            return CreatedAtAction(nameof(AddProduct), product);
        }
        
    }
}
