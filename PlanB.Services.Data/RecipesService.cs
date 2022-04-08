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

        public RecipeDetailsViewModel Details(int? id)
        {
            var recipe = recipeRepository.All().Where(x => x.Id == id).Select(i => new RecipeDetailsViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Ingradients = i.RecipesIngradients.Select(i => new IngradientViewModel
                {
                    Id = i.IngradientId,
                    Name = i.Ingradient.Product,
                    Quantity = i.Ingradient.Quantity
                }).ToList()
            }).FirstOrDefault();

           


            var viewModel = recipe;
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
