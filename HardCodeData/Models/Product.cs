using System.ComponentModel.DataAnnotations;

namespace HardCodeData.Models
{
    public class Product:BaseEntity
    {
        public string? Image { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<MiscFieldValue> MiscFieldValues { get; set; }
    }
}