namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;
    using System.Linq;

    public class DominionGames : List<Game>
    {
        public DominionGames()
        {
            this.Add(new FirstGame());

        }
    }

    internal class FirstGame : Game
    {
        public FirstGame()
        {
            Id = 1;
            Name = "First Game";
            Description = "Great first game";

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
}