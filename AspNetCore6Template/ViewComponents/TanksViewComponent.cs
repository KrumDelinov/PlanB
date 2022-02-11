using Microsoft.AspNetCore.Mvc;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Tanks;

namespace PlanB.ViewComponents
{
    //[ViewComponent(Name = "TankList")]
    public class TanksViewComponent : ViewComponent
    {
        private readonly ITanksServise tanksServise;

        public TanksViewComponent(ITanksServise tanksServise)
        {
            this.tanksServise = tanksServise;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tanks = tanksServise.GetAll<TankViewModel>();
            var view = new TanksListViewModel { Tanks = tanks };
            return View(view);
        }
    }
}
