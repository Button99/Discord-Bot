using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Entity
{
    internal class PoemEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("lines")]
        public List<string> Lines { get; set; }

        [JsonProperty("linecount")]
        public string LinesCount { get; set; }      
    }
}
