using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Recipe
{
    public class CreateRecipeViewModel
    {
        public string Name { get; set; }

        public IList<SelectListItem> Ingradients { get; set; }
    }
}
