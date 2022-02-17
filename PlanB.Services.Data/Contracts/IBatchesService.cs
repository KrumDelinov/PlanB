using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data.Contracts
{
    public interface IBatchesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllDalyBatches<T>(DateTime dateTime);

        IEnumerable<DateTime> Range(DateTime startDate, DateTime endDate);
    }
}
