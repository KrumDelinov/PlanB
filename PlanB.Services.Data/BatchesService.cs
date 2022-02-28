using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Services.Mapping;

namespace PlanB.Services.Data
{
    public class BatchesService : IBatchesService
    {
        private readonly IDeletableEntityRepository<Batch> batchesRepository;

        public BatchesService(IDeletableEntityRepository<Batch> batchesRepository)
        {
            this.batchesRepository = batchesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.batchesRepository.All().To<T>().ToList();
        }

        public IEnumerable<T> GetAllDalyBatches<T>(DateTime dateTime, string batchSize)
        {
            var result = this.batchesRepository.All().Where(d => d.CreatedOn.Date == dateTime.Date & d.Type == batchSize).To<T>().ToList();

            return result;
        }

        public IEnumerable<T> GetAllMonthlyBatches<T>(int month, string batchSize)
        {
            var result = this.batchesRepository.All().Where(d => d.CreatedOn.Date.Month == month & d.Type == batchSize).To<T>().ToList();

            return result;
        }

        public IEnumerable<T> GetAllTodayBatches<T>()
        {
            return this.batchesRepository.All().Where(d => d.CreatedOn.Date.Date == DateTime.Today.Date).To<T>().ToList();
        }

        public IEnumerable<DateTime> MontlyReport(DateTime startDate)
        {
            var endDate = startDate.AddMonths(5);
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }

        public IEnumerable<DateTime> WeeklyReport(DateTime startDate)
        {
            var endDate = startDate.AddDays(6);
            
            var month = startDate.ToString("MMMM");
            //
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }
    }
}
