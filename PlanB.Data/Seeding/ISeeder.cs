namespace PlanB.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(IServiceProvider serviceProvider);
    }
}
