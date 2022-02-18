using System.ComponentModel.DataAnnotations;

namespace PlanB.Web.ViewModels.Employee.Batches
{
    public class CreateBatchViewModel
    {
        [Required]
        public string Type { get; set; }
    }
}
