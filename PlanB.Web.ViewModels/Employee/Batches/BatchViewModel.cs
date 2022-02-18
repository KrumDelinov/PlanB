using PlanB.Data.Models;
using PlanB.Services.Mapping;

namespace PlanB.Web.ViewModels.Employee.Batches
{
    public class BatchViewModel : IMapFrom<Batch>
    {
        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string FullName => this.UserFirstName + " " + this.UserLastName;

        public string Hour => this.CreatedOn.ToString("MM/dd/yyyy HH:mm");

        public string Date => this.CreatedOn.ToShortDateString();


    }
}
