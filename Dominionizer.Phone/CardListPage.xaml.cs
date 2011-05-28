using System.Windows;
using Dominionizer.Messages;
using Dominionizer.Phone.Core;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Input.Touch;

namespace DominionKingdomDeck
{
    public partial class CardListPage : PhoneApplicationPage
    {
        public CardListPage()
        {
            InitializeComponent();
            TouchPanel.EnabledGestures = GestureType.Flick | GestureType.DoubleTap;
        }

        private void Grid_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample sample = TouchPanel.ReadGesture();
                if (sample.GestureType == GestureType.Flick || sample.GestureType == GestureType.DoubleTap)
                {
                    // determine the item over which a gesture was recorded
                    var sourceObject = e.OriginalSource as FrameworkElement;
                    var card = sourceObject.DataContext as Card;
                    Messenger.Default.Send<SwapCardMessage>(new SwapCardMessage(card));
                    AnimateRemove(sourceObject);
                }
            }
        }

        private void AnimateRemove(FrameworkElement sourceObject)
        {
            // do some kind of animation to make this framework element go away in a pretty way
        }

        private void RefreshButton_Click(object sender, System.EventArgs e)
        {
            Messenger.Default.Send<GenerateCardListMessage>(new GenerateCardListMessage());
        }
    }
}