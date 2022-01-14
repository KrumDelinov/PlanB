namespace PlanB.Web.Areas.Administration.Controllers
{
    using PlanB.Services.Data;
    using PlanB.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using PlanB.Data;

    public class DashboardController : AdministrationController
    {
        private readonly IUsersService usersService;
        private readonly IRolesService rolesService;
        private readonly ApplicationDbContext dbContext;

        public DashboardController(IUsersService usersService, IRolesService rolesService, ApplicationDbContext dbContext)
        {
            this.usersService = usersService;
            this.rolesService = rolesService;
            this.dbContext = dbContext;
        }

        public async Task< IActionResult> Index()
        {
            
            var model = await this.usersService.GetUsersWithRolesAsync();
            return this.View(model);
        }
    }
}

