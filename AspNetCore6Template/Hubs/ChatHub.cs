using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using PlanB.Common;
using PlanB.Data;
using PlanB.Data.Models;
using PlanB.Services.Data;
using PlanB.Services.Data.Contracts;
using SignalRChat.Models.Chat;

namespace PlanB.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IUsersService usersService;
        private readonly ITanksServise tanksServise;
        private readonly ApplicationDbContext _context;

        public ChatHub(IUsersService usersService, ITanksServise tanksServise, ApplicationDbContext context)
        {
            this.usersService = usersService;
            this.tanksServise = tanksServise;
            this._context = context;
        }

        public string UserFullName { get; set; }

        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { User = this.Context.User.Identity.Name, Text = message, });
        }
        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", user, message);

            
        }

        public async Task SendMessageCount(string userNameToSend, string messageId, string userNameFrom)
        {

            var currentUser = await usersService.GetUserByUserName(userNameFrom);

            var userFullName = $"{currentUser.FirstName} {currentUser.LastName}";
            var userId = await usersService.GetUserId(userNameToSend);
            //await Clients.All.SendAsync("ReceiveMessage", userId);
            await Clients.User(userId).SendAsync("ReceiveMessage", userFullName, messageId);
            
        }

        public async Task SendReportAsync (string userNameFrom)
        {
            var currentUser = await usersService.GetUserByUserName(userNameFrom);

            var userFullName = $"{currentUser.FirstName} {currentUser.LastName}";

           
            var batch = new Batch { Type = GlobalConstants.SmallCup, UserId = currentUser.Id };
            await tanksServise.UpdateTanksAsync(batch.Type);
            _context.Add(batch);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveReport", userFullName, batch.Type);
        }

    }
}
