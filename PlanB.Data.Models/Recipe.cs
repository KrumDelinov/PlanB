using PlanB.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Data.Models
{
    public class Recipe : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<RecipesIngradients> RecipesIngradients { get; set; } = new HashSet<RecipesIngradients>();
    }
}
