using System;
using System.IO;
using System.Threading.Tasks;
using CodMwStats.ApiWrapper;
using CodMwStats.ApiWrapper.Models;
using CodMwStats.Commands.ImageGenerationFiles;
using CoreHtmlToImage;
using Discord.Commands;
using Newtonsoft.Json;

namespace CodMwStats.Commands.WarzoneStatsCommands
{
    public class ActivisionWarzoneStats : ModuleBase<SocketCommandContext>
    {
        [Command("WarzoneStats-activision")]
        [Alias("WZStatsav")]
        public async Task StatsActivisionWarzone([Remainder] string userName)
        {
            if (userName.Contains("#"))
            {
                userName = userName.Replace("#", "%23");
            }
            var jsonAsString =
                await ApiProcessor.GetUser(
                    $"https://api.tracker.gg/api/v2/warzone/standard/profile/atvi/{userName}");
            var apiData = JsonConvert.DeserializeObject<ModerWarfareApiOutput>(jsonAsString);

            var name = apiData.Data.PlatformInfo.PlatformUserHandle;
            var pfp = apiData.Data.PlatformInfo.AvatarUrl;
            var playTime = apiData.Data.Segment[0].Stats.TimePlayed.DisplayValue;
            var matches = apiData.Data.Segment[0].Stats.GamesPlayed.DisplayValue;
            var levelImg = apiData.Data.Segment[0].Stats.Level.Metadata.IconUrl;
            var level = apiData.Data.Segment[0].Stats.Level.DisplayValue;
            var levelper = apiData.Data.Segment[0].Stats.LevelProgression.DisplayValue;
            var kd = apiData.Data.Segment[0].Stats.KdRatio.DisplayValue;
            var kills = apiData.Data.Segment[0].Stats.Kills.DisplayValue;
            var WinPer = apiData.Data.Segment[0].Stats.WlRatio.DisplayValue;
            var wins = apiData.Data.Segment[0].Stats.Wins.DisplayValue;
            var deaths = apiData.Data.Segment[0].Stats.Deaths.DisplayValue;
            var avgLife = apiData.Data.Segment[0].Stats.AverageLife.DisplayValue;
            var score = apiData.Data.Segment[0].Stats.Score.DisplayValue;
            var scoreGame = apiData.Data.Segment[0].Stats.ScorePerGame.DisplayValue;
            var top5 = apiData.Data.Segment[0].Stats.TopFive.DisplayValue;
            var top10 = apiData.Data.Segment[0].Stats.TopTen.DisplayValue;
            var downs = apiData.Data.Segment[0].Stats.Downs.DisplayValue;
            var contracts = apiData.Data.Segment[0].Stats.Contracts.DisplayValue;


            var converter = new HtmlConverter();
            var generationStrings = new StatsGenerationFiles();
            string css = generationStrings.WarzoneCss(levelper);
            string html = String.Format(generationStrings.WarzoneHtml(name, pfp, playTime, matches, levelImg.ToString(),
                level, levelper, kd, kills, WinPer, wins, deaths, avgLife, score, top5, top10, downs, scoreGame,
                contracts));
            int width = 520;
            var bytes = converter.FromHtmlString(css + html, width, CoreHtmlToImage.ImageFormat.Png);
            File.WriteAllBytes("Resources/AVWarzoneStats.png", bytes);
            await Context.Channel.SendFileAsync(new MemoryStream(bytes), "Resources/AVWarzoneStats.png");
        }
    }
}