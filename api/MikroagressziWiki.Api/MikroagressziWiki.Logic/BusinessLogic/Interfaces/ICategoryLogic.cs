using Mikroagresszi.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroagresszi.Logic.BusinessLogic.Interfaces
{
    public interface ICategoryLogic
    {
        IList<CategoryModel> GetAll();
    }
}
