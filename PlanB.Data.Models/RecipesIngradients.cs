using PlanB.Data.Common.Models;

namespace PlanB.Data.Models
{
    public class RecipesIngradients : BaseDeletableModel<int>
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngradientId { get; set; }

        public Ingradient Ingradient { get; set; }
    }
}
