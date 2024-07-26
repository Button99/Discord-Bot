using Discord.WebSocket;

namespace DiscordBot.Services
{
    internal class HelloWorldCommand
    {

        public static async Task<Discord.Rest.RestUserMessage> Hello(SocketMessage socketMessage)
        {
            return await socketMessage.Channel.SendMessageAsync("Hello Discord");
        }
    }
}
