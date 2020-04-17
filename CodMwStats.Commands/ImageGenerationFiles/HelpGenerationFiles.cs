namespace CodMwStats.Commands.ImageGenerationFiles
{
    public class HelpGenerationFiles
    {
        public string HelpHtml(string prefix)
        {
            return
                $"<html lang=\"en\" dir=\"ltr\">\n  <head>\n  </head>\n  <body>\n    <img src=\"https://i.imgur.com/yJpsyLD.png\" alt=\"\">\n    <ul class=\"prefix\">\n      <li>{prefix}</li>\n      <li>{prefix}</li>\n      <li>{prefix}</li>\n      <li>{prefix}</li>\n    </ul>\n    <ul class=\"prefix1\">\n      <li>{prefix}</li>\n      <li>{prefix}</li>\n      <li>{prefix}</li>\n      <li>{prefix}</li>\n    </ul>\n  </body>\n</html>";
        }

        public string AdminHelpHtml(string prefix)
        {
            return
                $"<html lang=\"en\" dir=\"ltr\">\n  <head>\n  </head>\n  <body>\n    <img src=\"https://i.imgur.com/6ifbG8t.png\" alt=\"\">\n    <ul class=\"prefix\">\n      <li>{prefix}</li>\n    </ul>\n  </body>\n</html>";
        }


        public string HelpCss()
        {
            return
                "<style media=\"screen\">\n    @import url('https://fonts.googleapis.com/css?family=Rajdhani&display=swap');\n      body{\n        margin: 0px;\n        padding: 0px;\n        background-repeat: no-repeat;\n        font-family: 'Rajdhani', sans-serif;\n      }\n      img{\n        z-index: 1;\n      }\n      .prefix{\n        position: absolute;\n        top: 155px;\n        left: -6px;\n        color: white;\n        list-style: none;\n        z-index: 2;\n  font-weight: bold;}\n      .prefix li{\n          padding-bottom: 2.5px;\n      }\n      .prefix1{\n        position: absolute;\n        top: 289px;\n        left: -6px;\n        color: white;\n        list-style: none;\n        z-index: 2;\n   font-weight: bold;}\n      .prefix1 li{\n          padding-bottom: 2.5px;\n      }\n    </style>";
        }
    }
}