using PlanB.Data.Models;
using PlanB.Web.ViewModels.Employee.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data.Contracts
{
    public interface IRecipesService
    {
        void CreateRecipe();

        RecipeDetailsViewModel Details();

        T GetT<T>(string name);

        Recipe GetRecipe(string name);
    }
}
