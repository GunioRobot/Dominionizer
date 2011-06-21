namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;
    using System.Linq;

    public class SaveGameManager
    {
        public List<SaveGame> Games { get; set; }

        private ISaveGameRepository repository;

        public SaveGameManager(ISaveGameRepository saveGameRepository)
        {
            repository = saveGameRepository;

            this.Games = repository.GetAllSaveGames();
        }

        public void InitializeBuiltInGames()
        {
            var builtInGames = new BuiltInSaveGames();
            foreach (var game in builtInGames.Games)
            {
                var saveGame = new SaveGame
                    {
                        Source = SavedGameSource.BuiltIn, 
                        Name = game.Key, 
                        CardNames = game.Value.Split(',').ToList()
                    };
                
                repository.Save(saveGame);
            }
            
        }

        public void Save(SaveGame saveGame)
        {
            // Don't allow games with the same name as a built in game????
            // Should we just save all games including built in the same way???

            repository.Save(saveGame);
        }

        public List<string> AvailableBuiltInGamesNames()
        {
            return this.Games.Where(x => x.Source == SavedGameSource.BuiltIn).Select(game => game.Name).ToList();
        }

        public List<string> AvailableUserDefinedGameNames()
        {
            return this.Games.Where(x => x.Source == SavedGameSource.UserDefined).Select(game => game.Name).ToList();
        }

        public List<Card> GetCardsForSavedGame(string savedGameName)
        {
            var savedGame = this.Games.Where(x => x.Name == savedGameName).FirstOrDefault();

            return BuildCardListFromSavedGame(savedGame);
        }

        private List<Card> BuildCardListFromSavedGame(SaveGame saveGame)
        {
            var cards = new Cards();
            return saveGame.CardNames.Select(name => cards.Where(x => x.Name == name).FirstOrDefault()).ToList();
        }

    }
}
