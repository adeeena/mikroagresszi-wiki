using AutoMapper;
using MikroagressziWiki.Logic.Models;

namespace MikroagressziWiki.Api.DTOs.Profiles
{
    public class SearchResultDtoProfile : Profile
    {
        public SearchResultDtoProfile()
        {
            CreateMap<SearchResultModel, SearchResultDto>()
                .ForMember(dest => dest.Entries, opt => opt.MapFrom(src => src.Entries));
        }
    }
}
