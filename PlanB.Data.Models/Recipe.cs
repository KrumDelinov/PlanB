using PlanB.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanB.Data.Models
{
    public class Recipe : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        
        public ICollection<RecipesIngradients> RecipesIngradients { get; set; } = new HashSet<RecipesIngradients>();
    }
}
