using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Mapping;
using PlanB.Web.ViewModels.Administration.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IEnumerable<T> GetAll<T>()
        {
            return this.usersRepository.All().To<T>().ToList();
        }

        public async Task<IndexViewModel> GetUsersWithRolesAsync()
        {
            
            var models = new List<UserViewModel>();
            var users = await userManager.Users.ToListAsync();

           

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);

                var userRoles = new List<RoleViewModel>();

                foreach (var name in roles)
                {
                    var roleModel = new RoleViewModel
                    {
                        Name = name,
                    };

                    userRoles.Add(roleModel);
                }

                var userModel = new UserViewModel 
                {
                    Id = user.Id,
                    PhomeNumber = user.PhoneNumber,
                    Email = user.Email,
                    Roles = userRoles
                };
                models.Add(userModel);
            }

            var viewModel = new IndexViewModel() { Users = models};
            return viewModel;
        }
    }
}
