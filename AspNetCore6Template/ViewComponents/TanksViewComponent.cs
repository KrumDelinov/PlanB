using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlanB.Hubs;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Tanks;

namespace PlanB.ViewComponents
{
    //[ViewComponent(Name = "TankList")]
    public class TanksViewComponent : ViewComponent
    {
        private readonly ITanksServise tanksServise;
        private readonly IHubContext<ChatHub> hubContext;

        public TanksViewComponent(ITanksServise tanksServise,
            IHubContext<ChatHub> hubContext)
        {
            this.tanksServise = tanksServise;
            this.hubContext = hubContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tanks = tanksServise.GetAll<TankViewModel>();
            var view = new TanksListViewModel { Tanks = tanks };
            await hubContext.Clients.All.SendAsync("Notify", tanks);
            return View(view);
        }
    }
}
