using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardCodeData.Models
{
    public class Product:BaseEntity
    {
        public string? Image { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public List<MiscFieldValue>? MiscFieldValues { get; set; }
    }
}