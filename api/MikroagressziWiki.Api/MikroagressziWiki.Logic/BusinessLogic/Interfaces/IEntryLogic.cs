using MikroagressziWiki.Logic.Models;

namespace MikroagressziWiki.Logic.BusinessLogic.Interfaces
{
    public interface IEntryLogic
    {
        CategoryEntriesResultModel GetBy(string categoryId);

        EntryModel GetById(string entryId);

        SearchResultModel SearchBy(string query);
    }
}
