using Microsoft.AspNetCore.SignalR;

namespace IdeventAdminBlazorServer.Common
{
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name;
        }
    }
}
