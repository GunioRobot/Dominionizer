using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Dominionizer.Phone.Core
{
    public class GameGenerator
    {
        Random numberGenerator = new Random();
        private CardComparer _cardComparer = new CardComparer();

        public List<Card> GetGameCards(GameGeneratorParameters gameGeneratorParameters)
        {
            var parameters = gameGeneratorParameters;

            var gameCards = new List<Card>();
            var remainingCards = 10;

            var availableCards = GetAvailableCards(parameters);
            if (availableCards.Count == 0)
                return gameCards;

            if (parameters.FindRule("RequireTwoToFiveCostCards").IsSet)
            {
                var twoToFiveCostCards = GetTwoToFiveCostCards(availableCards);
                gameCards.AddRange(twoToFiveCostCards);
                RemoveFromAvailableCards(availableCards, twoToFiveCostCards);
                remainingCards = remainingCards - twoToFiveCostCards.Count();
            }

            var nextCards = GetRandomCards(availableCards, remainingCards - 1);
            gameCards.AddRange(nextCards);

            gameCards.Add(GetLastCard(availableCards, gameCards, parameters));

            return gameCards;
        }

        private Card GetLastCard(List<Card> availableCards, IEnumerable<Card> gameCards, GameGeneratorParameters parameters)
        {
            Card lastCard;
            int reactionCardCount = availableCards.Where(x => x.Type == CardType.Reaction).Count();

            if (parameters.FindRule("RequireReactionToAttack").IsSet && reactionCardCount != 0)
                lastCard = GetReactionCard(availableCards, gameCards);
            else
                lastCard = GetRandomCardFromList(availableCards);

            return lastCard;
        }

        private Card GetReactionCard(List<Card> availableCards, IEnumerable<Card> gameCards)
        {
            var attackCardCount = gameCards.Where(x => x.Type == CardType.Attack).Count();
            var reactionCardCount = gameCards.Where(x => x.Type == CardType.Reaction).Count();

            var nonAttackCards = availableCards.Where(x => x.Type != CardType.Attack);
            var reactionCards = availableCards.Where(x => x.Type == CardType.Reaction);

            if ((attackCardCount > 0 && reactionCardCount > 0) || (attackCardCount == 0))
                return GetRandomCardFromList(nonAttackCards);

            return GetRandomCardFromList(reactionCards);
        }

        private void RemoveFromAvailableCards(List<Card> availableCards, Card card)
        {
            RemoveFromAvailableCards(availableCards, new Card[] { card });
        }

        // TODO: Jay - something is wrong here. I tried adding _cardComparer, but that didn't fix it. Somehow, removals are not happening...
        private void RemoveFromAvailableCards(List<Card> availableCards, IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                if (availableCards.Contains(card, _cardComparer))
                    availableCards.Remove(card);
            }
        }

        private IEnumerable<Card> GetTwoToFiveCostCards(List<Card> availableCards)
        {
            var twoCostCards = availableCards.Where(x => x.Cost == 2).ToList();
            var threeCostCards = availableCards.Where(x => x.Cost == 3).ToList();
            var fourCostCards = availableCards.Where(x => x.Cost == 4).ToList();
            var fiveCostCards = availableCards.Where(x => x.Cost == 5).ToList();

            var cards = new List<Card>();

            if (twoCostCards.Count() > 0) cards.Add(GetRandomCardFromList(twoCostCards));
            cards.Add(GetRandomCardFromList(threeCostCards));
            cards.Add(GetRandomCardFromList(fourCostCards));
            cards.Add(GetRandomCardFromList(fiveCostCards));

            return cards;
        }

        private Card GetRandomCardFromList(IEnumerable<Card> availableCards)
        {
            var index = numberGenerator.Next(0, availableCards.Count());

            return availableCards.ElementAt(index);
        }

        private IEnumerable<Card> GetRandomCards(List<Card> availableCards, int numberOfCards)
        {
            return GetRandomCardsFromList(availableCards, numberOfCards);
        }

        private IEnumerable<Card> GetRandomCardsFromList(List<Card> availableCards, int remainingCards)
        {
            var cards = new List<Card>();

            for (var i = 0; i < remainingCards; i++)
            {
                var card = GetRandomCardFromList(availableCards);
                cards.Add(card);
                RemoveFromAvailableCards(availableCards, card);
            }

            return cards;
        }

        private List<Card> GetAvailableCards(GameGeneratorParameters parameters)
        {
            var cards = new Cards();
            var availableCards = new List<Card>();

            // Regular Sets
            if (parameters.FindSet("Alchemy").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Alchemy));
            if (parameters.FindSet("Dominion").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Dominion));
            if (parameters.FindSet("Intrigue").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Intrigue));
            if (parameters.FindSet("Prosperity").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Prosperity));
            if (parameters.FindSet("Seaside").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Seaside));
            if (parameters.FindSet("Cornucopia").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Cornucopia));

            // Promo Cards
            if (parameters.FindSet("BlackMarket").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.BlackMarket));
            if (parameters.FindSet("Envoy").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Envoy));
            if (parameters.FindSet("Stash").IsSet) availableCards.AddRange(cards.Where(x => x.Set == CardSet.Stash));

            return availableCards;
        }

        public Card GetReplacementCard(IEnumerable<Card> cards, GameGeneratorParameters parameters)
        {
            // TODO: Need to figure out how to keep track of previosly selected cards

            // get the set of available cards for current parameters
            var availableCards = this.GetAvailableCards(parameters);

            // remove the cards already in the selected deck
            RemoveFromAvailableCards(availableCards, cards);

            // retrieve a card
            var newCard = this.GetRandomCardFromList(availableCards);
            var duplicates = cards.Where(c => c.Id == newCard.Id);
            while (duplicates.Count() > 0)
            {
                newCard = this.GetRandomCardFromList(availableCards);
                duplicates = cards.Where(c => c.Id == newCard.Id);
            }
            return newCard;
        }
    }

    public class CardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Card obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class GameGeneratorParameters
    {
        [XmlIgnore]
        private List<GameGeneratorSet> _Sets = new List<GameGeneratorSet>();

        public List<GameGeneratorSet> Sets
        {
            get
            {
                return _Sets;
            }
            set
            {
                _Sets = value;
            }
        }

        [XmlIgnore]
        private List<GameGeneratorRule> _Rules = new List<GameGeneratorRule>();

        public List<GameGeneratorRule> Rules
        {
            get
            {
                return _Rules;
            }
            set
            {
                _Rules = value;
            }
        }

        public GameGeneratorSet FindSet(string setKey)
        {
            return Sets.Where(set => set.Key == setKey).First();
        }

        public GameGeneratorRule FindRule(string ruleKey)
        {
            return Rules.Where(rule => rule.Key == ruleKey).First();
        }

        //TODO: Can we use the CardSet class here, it is an enum of all available cardsets?  Exampe Set = CardSet.Dominion
        public static GameGeneratorParameters GetInstance()
        {
            var parms = new GameGeneratorParameters();

            var cardSets = Enum<CardSet>.GetNames();

            foreach (var cardSet in cardSets)
            {
                parms.Sets.Add(new GameGeneratorSet() { Key = cardSet, Name = cardSet, IsSet = (cardSet == "Dominion") });
            }

            //parms.Sets.Add(new GameGeneratorSet() { Key = "Dominion", Name = "Dominion", IsSet = true });
            //parms.Sets.Add(new GameGeneratorSet() { Key = "Intrigue", Name = "Intrigue", IsSet = false });
            //parms.Sets.Add(new GameGeneratorSet() { Key = "Seaside", Name = "Seaside", IsSet = false });
            //parms.Sets.Add(new GameGeneratorSet() { Key = "Alchemy", Name = "Alchemy", IsSet = false });
            //parms.Sets.Add(new GameGeneratorSet() { Key = "Prosperity", Name = "Prosperity", IsSet = false });
            //parms.Sets.Add(new GameGeneratorSet() { Key = "Cornucopia", Name = "Cornucopia", IsSet = false });
            
            parms.Sets.Add(new GameGeneratorSet() { Key = "BlackMarket", Name = "Black Market", IsSet = false });
            parms.Sets.Add(new GameGeneratorSet() { Key = "Envoy", Name = "Envoy", IsSet = false });
            parms.Sets.Add(new GameGeneratorSet() { Key = "Stash", Name = "Stash", IsSet = false });
            
            parms.Rules.Add(new GameGeneratorRule() { Key = "RequireTwoToFiveCostCards", Name = "Require Two To Five Cost Cards", IsSet = false });
            parms.Rules.Add(new GameGeneratorRule() { Key = "RequireReactionToAttack", Name = "Require Reaction To Attack", IsSet = false });
            return parms;
        }
    }

    public abstract class GameGeneratorParameter
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public bool IsSet { get; set; }
    }

    public class GameGeneratorSet : GameGeneratorParameter
    {
    }

    public class GameGeneratorRule : GameGeneratorParameter
    {
        public string Description { get; set; }
    }
}