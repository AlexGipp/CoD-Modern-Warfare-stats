using System;
using System.IO;
using System.Threading.Tasks;
using CodMwStats.ApiWrapper;
using CodMwStats.ApiWrapper.Models;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;
using Discord.Commands;
using ModernWarfare.Net;
using ModernWarfare.Net.Models.Enums;
using Newtonsoft.Json;

namespace CodMwStats.Commands.BattleRoyalStatsCommands
{
    public class PS4BattleRoyalStats : ModuleBase<SocketCommandContext>
    {
        [Command("BattleRoyaleStats-psn")]
        [Alias("BRStatspsn")]
        public async Task StatsPSNBattleRoyale([Remainder] string userName)
        {
            var jsonAsString =
                await ApiProcessor.GetUser(
                    $"https://api.tracker.gg/api/v2/warzone/standard/profile/psn/{userName}");
            var apiData = JsonConvert.DeserializeObject<ModerWarfareApiOutput>(jsonAsString);

            var name = apiData.Data.PlatformInfo.PlatformUserHandle;
            var pfp = apiData.Data.PlatformInfo.AvatarUrl;
            var levelImg = apiData.Data.Segment[0].Stats.Level.Metadata.IconUrl;

            var client = new ModernWarfareClient();
            var allStats = await client.GetWarzoneStatsAsync(Platform.PSN, userName);
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

            File.WriteAllBytes("Resources/PSNBattleRoyaleStats.png", bytes);
            await Context.Channel.SendFileAsync(new MemoryStream(bytes), "Resources/PSNBattleRoyaleStats.png");
        }
    }
}