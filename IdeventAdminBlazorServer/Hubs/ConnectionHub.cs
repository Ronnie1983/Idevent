using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using IdeventAdminBlazorServer.Common;
using Microsoft.AspNetCore.Authorization;
using IdeventLibrary.Models;

namespace IdeventAdminBlazorServer.Hubs
{

    public class ConnectionHub :Hub
    {
        public async Task SendSelectedStand(int stand, string client)
        {
            await Clients.Client(client).SendAsync("GetStand", stand);
        }
        public async Task AskForStand(ChipModel chip)
        {
            var user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("RecieveStand", Context.ConnectionId, chip);
        }
    }
}
