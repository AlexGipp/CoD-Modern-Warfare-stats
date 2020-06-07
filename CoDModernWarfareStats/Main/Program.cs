using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;
using CodMwStats.AccountLogic.ServerAccounts;
using CodMwStats.ApiWrapper;
using CodMwStats.Commands;

namespace CodMwStats.Core.Main
{
    class Program : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient _client;
        private CommandHandler _handler;

        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            string filePath = "Resources/Ascii.json";

            if (File.Exists(filePath))
            {
                string ascii = File.ReadAllText(filePath);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(ascii);
                Console.ForegroundColor = ConsoleColor.White;
            }

            ApiHelper.InitializeClient();

            if (string.IsNullOrEmpty(Config.bot.token)) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            _client.ReactionAdded += OnReactionAdded;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            await Task.Run(() =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(DateTimeOffset.UtcNow.ToString("[d.MM.yyyy HH:mm:ss]"));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{msg.Message}");
            });
        }

        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            //help
            var currentChannel = (ITextChannel)channel;
            var currentGuild = (SocketGuild)currentChannel.Guild;
            var serverAccount = ServerAccounts.GetAccount(currentGuild);

            if (reaction.MessageId == Global.MessageToToTrack)
            {
                if (reaction.Emote.Name == "\U00000031\U000020e3" && !reaction.User.Value.IsBot)
                {
                    var userMessage = await cache.GetOrDownloadAsync();
                    var embed = new EmbedBuilder();

                    await userMessage.ModifyAsync(x =>
                    {
                        embed.WithTitle("Page 1/2");
                        embed.WithDescription($"**Server Prefix:** `{serverAccount.Prefix}`");
                        embed.WithImageUrl("https://i.imgur.com/9ImiHyn.png");

                        x.Embed = embed.Build();
                    });
                    await userMessage.RemoveReactionAsync(new Emoji("\U00000031\U000020e3"), reaction.User.Value);
                }
            }
            if (reaction.MessageId == Global.MessageToToTrack)
            {
                if (reaction.Emote.Name == "\U00000032\U000020e3" && !reaction.User.Value.IsBot)
                {
                    var userMessage = await cache.GetOrDownloadAsync();
                    var embed = new EmbedBuilder();

                    await userMessage.ModifyAsync(x =>
                    {
                        embed.WithTitle("Page 2/2");
                        embed.WithDescription($"**Server Prefix:** `{serverAccount.Prefix}`");
                        embed.WithImageUrl("https://i.imgur.com/gnwR1GG.png");

                        x.Embed = embed.Build();
                    });
                    await userMessage.RemoveReactionAsync(new Emoji("\U00000032\U000020e3"), reaction.User.Value);
                }
            }
            
            if (reaction.MessageId == Global.MessageToToTrack)
            {
                if (reaction.Emote.Name == "\U00002754" && !reaction.User.Value.IsBot)
                {
                    var userMessage = await cache.GetOrDownloadAsync();
                    var embed = new EmbedBuilder();

                    await userMessage.ModifyAsync(x =>
                    {
                        embed.WithImageUrl("https://i.imgur.com/Yyth15i.png");
                        embed.WithDescription("[Invite the bot to your Server](https://discordapp.com/oauth2/authorize?client_id=695738324425375805&scope=bot&permissions=388161)");

                        x.Embed = embed.Build();
                    });
                    await userMessage.RemoveReactionAsync(new Emoji("\U00002754"), reaction.User.Value);
                }
            }
            if (reaction.MessageId == Global.MessageToToTrack)
            {
                if (reaction.Emote.Name == "\U000023f9" && !reaction.User.Value.IsBot)
                {
                    var userMessage = await cache.GetOrDownloadAsync();
                    await userMessage.DeleteAsync();
                }
            } 
        }
    }
}
