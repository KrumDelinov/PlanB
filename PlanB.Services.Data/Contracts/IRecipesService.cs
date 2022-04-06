using PlanB.Data.Models;
using PlanB.Web.ViewModels.Employee.Recipe;

namespace PlanB.Services.Data.Contracts
{
    public interface IRecipesService
    {
        void CreateRecipe();

        RecipeDetailsViewModel Details(int? id);

        T GetT<T>(string name);

        Recipe GetRecipe(string name);
    }
}
