using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanB.Data.Models;
using PlanB.Services.Data;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Batches;
using PlanB.Web.ViewModels.Employee.Home;
using PlanB.Web.ViewModels.Employee.Tanks;

namespace PlanB.Areas.Employee.Controllers
{
    public class HomeController : EmployeeController
    {
        private readonly IUsersService usersService;
        private readonly IMassagesService massagesService;
        private readonly IRecipesService recipesService;
        private readonly IBatchesService batchService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IUsersService usersService,
            IMassagesService massagesService,
            IRecipesService recipesService,
            IBatchesService batchService,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.massagesService = massagesService;
            this.recipesService = recipesService;
            this.batchService = batchService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var batches = batchService.GetAllTodayBatches<BatchViewModel>();
            var view = new BatchesListViewModel { Batches = batches };

            return this.View(view);
        }

        public IActionResult ChartReport()
        {
            return this.View();
        }
        public ActionResult Column()
        {
            return View();
        }

        public IActionResult Tank()
        {
            var view = new TankViewModel { Name = "Oak", Amount = 1000 };

            return PartialView("_TanksPartial", view);
            //return this.View(view);
        }

        public IActionResult Chat()
        {
            var user = userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
            var view = usersService.GetT<ChatViewModel>(user.Id);
            return View(view);
        }
        public IActionResult All()
        {
            var user = userManager.GetUserAsync(this.User).GetAwaiter().GetResult();

            var massage = this.massagesService.GetAllUnread<MassageInfoViewModel>(user.UserName);
            var model = new AllMassagesViewModel { Massages = massage, StatusMessage = "Your profile has been updated" };
            return this.View(model);
        }

        

        public async Task< IActionResult> ReadMessage(int id)

        {
            await massagesService.ReadMessage(id);
            var view = this.massagesService.GetMessageById<MassageInfoViewModel>(id);
            return this.View(view);
        }
        public IActionResult CreateRecipe()
        {

            return View();
        }
        public IActionResult RecipeDetails()
        {

            return View();
        }

        public IActionResult MessageResult(int id)
        {
            var viewModel =  this.massagesService.GetMessageById<MessageReportViewModel>(id);
            return View(viewModel);
        }

        public async Task<IActionResult> CreateAsync()
        {

            var users = usersService.GetAll<UserDropDownViewModel>();
            var viewModel = new MassageViewModel { Users = users };
            return this.View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MassageViewModel input)
        {
            var user = await userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var massageId = await massagesService.CreateAsync(input.Content, input.UserName, user.Id);

            this.TempData["InfoMessage"] = "Forum post created!";

            return this.RedirectToAction(nameof(this.MessageResult), new {id = massageId});
        }

       

    }
}
