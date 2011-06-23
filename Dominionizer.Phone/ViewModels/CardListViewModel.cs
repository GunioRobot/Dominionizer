using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using Dominionizer.Messages;
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
        }

        private void SwapCard(Card card)
        {
            if (!Cards.Contains(card))
                return;
            var location = Cards.IndexOf(card);
            Cards.Remove(card);
            var newCard = _generator.GetReplacementCard(Cards, _parameters);
            Cards.Insert(location, newCard);
        }

        private void GenerateCardListForSettings()
        {
            ShowInstructions = Visibility.Collapsed;
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

        /// <summary>
        /// The <see cref="ShowInstructions" /> property's name.
        /// </summary>
        public const string ShowInstructionsPropertyName = "ShowInstructions";

        private Visibility _showInstructions = Visibility.Visible;

        /// <summary>
        /// Gets the ShowInstructions property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event.
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public Visibility ShowInstructions
        {
            get
            {
                return _showInstructions;
            }

            set
            {
                if (_showInstructions == value)
                {
                    return;
                }

                _showInstructions = value;
                RaisePropertyChanged(ShowInstructionsPropertyName);
            }
        }
    }
}