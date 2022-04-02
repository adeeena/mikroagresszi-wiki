using System;
using System.Collections.Generic;

namespace MikroagressziWiki.Domain.Models
{
    public partial class Translation
    {
        public int Id { get; set; }
        public string TranslationKey { get; set; }
        public string TranslationValue { get; set; }
        public string LanguageCode { get; set; }
    }
}
