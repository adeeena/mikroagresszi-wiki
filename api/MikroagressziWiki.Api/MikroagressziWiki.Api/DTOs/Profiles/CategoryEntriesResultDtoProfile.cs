using AutoMapper;
using MikroagressziWiki.Logic.Models;

namespace MikroagressziWiki.Api.DTOs.Profiles
{
    public class CategoryEntriesResultDtoProfile : Profile
    {
        public CategoryEntriesResultDtoProfile()
        {
            CreateMap<CategoryEntriesResultModel, CategoryEntriesResultDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Entries, opt => opt.MapFrom(src => src.Entries));
        }
    }
}
