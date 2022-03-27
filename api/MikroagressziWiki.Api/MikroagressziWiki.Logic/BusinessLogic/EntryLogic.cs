using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MikroagressziWiki.Core.Extensions;
using MikroagressziWiki.Domain.Models;
using MikroagressziWiki.Logic.BusinessLogic.Interfaces;
using MikroagressziWiki.Logic.Models;

namespace MikroagressziWiki.Logic.BusinessLogic
{
    public class EntryLogic : IEntryLogic
    {
        #region Properties

        private readonly MikroagressziContext _context;

        private readonly IMapper _mapper;

        private readonly IMemoryCache _memoryCache;

        #endregion

        #region ctor

        public EntryLogic(MikroagressziContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            _context = context;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        #endregion

        #region Additional Methods

        public CategoryEntriesResultModel GetBy(string categoryId)
        {
            string CACHE_KEY = "ENTRIES_BY_CATEGORY_" + categoryId;

            if (!_memoryCache.TryGetValue(CACHE_KEY, out CategoryEntriesResultModel cacheValue))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                var category = _context.Categories.SingleOrDefault(q => q.Id == categoryId);
                var entries = _context.Entries
                    .Where(q => q.Categories.Any(w => w.Id == categoryId)).ToList();

                cacheValue = new CategoryEntriesResultModel
                {
                    Name = category.Name,
                    Description = category.Description,
                    Entries = entries
                };

                _memoryCache.Set(CACHE_KEY, cacheValue, cacheEntryOptions);
            }

            return cacheValue;
        }

        public EntryModel GetById(string entryId)
        {
            string CACHE_KEY = "ENTRY_BY_ID_" + entryId;

            if (!_memoryCache.TryGetValue(CACHE_KEY, out EntryModel cacheValue))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                var entry = _context.Entries
                    .Include(q => q.Categories)
                    .Include(q => q.Entryresources)
                    .SingleOrDefault(q => q.Id == entryId);

                var entryRelatedKeywords = entry.Description.Split(' ',
                    StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .OrderByDescending(q => q.Length).Take(3).ToList();

                List<Entry> relatedEntries = new List<Entry>();

                for (var i = 0; i < entryRelatedKeywords.Count(); i++)
                {
                    var keyword = entryRelatedKeywords[i];

                    if (keyword.Length > 5)
                    {
                        keyword = keyword.Substring(0, 5);
                    }

                    relatedEntries.AddRange(_context.Entries
                        .Where(q => q.Id != entry.Id &&
                        (q.Title.Contains(keyword) || q.Description.Contains(keyword)))
                        .Take(6).ToList());
                }

                relatedEntries = relatedEntries.DistinctBy(q => q.Id).Take(6).ToList();

                // euh do it in correct way TODO
                var relatedEntryModels = _mapper.MapCollection<Entry, EntryModel>(relatedEntries);
                cacheValue = _mapper.Map<Entry, EntryModel>(entry);
                cacheValue.RelatedEntries = relatedEntryModels;

                _memoryCache.Set(CACHE_KEY, cacheValue, cacheEntryOptions);
            }

            return cacheValue;
        }

        public CategoryEntriesResultModel SearchBy(string query)
        {
            string CACHE_KEY = "ENTRY_SEARCH_BY_ID_" + query;

            if (!_memoryCache.TryGetValue(CACHE_KEY, out CategoryEntriesResultModel cacheValue))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                var entries = _context.Entries
                    .Where(q => q.Description.Contains(query) || q.Title.Contains(query)).ToList();

                cacheValue = new CategoryEntriesResultModel
                {
                    Entries = entries
                };

                _memoryCache.Set(CACHE_KEY, cacheValue, cacheEntryOptions);
            }

            return cacheValue;
        }

        #endregion
    }
}
