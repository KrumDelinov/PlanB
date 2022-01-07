using PlanB.Data;

namespace PlanB.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync (IServiceProvider serviceProvider)
        {
         

            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                if (serviceProvider == null)
                {
                    throw new ArgumentNullException(nameof(serviceProvider));
                }

                var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

                var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new SettingsSeeder(),
                          };

                foreach (var seeder in seeders)
                {
                    await seeder.SeedAsync(serviceProvider);
                    await context.SaveChangesAsync();
                    logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
                }
            }
        }


    }
}
