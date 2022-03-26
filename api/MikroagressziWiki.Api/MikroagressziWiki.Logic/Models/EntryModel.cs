using Mikroagresszi.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroagressziWiki.Logic.Models
{
    public class EntryModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IList<CategoryModel> Categories { get; set; }
    }
}
