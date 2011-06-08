namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;
    using System.Linq;

    public class DominionGames : List<Game>
    {
        public DominionGames()
        {
            this.Add(new FirstGame());
            this.Add(new BigMoney());
            this.Add(new Interaction());
            this.Add(new SizeDistortion());
            this.Add(new VillageSquare());
        }
    }

    internal class FirstGame : Game
    {
        public FirstGame()
        {
            Id = 1;
            Name = "First Game";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Cellar").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Market").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Militia").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Mine").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Moat").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Remodel").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Smithy").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Village").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Woodcutter").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Workshop").First().Id);
        }
    }

    internal class BigMoney : Game 
    {
        public BigMoney()
        {
            Id = 2;
            Name = "Big Money";

            var cards = new Cards();
            this.Cards.Add(cards.Where(x => x.Name == "Adventurer").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Bureaucrat").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Chancellor").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Chapel").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Feast").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Labratory").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Market").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Mine").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Moneylender").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Throne Room").First().Id);
        }
    }

    internal class Interaction : Game
    {
        public Interaction()
        {
            Id = 3;
            Name = "Interaction";

            var cards = new Cards();
            this.Cards.Add(cards.Where(x => x.Name == "Bureaucrat").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Chancellor").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Council Room").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Festival").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Library").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Militia").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Moat").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Spy").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Thief").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Village").First().Id);

        }
    }

    internal class SizeDistortion : Game
    {
        public SizeDistortion()
        {
            Id = 4;
            Name = "Size Distortion";

            var cards = new Cards();
            this.Cards.Add(cards.Where(x => x.Name == "Cellar").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Chapel").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Feast").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Gardens").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Laboratory").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Thief").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Village").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Witch").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Woodcutter").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Workshop").First().Id);
        }
    }

    internal class VillageSquare : Game
    {
        public VillageSquare()
        {
            Id = 4;
            Name = "Village Square";

            var cards = new Cards();
            this.Cards.Add(cards.Where(x => x.Name == "Bureaucrat").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Cellar").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Festival").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Library").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Market").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Remodel").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Smithy").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Throne Room").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Village").First().Id);
            this.Cards.Add(cards.Where(x => x.Name == "Woodcutter").First().Id);
        }
    }
}