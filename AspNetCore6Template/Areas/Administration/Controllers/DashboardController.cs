namespace PlanB.Web.Areas.Administration.Controllers
{
    using PlanB.Services.Data;
    using PlanB.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using PlanB.Data;
    using Microsoft.AspNetCore.Identity;
    using PlanB.Data.Models;
    using PlanB.Common;

    public class DashboardController : AdministrationController
    {
        private readonly IUsersService usersService;
        private readonly IRolesService rolesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext dbContext;

        public DashboardController(IUsersService usersService,
            IRolesService rolesService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dbContext)
        {
            this.usersService = usersService;
            this.rolesService = rolesService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }

        public string StatusMessage { get; set; }

        public async Task< IActionResult> Index()
        {
            
            var model = await this.usersService.GetUsersWithRolesAsync();
            return this.View(model);
        }

        public async Task<IActionResult> EditAsync(string id)
        { 
            var viewModel = await usersService.EditUser(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(string id, EditUserViewModel view)
        {
            var user = await userManager.FindByIdAsync(id);

            var currentUser = await userManager.GetUserAsync(User);
            string addRoleName = Request.Form["AddRole"].ToString();
            string removeRoleName = Request.Form["RemoveRole"].ToString();

            if (ModelState.IsValid)
            {
                
                return this.View(view);
            }

            var phoneNumber = await userManager.GetPhoneNumberAsync(user);
            if (view.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await userManager.SetPhoneNumberAsync(user, view.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return this.View(view);
                }
            }
            if (view.FirstName != user.FirstName)
            {
                user.FirstName = view.FirstName;
            }

            if (view.LastName != user.LastName)
            {
                user.LastName = view.LastName;
            }

            if (addRoleName != GlobalConstants.AddRole)
            {
                var result = await userManager.AddToRoleAsync(user, addRoleName);
            }

            if (removeRoleName != GlobalConstants.RemoveFromRole)
            {
                var result = await userManager.RemoveFromRoleAsync(user, removeRoleName);
            }
            
            
            
            await userManager.UpdateAsync(user);


            await signInManager.RefreshSignInAsync(currentUser);
            StatusMessage = "Your profile has been updated";
            return RedirectToAction("Index");
        }
    }
}

