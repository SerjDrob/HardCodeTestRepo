using HardCodeData.Models;
using System.ComponentModel.DataAnnotations;

namespace HardCodeTest.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string ImageBytes { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        /// <summary>
        /// MiscFieldId, MiscFieldName,MiscFildValue
        /// </summary>
        public IList<PropertyField>? AdditionalFields { get; set; }
    }
}
