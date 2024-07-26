using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Entity
{
    internal class FactEntity
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }
        public string SourceUrl { get; set; }

        public string Language { get; set; }

        public string PermaLink {  get; set; }
    }
}
