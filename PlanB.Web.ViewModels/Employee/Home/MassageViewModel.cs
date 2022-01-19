using PlanB.Data.Models;
using PlanB.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class MassageViewModel : IMapFrom<Massage>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        public IEnumerable<UserDropDownViewModel>  Users { get; set; }
    }
}
