﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Dominionizer;
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

        private void ViewCardMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (CardsListBox.SelectedItem == null)
            {
                Debug.WriteLine("Null card selected");
                return;
            }
            HideCardsList();
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point tmpPoint = e.GetPosition(null);
            List<UIElement> oControls = (List<UIElement>)VisualTreeHelper.FindElementsInHostCoordinates(tmpPoint, this);
            foreach (UIElement ctrl in oControls)
            {
                if (ctrl is ListBoxItem)
                {
                    var control = (ListBoxItem)ctrl;
                    CardsListBox.SelectedItem = control.Content;
                    break;
                }
                Debug.WriteLine("No item found!");
            }
        }
    }
}