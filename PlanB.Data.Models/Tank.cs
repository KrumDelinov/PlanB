using PlanB.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Data.Models
{
    public class Tank : BaseDeletableModel<int>
    {
        [Required]
        public string  Name { get; set; }

        public double Amount { get; set; }
    }
}
