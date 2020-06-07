using System;
using System.Collections.Generic;
using System.Text;

namespace CodMwStats.Commands.ImageGenerationFiles
{
    public class StatsGenerationFiles
    {
        public string MultiplayerHtml(
            string username,
            string profilePicture,
            string playTime,
            string matches,
            string levelIcon,
            string level,
            string levelProgression,
            string kd,
            string kills,
            string wlRatio,
            string wins,
            string longestKillstreak,
            string losses,
            string deaths,
            string avarageLife,
            string assists,
            string score,
            string accuracy,
            string headshotAccuracy)
        {
            return
                $"<div class=\"backgroundimg\"><img src=\"https://i.imgur.com/yJipVuJ.png\" ></div>\n<div class=\"ProfilePictureBig\"><img src=\"{profilePicture}\" ></div>\n<div class=\"profilePic\"><img src=\"{levelIcon}\" alt=\"\"></div>\n\n<div class=\"Username\">\n    <h1>\n        {username}\n    </h1>\n</div>\n\n<div class=\"playTime\">\n    <h1>\n        {playTime} Play Time\n    </h1>\n</div>\n\n<div class=\"matches\">\n    <h1>\n        {matches} Matches\n    </h1>\n</div>\n\n<div class=\"level\">\n    <h1>\n        {level}\n    </h1>\n</div>\n\n<div class=\"progressbar\">\n\n  <div class=\"progressbarContent\"></div>\n\n</div>\n\n<div class=\"levelProgression\">\n    <h1>\n        {levelProgression}\n    </h1>\n</div>\n\n<div class=\"kdRatio\">\n    <h1>\n        {kd}\n    </h1>\n</div>\n\n<div class=\"kills\">\n    <h1>\n        {kills}\n    </h1>\n</div>\n\n<div class=\"winPercentage\">\n    <h1>\n        {wlRatio}\n    </h1>\n</div>\n\n<div class=\"wins\">\n    <h1>\n        {wins}\n    </h1>\n</div>\n\n<div class=\"bestKillstreak\">\n    <h1>\n        {longestKillstreak}\n    </h1>\n</div>\n\n<div class=\"deaths\">\n    <h1>\n        {deaths}\n    </h1>\n</div>\n\n<div class=\"assists\">\n    <h1>\n        {assists}\n    </h1>\n</div>\n\n<div class=\"losses\">\n    <h1>\n        {losses}\n    </h1>\n</div>\n\n<div class=\"accuracy\">\n    <h1>\n        {accuracy}\n    </h1>\n</div>\n\n<div class=\"hsAccuracy\">\n    <h1>\n        {headshotAccuracy}\n    </h1>\n</div>\n\n<div class=\"avgLife\">\n    <h1>\n        {avarageLife}\n    </h1>\n</div>\n\n<div class=\"score\">\n    <h1>\n        {score}\n    </h1>\n</div>\n";
        }

        public string WarzoneHtml(
            string username,
            string profilePicture,
            string playTime,
            string matches,
            string levelIcon,
            string level,
            string levelProgression,
            string kd,
            string kills,
            string wlRatio,
            string wins,
            string deaths,
            string avarageLife,
            string score,
            string top5,
            string top10,
            string downs,
            string scoreGame,
            string contracts)
        {
            return
                $"<div class=\"backgroundimg\"><img src=\"https://i.imgur.com/bGob51H.png\" ></div>\n<div class=\"ProfilePictureBig\"><img src=\"{profilePicture}\" ></div>\n<div class=\"profilePic\"><img src=\"{levelIcon}\" alt=\"\"></div>\n\n<div class=\"Username\">\n    <h1>\n        {username}\n    </h1>\n</div>\n\n<div class=\"playTime\">\n    <h1>\n        {playTime} Play Time\n    </h1>\n</div>\n\n<div class=\"matches\">\n    <h1>\n        {matches} Matches\n    </h1>\n</div>\n\n<div class=\"level\">\n    <h1>\n        {level}\n    </h1>\n</div>\n\n<div class=\"progressbar\">\n\n  <div class=\"progressbarContent\"></div>\n\n</div>\n\n<div class=\"levelProgression\">\n    <h1>\n        {levelProgression}\n    </h1>\n</div>\n\n<div class=\"Wins\">\n    <h1>\n        {wins}\n    </h1>\n</div>\n\n<div class=\"top5\">\n    <h1>\n        {top5}\n    </h1>\n</div>\n\n<div class=\"kdRatio\">\n    <h1>\n        {kd}\n    </h1>\n</div>\n\n<div class=\"kills\">\n    <h1>\n        {kills}\n    </h1>\n</div>\n\n<div class=\"top10\">\n    <h1>\n        {top10}\n    </h1>\n</div>\n\n<div class=\"downs\">\n    <h1>\n        {downs}\n    </h1>\n</div>\n\n<div class=\"score\">\n    <h1>\n        {score}\n    </h1>\n</div>\n\n<div class=\"scoreGame\">\n    <h1>\n        {scoreGame}\n    </h1>\n</div>\n\n<div class=\"contracts\">\n    <h1>\n        {contracts}\n    </h1>\n</div>\n\n<div class=\"avgLife\">\n    <h1>\n        {avarageLife}\n    </h1>\n</div>\n\n<div class=\"deaths\">\n    <h1>\n        {deaths}\n    </h1>\n</div>\n\n<div class=\"winPercentage\">\n    <h1>\n        {wlRatio}\n    </h1>\n</div>\n";
        }

        public string PlunderHtml(
            string username,
            string profilePicture,
            string playTime,
            string matches,
            string levelIcon,
            string level,
            string levelProgression,
            string kd,
            string kills,
            string wlRatio,
            string wins,
            string deaths,
            string avarageLife,
            string score,
            string scoreGame,
            string scoreMin,
            string downs,
            string cash,
            string contracts)
        {
            return
                $"<div class=\"backgroundimg\"><img src=\"https://i.imgur.com/ULjIYzg.png\" ></div>\n<div class=\"ProfilePictureBig\"><img src=\"{profilePicture}\" ></div>\n<div class=\"profilePic\"><img src=\"{levelIcon}\" alt=\"\"></div>\n\n<div class=\"Username\">\n    <h1>\n        {username}\n    </h1>\n</div>\n\n<div class=\"playTime\">\n    <h1>\n        {playTime} Play Time\n    </h1>\n</div>\n\n<div class=\"matches\">\n    <h1>\n        {matches} Matches\n    </h1>\n</div>\n\n<div class=\"level\">\n    <h1>\n        {level}\n    </h1>\n</div>\n\n<div class=\"progressbar\">\n\n  <div class=\"progressbarContent\"></div>\n\n</div>\n\n<div class=\"levelProgression\">\n    <h1>\n        {levelProgression}\n    </h1>\n</div>\n\n<div class=\"Wins\">\n    <h1>\n        {wins}\n    </h1>\n</div>\n\n<div class=\"top5\">\n    <h1>\n        {scoreGame}\n    </h1>\n</div>\n\n<div class=\"kdRatio\">\n    <h1>\n        {kd}\n    </h1>\n</div>\n\n<div class=\"kills\">\n    <h1>\n        {kills}\n    </h1>\n</div>\n\n<div class=\"top10\">\n    <h1>\n        {scoreMin}\n    </h1>\n</div>\n\n<div class=\"downs\">\n    <h1>\n        {downs}\n    </h1>\n</div>\n\n<div class=\"score\">\n    <h1>\n        {score}\n    </h1>\n</div>\n\n<div class=\"scoreGame\">\n    <h1>\n        {cash}\n    </h1>\n</div>\n\n<div class=\"contracts\">\n    <h1>\n        {contracts}\n    </h1>\n</div>\n\n<div class=\"avgLife\">\n    <h1>\n        {avarageLife}\n    </h1>\n</div>\n\n<div class=\"deaths\">\n    <h1>\n        {deaths}\n    </h1>\n</div>\n\n<div class=\"winPercentage\">\n    <h1>\n        {wlRatio}\n    </h1>\n</div>\n";
        }

        public string BattleRoyaleHtml(
            string username,
            string profilePicture,
            string playTime,
            string matches,
            string levelIcon,
            string level,
            string levelProgression,
            string kd,
            string kills,
            string wlRatio,
            string wins,
            string deaths,
            string avarageLife,
            string score,
            string top5,
            string top10,
            string downs,
            string top25,
            string contracts)
        {
            return
                $"<div class=\"backgroundimg\"><img src=\"https://i.imgur.com/UMVybv6.png\" ></div>\n<div class=\"ProfilePictureBig\"><img src=\"{profilePicture}\" ></div>\n<div class=\"profilePic\"><img src=\"{levelIcon}\" alt=\"\"></div>\n\n<div class=\"Username\">\n    <h1>\n        {username}\n    </h1>\n</div>\n\n<div class=\"playTime\">\n    <h1>\n        {playTime} Play Time\n    </h1>\n</div>\n\n<div class=\"matches\">\n    <h1>\n        {matches} Matches\n    </h1>\n</div>\n\n<div class=\"level\">\n    <h1>\n        {level}\n    </h1>\n</div>\n\n<div class=\"progressbar\">\n\n  <div class=\"progressbarContent\"></div>\n\n</div>\n\n<div class=\"levelProgression\">\n    <h1>\n        {levelProgression}\n    </h1>\n</div>\n\n<div class=\"Wins\">\n    <h1>\n        {wins}\n    </h1>\n</div>\n\n<div class=\"top5\">\n    <h1>\n        {top5}\n    </h1>\n</div>\n\n<div class=\"kdRatio\">\n    <h1>\n        {kd}\n    </h1>\n</div>\n\n<div class=\"kills\">\n    <h1>\n        {kills}\n    </h1>\n</div>\n\n<div class=\"top10\">\n    <h1>\n        {top10}\n    </h1>\n</div>\n\n<div class=\"downs\">\n    <h1>\n        {downs}\n    </h1>\n</div>\n\n<div class=\"score\">\n    <h1>\n        {score}\n    </h1>\n</div>\n\n<div class=\"scoreGame\">\n    <h1>\n        {top25}\n    </h1>\n</div>\n\n<div class=\"contracts\">\n    <h1>\n        {contracts}\n    </h1>\n</div>\n\n<div class=\"avgLife\">\n    <h1>\n        {avarageLife}\n    </h1>\n</div>\n\n<div class=\"deaths\">\n    <h1>\n        {deaths}\n    </h1>\n</div>\n\n<div class=\"winPercentage\">\n    <h1>\n        {wlRatio}\n    </h1>\n</div>";
        }


        public string MultiplayerCss(string levelProgression)
        {
            return
                "<style>\n    .backgroundimg\n    {\n        z-index: 1;\n        position: absolute;\n        top: 0;\n        left: 0px;\n    }\n\n    .ProfilePictureBig img\n    {\n        position: absolute;\n        height: 51px;\n        width: 51px;\n        top: 14px;\n        left: 23px;\n        z-index: 2;\n        border-radius: 200px;\n    }\n    .profilePic img {\n      position: absolute;\n      height: 62px;\n      width: 62px;\n      top: 145px;\n      left: 15px;\n      z-index: 3;\n    }\n\n    .Username h1\n    {\n        font-family: Arial;\n        font-size: 18.37px;\n        font-weight: lighter;\n        color: white;\n        position: absolute;\n        top: 17px;\n        left: 90px;\n        z-index: 3;\n    }\n\n    .playTime h1\n    {\n        font-family: Arial;\n        font-size: 12px;\n        font-weight: bold;\n        color: #aebecf;\n        position: absolute;\n        top: 95.55px;\n        left: 224px;\n        z-index: 3;\n    }\n\n    .matches h1\n    {\n        font-family: Arial;\n        font-size: 12px;\n        font-weight: bold;\n        color: #aebecf;\n        position: absolute;\n        top: 95.55px;\n        left: 404px;\n        z-index: 3;\n    }\n\n    .level h1\n    {\n        font-family: Arial;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 137px;\n        left: 143px;\n        z-index: 3;\n    }\n\n    .progressbar {\n      position: absolute;\n      background-color: grey;\n      border-radius: 8px;\n      width: 140px;\n      left: 94px;\n      top: 172px;\n      z-index: 3;\n    }\n\n    .progressbar>.progressbarContent {\n      background-color: #cbb765;\n      width: " + levelProgression + ";\n      height: 12px;\n      border-radius: 8px;\n    }\n\n    .levelProgression h1\n    {\n        font-family: Arial;\n        font-size: 12px;\n        font-weight: bold;\n        color: #aebecf;\n        position: absolute;\n        top: 177px;\n        left: 202px;\n        z-index: 3;\n    }\n\n    .kdRatio h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 22px;\n        z-index: 3;\n    }\n\n    .kills h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 145px;\n        z-index: 3;\n    }\n\n    .winPercentage h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 271px;\n        z-index: 3;\n    }\n\n    .wins h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 396px;\n        z-index: 3;\n    }\n\n    .bestKillstreak h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 21px;\n        z-index: 3;\n    }\n\n    .deaths h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 21px;\n        z-index: 3;\n    }\n\n    .assists h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 145px;\n        z-index: 3;\n    }\n\n    .losses h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 145px;\n        z-index: 3;\n    }\n\n    .accuracy h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 273px;\n        z-index: 3;\n    }\n\n    .hsAccuracy h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 273px;\n        z-index: 3;\n    }\n\n    .avgLife h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 396px;\n        z-index: 3;\n    }\n\n    .score h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 396px;\n        z-index: 3;\n    }\n</style>";
        }

        public string WarzoneCss(string levelProgression)
        {
            return
                "<style>\n    .backgroundimg\n    {\n        z-index: 1;\n        position: absolute;\n        top: 0;\n        left: 0px;\n    }\n\n    .ProfilePictureBig img\n    {\n        position: absolute;\n        height: 51px;\n        width: 51px;\n        top: 14px;\n        left: 23px;\n        z-index: 2;\n        border-radius: 200px;\n    }\n    .profilePic img {\n      position: absolute;\n      height: 62px;\n      width: 62px;\n      top: 145px;\n      left: 15px;\n      z-index: 3;\n    }\n\n    .Username h1\n    {\n        font-family: Arial;\n        font-size: 18.37px;\n        font-weight: lighter;\n        color: white;\n        position: absolute;\n        top: 17px;\n        left: 90px;\n        z-index: 3;\n    }\n\n    .playTime h1\n    {\n        font-family: Arial;\n        font-size: 12px;\n        font-weight: bold;\n        color: #aebecf;\n        position: absolute;\n        top: 95.55px;\n        left: 224px;\n        z-index: 3;\n    }\n\n    .matches h1\n    {\n        font-family: Arial;\n        font-size: 12px;\n        font-weight: bold;\n        color: #aebecf;\n        position: absolute;\n        top: 95.55px;\n        left: 404px;\n        z-index: 3;\n    }\n\n    .level h1\n    {\n        font-family: Arial;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 137px;\n        left: 143px;\n        z-index: 3;\n    }\n\n    .progressbar {\n      position: absolute;\n      background-color: grey;\n      border-radius: 8px;\n      width: 140px;\n      left: 94px;\n      top: 172px;\n      z-index: 3;\n    }\n\n    .progressbar>.progressbarContent {\n      background-color: #cbb765;\n      width: " + levelProgression + ";\n      height: 12px;\n      border-radius: 8px;\n    }\n\n    .levelProgression h1\n    {\n        font-family: Arial;\n        font-size: 12px;\n        font-weight: bold;\n        color: #aebecf;\n        position: absolute;\n        top: 177px;\n        left: 202px;\n        z-index: 3;\n    }\n\n    .Wins h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 22px;\n        z-index: 3;\n    }\n\n    .top5 h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 145px;\n        z-index: 3;\n    }\n\n    .kdRatio h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 271px;\n        z-index: 3;\n    }\n\n    .kills h1\n    {\n        font-family: Roboto;\n        font-size: 25px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 215px;\n        left: 396px;\n        z-index: 3;\n    }\n\n    .top10 h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 21px;\n        z-index: 3;\n    }\n\n    .downs h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 21px;\n        z-index: 3;\n    }\n\n    .score h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 145px;\n        z-index: 3;\n    }\n\n    .scoreGame h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 145px;\n        z-index: 3;\n    }\n\n    .contracts h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 273px;\n        z-index: 3;\n    }\n\n    .avgLife h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 273px;\n        z-index: 3;\n    }\n\n    .deaths h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 288px;\n        left: 396px;\n        z-index: 3;\n    }\n\n    .winPercentage h1\n    {\n        font-family: Roboto;\n        font-size: 18px;\n        font-weight: bold;\n        color: white;\n        position: absolute;\n        top: 337px;\n        left: 396px;\n        z-index: 3;\n    }\n</style>";
        }
    }
}
