using Discord.WebSocket;
using Markdig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    internal class HelpCommand
    {

        public static async Task<Discord.Rest.RestUserMessage> Help(SocketMessage socketMessage)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Markups", "Help.md");
            string content;
            try
            {
                content = File.ReadAllText(filePath);

            } catch (Exception ex)
            {
                content = "Error please try again!\n";
            }
            return await socketMessage.Channel.SendMessageAsync(content);
        }
    }
}
