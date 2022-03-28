using MikroagressziWiki.Api.DTOs;
using MikroagressziWiki.Domain.Models;

namespace MikroagressziWiki.Logic.Models
{
    public class SearchResultDto
    {
        public IList<EntryDto> Entries { get; set; }
    }
}
