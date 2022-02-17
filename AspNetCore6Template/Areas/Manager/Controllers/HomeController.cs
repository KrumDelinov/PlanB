using Microsoft.AspNetCore.Mvc;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Batches;

namespace PlanB.Areas.Manager.Controllers
{
    public class HomeController : ManagerController
    {
        private readonly IBatchesService batchesService;

        public HomeController(IBatchesService batchesService)
        {
            this.batchesService = batchesService;
        }
        public IActionResult Date()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Date(BatchDateViewModel batchDate)
        {

            var test = batchDate.StartDade;

            var dateRange = batchesService.Range(batchDate.StartDade, batchDate.EndDate);
            //

            var test2 = new int[] { 23, 12, 13, 14, 15, 12, 5};
            var view = new WeekBatchesViewModel
            {
                BatchCounts = test2
            };
            return RedirectToAction(nameof(Reports), view);
        }

        public IActionResult Reports(BatchDateViewModel batchDate)
        {
            var weekDaysList = new List<string>();
            var batchesCountList = new List<int>();

            var dateRange = batchesService.Range(batchDate.StartDade, batchDate.EndDate);
            //
            
            foreach (var day in dateRange)
            {
                var weekDay = day.DayOfWeek.ToString();
                var batches = batchesService.GetAllDalyBatches<BatchViewModel>(day.Date);
                var batchCount = batches.Count();
                weekDaysList.Add(weekDay);
                batchesCountList.Add(batchCount);

            }

            var weekDaysArray = weekDaysList.ToArray();
            var batchCounts = batchesCountList.ToArray();
            var view = new WeekBatchesViewModel
            {
                BatchCounts = batchCounts,
                WeekDays = weekDaysArray
            };

            return View(view);
        }
    }
}
