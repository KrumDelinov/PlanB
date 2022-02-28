namespace PlanB.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlanB.Common;
    using PlanB.Data.Models;
    using PlanB.Services.Data;
    using PlanB.Web.ViewModels;
    using PlanB.Web.ViewModels.Employee.Home;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public HomeController(IUsersService usersService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task< IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user != null) 
            {
                var roles = await userManager.GetRolesAsync(user);

                if (roles.Contains(GlobalConstants.AdministratorRoleName))
                {
                    return RedirectToAction("Index", "Home", new { area = "Administration" });
                }

                else if (roles.Contains(GlobalConstants.EmploeeRoleName))
                {
                    return RedirectToAction("Index", "Home", new { area = "Employee" });
                }
            }
           
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Chat()
        {
            var user = userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
            var view = usersService.GetT<ChatViewModel>(user.Id);
            return View(view);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

