namespace PlanB.Services.Data.Contracts
{
    public interface IMassagesService
    {
        Task<int> CreateAsync(string content, string userName, string userId);

        IEnumerable<T> GetAll<T>(string userName);

        public IEnumerable<T> GetAllUnread<T>(string userName);

        public IEnumerable<T> GetAllRead<T>(string userName);

        Task ReadMessage(int messageId);

        public T? GetMessageById<T>(int messageId);
    }
}
