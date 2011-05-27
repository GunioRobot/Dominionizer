using System;
using System.IO.IsolatedStorage;
using Dominionizer.Phone.Core;

namespace Dominionizer.ViewModels
{
    public class StorageHelper
    {
        private static IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        public static void SaveGameParameters(GameGeneratorParameters parameters)
        {
            if (!settings.Contains("parameters"))
                settings.Add("parameters", parameters);
            else
                settings["parameters"] = parameters;
        }

        public static GameGeneratorParameters LoadGameParameters()
        {
            try
            {
                GameGeneratorParameters parameters;
                if (settings.TryGetValue<GameGeneratorParameters>("parameters", out parameters))
                {
                    if (parameters == null)
                    {
                        return new GameGeneratorParameters();
                    }
                    else
                    {
                        return parameters;
                    }
                }
                else
                {
                    return new GameGeneratorParameters();
                }
            }
            catch
            {
                return new GameGeneratorParameters();
            }
        }
    }
}