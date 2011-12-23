namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;

    public class SaveGame
    {
        public string Name { get; set; }

        public SavedGameSource Source { get; set; }

        public List<string> CardNames { get; set; }
    }
}