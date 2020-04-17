using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DiscordBotsList.Api;
using DiscordBotsList.Api.Objects;
using Newtonsoft.Json;

namespace CodMwStats.ServerListIntegration
{
    public class TopGgIntegration
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";

        public static BotConfig bot;
        public async void SyncWithTopGG()
        {
            string json = File.ReadAllText(configFolder + "/" + configFile);
            bot = JsonConvert.DeserializeObject<BotConfig>(json);

            //Integration

        }

        public struct BotConfig
        {
            public string token;
            public string cmdPrefix;
        }
    }
}
