using Dominionizer.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Dominionizer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand GenerateCardList { get; private set; }

        public MainViewModel()
        {
            GenerateCardList = new RelayCommand(() =>
            {
                Messenger.Default.Send<GenerateCardListMessage>(new GenerateCardListMessage());
            });
        }
    }
}