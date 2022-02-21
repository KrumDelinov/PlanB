namespace PlanB.Web.ViewModels.Administration.Dashboard
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhomeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public ICollection<RoleViewModel> Roles { get; set; }
    }
}
