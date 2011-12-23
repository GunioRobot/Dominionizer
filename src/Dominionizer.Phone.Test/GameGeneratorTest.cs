namespace Dominionizer.Phone.Test
{
    using System.Linq;
    using Dominionizer.Phone.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameGeneratorTest
    {
        [TestMethod]
        public void Pick10RandomCardsWithNoRules()
        {
            var game = new GameGenerator();
            var parameters = (GameGeneratorParameters.GetInstance());
            parameters.FindSet("Dominion").IsSet = true;
            parameters.FindSet("Intrigue").IsSet = true;

            var cards = game.GetGameCards(parameters);

            Assert.AreEqual(10, cards.Count);
        }

        [TestMethod]
        public void Pick10RandomCardsThatRequiresTwoToFiveCostCards()
        {
            var game = new GameGenerator();
            var parameters = GameGeneratorParameters.GetInstance();
            parameters.FindSet("Dominion").IsSet = true;
            parameters.FindRule("RequireTwoToFiveCostCards").IsSet = true;

            var cards = game.GetGameCards(parameters);

            Assert.IsTrue(cards.Where(x => x.Cost == 2).Count() >= 1);
            Assert.IsTrue(cards.Where(x => x.Cost == 3).Count() >= 1);
            Assert.IsTrue(cards.Where(x => x.Cost == 4).Count() >= 1);
            Assert.IsTrue(cards.Where(x => x.Cost == 5).Count() >= 1);
        }

        [TestMethod]
        public void Pick10RandomCardsThatRequireAReactionCardIfAttackCardPresent()
        {
            var game = new GameGenerator();
            var parameters = GameGeneratorParameters.GetInstance();
            parameters.FindSet("Dominion").IsSet = true;
            parameters.FindRule("RequireReactionToAttack").IsSet = true;

            var cards = game.GetGameCards(parameters);

            if (cards.Where(x => x.Type == CardType.Attack).Count() > 0)
                Assert.IsTrue(cards.Where(x => x.Type == CardType.Reaction).Count() > 0);
            else
                Assert.IsTrue(cards.Where(x => x.Type == CardType.Attack).Count() == 0);
        }

        [TestMethod]
        public void Pick10RandomCardsWithTwoToFiveCostAndRequireReactionIfAttackCardPresent()
        {
            var game = new GameGenerator();
            var parameters = GameGeneratorParameters.GetInstance();
            parameters.FindSet("Dominion").IsSet = true;
            parameters.FindRule("RequireTwoToFiveCostCards").IsSet = true;
            parameters.FindRule("RequireReactionToAttack").IsSet = true;

            var cards = game.GetGameCards(parameters);

            if (cards.Where(x => x.Type == CardType.Attack).Count() > 0)
                Assert.IsTrue(cards.Where(x => x.Type == CardType.Reaction).Count() > 0);
            else
                Assert.IsTrue(cards.Where(x => x.Type == CardType.Attack).Count() == 0);

            Assert.IsTrue(cards.Where(x => x.Cost == 2).Count() >= 1);
            Assert.IsTrue(cards.Where(x => x.Cost == 3).Count() >= 1);
            Assert.IsTrue(cards.Where(x => x.Cost == 4).Count() >= 1);
            Assert.IsTrue(cards.Where(x => x.Cost == 5).Count() >= 1);
        }
    }
}