using Ganss.XSS;
using PlanB.Data.Models;
using PlanB.Services.Mapping;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class MassageViewModel : IMapFrom<Massage>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserName { get; set; }

        public IEnumerable<UserDropDownViewModel>? Users { get; set; }
    }
}
