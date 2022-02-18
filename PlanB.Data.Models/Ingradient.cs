using PlanB.Data.Common.Models;

namespace PlanB.Data.Models
{
    public class Ingradient : BaseDeletableModel<int>
    {
        public string Product { get; set; }

        public double Quantity { get; set; }

        public ICollection<RecipesIngradients> RecipesIngradients { get; set; } = new HashSet<RecipesIngradients>();
    }
}
