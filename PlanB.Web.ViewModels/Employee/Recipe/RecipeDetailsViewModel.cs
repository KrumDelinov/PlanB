namespace PlanB.Web.ViewModels.Employee.Recipe
{
    public class RecipeDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<IngradientViewModel> Ingradients { get; set; }
    }
}
