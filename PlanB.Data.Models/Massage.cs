using PlanB.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Data.Models
{
    public class Massage : BaseDeletableModel<int>
    {
        [MaxLength(300)]
        public string Content { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
