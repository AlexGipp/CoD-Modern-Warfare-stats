using System;
using System.IO;
using System.Threading.Tasks;
using CodMwStats.AccountLogic.ServerAccounts;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace CodMwStats.Commands
{
    public class AdminCommands : ModuleBase<SocketCommandContext>
    {
        [Command("SetPrefix")]
        [Alias("SP")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SetPrefix(string prefix)
        {
            SocketGuild target = Context.Guild;

            var serverAccount = ServerAccounts.GetAccount((SocketGuild)target);
            
            serverAccount.Prefix = prefix;
            ServerAccounts.SaveAccounts();

            var embed = new EmbedBuilder();
            embed.WithTitle($"Prefix changed to `{prefix}` !");
            embed.WithDescription($"You can still use @ModernWarfareStats as the Prefix to execute commands.");
            embed.AddField("Example:", "<@695738324425375805> help"); 
            embed.WithColor(new Discord.Color(128, 213, 255));
            await Context.Channel.SendMessageAsync("", false, embed.Build());

            var converter = new HtmlConverter();
            var generationStrings = new HelpGenerationFiles();

            string css = generationStrings.HelpCss();
            string html = String.Format(generationStrings.HelpHtml(serverAccount.Prefix));
            int width = 520;
            var bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);
            File.WriteAllBytes($"Resources/{Context.Guild.Id}.png", bytes);

            css = generationStrings.HelpCss();
            html = String.Format(generationStrings.AdminHelpHtml(serverAccount.Prefix));
            width = 520;
            bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);
            File.WriteAllBytes($"Resources/{Context.Guild.Id}Admin.png", bytes);
        }
    }
}