namespace HardCodeFront.Models
{
    public class HomeVM
    {
        public IEnumerable<string> CategorieNames { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
