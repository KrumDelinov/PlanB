namespace PlanB.Web.ViewModels.Employee.Home
{
    public class AllMassagesViewModel
    {
        public string StatusMessage { get; set; }
        public IEnumerable<MassageInfoViewModel> Massages { get; set; }
    }
}
