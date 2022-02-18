using PlanB.Data.Models;
using PlanB.Services.Mapping;

namespace PlanB.Web.ViewModels.Administration.Dashboard
{
    public class RoleViewModel : IMapFrom<ApplicationRole>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
