using System.ComponentModel.DataAnnotations;

namespace HardCodeFront.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public IDictionary<int,string>? AdditionalFields { get; set; }
    }
}
