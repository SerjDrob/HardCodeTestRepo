using System.ComponentModel.DataAnnotations;

namespace HardCodeData.Models
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public IList<MiscField>? MiscFields { get; set; }
        public IList<Product>? Products { get; set; }
    }
}