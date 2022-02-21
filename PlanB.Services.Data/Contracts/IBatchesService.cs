namespace PlanB.Services.Data.Contracts
{
    public interface IBatchesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllTodayBatches<T>();

        IEnumerable<T> GetAllDalyBatches<T>(DateTime dateTime, string batchSize);

        IEnumerable<DateTime> Range(DateTime startDate, DateTime endDate);
    }
}
