using PlanB.Data;
using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Services.Mapping;
using PlanB.Web.ViewModels.Employee.Recipe;

namespace PlanB.Services.Data
{
    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;
        private readonly ApplicationDbContext dbContext;

        public RecipesService(IDeletableEntityRepository<Recipe> recipeRepository, ApplicationDbContext dbContext)
        {
            this.recipeRepository = recipeRepository;
            this.dbContext = dbContext;
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

        public Recipe GetRecipe(string name)
        {
            return dbContext.Recipes.Where(n => n.Name == name).FirstOrDefault();
        }

        public T GetT<T>(string name)
        {
            return recipeRepository.All().Where(n => n.Name == name).To<T>().FirstOrDefault();
        }
    }
}
