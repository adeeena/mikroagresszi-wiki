using MikroagressziWiki.Logic.Models;

namespace Mikroagresszi.Logic.BusinessLogic.Interfaces
{
    public interface ITranslationLogic
    {
        object GetBy(string languageCode);
    }
}
