using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using Dominionizer.Phone.Core;
using Newtonsoft.Json;

namespace Dominionizer.ViewModels
{
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