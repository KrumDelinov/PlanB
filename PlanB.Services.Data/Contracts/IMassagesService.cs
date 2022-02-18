namespace PlanB.Services.Data.Contracts
{
    public interface IMassagesService
    {
        Task<int> CreateAsync(string content, string userName, string userId);

        IEnumerable<T> GetAll<T>(string userName);
    }
}
