namespace PlanB.Web.ViewModels.Settings
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;

    public class SettingsListViewModel : PageModel
    {
        public IEnumerable<SettingViewModel> Settings { get; set; }

        public void OnGet()
        {
        }
    }
}
