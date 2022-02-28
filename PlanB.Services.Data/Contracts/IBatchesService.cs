namespace PlanB.Services.Data.Contracts
{
    public interface IBatchesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllTodayBatches<T>();

        IEnumerable<T> GetAllDalyBatches<T>(DateTime dateTime, string batchSize);
        public IEnumerable<T> GetAllMonthlyBatches<T>(int month, string batchSize);

        IEnumerable<DateTime> WeeklyReport(DateTime startDate);

        IEnumerable<DateTime> MontlyReport(DateTime startDate);
    }
}
