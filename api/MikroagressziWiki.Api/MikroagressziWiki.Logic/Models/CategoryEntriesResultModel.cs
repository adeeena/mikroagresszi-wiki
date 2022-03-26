using MikroagressziWiki.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroagressziWiki.Logic.Models
{
    public class CategoryEntriesResultModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Entry> Entries { get; set; }
    }
}
