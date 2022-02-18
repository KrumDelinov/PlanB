using System.ComponentModel.DataAnnotations;

namespace PlanB.Web.ViewModels.Administration.Dashboard
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserRolles { get; set; }

        public IEnumerable<string> AllUserRoles { get; set; }

        public IEnumerable<string> AllNoUserRoles { get; set; }
    }
}
