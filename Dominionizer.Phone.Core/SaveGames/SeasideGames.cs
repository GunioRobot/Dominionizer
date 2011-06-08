namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;
    using System.Linq;

    public class SeasideGames : List<Game>
    {
        public SeasideGames()
        {
            this.Add(new HighSeas());
            this.Add(new BuriedTreasure());
            this.Add(new Shipwrecks());

            this.Add(new ReachForTomorrow());
            this.Add(new Repetition());
            this.Add(new GiveAndTake());
        }
    }

    internal class HighSeas : Game
    {
        public HighSeas()
        {
            Id = 10;
            Name = "High Seas";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Bazaar").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Caravan").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Embargo").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Explorer").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Haven").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Island").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Lookout").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pirate Ship").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Smugglers").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Wharf").First().Id);
        }
    }

    internal class BuriedTreasure : Game
    {
        public BuriedTreasure()
        {
            Id = 11;
            Name = "Buried Treasure";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Ambassador").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Cutpurse").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Fishing Village").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Lighthouse").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Outpost").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pearl Diver").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Tactician").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Treasure Map").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Wharehouse").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Wharf").First().Id);
        }
    }

    internal class Shipwrecks : Game
    {
        public Shipwrecks()
        {
            Id = 12;
            Name = "Shipwrecks";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Ghost Ship").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Merchant Ship").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Native Village").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Navigator").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pearl Diver").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Salvager").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Sea Hag").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Smugglers").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Treasury").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Wharehouse").First().Id);
        }
    }

    internal class ReachForTomorrow : Game
    {
        public ReachForTomorrow()
        {
            Id = 13;
            Name = "Reach for Tomorrow";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Adventurer").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Cellar").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Council Room").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Cutpurse").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Ghost Ship").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Lookout").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Sea Hag").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Spy").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Trasure Map").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Village").First().Id);
        }
    }

    internal class Repetition : Game
    {
        public Repetition()
        {
            Id = 14;
            Name = "Repetition";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Caravan").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Chancellor").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Explorer").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Festival").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Militia").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Outpost").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pearl Diver").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pirate Ship").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Treasurey").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Workshop").First().Id);
        }
    }

    internal class GiveAndTake : Game
    {
        public GiveAndTake()
        {
            Id = 15;
            Name = "Give and Take";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Ambassador").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Fishing Village").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Haven").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Island").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Library").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Market").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Moneylender").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Salvager").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Smugglers").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Witch").First().Id);
        }
    }
}