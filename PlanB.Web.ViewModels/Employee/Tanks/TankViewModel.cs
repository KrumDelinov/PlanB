using PlanB.Data.Models;
using PlanB.Services.Mapping;

namespace PlanB.Web.ViewModels.Employee.Tanks
{
    public class TankViewModel : IMapFrom<Tank>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }
    }
}
