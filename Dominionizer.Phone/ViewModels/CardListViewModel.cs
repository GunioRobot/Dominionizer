using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using Dominionizer.Messages;
using Dominionizer.Phone.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Dominionizer.ViewModels
{
    using System;
    using System.Collections;
    using Dominionizer.Phone.Core;

    public class CardListViewModel : ViewModelBase
    {
        [XmlIgnore]
        public RelayCommand GenerateCardList { get; private set; }

        private GameGeneratorParameters _parameters;
        private GameGenerator _generator = new GameGenerator();

        public CardListViewModel()
        {
            // make sure we have the parameters loaded from IsolatedStorage before trying to calculate cards
            if (!IsInDesignMode)
                LoadGameParameters();

            SwapCardCommand = new RelayCommand<Card>((card) => SwapCard(card));

            // set up commands
            GenerateCardList = new RelayCommand(() =>
                {
                    GenerateCardListForSettings();
                });

            // register for messages
            Messenger.Default.Register<GenerateCardListMessage>(this, (message) =>
                {
                    GenerateCardListForSettings();
                });
            Messenger.Default.Register<SettingsSavedMessage>(this, (message) =>
                {
                    _parameters = message.Parameters;
                    GenerateCardListForSettings();
                });
            Messenger.Default.Register<SwapCardMessage>(this, (message) =>
            {
                SwapCard(message.SelectedCard);
            });
        }

        public RelayCommand<Card> SwapCardCommand { get; set; }

        private void SwapCard(Card card)
        {
            if (!Cards.Contains(card))
                return;
            var location = Cards.IndexOf(card);
            Cards.Remove(card);
            var newCard = _generator.GetReplacementCard(Cards, _parameters);
            Cards.Insert(location, newCard);
        }

        private void LoadGameParameters()
        {
            _parameters = StorageHelper.LoadGameParameters();
        }

        private void GenerateCardListForSettings()
        {
            var cards = _generator.GetGameCards(_parameters);
            Cards.Clear();
            foreach (var item in cards)
            {
                Cards.Add(item);
            }
        }

        #region SelectedCard property

        public const string SelectedCardPropertyName = "SelectedCard";
        private Card _selectedCard = null;

        public Card SelectedCard
        {
            get
            {
                return _selectedCard;
            }
            set
            {
                if (_selectedCard == value)
                {
                    return;
                }
                var oldValue = _selectedCard;
                _selectedCard = value;
                RaisePropertyChanged(SelectedCardPropertyName);
                if (value != null)
                {
                    // Messenger.Default.Send<CardSelectedMessage>(new CardSelectedMessage() { Card = SelectedCard });
                }
            }
        }

        #endregion SelectedCard property

        #region Cards property

        public const string CardsPropertyName = "Cards";

        private ObservableCollection<Card> _cards = new ObservableCollection<Card>();

        public ObservableCollection<Card> Cards
        {
            get
            {
                return _cards;
            }

            set
            {
                if (_cards == value)
                {
                    return;
                }

                var oldValue = _cards;
                _cards = value;
                RaisePropertyChanged(CardsPropertyName);
            }
        }

        #endregion Cards property
    }

    //public static class ListExtension
    //{
    //    public static void BubbleSort<T>(this IList o) where T : IComparable<T>
    //    {
    //        for (int i = o.Count - 1; i >= 0; i--)
    //        {
    //            for (int j = 1; j <= i; j++)
    //            {
    //                T o1 = (T)o[j - 1];
    //                T o2 = (T)o[j];
    //                if (o1.CompareTo(o2) > 0)
    //                {
    //                    o.Remove(o1);
    //                    o.Insert(j, o1);
    //                }
    //            }
    //        }
    //    }
    //}
}