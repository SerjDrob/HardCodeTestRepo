using AutoMapper;
using HardCodeData.Models;

namespace HardCodeTest.DTOs.MapProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, Category>()
                .ForMember(dest=>dest.MiscFields, opt=>opt.MapFrom(src=>src.MiscFields.Select(mf=>new MiscField { Name = mf})))
                .ReverseMap()
                .ForPath(dest=>dest.MiscFields, opt=>opt.MapFrom(src=>src.MiscFields.Select(mf=>mf.Name)));
        }
    }
}
