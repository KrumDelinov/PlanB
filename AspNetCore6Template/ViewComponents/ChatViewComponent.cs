using Microsoft.AspNetCore.Mvc;

namespace PlanB.ViewComponents
{
    public class ChatViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
