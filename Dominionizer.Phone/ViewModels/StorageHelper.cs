using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using Dominionizer.Phone.Core;
using Newtonsoft.Json;

namespace Dominionizer.ViewModels
{
    using System.Linq;

    public class StorageHelper
    {
        private readonly static string filename = "settings.dat";

        public static void SaveGameParameters(GameGeneratorParameters parameters)
        {
            var json = JsonConvert.SerializeObject(parameters);
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fs = isf.OpenFile(filename, FileMode.Create))
                {
                    using (var writer = new StreamWriter(fs))
                    {
                        writer.Write(json);
                        writer.Close();
                    }
                }
            }
        }

        public static GameGeneratorParameters LoadGameParameters()
        {
            var parameters = GameGeneratorParameters.GetInstance();

            var storedParameters = GetGameParametersFromStorage();

            if (storedParameters.Sets.Count > 0)
            {
                foreach (var set in parameters.Sets)
                {
                    var storedSet = storedParameters.Sets.Where(x => x.Name == set.Name).FirstOrDefault();

                    if (storedSet == null) continue;
                        
                    set.IsSet = storedSet.IsSet;
                }
            }

            if (storedParameters.Rules.Count > 0)
            {
                foreach (var rule in parameters.Rules)
                {
                    var storedRule = storedParameters.Rules.Where(x => x.Name == rule.Name).First();

                    if (storedRule == null) continue;
                    
                    rule.IsSet = storedRule.IsSet;
                }
            }

            return parameters;
        }

        private static GameGeneratorParameters GetGameParametersFromStorage()
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists(filename))
                {
                    using (IsolatedStorageFileStream fs = isf.OpenFile(filename, FileMode.Open))
                    {
                        using (var reader = new StreamReader(fs))
                        {
                            var json = reader.ReadToEnd();
                            var parameters = JsonConvert.DeserializeObject<GameGeneratorParameters>(json);
                            return parameters;
                        }
                    }
                }
                else
                {
                    return GameGeneratorParameters.GetInstance();
                }
            }
        }
    }
}