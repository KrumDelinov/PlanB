using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data
{
    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public RecipesService(IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }


        public void CreateRecipe() 
        {
            string name = "BigCup";
            var ingredients = new Dictionary<string, decimal>();

            ingredients.Add("Flour", 12.4m);
            ingredients.Add("Oat", 24.3m);
            ingredients.Add("Sugar", 12m);

        }

        public RecipeDetailsViewModel Details()
        {
            var recipe = recipeRepository.All().Where(x => x.Id == 2).FirstOrDefault();

            var ingradients = new List<IngradientViewModel>();
         

            var viewModel = new RecipeDetailsViewModel { Name = recipe.Name, Ingradients = ingradients };
            return viewModel;
        }
    }
}
