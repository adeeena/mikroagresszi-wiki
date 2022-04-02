using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Mikroagresszi.Logic.BusinessLogic.Interfaces;
using MikroagressziWiki.Core.Extensions;
using MikroagressziWiki.Domain.Models;
using MikroagressziWiki.Logic.Models;
using Newtonsoft.Json;

namespace MikroagressziWiki.Logic.BusinessLogic
{
    public class TranslationLogic : ITranslationLogic
    {
        #region Properties

        private readonly MikroagressziContext _context;

        private readonly IMapper _mapper;

        private readonly IMemoryCache _memoryCache;

        #endregion

        #region ctor

        public TranslationLogic(MikroagressziContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            _context = context;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        #endregion

        #region Additional Methods

        public object GetBy(string languageCode)
        {
            string CACHE_KEY = "TRANSLATION_" + languageCode;

            if (true || !_memoryCache.TryGetValue(CACHE_KEY, out object cacheValue))
            {
                MemoryCacheEntryOptions? cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                List<Translation> translations = _context.Translations
                    .Where(q => q.LanguageCode == languageCode).ToList();

                var translationModels = _mapper.MapCollection<Translation, TranslationModel>(translations);

                //Dictionary<string, Dic>

                cacheValue = JsonConvert.SerializeObject(
                    translationModels.ToDictionary(key => key.Key, v => v.Value));

                _memoryCache.Set(CACHE_KEY, cacheValue, cacheEntryOptions);
            }

            return cacheValue;
        }

        #endregion
    }
}
