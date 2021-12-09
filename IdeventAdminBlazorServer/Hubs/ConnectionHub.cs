using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using IdeventAdminBlazorServer.Common;
using Microsoft.AspNetCore.Authorization;

namespace IdeventAdminBlazorServer.Hubs
{

    public class ConnectionHub :Hub
    {
     
        public async Task SendSelectedStand(int stand, string client)
        {
            //await Clients.Client(client).SendAsync("RecieveMessage", user, stand, Context.UserIdentifier);
            await Clients.Client(client).SendAsync("GetStand", stand);
        }

        public async Task AskForStand()
        {
            var user = Context.UserIdentifier;
            //await Clients.User(client).SendAsync("RecieveStand", Context.ConnectionId);
            await Clients.User(user).SendAsync("RecieveStand", Context.ConnectionId);
        }
    }
}
