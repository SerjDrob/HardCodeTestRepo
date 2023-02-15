using System.ComponentModel.DataAnnotations;

namespace HardCodeData.Models
{
    public class MiscFieldValue:BaseEntity
    {
        [Required]
        public string FieldValue { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MiscFieldId { get; set; }
        public MiscField MiscField { get; set; }
    }
}