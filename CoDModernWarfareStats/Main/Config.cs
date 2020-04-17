using Newtonsoft.Json;
using System.IO;

namespace CodMwStats.Core.Main
{
    public class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";
        private const string asciiFile = "ascii.json";


        public static BotConfig bot;

        static Config()
        {
            if (!Directory.Exists(configFolder)) Directory.CreateDirectory(configFolder);
            if (!File.Exists(configFolder + "/" + configFile))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(configFolder + "/" + configFile, json);
            }
            if (!File.Exists(configFolder + "/" + asciiFile))
            {
                File.Create(configFolder + "/" + asciiFile);
            }
            else
            {
                string json = File.ReadAllText(configFolder + "/" + configFile);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}
