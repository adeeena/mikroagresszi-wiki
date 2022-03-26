using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroagresszi.Logic.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Order { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
