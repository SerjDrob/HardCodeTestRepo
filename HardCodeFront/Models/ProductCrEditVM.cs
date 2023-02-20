namespace HardCodeFront.Models
{
    public class ProductCrEditVM
    {
        public ProductDTO ProductDTO { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<string>? AdFields { get; set; }
    }
}
