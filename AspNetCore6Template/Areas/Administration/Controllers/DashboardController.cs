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

        public IActionResult Index()
        {
            var users = this.usersService.GetAll<UserViewModel>();
            var roles = this.rolesService.GetAll<RoleViewModel>();
            var model = new IndexViewModel { Users = users, Roles = roles};
            return this.View(model);
        }
    }
}

