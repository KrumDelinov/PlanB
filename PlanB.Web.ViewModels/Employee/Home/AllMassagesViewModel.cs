using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class AllMassagesViewModel
    {
        public string StatusMessage { get; set; }
        public IEnumerable<MassageInfoViewModel> Massages { get; set; }
    }
}
