using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PlanB.Services.Data;
using SignalRChat.Models.Chat;

namespace PlanB.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IUsersService usersService;

        public ChatHub(IUsersService usersService)
        {
            this.usersService = usersService;
        }
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

        public async Task SendMessageCount(string userName)
        {
            var userId = await usersService.GetUserId(userName);
            //await Clients.All.SendAsync("ReceiveMessage", userId);
            await Clients.User(userId).SendAsync("ReceiveMessage", userId);
            
        }

    }
}
