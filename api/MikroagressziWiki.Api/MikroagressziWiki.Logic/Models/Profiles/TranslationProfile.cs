using AutoMapper;
using MikroagressziWiki.Domain.Models;
using MikroagressziWiki.Logic.Models;

namespace Mikroagresszi.Logic.Models.Adapters
{
    public class TranslationProfile : Profile
    {
        public TranslationProfile()
        {
            CreateMap<Translation, TranslationModel>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.TranslationKey))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.TranslationValue));
        }
    }
}
