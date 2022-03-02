using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace PlanB.Data.Seeding
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PlanB.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class IngradientsSeeder : ISeeder
    {
        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context.Ingredients.Any())
            {
                return;
            }

            await context.Ingredients.AddAsync(new Ingradient { Product = "Flour", Quantity = 10.3 });
        }
    }
}
