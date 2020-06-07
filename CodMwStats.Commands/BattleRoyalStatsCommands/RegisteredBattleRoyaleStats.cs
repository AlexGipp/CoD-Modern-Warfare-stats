using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodMwStats.AccountLogic.ServerAccounts;
using CodMwStats.AccountLogic.UserAccounts;
using CodMwStats.ApiWrapper;
using CodMwStats.ApiWrapper.Models;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ModernWarfare.Net;
using ModernWarfare.Net.Models.Enums;
using Newtonsoft.Json;

namespace CodMwStats.Commands.BattleRoyalStatsCommands
{
    public class RegisteredBattleRoyaleStats : ModuleBase<SocketCommandContext>
    {
        [Command("BattleRoyaleStats")]
        [Alias("BRStats")]
        public async Task StatsBattleNetBattleRoyale([Remainder] string arg = "")
        {
            SocketUser target = null;
            var mentionUser = Context.Message.MentionedUsers.FirstOrDefault();
            target = mentionUser ?? Context.User;

            var account = UserAccounts.GetAccount(target);
            var serverAccount = ServerAccounts.GetAccount(Context.Guild);

            if (string.IsNullOrEmpty(account.GameUsername))
            {
                var errorEmbed = new EmbedBuilder();
                errorEmbed.WithTitle("Ouch! An error occurred.");
                errorEmbed.WithDescription($"User not registered.");
                errorEmbed.WithColor(255, 0, 0);
                await Context.Channel.SendMessageAsync("", false, errorEmbed.Build());
                return;
            }



            var jsonAsString = await ApiProcessor.GetUser($"https://api.tracker.gg/api/v2/warzone/standard/profile/{account.Platform}/{account.GameUsername}");
            var apiData = JsonConvert.DeserializeObject<ModerWarfareApiOutput>(jsonAsString);

            var name = apiData.Data.PlatformInfo.PlatformUserHandle;
            var pfp = apiData.Data.PlatformInfo.AvatarUrl;
            var levelImg = apiData.Data.Segment[0].Stats.Level.Metadata.IconUrl;

            Platform platform = Platform.BattleNet;
            if (account.Platform == "atvi")
            {
                platform = Platform.Activision;
            }
            else if (account.Platform == "psn")
            {
                platform = Platform.PSN;
            }
            else if (account.Platform == "xbl")
            {
                platform = Platform.XBL;
            }

            var client = new ModernWarfareClient();
            var allStats = await client.GetWarzoneStatsAsync(platform, account.GameUsername);
            var battleRoyalStats = allStats.BattleRoyalStats;

            var converter = new HtmlConverter();
            var generationStrings = new StatsGenerationFiles();

            string css = generationStrings.WarzoneCss(allStats.LifetimeStats.LevelProgression.DisplayValue);
            string html = String.Format(generationStrings.BattleRoyaleHtml(name, pfp,
                battleRoyalStats.TimePlayed.DisplayValue, battleRoyalStats.GamesPlayed.DisplayValue,
                levelImg.ToString(), allStats.LifetimeStats.Level.DisplayValue,
                allStats.LifetimeStats.LevelProgression.DisplayValue, battleRoyalStats.KdRatio.DisplayValue,
                battleRoyalStats.Kills.DisplayValue, battleRoyalStats.WlRatio.DisplayValue,
                battleRoyalStats.Wins.DisplayValue, battleRoyalStats.Deaths.DisplayValue,
                battleRoyalStats.AvarageLife.DisplayValue, battleRoyalStats.Score.DisplayValue,
                battleRoyalStats.Top5.DisplayValue, battleRoyalStats.Top10.DisplayValue,
                battleRoyalStats.Downs.DisplayValue, battleRoyalStats.Top25.DisplayValue,
                battleRoyalStats.Contracts.DisplayValue));

            int width = 520;
            var bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);

            File.WriteAllBytes("Resources/BattleRoyaleStats.png", bytes);
            await Context.Channel.SendFileAsync(new MemoryStream(bytes), "Resources/BattleRoyaleStats.png");
        }
    }
}