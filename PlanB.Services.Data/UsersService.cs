using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Mapping;
using PlanB.Web.ViewModels.Administration.Dashboard;
using System.Security.Claims;

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

        public ClaimsPrincipal User { get; private set; }

        public async Task<EditUserViewModel> EditUser(string id)
        {
            
            var user = await userManager.FindByIdAsync(id);
            var userName = await userManager.GetUserNameAsync(user);
            var phoneNumber = await userManager.GetPhoneNumberAsync(user);
            var userRolles = await userManager.GetRolesAsync(user);
            var roles = roleManager.Roles.Select(n => n.Name).ToList();

            //var allRoles = new List<RoleViewModel>();
            //foreach (var role in roles)
            //{
            //    var newRole = new RoleViewModel {Id = role.Id, Name = role.Name};
            //    allRoles.Add(newRole);
            //}

            var viewModel = new EditUserViewModel
            {
                Id = id,
                UserName = userName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = phoneNumber,
                UserRolles = $"{(userRolles.Count > 0 ? string.Join(", ", userRolles) : "No roles")}",
                AllUserRoles = userRolles,
                AllNoUserRoles = roles
            };

            return viewModel;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.usersRepository.All().To<T>().ToList();
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {

            return await userManager.GetUserAsync(this.User);
        }

        public T GetT<T>(string userId)
        {
            var user = usersRepository.All().Where(u => u.Id == userId).To<T>().FirstOrDefault();
            return user;
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
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = userRoles
                };
                models.Add(userModel);
            }

            var viewModel = new IndexViewModel() { Users = models };
            return viewModel;
        }

        public async Task<string> GetUserId(string userName)
        {
            

            var user = await userManager.FindByNameAsync(userName);

            return await userManager.GetUserIdAsync(user);
        }

        public  IEnumerable<T> GetAllOtherUsers<T>(string id)
        {
            

            var users = this.usersRepository.All().Where(i => i.Id != id).To<T>().ToList();

            return users;
        }

        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user;
        }
    }
}
