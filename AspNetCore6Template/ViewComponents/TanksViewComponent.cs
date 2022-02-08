using Microsoft.AspNetCore.Mvc;

namespace PlanB.ViewComponents
{
    //[ViewComponent(Name = "TankList")]
    public class TanksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
