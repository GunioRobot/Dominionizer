﻿using System;
using Dominionizer.Messages;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace Dominionizer
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            Messenger.Default.Register<SettingsSavedMessage>(this, (message) =>
            {
                if (NavigationService.CanGoBack)
                    NavigationService.GoBack();
            });
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            Messenger.Default.Send<SaveSettingsMessage>(new SaveSettingsMessage());
            base.OnNavigatedFrom(e);
        }
    }
}