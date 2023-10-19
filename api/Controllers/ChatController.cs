using System.Threading.Tasks;
using SignalR.Hubs;
using SignalR.Hubs.Clients;
using SignalR.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;

        public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpPost]
        [Route("messages")]
        public async Task Post(ChatMessage message)
        {
            // some logic...

            await _chatHub.Clients.All.ReceiveMessage(message);
        }
    }
}