using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRPOC.Hubs
{
    public class ConnectionHub :Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message, Context.ConnectionId);
        }

        public async Task SendMessageClient(string user, string message, string client)
        {
            await Clients.Client(client).SendAsync("RecieveMessage", user, message, Context.ConnectionId);
        }
    }
}
