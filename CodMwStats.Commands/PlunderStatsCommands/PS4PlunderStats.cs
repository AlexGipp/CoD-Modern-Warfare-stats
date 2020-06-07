using System;
using System.IO;
using System.Threading.Tasks;
using CodMwStats.ApiWrapper;
using CodMwStats.ApiWrapper.Models;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;
using Discord;
using Discord.Commands;
using ModernWarfare.Net;
using ModernWarfare.Net.Models.Enums;
using Newtonsoft.Json;

namespace CodMwStats.Commands.PlunderStatsCommands
{
    public class PS4PlunderStats : ModuleBase<SocketCommandContext>
    {
        [Command("PlunderStats-psn")]
        [Alias("PlStatspsn")]
        public async Task StatsPSNPlunder([Remainder] string userName)
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
            var plunderStats = allStats.PlunderStats;

            var converter = new HtmlConverter();
            var generationStrings = new StatsGenerationFiles();

            string css = generationStrings.WarzoneCss(allStats.LifetimeStats.LevelProgression.DisplayValue);
            string html = String.Format(generationStrings.PlunderHtml(name, pfp, plunderStats.TimePlayed.DisplayValue, plunderStats.GamesPlayed.DisplayValue, levelImg.ToString(),
                allStats.LifetimeStats.Level.DisplayValue, allStats.LifetimeStats.LevelProgression.DisplayValue, plunderStats.KdRatio.DisplayValue, plunderStats.Kills.DisplayValue, plunderStats.WlRatio.DisplayValue, plunderStats.Wins.DisplayValue, plunderStats.Deaths.DisplayValue, plunderStats.AvarageLife.DisplayValue, plunderStats.Score.DisplayValue, plunderStats.ScorePerGame.DisplayValue, plunderStats.ScorePerMinute.DisplayValue, plunderStats.Downs.DisplayValue, plunderStats.Cash.DisplayValue,
                plunderStats.Contracts.DisplayValue));

            int width = 520;
            var bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);

            File.WriteAllBytes("Resources/PSNPlunderStats.png", bytes);
            await Context.Channel.SendFileAsync(new MemoryStream(bytes), "Resources/PSNPlunderStats.png");
        }
    }
}