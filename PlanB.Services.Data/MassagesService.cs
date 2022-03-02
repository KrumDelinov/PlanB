using PlanB.Data;
using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Services.Mapping;

namespace PlanB.Services.Data
{
    public class MassagesService : IMassagesService
    {
        private const bool V = true;
        private readonly IDeletableEntityRepository<Massage> massagesRepository;
        private readonly ApplicationDbContext dbContext;

        public MassagesService(IDeletableEntityRepository<Massage> massagesRepository, ApplicationDbContext dbContext)
        {
            this.massagesRepository = massagesRepository;
            this.dbContext = dbContext;
        }
        public async Task<int> CreateAsync(string content, string userName, string userId)
        {

            var massage = new Massage
            {

                Content = content,
                UserName = userName,
                UserId = userId,
            };

            await this.massagesRepository.AddAsync(massage);
            await this.massagesRepository.SaveChangesAsync();
            return massage.Id;
        }

        public IEnumerable<T> GetAll<T>(string userName)
        {
            return this.massagesRepository.All().Where(n => n.UserName == userName).To<T>().ToList();
        }

        public IEnumerable<T> GetAllUnread<T>(string userName)
        {
            return this.massagesRepository.All().Where(n => n.UserName == userName && n.IsRead == false).To<T>().ToList();
        }

        public IEnumerable<T> GetAllRead<T>(string userName)
        {
            return this.massagesRepository.All().Where(n => n.UserName == userName && n.IsRead == true).To<T>().ToList();
        }

        public async Task ReadMessage(int messageId)
        {
            var message1 = await dbContext.Massages.FindAsync(messageId);
            var message = this.massagesRepository.All().Where(i => i.Id == messageId).FirstOrDefault();
            message1.IsRead = true;
            this.massagesRepository.Update(message1);
            await this.massagesRepository.SaveChangesAsync();
        }

        public T? GetMessageById<T>(int messageId)
        {
            
            return this.massagesRepository.All().Where(n => n.Id == messageId).To<T>().FirstOrDefault();
        }
    }
}
