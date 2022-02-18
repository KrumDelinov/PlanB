using PlanB.Data.Common.Models;

namespace PlanB.Data.Models
{
    public class Recipe : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<RecipesIngradients> RecipesIngradients { get; set; } = new HashSet<RecipesIngradients>();
    }
}
