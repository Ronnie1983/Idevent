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
        string user;
        public async Task SendSelectedStand(int stand, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("GetStand", stand);
        }
        public async Task AskForStand(ChipModel chip)
        {
            user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("RecieveStand", Context.ConnectionId, chip);
        }

        public async Task SendOrder(List<StandProductModel> list, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("FetchOrder",list);
        }

        public async Task AcceptOrder(string input)
        {
            user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("ClientAccept", input);
        }

        public async Task CancelTransaction(string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("CancelOrder");
        }

        public async Task FailedOrder()
        {
            user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("OperationCanceled");
            await Clients.User(user).SendAsync("WrongChip");
        }

        public async Task ScannetChip(ChipModel chip)
        {
            user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("TheChip", chip);
        }
        public async Task ChipNotActive(ChipModel chip)
        {
            user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("ChipNotActive", chip);
        }
        public async Task InvalidChip()
        {
            user = Context.UserIdentifier;
            await Clients.User(user).SendAsync("InvalidChip");
        }

    }
}
