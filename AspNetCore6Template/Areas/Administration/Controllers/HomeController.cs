using Microsoft.AspNetCore.Mvc;
using PlanB.Web.Areas.Administration.Controllers;

namespace PlanB.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
