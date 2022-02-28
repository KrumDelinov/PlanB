using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Batches
{
    public class MonthBatchesViewModel
    {
        public int[] BigBatchCounts { get; set; }

        public int[] SmallBatchesCount { get; set; }

        public string[] Months { get; set; }
    }
}
