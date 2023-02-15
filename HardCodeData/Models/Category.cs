using System.ComponentModel.DataAnnotations;

namespace HardCodeData.Models
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<MiscField>? MiscFields { get; set; }
    }
}