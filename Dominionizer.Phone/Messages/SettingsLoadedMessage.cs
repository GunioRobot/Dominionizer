using System;
using Dominionizer.Phone.Core;

namespace Dominionizer.Messages
{
    public class SettingsLoadedMessage
    {
        public GameGeneratorParameters Parameters { get; set; }

        public SettingsLoadedMessage(GameGeneratorParameters parameters)
        {
            Parameters = parameters;
        }
    }
}