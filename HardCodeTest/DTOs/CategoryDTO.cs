namespace HardCodeTest.DTOs
{
    public class CategoryDTO
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> MiscFields { get; set; }
    }
}
