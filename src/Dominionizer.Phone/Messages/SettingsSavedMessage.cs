using System;
using Dominionizer.Phone.Core;

namespace Dominionizer.Messages
{
    public class SettingsSavedMessage
    {
        public GameGeneratorParameters Parameters { get; private set; }

        public SettingsSavedMessage(GameGeneratorParameters parameters)
        {
            Parameters = parameters;
        }
    }
}