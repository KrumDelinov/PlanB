using Ganss.XSS;
using PlanB.Data.Models;
using PlanB.Services.Mapping;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class MassageInfoViewModel : IMapFrom<Massage>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string FullName => this.UserFirstName + " " + this.UserLastName;

        public DateTime CreatedOn { get; set; }
    }
}
