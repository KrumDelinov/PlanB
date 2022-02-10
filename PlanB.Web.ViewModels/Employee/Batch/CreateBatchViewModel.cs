using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Batch
{
    public class CreateBatchViewModel
    {
        [Required]
        public string Type { get; set; }
    }
}
