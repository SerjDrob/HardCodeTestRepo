using System.ComponentModel.DataAnnotations;

namespace HardCodeData.Models
{
    public class MiscField:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<MiscFieldValue>? MiscFieldValues { get; set; }
    }
}