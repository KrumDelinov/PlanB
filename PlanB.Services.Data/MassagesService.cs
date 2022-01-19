using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data
{
    public class MassagesService : IMassagesService
    {
        private readonly IDeletableEntityRepository<Massage> massagesRepository;

        public MassagesService(IDeletableEntityRepository<Massage>  massagesRepository)
        {
            this.massagesRepository = massagesRepository;
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
    }
}
