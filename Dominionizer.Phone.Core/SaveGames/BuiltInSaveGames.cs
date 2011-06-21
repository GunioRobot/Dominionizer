namespace Dominionizer.Phone.Core.SaveGames
{
    using System;
    using System.Collections.Generic;

    public class BuiltInSaveGames
    {
        public Dictionary<string, string> Games { get; set; }

        public BuiltInSaveGames()
        {
            Games = new Dictionary<string, string>();

            this.LoadDominionGames();
            this.LoadIntrigueGames();
            this.LoadSeasideGames();
            this.LoadAlchemyGames();
            this.LoadProsperityGames();
            // this.LoadCornucopiaGames();
        }
        
        private void LoadDominionGames()
        {
            Games.Add("First Game", "Cellar,Market,Militia,Mine,Moat,Remodel,Smithy,Village,Woodcutter,Workshop");
            Games.Add("Big Money", "Adventurer,Bureaucrat,Chancellor,Chapel,Feast,Labratory,Market,Mine,Moneylender,Throne Room");
            Games.Add("Interaction", "Bureaucrat,Chancellor,Council Room,Festival,Library,Militia,Moat,Spy,Thief,Village");
            Games.Add("Size Distortion", "Cellar,Chapel,Feast,Gardens,Laboratory,Thief,Village,Witch,Woodcutter,Workshop");
            Games.Add("Village Square", "Bureaucrat,Cellar,Festival,Market,Remodel,Smithy,Throne Room,Village,Woodcutter");
        }

        private void LoadIntrigueGames()
        {
            // Intrigue 
            Games.Add("Victry Dance", "Bridge,Duke,Great Hall,Harem,Ironworks,Masquerade,Nobles,Pawn,Scout,Upgrade");
            Games.Add("Secret Schemes", "Consirator,Harem,Ironworks,Pawn,Saboteur,Shanty Town,Steward,Swindler,Trading Post,Tribute");
            Games.Add("Best Wishes", "Coopersmith,Courtyard,Masquerade,Scout,Shanty Town,Steward,Torturer,Trading Post, Upgrade, Wishing Well");

            // Intrigue and Dominion
            Games.Add("Deconstruction", "Bridge,Mining Village,Remodel,Saboteur,Secret Chamber,Spy,Swinder,Thief,Throne Room,Torturer");
            Games.Add("Hand Madness", "Bureaucrate,Chancellor,Council Room,Courtyard,Mine,Militia,Minion,Nobles,Steward,Torturer");
            Games.Add("Underlings", "Baron,Cellar,Festival,Library,Masquerade,Minion,Nobles,Pawn,Steward,Witch");
        }

        private void LoadSeasideGames()
        {
            // Seaside
            Games.Add("High Seas", "Bazaar,Caravan,Embargo,Explorer,Haven,Island,Lookout,Pirate Ship,Smugglers,Wharf");
            Games.Add("Buried Treasure", "Ambassador,Cutpurse,Fishing Village,Lighthouse,Outpost,Pearl Diver,Tactician,Treasure Map,Warehouse,Wharf");
            Games.Add("Shipwrecks", "Ghost Ship,Merchant Ship,Native Village,Navigator, Pearl Diver,Salvager,Sea Hag,Smugglers,Treasury,Warehouse");

            // Seaside and Dominion
            Games.Add("Rich for Tomorrow", "Adventurer,Cellar,Council Room,Cutpurse,Ghost Ship,Lookout,Sea Hag,Spy,Treasure Map, Village");
            Games.Add("Reptition", "Caravan,Chancellor,Explorer,Festival,Militia,Outpust,Pearl Diver,Pirate Ship,Treasury,Workshop");
            Games.Add("Give and Take", "Ambassador,Fishing Village,Haven,Island,Library,Market,Moneylender,Salvager,Smugglers,Witch");

        }

        private void LoadAlchemyGames()
        {
            // Alchemy and Diminion
            Games.Add("Forbidden Arts", "Apprentice,Familiar,Possession,University,Cellar,Council Room,Gardens,Laboratory,Thief,Throne Room");
            Games.Add("Potion Mixers", "Alchemist,Apothecary,Golem,Herbalist,Transmute,Cellar,Chancellor,Festival,Miitia,Smithy");
            Games.Add("Chemistry Lesson", "Alchemist,Golem,Philosopher's Stone,University,Bureaucrate,Market,Moat,Remodel,Witch,Woodcutter");

            // Alcheme and Intrigue
            Games.Add("Servants", "Golem,Possession,Scrying Pool,Transmute,Vinyard,Conspirator,Great Hall,Minion,Pawn,Steward");
            Games.Add("Secret Research", "Familiar,Herbalist,Philosopher's Stone,University,Bridge,Masquerade,Minion,Nobles,Shanty Town,Torturer");
            Games.Add("Pools, Tool's, and Fools", "Aotherecary,Apprentice,Golem,Scrying Pool,Baron,Coppersmith,Ironworks,Nobles,Trading Post,Wishing Well");
        }

        private void LoadProsperityGames()
        {
            // Prosperity Only
            Games.Add("Beginners", "Bank,Counting House,Expand,Goons,Monument,Rabble,Royal Seal,Venture,Watchtower,Worker's Village");
            Games.Add("Friendly Interactive", "Bishop,City,Contraband,Forge,Hoard,Peddler,Royal Seal,Trade Route,Vault,Worker's Village");
            Games.Add("Big Actions", "City,Expand,Grand Market,King's Court,Loan,Mint,Quarry,Rabble,Talisman,Vault");

            // Prosperity and Dominion
            Games.Add("Biggest Money", "Bank,Grand Market,Mint,Royal Seal,Venture,Adventurer,Laboratory,Mine,Moneylender,Spy");
            Games.Add("The King's Army", "Expand,Goons,King's Court,Rabble,Vault,Bureaucrat,Council Room,Moat,Spy,Village");
            Games.Add("The Good Life", "Contraband,Counting House,Hoard,Monument,Mountebank,Bureaucrat,Cellar,Chancellor,Gardens,Village");

            // Prosperity and Intrigue
            Games.Add("Paths to Victory", "Bishop,Counting House,Goons,Monument,Peddler,Baron,Harem,Pawn,Shanty Town,Upgrade");
            Games.Add("All Along the Watchtower ", "Hoard,Talisman,Trade Route,Vault,Watchtower,Bridge,Great Hall,Mining Village,Pawn Torturer");
            Games.Add("Lucky Seven", "Bank,Expand,Forge,King's Court,Vault,Bridge,Coopersmith,Swindler,Tribute,Wishing Well");
        }

        private void LoadCornucopiaGames()
        {
            Games.Add("", "");
        }


    }
}