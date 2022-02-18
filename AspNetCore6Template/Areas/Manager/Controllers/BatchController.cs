using Microsoft.AspNetCore.Mvc;
using PlanB.Common;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Batches;

namespace PlanB.Areas.Manager.Controllers
{
    public class BatchController : ManagerController
    {
        private readonly IBatchesService batchesService;

        public BatchController(IBatchesService batchesService)
        {
            this.batchesService = batchesService;
        }
        public IActionResult DalyBatch()
        {

            return this.View();
        }

        public IActionResult DalyBatchReport(DalyBatchViewModel batchViewModel)
        {
            var batches = batchesService.GetAllDalyBatches<BatchViewModel>(batchViewModel.StartDade.Date, GlobalConstants.BigCup);
            var view = new BatchesListViewModel { Batches = batches };

            return this.View(view);
        }
    }
}
