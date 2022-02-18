using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Mapping;

namespace PlanB.Services.Data
{
    public class RolesService : IRolesService
    {
        private readonly IDeletableEntityRepository<ApplicationRole> roleRepository;

        public RolesService(IDeletableEntityRepository<ApplicationRole> roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public IEnumerable<T> GetAll<T>()
        {
            return this.roleRepository.All().To<T>().ToList();
        }
    }
}
