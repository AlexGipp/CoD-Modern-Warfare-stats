using System.Threading.Tasks;
using CodMwStats.AccountLogic.ServerAccounts;
using CodMwStats.AccountLogic.UserAccounts;
using CodMwStats.ApiWrapper;
using CodMwStats.ApiWrapper.Models;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Newtonsoft.Json;

namespace CodMwStats.Commands
{
    public class UserCommands : ModuleBase<SocketCommandContext>
    {
        [Command("RegisterBN")]
        public async Task RegisterBN([Remainder]string gameUsername)
        {
            if (gameUsername.Contains("#"))
            {
                gameUsername = gameUsername.Replace("#", "%23");
            }
            else
            {
                var errorEmbed = new EmbedBuilder();
                errorEmbed.WithTitle("Ouch! An error occurred.");
                errorEmbed.WithDescription("Invalid BattleNet username.");
                errorEmbed.WithColor(255, 0, 0);
                await Context.Channel.SendMessageAsync("", false, errorEmbed.Build());
                return;
            }

            var jsonAsString = await ApiProcessor.GetUser($"https://api.tracker.gg/api/v2/warzone/standard/profile/battlenet/{gameUsername}");

            var serverAccount = ServerAccounts.GetAccount(Context.Guild);

            var account = UserAccounts.GetAccount(Context.User);
            account.Platform = "battlenet";
            account.GameUsername = gameUsername;
            UserAccounts.SaveAccounts();

            var embed = new EmbedBuilder();
            embed.WithDescription($"**Server Prefix:** `{serverAccount.Prefix}`");
            embed.WithImageUrl("https://i.imgur.com/0hI99PO.png");
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("RegisterAV")]
        public async Task RegisterAV([Remainder]string gameUsername)
        {
            if (gameUsername.Contains("#"))
            {
                gameUsername = gameUsername.Replace("#", "%23");
            }

            var jsonAsString = await ApiProcessor.GetUser($"https://api.tracker.gg/api/v2/warzone/standard/profile/atvi/{gameUsername}");

            var serverAccount = ServerAccounts.GetAccount(Context.Guild);


            var account = UserAccounts.GetAccount(Context.User);
            account.Platform = "atvi";
            account.GameUsername = gameUsername;
            UserAccounts.SaveAccounts();

            var embed = new EmbedBuilder();
            embed.WithDescription($"**Server Prefix:** `{serverAccount.Prefix}`");
            embed.WithImageUrl("https://i.imgur.com/0hI99PO.png");
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("RegisterPSN")]
        public async Task RegisterPSN([Remainder]string gameUsername)
        {
            var jsonAsString = await ApiProcessor.GetUser($"https://api.tracker.gg/api/v2/warzone/standard/profile/psn/{gameUsername}");

            var serverAccount = ServerAccounts.GetAccount(Context.Guild);

            var account = UserAccounts.GetAccount(Context.User);
            account.Platform = "psn";
            account.GameUsername = gameUsername;
            UserAccounts.SaveAccounts();

            var embed = new EmbedBuilder();
            embed.WithDescription($"**Server Prefix:** `{serverAccount.Prefix}`");
            embed.WithImageUrl("https://i.imgur.com/0hI99PO.png");
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("RegisterXBL")]
        public async Task RegisterXBL([Remainder]string gameUsername)
        {
            var jsonAsString = await ApiProcessor.GetUser($"https://api.tracker.gg/api/v2/warzone/standard/profile/xbl/{gameUsername}");

            var serverAccount = ServerAccounts.GetAccount(Context.Guild);

            var account = UserAccounts.GetAccount(Context.User);
            account.Platform = "xbl";
            account.GameUsername = gameUsername;
            UserAccounts.SaveAccounts();

            var embed = new EmbedBuilder();
            embed.WithDescription($"**Server Prefix:** `{serverAccount.Prefix}`");
            embed.WithImageUrl("https://i.imgur.com/0hI99PO.png");
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}