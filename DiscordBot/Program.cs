// See https://aka.ms/new-console-template for more information
using Discord;
using Discord.WebSocket;
using DiscordBot.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    private DiscordSocketClient _discordClient;

    static async Task Main(string[] args)
    {
        var program = new Program();
        var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();
        var discordToken= config.GetSection("DiscordToken").Value.ToString();
        Task.Run(() =>
        {
            DiscordBot.KeepBotAlive.Start();
        });

        await program.RunBotAsync(discordToken);
    }

    // Login
    public async Task RunBotAsync(string token)
    {
        _discordClient = new(new DiscordSocketConfig()
        {
            AlwaysDownloadUsers = true,
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
        });
        _discordClient.Log += Log;
        _discordClient.MessageReceived += MessageReceivedAsync;

        // Change this line if token is changed
        await _discordClient.LoginAsync(Discord.TokenType.Bot, token);
        await _discordClient.StartAsync();

        await Task.Delay(-1);

    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg);
        return Task.CompletedTask;
    }

    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if (message.Content.ToLower() == "!hello")
        {
            await HelloWorldCommand.Hello(message);
        }

        if(message.Content.ToLower() == "!ping")
        {
            await PingCommand.Ping(message);
        }

        if(message.Content.ToLower() == "!randomnumber")
        {
            await RandomCommand.RandomNumber(message);
        }

        if(message.Content.ToLower() == "!randompoem")
        {
            await RandomCommand.RandomPoem(message);
        }

        if(message.Content.ToLower() == "!uwu")
        {
            await PingCommand.Uwu(message);
        }

        if(message.Content.ToLower() == "!truth")
        {
            await TruthOrDare.GetTruth(message);
        }

        if(message.Content.ToLower() == "!dare")
        {
            await TruthOrDare.GetDare(message);
        }

        if (message.Content.ToLower() == "!randommovie")
        {
            await RandomCommand.RandomMovie(message);
        }

        if(message.Content.ToLower() == "!randomavatar")
        {
            await RandomCommand.RandomAvatar(message);
        }

        if (message.Content.ToLower() == "!randomfact")
        {
            await RandomCommand.RandomFact(message);
        }

        if(message.Content.ToLower() == "!catfact")
        {
            await RandomCommand.RandomCatFact(message);
        }

        if(message.Content.ToLower() == "!help")
        {
            await HelpCommand.Help(message);
        }
    }
}