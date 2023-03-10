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
    public class CategoryController : BaseController
    {
        public CategoryController(HardCodeDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        [HttpGet]
        public ActionResult GetAllCategories()
        {
            var categories = _db.Set<Category>()
                .Include(c => c.MiscFields)
                .ToList();
            var categoryDTOs = categories.Select(_mapper.Map<CategoryDTO>).ToList();
            return Ok(categoryDTOs);
        }
        [HttpPost]
        public ActionResult AddCategory([FromBody]CategoryDTO categoryDTO) 
        {
            var category = _mapper.Map<Category>(categoryDTO);
            try
            {
                _db.Add(category);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return CreatedAtAction(nameof(AddCategory),category);
        }
        [HttpDelete]
        public ActionResult DeleteCategory([FromQuery]int id)
        {
            var category = _db.Set<Category>().SingleOrDefault(c => c.Id == id);
            if (category is null) return NotFound();
            _db.Remove(category);
            _db.SaveChanges();
            return Ok();
        }
    }
}
