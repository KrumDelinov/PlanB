using PlanB.Data;
using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Services.Mapping;

namespace PlanB.Services.Data
{
    public class TanksServise : ITanksServise
    {
        private readonly IDeletableEntityRepository<Tank> tankRepository;
        private readonly IRecipesService recipesService;
        private readonly ApplicationDbContext dbContext;
        private readonly IDeletableEntityRepository<Ingradient> ingradientRepository;

        public TanksServise(IDeletableEntityRepository<Tank> tankRepository,
            IRecipesService recipesService,
            ApplicationDbContext dbContext,
            IDeletableEntityRepository<Ingradient> ingradientRepository
            )
        {
            this.tankRepository = tankRepository;
            this.recipesService = recipesService;
            this.dbContext = dbContext;
            this.ingradientRepository = ingradientRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return tankRepository.All().To<T>().ToList();
        }

        public async Task UpdateTanksAsync(string recipeName)
        {
            var recipe = recipesService.GetRecipe(recipeName);

            var recipeIngradient = dbContext.RecipesIngradients.Where(i => i.RecipeId == recipe.Id).ToList();

            var tanks = tankRepository.All().ToList();

            foreach (var item in recipeIngradient)
            {
                var ingradient = ingradientRepository.All().Where(i => i.Id == item.IngradientId).FirstOrDefault();
                var tank = tanks.FirstOrDefault(x => x.Name == ingradient.Product);

                tank.Amount -= ingradient.Quantity;
                tankRepository.Update(tank);
                await tankRepository.SaveChangesAsync();
            }
        }
    }
}
