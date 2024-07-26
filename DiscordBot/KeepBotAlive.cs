using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    internal class KeepBotAlive
    {
        public static void Start()
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(Configure)
                .Build();

            host.Run();
        }

        private static void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                // Set the content type to HTML
                context.Response.ContentType = "text/html";

                // Write the HTML content to the response stream
                await context.Response.WriteAsync("<html><body><h1>Hello from your Discord bot!</h1></body></html>");
            });
        }
    }
}
