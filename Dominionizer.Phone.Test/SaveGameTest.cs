namespace Dominionizer.Phone.Test
{
    using System.Collections.Generic;

    using Dominionizer.Phone.Core.SaveGames;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SaveGameTest
    {
        // Retrieve list of available built in saved games
        [TestMethod]
        public void CanRetrieveAListOfBuiltInGames()
        {
            var builtInGames = new SaveGameManager(new MockSaveGameRepository()).AvailableBuiltInGamesNames();

            Assert.AreEqual(11, builtInGames.Count);
        }

        // Retrieve list of available user saved games
        [TestMethod]
        public void CanRetrieveAListOfCardsFromGameName()
        {
            var savedGames = new SaveGameManager(new MockSaveGameRepository());
            var cards = savedGames.GetCardsForSavedGame("First Game");

            Assert.AreEqual(10, cards.Count);
        }

        // Create and save new user defined game
        [TestMethod]
        public void SaveAndCreateUserDefinedGame()
        {
            var newSavedGame = new SaveGame();

            newSavedGame.Name = "New Saved Game";
            newSavedGame.Source = SavedGameSource.UserDefined;
            newSavedGame.CardNames = new List<string>
                {
                    "Bridge",
                    "Duke",
                    "Great Hall",
                    "Harem",
                    "Ironworks",
                    "Masquerade",
                    "Nobles",
                    "Pawn",
                    "Scout",
                    "Upgrade"
                };

            var savedGames = new SaveGameManager(new MockSaveGameRepository());
            savedGames.Save(newSavedGame);
        }
    }
}