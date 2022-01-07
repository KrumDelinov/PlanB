using PlanB.Data.Models;
using PlanB.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Administration.Dashboard
{
    public class RoleViewModel : IMapFrom<ApplicationRole>
    {
        
        public string Name { get; set; }
    }
}
