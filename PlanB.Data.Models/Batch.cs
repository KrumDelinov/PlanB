using PlanB.Data.Common.Models;

namespace PlanB.Data.Models
{
    public class Batch :BaseDeletableModel<int>
    {
        public string Type { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
