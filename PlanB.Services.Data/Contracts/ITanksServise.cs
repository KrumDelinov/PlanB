namespace PlanB.Services.Data.Contracts
{
    public interface ITanksServise
    {
        IEnumerable<T> GetAll<T>();
        Task UpdateTanksAsync(string recipeName);
    }
}
