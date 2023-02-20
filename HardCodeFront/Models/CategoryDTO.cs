using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HardCodeFront.Models
{
    public class CategoryDTO
    {   
        public int Id { get; set; }
        [DisplayName("Название")]
        [Required(ErrorMessage = "Необходимо ввести название категории")]
        public string Name { get; set; }
        public IEnumerable<PropertyField> MiscFields { get; set; } = new List<PropertyField>();
        [JsonIgnore]
        public IEnumerable<string>? ExistingFields { get; set; }
    }
}
