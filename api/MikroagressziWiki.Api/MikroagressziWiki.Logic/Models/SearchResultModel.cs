using MikroagressziWiki.Domain.Models;

namespace MikroagressziWiki.Logic.Models
{
    public class SearchResultModel
    {
        public IList<EntryModel> Entries { get; set; }
    }
}
