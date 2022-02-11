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
    }
}
