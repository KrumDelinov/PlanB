using Microsoft.AspNetCore.Mvc;
using PlanB.Services.Data;
using PlanB.Web.Areas.Administration.Controllers;

namespace PlanB.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await this.usersService.GetUsersWithRolesAsync();
            return this.View(model);
        }
    }
}
