using System;
using Dominionizer.Messages;
using Dominionizer.ViewModels;
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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //TODO: Add some code here to make sure we're saving changes before leaving unexpectedly
            base.OnBackKeyPress(e);
        }
    }
}