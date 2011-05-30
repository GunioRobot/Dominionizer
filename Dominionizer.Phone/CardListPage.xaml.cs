using System;
using System.Diagnostics;
using System.Windows;
using Dominionizer.Messages;
using Dominionizer.Phone.Core;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace DominionKingdomDeck
{
    public partial class CardListPage : PhoneApplicationPage
    {
        public CardListPage()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ShowCardsList();
            NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        private void RefreshButton_Click(object sender, System.EventArgs e)
        {
            ShowCardsList();
            GenerateCardList();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GenerateCardList();
        }

        private void GenerateCardList()
        {
            Messenger.Default.Send<GenerateCardListMessage>(new GenerateCardListMessage());
        }

        private void CardsListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var card = CardsListBox.SelectedItem as Card;
            Debug.WriteLine(String.Format("/Images/Cards/{0}/{1}.jpg", card.Set, card.Name.Replace(" ", "").ToLower()));
            if (card == null)
                return;
            HideCardsList();
        }

        private void CardImageButton_Click(object sender, RoutedEventArgs e)
        {
            ShowCardsList();
        }

        private void HideCardsList()
        {
            CardImageButton.Visibility = Visibility.Visible;
            CardsListDisplayArea.Visibility = Visibility.Collapsed;
        }

        private void ShowCardsList()
        {
            CardsListDisplayArea.Visibility = Visibility.Visible;
            CardImageButton.Visibility = Visibility.Collapsed;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (CardsListDisplayArea.Visibility == Visibility.Collapsed)
            {
                ShowCardsList();
                e.Cancel = true;
            }
            else
            {
                base.OnBackKeyPress(e);
            }
        }
    }
}