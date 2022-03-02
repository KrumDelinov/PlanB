using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class TopBarAllMessageViewModel
    {
        public IEnumerable <TopBarMassageViewModel> Messages { get; set; }

        public int UnreadMessagesCount { get; set; } 
    }
}
