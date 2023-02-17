using AutoMapper;
using HardCodeData.Models;

namespace HardCodeTest.DTOs.MapProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest=>dest.AdditionalFields,                 
                opt=>opt.MapFrom(src=>src.MiscFieldValues.Select(k=> new PropertyField(k.MiscFieldId,k.MiscField.Name, k.FieldValue ))));
        }
    }
}
