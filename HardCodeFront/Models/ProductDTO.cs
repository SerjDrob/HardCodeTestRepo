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

    public class ProductCrEditVM
    {
        public ProductDTO ProductDTO { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }


    public struct PropertyField
    {
        public PropertyField(int id, string name, string value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
