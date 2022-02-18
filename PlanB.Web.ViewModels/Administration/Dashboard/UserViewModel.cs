namespace PlanB.Web.ViewModels.Administration.Dashboard
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhomeNumber { get; set; }

        public ICollection<RoleViewModel> Roles { get; set; }
    }
}
