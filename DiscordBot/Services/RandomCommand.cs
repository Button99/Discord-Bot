using Discord.WebSocket;
using DiscordBot.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    internal class RandomCommand
    {
        public static async Task<Discord.Rest.RestUserMessage> RandomNumber(SocketMessage socketMessage)
        {
            Random random = new Random();
            var value = random.NextInt64(1, 100).ToString();
            return await socketMessage.Channel.SendMessageAsync(value);
        }

        public static async Task<Discord.Rest.RestUserMessage> RandomPoem(SocketMessage socketMessage)
        {
            HttpClient httpClient = new HttpClient();
            Random random = new Random();
            httpClient.BaseAddress = new Uri("https://poetrydb.org/linecount,random/" + random.Next(1, 50) + ";1");
            HttpResponseMessage res = httpClient.GetAsync("").Result;
            res.EnsureSuccessStatusCode();
            var msg = res.Content.ReadAsStringAsync().Result;
            List<PoemEntity> poem = JsonConvert.DeserializeObject<List<PoemEntity>>(msg);
            var text = "";
            var author = "";
            var title = "";
            var lineCount = 0;
            foreach(var p in poem)
            {
                author = p.Author;
                title = p.Title;
                lineCount = int.Parse(p.LinesCount);
                if(lineCount > 100)
                {
                    return await socketMessage.Channel.SendMessageAsync("Error please try again");
                }
                foreach(var line in p.Lines)
                {
                    text += line;
                }
            }
            var messageToShow = "Author: " + author + ":\n"
                    + "Title: " + title + "\n"
                    + "Poem: " + text + "\n";
            return await socketMessage.Channel.SendMessageAsync(messageToShow);
        }

        public static async Task<Discord.Rest.RestUserMessage> RandomMovie(SocketMessage socketMessage)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.reelgood.com/v3.0/content/random?availability=onAnySource&content_kind=movie&nocache=true&region=us&spin_count=1");
            HttpResponseMessage res = httpClient.GetAsync("").Result;
            res.EnsureSuccessStatusCode();
            var msg= res.Content.ReadAsStringAsync().Result;
            JObject movieObject = JObject.Parse(msg);
            try
            {
                var messageToShow = "Title: " + movieObject["title"].ToString() + "\n"
                        + "Overview: " + movieObject["overview"].ToString() + "\n"
                        + "Runtime: " + movieObject["runtime"].ToString() + "\n"
                        + "Rating: " + movieObject["imdb_rating"].ToString();

                return await socketMessage.Channel.SendMessageAsync(messageToShow);
            }
            catch (Exception ex)
            {
                return await socketMessage.Channel.SendMessageAsync("Try again later");
            }
        }

        public static async Task<Discord.Rest.RestUserMessage> RandomAvatar(SocketMessage socketMessage)
        {
            Random random = new Random();
            var value = random.NextInt64(1, 8000).ToString();
            return await socketMessage.Channel.SendMessageAsync("https://api.multiavatar.com/" + value + ".png");
        }

        public static async Task<Discord.Rest.RestUserMessage> RandomFact(SocketMessage socketMessage)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://uselessfacts.jsph.pl/api/v2/facts/random");
            HttpResponseMessage res = httpClient.GetAsync("").Result;
            res.EnsureSuccessStatusCode();
            var msg = res.Content.ReadAsStringAsync().Result;
            FactEntity fact = JsonConvert.DeserializeObject<FactEntity>(msg);
            var messageToShow = "Did you know:  " + fact.Text + "\n";
            return await socketMessage.Channel.SendMessageAsync(messageToShow);
        }

        public static async Task<Discord.Rest.RestUserMessage> RandomCatFact(SocketMessage socketMessage)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://catfact.ninja/fact?max_length=1000");
            HttpResponseMessage res = httpClient.GetAsync("").Result;
            res.EnsureSuccessStatusCode();
            var msg = res.Content.ReadAsStringAsync().Result;
            CatEntity cat = JsonConvert.DeserializeObject<CatEntity>(msg);
            var messageToShow = "Did you know:  " + cat.Fact + "\n";
            return await socketMessage.Channel.SendMessageAsync(messageToShow);
        }
    }
}
