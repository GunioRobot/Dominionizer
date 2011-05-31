using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dominionizer.Phone.Test
{
    using Dominionizer.Phone.Core;

    [TestClass]
    public class CardTest
    {
        private readonly Card card1 = new Card(1, CardSet.Dominion, "TestCard", 0, 0, CardType.Action);
        private readonly Card card2 = new Card(1, CardSet.Dominion, "TestCard", 0, 0, CardType.Action);
        private readonly Card card3 = new Card(3, CardSet.Dominion, "TestCard", 0, 0, CardType.Action);
        
        [TestMethod]
        public void TwoCardsAreTheSame()
        {
            Assert.IsTrue(card1 == card2);
            Assert.AreEqual(card1, card2);
        }

        [TestMethod]
        public void TwoCardsAreNotTheSame()
        {
            Assert.IsTrue(card1 != card3);
            Assert.AreNotEqual(card1, card3);
        }
    }
}
