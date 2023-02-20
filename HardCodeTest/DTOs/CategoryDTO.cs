namespace HardCodeTest.DTOs
{
    public class CategoryDTO
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PropertyField> MiscFields { get; set; }
    }
}
