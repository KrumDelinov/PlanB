using PlanB.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanB.Data.Models
{
    public class Ingradient : BaseDeletableModel<int>
    {
        [Required]
        public string Product { get; set; }

        [Required]
        public double Quantity { get; set; }

        public ICollection<RecipesIngradients> RecipesIngradients { get; set; } = new HashSet<RecipesIngradients>();
    }
}
