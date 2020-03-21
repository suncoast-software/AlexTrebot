using AlexTrebot.Handlers;
using AlexTrebot.Helpers;
using AlexTrebot.Models;
using AlexTrebot.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlexTrebot
{
    class Program : ConfigService
    {
        private static DiscordSocketClient _client;
        private static CommandService _commands;

        private static IServiceProvider _services;

        public object EmbedBuilerHelper { get; private set; }

        static void Main(string[] args)
        => new Program().RunBotAsync().GetAwaiter().GetResult();

        private async Task RunBotAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                ExclusiveBulkDelete = true,
                DefaultRetryMode = RetryMode.AlwaysRetry
            });

            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            _client.Log += _client_Log;
            _client.UserJoined += _client_UserJoined;
            _client.MessageDeleted += _client_MessageDeleted;

            var token = GetToken();

            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.SetGameAsync("Everyone", "", ActivityType.Watching);
            await _client.StartAsync();

            var serverTimer = new ServerTimerService();
            
            Console.WriteLine(String.Format("{0}\t Gateway \tServer Started", DateTime.Now.ToLongTimeString()));
            await Task.Delay(-1);
        }

        private async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += _client_MessageReceived;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

        }

        private async Task _client_MessageReceived(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);

            if (message.Author.IsBot) return; //return if the message is from the bot!
            
            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                    await context.Channel.SendMessageAsync(String.Format("an error occured! {0}", result.ErrorReason));
                }
                else
                {

                }
            }
            else
            {
                
            }
        }

        private Task _client_MessageDeleted(Cacheable<IMessage, ulong> arg1, ISocketMessageChannel arg2)
        {
             Console.WriteLine(String.Format("Message deleted from {0} at {1}", arg2, DateTime.Now.ToLongTimeString()));
             return Task.CompletedTask;
        }

        private async Task _client_UserJoined(SocketGuildUser arg)
        {
            UserManagerHandler userHandler = new UserManagerHandler();
            await userHandler.WelcomeUser(_client, arg);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(String.Format("{0} {1}\t", DateTime.Now.ToLongTimeString(), arg));
            return Task.CompletedTask;
        }

    }
}
