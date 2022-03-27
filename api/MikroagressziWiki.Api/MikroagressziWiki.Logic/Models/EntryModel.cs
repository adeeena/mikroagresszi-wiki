﻿using Mikroagresszi.Logic.Models;

namespace MikroagressziWiki.Logic.Models
{
    public class EntryModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IList<CategoryModel> Categories { get; set; }

        public IList<EntryModel> RelatedEntries { get; set; }
    }
}
