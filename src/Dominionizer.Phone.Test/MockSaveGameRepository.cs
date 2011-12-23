namespace Dominionizer.Phone.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Dominionizer.Phone.Core.SaveGames;

    public class MockSaveGameRepository : ISaveGameRepository
    {
        private List<SaveGame> Games { get; set; }

        public MockSaveGameRepository()
        {
            Games = new List<SaveGame>();
            var builtInGames  = new BuiltInSaveGames();

            foreach (var item in builtInGames.Games)
            {
                var newSaveGame = new SaveGame
                    {
                        Name = item.Key, 
                        Source = SavedGameSource.BuiltIn, 
                        CardNames = item.Value.Split(',').ToList()
                    };

                Games.Add(newSaveGame);
            }
        }

        public List<SaveGame> GetAllSaveGames()
        {
            return Games;
        }

        public SaveGame GetSaveGameByName(string name)
        {
            return Games.Where(x => x.Name == name).FirstOrDefault();
        }

        public void Save(SaveGame saveGame)
        {
            // Do nothing
        }
    }
}