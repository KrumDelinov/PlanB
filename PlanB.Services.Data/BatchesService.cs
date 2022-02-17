using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<T> GetAllDalyBatches<T>(DateTime dateTime)
        {
            var result = this.batchesRepository.All().Where(d => d.CreatedOn.Date == dateTime.Date).To<T>().ToList();

            return result;
        }

        public  IEnumerable<DateTime> Range( DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }
    }
}
