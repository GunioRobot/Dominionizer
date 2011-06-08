namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;
    using System.Linq;

    public class AlchemyGames : List<Game>
    {
        public AlchemyGames()
        {
            this.Add(new ForbiddenArts());
            this.Add(new PotionMixers());
            this.Add(new ChemistryLesson());

            this.Add(new Servants());
            // this.Add(new SecretResearch());
            // this.Add(new PoolsToolAndFools());
        }
    }

    internal class ForbiddenArts : Game
    {
        public ForbiddenArts()
        {
            Id = 16;
            Name = "Forbidden Arts";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Apprentice").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Familiar").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Possesion").First().Id);
            Cards.Add(cards.Where(x => x.Name == "University").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Cellar").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Council Room").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Gardens").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Laboratory").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Thief").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Throne Room").First().Id);
        }
    }

    internal class PotionMixers : Game
    {
        public PotionMixers()
        {
            Id = 17;
            Name = "Potion Mixers";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Alchemist").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Apothecary").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Golem").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Herbalist").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Transmute").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Cellar").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Chancellor").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Festival").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Militia").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Smithy").First().Id);

        }
    }

    internal class ChemistryLesson : Game
    {
        public ChemistryLesson()
        {
            Id = 18;
            Name = "Chemistry Lesson";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Alchemist").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Golem").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Philosopher's Stone").First().Id);
            Cards.Add(cards.Where(x => x.Name == "University").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Bureaucrat").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Market").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Moat").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Remodel").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Witch").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Woodcutter").First().Id);

        }
    }

    internal class Servants : Game
    {
        public Servants()
        {
            Id = 19;
            Name = "Servants";

            var cards = new Cards();
            Cards.Add(cards.Where(x => x.Name == "Golem").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Possession").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Scrying Pool").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Transmute").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Vineyard").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Consirator").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Great Hall").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Minion").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Pawn").First().Id);
            Cards.Add(cards.Where(x => x.Name == "Steward").First().Id);

        }
    }
}