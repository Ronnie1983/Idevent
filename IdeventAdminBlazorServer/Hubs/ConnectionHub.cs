using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using IdeventAdminBlazorServer.Common;
using Microsoft.AspNetCore.Authorization;
using IdeventLibrary.Models;
using System.Collections.Generic;

namespace IdeventAdminBlazorServer.Hubs
{

    public class ConnectionHub :Hub
    {
        public async Task SendSelectedStand(int stand, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("GetStand", stand);
        }
        public async Task AskForStand(ChipModel chip)
        {
            var user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("RecieveStand", Context.ConnectionId, chip);
        }

        public async Task SendOrder(List<StandProductModel> list, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("FetchOrder",list);
        }

        public async Task AcceptOrder(int input)
        {
            var user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("ClientAccept", input);
        }
    }
}
