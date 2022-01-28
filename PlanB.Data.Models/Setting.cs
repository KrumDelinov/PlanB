namespace PlanB.Data.Models
{
    using PlanB.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }  
    }
}
