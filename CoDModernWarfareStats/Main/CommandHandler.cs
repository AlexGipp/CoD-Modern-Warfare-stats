using CodMwStats.AccountLogic.ServerAccounts;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;

namespace CodMwStats.Core.Main
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        private async void setPlayStatus()
        {
            await _client.SetGameAsync($">help");
            System.Threading.Thread.Sleep(5000);
            await _client.SetGameAsync($"Call of Duty Modern Warfare");
            System.Threading.Thread.Sleep(5000);
            await _client.SetGameAsync($"Looking over {_client.Guilds.Count} Guilds.");
            System.Threading.Thread.Sleep(5000);
            setPlayStatus();
        }

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            await _service.AddModulesAsync(typeof(CodMwStats.Commands.Utilities).Assembly, null);
            _client.MessageReceived += HandleCommandAsync;
            _client.JoinedGuild += JoinedServer;
            setPlayStatus();
        }


        private async Task HandleCommandAsync(SocketMessage socketMessage)
        {
            var msg = socketMessage as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            if (context.User.IsBot) return;

            var serverPrefix = "";
            if (!(context.Channel is IDMChannel))
            {
                serverPrefix = ServerAccounts.GetAccount((SocketGuild)context.Guild).Prefix;
            }
            else
            {
                serverPrefix = ">";
            }

            int argPos = 0;
            if (msg.HasStringPrefix(serverPrefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos, null);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(DateTimeOffset.UtcNow.ToString("[d.MM.yyyy HH:mm:ss] "));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.ErrorReason);
                    Console.ForegroundColor = ConsoleColor.White;

                    var embed = new EmbedBuilder();
                    embed.WithTitle("Ouch! An error occurred.");
                    embed.WithDescription(result.ErrorReason);
                    embed.WithColor(255, 0, 0);
                    await context.Channel.SendMessageAsync("", false, embed.Build());
                }
            }
        }

        public async Task JoinedServer(SocketGuild guild)
        {
            await Task.Run(() =>
            {
                var target = guild;
                ServerAccounts.GetAccount(target);
            });
        }
    }
}
