using MikroagressziWiki.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroagressziWiki.Logic.BusinessLogic.Interfaces
{
    public interface IEntryLogic
    {
        CategoryEntriesResultModel GetBy(string categoryId);

        EntryModel GetById(string entryId);

        //TODO proper return object to write
        CategoryEntriesResultModel SearchBy(string query);
    }
}
