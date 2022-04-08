namespace PlanB.Web.ViewModels.Employee.Recipe
{
    public class RecipeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<IngradientViewModel> Ingradients { get; set; }
    }
}
