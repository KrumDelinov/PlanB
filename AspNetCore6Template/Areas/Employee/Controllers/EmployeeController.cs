using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanB.Common;

namespace PlanB.Areas.Employee.Controllers
{
    [Authorize(Roles = GlobalConstants.EmploeeRoleName)]
    [Area("Employee")]
    public class EmployeeController : Controller
    {
    }
}
