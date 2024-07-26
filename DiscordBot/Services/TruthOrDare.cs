using Discord.WebSocket;
using DiscordBot.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    internal class TruthOrDare
    {

        public static async Task<Discord.Rest.RestUserMessage> GetTruth(SocketMessage socketMessage)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.truthordarebot.xyz/v1/truth?rating=pg");
            HttpResponseMessage res = httpClient.GetAsync("").Result;
            res.EnsureSuccessStatusCode();
            var msg = res.Content.ReadAsStringAsync().Result;
            TruthEntity truthEntity = JsonConvert.DeserializeObject<TruthEntity>(msg);
            var messageToShow = "Rating: " + truthEntity.Rating + "\n" +
                "Question: " + truthEntity.Question + "\n";
            return await socketMessage.Channel.SendMessageAsync(messageToShow);
        }

        public static async Task<Discord.Rest.RestUserMessage> GetDare(SocketMessage socketMessage)
        {
            HttpClient httpsClient = new HttpClient();
            httpsClient.BaseAddress = new Uri("https://api.truthordarebot.xyz/api/dare?rating=pg");
            HttpResponseMessage res = httpsClient.GetAsync("").Result;
            res.EnsureSuccessStatusCode();
            var msg = res.Content?.ReadAsStringAsync().Result;
            DareEntity dareEntity = JsonConvert.DeserializeObject<DareEntity>(msg);
            var messageToShow = "Rating: " + dareEntity.Rating + "\n" +
                "Question: " + dareEntity.Question + "\n";
            return await socketMessage.Channel.SendMessageAsync(messageToShow);
        }
    }
}
