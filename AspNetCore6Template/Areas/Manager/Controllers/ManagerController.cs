using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanB.Common;

namespace PlanB.Areas.Manager.Controllers
{
    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    [Area("Manager")]
    public class ManagerController : Controller
    {
    }
}
