using Microsoft.AspNetCore.Mvc;
using PlanB.Common;
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
  

        public IActionResult Reports(BatchDateViewModel batchDate)
        {
            var weekDaysList = new List<string>();
            var bigBatchesCountList = new List<int>();
            var smallBatchesCountList = new List<int>();

            var dateRange = batchesService.Range(batchDate.StartDade, batchDate.EndDate);
            //

            foreach (var day in dateRange)
            {
                var weekDay = day.DayOfWeek.ToString();
                var bigBatches = batchesService.GetAllDalyBatches<BatchViewModel>(day.Date, GlobalConstants.BigCup);
                var smallBatches = batchesService.GetAllDalyBatches<BatchViewModel>(day.Date, GlobalConstants.SmallCup);
                var bigBatchCount = bigBatches.Count();
                var smallBatchCount = smallBatches.Count();
                weekDaysList.Add(weekDay);
                bigBatchesCountList.Add(bigBatchCount);
                smallBatchesCountList.Add(smallBatchCount);

            }

            var weekDaysArray = weekDaysList.ToArray();
            var batchCounts = bigBatchesCountList.ToArray();
            var view = new WeekBatchesViewModel
            {
                BigBatchCounts = bigBatchesCountList.ToArray(),
                SmallBatchesCount = smallBatchesCountList.ToArray(),
                WeekDays = weekDaysArray
            };

            return View(view);
        }
    }
}
