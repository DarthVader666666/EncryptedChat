using Microsoft.AspNetCore.SignalR;
using EncryptedChat.Bll.Services;

namespace EncryptedChat.Server.Hubs
{
    public class ChatHub: Hub
    {
        readonly CryptoService _cryptoService;

        public ChatHub(CryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public async Task SendMessage(string user, string message, string time)
        {
            _cryptoService.WriteEncryptedCache(user, message, time);

            await Clients.All.SendAsync("ReceiveMessage", user, message, time);
        }

        public void ClearCache()
        {
            File.WriteAllText(CryptoService.messageCachePath, string.Empty);
        }
    }
}
