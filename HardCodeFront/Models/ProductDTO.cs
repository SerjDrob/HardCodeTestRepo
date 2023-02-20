using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HardCodeFront.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [DisplayName("Изображение")]
        public IFormFile? Image { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string? Description { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Категория")]
        public string? CategoryName { get; set; }
        public IList<PropertyField>? AdditionalFields { get; set; }
    }
}
