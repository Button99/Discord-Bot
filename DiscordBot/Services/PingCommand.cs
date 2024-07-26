using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    internal class PingCommand
    {
        public static async Task<Discord.Rest.RestUserMessage> Ping(SocketMessage socketMessage)
        {
            return await socketMessage.Channel.SendMessageAsync("Pong");
        }

        public static async Task<Discord.Rest.RestUserMessage> Uwu(SocketMessage socketMessage)
        {
            return await socketMessage.Channel.SendMessageAsync("Uwu");
        }
    }
}
