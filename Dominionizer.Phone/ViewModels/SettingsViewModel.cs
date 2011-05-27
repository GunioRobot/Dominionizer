using Dominionizer.Phone.Core;
using Dominionizer.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Dominionizer.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public RelayCommand SaveSettingsCommand { get; private set; }

        public RelayCommand LoadSettingsCommand { get; private set; }

        public RelayCommand ResetSettingsCommand { get; private set; }

        public SettingsViewModel()
        {
            LoadSettingsCommand = new RelayCommand(() => this.LoadSettings());
            ResetSettingsCommand = new RelayCommand(() => this.LoadSettings());
            SaveSettingsCommand = new RelayCommand(() => this.SaveSettings());
            if (!IsInDesignMode)
                LoadSettings();
        }

        private void LoadSettings()
        {
            Parameters = StorageHelper.LoadGameParameters();
        }

        private void SaveSettings()
        {
            StorageHelper.SaveGameParameters(Parameters);
            Messenger.Default.Send<SettingsSavedMessage>(new SettingsSavedMessage(Parameters));
        }

        #region Parameters property

        public const string ParametersPropertyName = "Parameters";
        private GameGeneratorParameters _parameters = new GameGeneratorParameters();

        public GameGeneratorParameters Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                if (_parameters == value)
                {
                    return;
                }
                var oldValue = _parameters;
                _parameters = value;
                RaisePropertyChanged(ParametersPropertyName);
            }
        }

        #endregion Parameters property
    }
}