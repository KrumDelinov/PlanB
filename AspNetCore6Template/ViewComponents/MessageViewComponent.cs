using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Home;

namespace PlanB.ViewComponents
{
    public class MessageViewComponent : ViewComponent
    {
        private readonly IMassagesService massagesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationUser applicationUser;

        public MessageViewComponent(IMassagesService massagesService, UserManager<ApplicationUser> userManager)
        {
            this.massagesService = massagesService;
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)this.User);
            var messages = massagesService.GetAllUnread<TopBarMassageViewModel>(user.UserName);
            var view = new TopBarAllMessageViewModel { Messages = messages, UnreadMessagesCount = messages.Count() };
            return View(view);
        }
    }
}
