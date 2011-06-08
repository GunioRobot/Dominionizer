namespace Dominionizer.Phone.Core
{
    using System.Collections.Generic;

    using Dominionizer.Phone.Core.SaveGames;

    public class SavedGames
    {
        public List<Game> BuiltInGames { get; set; }

        public List<Game> UserDefinedGames { get; set; }

        public SavedGames()
        {
            LoadBuildInGames();

            LoadUesrDefinedGames();
        }

        private void LoadBuildInGames()
        {
            this.BuiltInGames.AddRange(new DominionGames());
            this.BuiltInGames.AddRange(new IntrigueGames());
            this.BuiltInGames.AddRange(new SeasideGames());
            this.BuiltInGames.AddRange(new AlchemyGames());

            // this.BuiltInGames.AddRange(new ProsperityGames());
            // this.BuiltInGames.AddRange(new CornucopiaGames());
        }

        private void LoadUesrDefinedGames()
        {
            // Search storage and build up a list of games and add them
            UserDefinedGames.Add(new Game { Id = 100, Name = "User Save Game" });
        }
    }
}