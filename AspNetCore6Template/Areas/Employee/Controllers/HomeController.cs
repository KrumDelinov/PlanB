using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanB.Data.Models;
using PlanB.Services.Data;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Home;
using System.Security.Claims;

namespace PlanB.Areas.Employee.Controllers
{
    public class HomeController : EmployeeController
    {
        private readonly IUsersService usersService;
        private readonly IMassagesService massagesService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IUsersService usersService,
            IMassagesService massagesService,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.massagesService = massagesService;
            this.userManager = userManager;
        }
        public  IActionResult Index()
        {

            var users = usersService.GetAll<UserDropDownViewModel>();
            var viewModel = new MassageViewModel { Users = users};
            return this.View(viewModel);
        }
        [HttpPost]
        public async Task< IActionResult> Index(MassageViewModel input)
        {
            var user = await userManager.GetUserAsync(this.User);
            if (this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var massageId = await massagesService.CreateAsync(input.Content, input.UserName, user.Id);
            
            return this.View(input);
        }

    }
}
