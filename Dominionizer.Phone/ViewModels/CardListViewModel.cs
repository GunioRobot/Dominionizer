using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using Dominionizer.Messages;
using Dominionizer.Models;
using Dominionizer.Phone.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Dominionizer.ViewModels
{
    public class CardListViewModel : ViewModelBase
    {
        [XmlIgnore]
        public RelayCommand GenerateCardList { get; private set; }

        [XmlIgnore]
        public RelayCommand<Card> SwapCardCommand { get; private set; }

        private GameGeneratorParameters _parameters;
        private GameGenerator _generator = new GameGenerator();

        public CardListViewModel()
        {
            // set up commands
            GenerateCardList = new RelayCommand(() => GenerateCardListForSettings());
            SwapCardCommand = new RelayCommand<Card>((card) => SwapCard(card));

            // register for messages
            Messenger.Default.Register<SettingsLoadedMessage>(this, (message) => _parameters = message.Parameters);
            Messenger.Default.Register<SettingsSavedMessage>(this, (message) =>
            {
                _parameters = message.Parameters;
                GenerateCardListForSettings();
            });
            Messenger.Default.Register<GenerateCardListMessage>(this, (message) => GenerateCardListForSettings());
            Messenger.Default.Register<SwapCardMessage>(this, (message) => SwapCard(message.SelectedCard));
            Messenger.Default.Register<SortCardListMessage>(this, (message) => SortCards());
        }

        private void SwapCard(Card card)
        {
            if (!Cards.Contains(card))
                return;
            var location = Cards.IndexOf(card);
            Cards.Remove(card);
            var newCard = _generator.GetReplacementCard(Cards, _parameters);
            Cards.Insert(location, newCard);
            SortCards();
        }

        private void GenerateCardListForSettings()
        {
            var cards = _generator.GetGameCards(_parameters);
            Cards.Clear();
            foreach (var item in cards)
            {
                Cards.Add(item);
            }
            SortCards();
        }

        private void SortCards()
        {
            if (SelectedSortStrategy == null)
                SelectedSortStrategy = _sortStrategies[0];

            if (SelectedSortStrategy.SortField == "Name")
            {
                Cards = new ObservableCollection<Card>(Cards.OrderBy(c => c.Name));
            }
            else if (SelectedSortStrategy.SortField == "Cost")
            {
                Cards = new ObservableCollection<Card>(Cards.OrderBy(c => c.Cost));
            }
            else if (SelectedSortStrategy.SortField == "Set")
            {
                Cards = new ObservableCollection<Card>(Cards.OrderBy(c => c.Set));
            }
        }

        #region SortStrategies property

        private SortStrategy[] _sortStrategies = new SortStrategy[]
        {
            new SortStrategy() { DisplayIndex = 0, SortField="Name" },
            new SortStrategy() { DisplayIndex = 1, SortField="Cost" },
            new SortStrategy() { DisplayIndex = 2, SortField="Set" },
        };

        [XmlIgnore]
        public IEnumerable<SortStrategy> SortStrategies
        {
            get { return _sortStrategies; }
        }

        #endregion SortStrategies property

        #region SelectedSortStrategy property

        private SortStrategy _SelectedSortStrategy;

        public SortStrategy SelectedSortStrategy
        {
            get { return _SelectedSortStrategy; }
            set
            {
                _SelectedSortStrategy = value;
                RaisePropertyChanged(() => this.SelectedSortStrategy);
            }
        }

        #endregion SelectedSortStrategy property

        #region SelectedCard property

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
                _selectedCard = value;
                RaisePropertyChanged(() => SelectedCard);
            }
        }

        #endregion SelectedCard property

        #region Cards property

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

                _cards = value;
                RaisePropertyChanged(() => Cards);
            }
        }

        #endregion Cards property
    }
}