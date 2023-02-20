using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HardCodeData.Models
{
    public class Product:BaseEntity
    {
        public string? Image { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        //[Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public List<MiscFieldValue>? MiscFieldValues { get; set; }
    }
}