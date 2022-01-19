using AutoMapper;
using PlanB.Data.Models;
using PlanB.Services.Mapping;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class UserDropDownViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserDropDownViewModel>().ForMember(
                m => m.FullName,
                opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));
        }
    }
}