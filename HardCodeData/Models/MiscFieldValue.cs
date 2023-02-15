using System.ComponentModel.DataAnnotations;

namespace HardCodeData.Models
{
    public class MiscFieldValue:BaseEntity
    {
        [Required]
        public string FieldValue { get; set; }
    }
}