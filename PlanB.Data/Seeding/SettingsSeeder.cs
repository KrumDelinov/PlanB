namespace PlanB.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PlanB.Data.Models;

    internal class SettingsSeeder : ISeeder
    {
        public async Task SeedAsync(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Settings.Any())
                {
                    return;
                }

                await context.Settings.AddAsync(new Setting { Name = "Setting1", Value = "value1" });
            }
        }
    }
}
