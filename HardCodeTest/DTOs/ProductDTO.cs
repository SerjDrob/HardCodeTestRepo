using HardCodeData.Models;
using System.ComponentModel.DataAnnotations;

namespace HardCodeTest.DTOs
{
    public class ProductDTO
    {
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class CategoryDTO
    {
        public string Name { get; set; }
        public IEnumerable<string> MiscFields { get; set; }
    }
}
