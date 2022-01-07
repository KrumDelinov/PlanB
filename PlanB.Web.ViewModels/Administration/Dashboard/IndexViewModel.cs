namespace PlanB.Web.ViewModels.Administration.Dashboard
{
    public class IndexViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}