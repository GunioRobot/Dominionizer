using Dominionizer.Messages;
using Dominionizer.Phone.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Dominionizer.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            Messenger.Default.Register<SaveSettingsMessage>(this, (message) => SaveSettings());
            if (!IsInDesignMode)
                LoadSettings();
        }

        private void LoadSettings()
        {
            var settings = StorageHelper.LoadGameParameters();
            if (Parameters != null)
            {
                Parameters.Rules.Clear();
                Parameters.Sets.Clear();
            }
            Parameters = settings;
            Messenger.Default.Send<SettingsLoadedMessage>(new SettingsLoadedMessage(Parameters));
        }

        private void SaveSettings()
        {
            StorageHelper.SaveGameParameters(Parameters);
            Messenger.Default.Send<SettingsSavedMessage>(new SettingsSavedMessage(Parameters));
        }

        #region Parameters property

        public const string ParametersPropertyName = "Parameters";
        private GameGeneratorParameters _parameters = GameGeneratorParameters.GetInstance();

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