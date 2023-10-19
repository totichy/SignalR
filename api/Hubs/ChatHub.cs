using Microsoft.AspNetCore.SignalR;
using SignalR.Model;
using SignalR.Hubs.Clients;

namespace SignalR.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        //public async Task SendMessage(ChatMessage message)
        //{
        //    await Clients.All.ReceiveMessage(message);
        //}
    }
}

