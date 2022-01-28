using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Recipe
{
    public class RecipeDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<IngradientViewModel>  Ingradients { get; set; }
    }
}
