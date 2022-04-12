namespace PlanB.Services.Data.Contracts
{
    public interface ITanksServise
    {
        IEnumerable<T> GetAll<T>();
        Task UpdateTanksAsync(string recipeName);

        T GetT<T>(int? id);
    }
}
