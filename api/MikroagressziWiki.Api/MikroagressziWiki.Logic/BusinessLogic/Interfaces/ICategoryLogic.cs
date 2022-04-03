using Mikroagresszi.Logic.Models;

namespace Mikroagresszi.Logic.BusinessLogic.Interfaces
{
    public interface ICategoryLogic
    {
        IList<CategoryModel> GetBy(string languageCode);
    }
}
