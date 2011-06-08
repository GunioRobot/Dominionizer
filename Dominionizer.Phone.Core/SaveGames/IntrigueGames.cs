namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntrigueGames : List<Game>
    {
        public IntrigueGames()
        {
            this.Add(new VictoryDance());
            this.Add(new SecretSchemes());
            this.Add(new BestWishes());
            
            this.Add(new Deconstruction());
            this.Add(new HandMadness());
            this.Add(new Underlings());
        }
    }

    internal class VictoryDance : Game
    {
        public VictoryDance()
        {
            Id = 5;
            Name = "Victry Dance";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Bridge").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Duke").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Great Hall").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Harem").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Ironworks").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Masquerade").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Nobles").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pawn").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Scout").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Upgrade").First().Id);
        }
    }

    internal class SecretSchemes : Game
    {
        public SecretSchemes()
        {
            Id = 6;
            Name = "Secret Schemes";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Consirator").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Harem").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Ironworks").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pawn").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Saboteur").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Shanty Town").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Steward").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Swindler").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Trading Post").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Tribute").First().Id);
        }
    }

    internal class BestWishes : Game
    {
        public BestWishes()
        {
            Id = 7;
            Name = "Best Wishes";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Coppersmith").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Courtyard").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Masquerade").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Scout").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Shanty Town").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Steward").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Torturer").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Trading Post").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Upgrade").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Wishing Well").First().Id);
        }
    }

    internal class Deconstruction : Game
    {
        public Deconstruction()
        {
            Id = 8;
            Name = "Deconstruction";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Bridge").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Mining Village").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Remodel").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Saboteur").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Secret Chamber").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Spy").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Swindler").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Thief").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Throne Room").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Torturer").First().Id);
        }
    }

    internal class HandMadness : Game
    {
        public HandMadness()
        {
            Id = 9;
            Name = "Hand Madness";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Bureaucreat").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Chancellor").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Council Room").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Courtyard").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Mine").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Militia").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Minion").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Nobles").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Steward").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Torturer").First().Id);
        }
    }

    internal class Underlings : Game
    {
        public Underlings()
        {
            Id = 10;
            Name = "Underlings";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Baron").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Cellar").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Festival").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Library").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Masquerade").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Minion").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Nobles").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pawn").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Steward").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Witch").First().Id);
        }
    }

}