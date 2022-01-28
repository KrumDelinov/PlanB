using PlanB.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Data.Models
{
    public class Ingradient : BaseDeletableModel<int>
    {
        public string Product { get; set; }

        public double Quantity { get; set; }

        public ICollection<RecipesIngradients>  RecipesIngradients { get; set; } = new HashSet<RecipesIngradients>();
    }
}
