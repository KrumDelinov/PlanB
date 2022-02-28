using Microsoft.AspNetCore.Mvc;
using PlanB.Common;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Batches;
using System.Globalization;

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

        public IActionResult Month()
        {
            return View();
        }


        public IActionResult Reports(BatchDateViewModel batchDate)
        {
            var weekDaysList = new List<string>();
            var bigBatchesCountList = new List<int>();
            var smallBatchesCountList = new List<int>();

            var dateRange = batchesService.WeeklyReport(batchDate.StartDade);
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

        public IActionResult MonthlyReport(BatchDateViewModel batchDate)
        {
            var montNamehList = new List<string>();
            var monthInthList = new List<int>();
            var bigBatchesCountList = new List<int>();
            var smallBatchesCountList = new List<int>();

            var dateRange = batchesService.MontlyReport(batchDate.StartDade);
           

            foreach (var day in dateRange)
            {
                var monthName = day.ToString("MMM", CultureInfo.InvariantCulture);
                var monthInth = day.Month;
                bool containMonth = montNamehList.Contains(monthName);
                if (!containMonth)
                {
                    montNamehList.Add(monthName);
                    monthInthList.Add(monthInth);
                }
              

            }

            foreach (var month in monthInthList)
            {
                var bigBatches = batchesService.GetAllMonthlyBatches<BatchViewModel>(month, GlobalConstants.BigCup);
                var smallBatches = batchesService.GetAllMonthlyBatches<BatchViewModel>(month, GlobalConstants.SmallCup);
                var bigBatchCount = bigBatches.Count();
                var smallBatchCount = smallBatches.Count();
                bigBatchesCountList.Add(bigBatchCount);
                smallBatchesCountList.Add(smallBatchCount);
            }

            
            var monthsNameArray = montNamehList.ToArray();
            var view = new MonthBatchesViewModel
            {
                BigBatchCounts = bigBatchesCountList.ToArray(),
                SmallBatchesCount = smallBatchesCountList.ToArray(),
                Months = monthsNameArray
            };

            //

            return View(view);
        }


    }
}
