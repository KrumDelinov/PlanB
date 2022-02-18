using PlanB.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

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
