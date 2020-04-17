using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CodMwStats.AccountLogic.ServerAccounts;
using CodMwStats.ApiWrapper;
using CodMwStats.ApiWrapper.Models;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace CodMwStats.Commands
{
    public class Utilities : ModuleBase<SocketCommandContext>
    {
        [Command("Ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("Pong");
        }

        [Command("invite")]
        public async Task Invite()
        {
            var embed = new EmbedBuilder();
            embed.WithImageUrl("https://i.imgur.com/Yyth15i.png");
            embed.WithDescription("[Invite the bot to your Server](https://discordapp.com/oauth2/authorize?client_id=695738324425375805&scope=bot&permissions=388161)");

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("help")]
        public async Task Help()
        {
            if (Context.Channel is IDMChannel)
            {
                await Context.Channel.SendMessageAsync($"https://i.imgur.com/zcB6CoO.png");
                return;
            }

            SocketGuild target = Context.Guild;
            var serverAccount = ServerAccounts.GetAccount((SocketGuild)target);
            var prefix = serverAccount.Prefix;


            if (!File.Exists($"Resources/{Context.Guild.Id}.png"))
            {
                var converter = new HtmlConverter();
                var generationStrings = new HelpGenerationFiles();

                string css = generationStrings.HelpCss();
                string html = String.Format(generationStrings.HelpHtml(prefix));
                int width = 520;
                var bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);
                File.WriteAllBytes($"Resources/{Context.Guild.Id}.png", bytes);
            }
            await Context.Channel.SendFileAsync($"Resources/{Context.Guild.Id}.png");
        }

        [Command("adminHelp")]
        [Alias("AHelp")]
        public async Task AdminHelp()
        {
            if (Context.Channel is IDMChannel)
            {
                await Context.Channel.SendMessageAsync($"https://i.imgur.com/6ifbG8t.png");
                return;
            }

            SocketGuild target = Context.Guild;
            var serverAccount = ServerAccounts.GetAccount((SocketGuild)target);
            var prefix = serverAccount.Prefix;

            if (!File.Exists($"Resources/{Context.Guild.Id}Admin.png"))
            {
                var converter = new HtmlConverter();
                var generationStrings = new HelpGenerationFiles();

                string css = generationStrings.HelpCss();
                string html = String.Format(generationStrings.AdminHelpHtml(prefix));
                int width = 520;
                var bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);
                File.WriteAllBytes($"Resources/{Context.Guild.Id}Admin.png", bytes);
            }
            await Context.Channel.SendFileAsync($"Resources/{Context.Guild.Id}Admin.png");
        }


    }
}
