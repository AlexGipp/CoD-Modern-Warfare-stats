using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CodMwStats.ApiWrapper;
using CodMwStats.ApiWrapper.Models;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;
using Discord.Commands;
using Newtonsoft.Json;

namespace CodMwStats.Commands.MainStatsCommands
{
    public class ActivisionStats : ModuleBase<SocketCommandContext>
    {
        [Command("Stats-activision")]
        [Alias("Statsav")]
        public async Task Statsatvi([Remainder] string userName)
        {
            if (userName.Contains("#"))
            {
                userName = userName.Replace("#", "%23");
            }
            var jsonAsString = await ApiProcessor.GetUser($"https://api.tracker.gg/api/v2/modern-warfare/standard/profile/atvi/{userName}");
            var apiData = JsonConvert.DeserializeObject<ModerWarfareApiOutput>(jsonAsString);

            var name = apiData.Data.PlatformInfo.PlatformUserHandle;
            var pfp = apiData.Data.PlatformInfo.AvatarUrl;
            var playTime = apiData.Data.Segment[0].Stats.TimePlayedTotal.DisplayValue;
            var matches = apiData.Data.Segment[0].Stats.TotalGamesPlayed.DisplayValue;
            var levelImg = apiData.Data.Segment[0].Stats.Level.Metadata.IconUrl;
            var level = apiData.Data.Segment[0].Stats.Level.DisplayValue;
            var levelper = apiData.Data.Segment[0].Stats.LevelProgression.DisplayValue;
            var kd = apiData.Data.Segment[0].Stats.KdRatio.DisplayValue;
            var kills = apiData.Data.Segment[0].Stats.Kills.DisplayValue;
            var WinPer = apiData.Data.Segment[0].Stats.WlRatio.DisplayValue;
            var wins = apiData.Data.Segment[0].Stats.Wins.DisplayValue;
            var bestKillsreak = apiData.Data.Segment[0].Stats.LongestKillstreak.DisplayValue;
            var losses = apiData.Data.Segment[0].Stats.Losses.DisplayValue;
            var deaths = apiData.Data.Segment[0].Stats.Deaths.DisplayValue;
            var avgLife = apiData.Data.Segment[0].Stats.AverageLife.DisplayValue;
            var assists = apiData.Data.Segment[0].Stats.Assists.DisplayValue;
            var score = apiData.Data.Segment[0].Stats.CareerScore.DisplayValue;
            var accuracy = apiData.Data.Segment[0].Stats.Accuracy.DisplayValue;
            var headshotaccuracy = apiData.Data.Segment[0].Stats.HeadshotPercentage.DisplayValue;

            var converter = new HtmlConverter();
            var generationStrings = new StatsGenerationFiles();
            string css = generationStrings.MultiplayerCss(levelper);
            string html = String.Format(generationStrings.MultiplayerHtml(name, pfp, playTime, matches, levelImg.ToString(), level, levelper, kd, kills, WinPer, wins, bestKillsreak, losses, deaths, avgLife, assists, score, accuracy, headshotaccuracy));
            int width = 520;
            var bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);
            File.WriteAllBytes("Resources/ATVIStats.png", bytes);
            await Context.Channel.SendFileAsync(new MemoryStream(bytes), "Resources/ATVIStats.png");
        }
    }
}
