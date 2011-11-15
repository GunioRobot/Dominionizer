﻿using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace Dominionizer.ViewModels
{
    public class GlobalViewModelLocator
    {
        private const string STR_CardListViewModel = "CardListViewModel";
        private const string STR_SettingsViewModel = "SettingsViewModel";

        private IsolatedStorageSettings settings;

        public GlobalViewModelLocator()
        {
            if (!ViewModelBase.IsInDesignModeStatic)
                settings = IsolatedStorageSettings.ApplicationSettings;

            CreateMainViewModel();
            CreateCardListViewModel();
            CreateSettingsViewModel();
        }

        public static void Cleanup()
        {
            ClearSettingsViewModel();
            ClearCardListViewModel();
            ClearMainViewModel();
        }

        #region ViewModels

        #region MainViewModel

        private static MainViewModel _main;

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        public static MainViewModel MainViewModelStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMainViewModel();
                }

                return _main;
            }
        }

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel
        {
            get
            {
                return MainViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the MainViewModel property.
        /// </summary>
        public static void ClearMainViewModel()
        {
            _main.Cleanup();
            _main = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the MainViewModel property.
        /// </summary>
        public static void CreateMainViewModel()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }

        #endregion MainViewModel

        #region SettingsViewModel

        private static SettingsViewModel _settingsViewModel;

        public static SettingsViewModel SettingsViewModelStatic
        {
            get
            {
                if (_settingsViewModel == null)
                {
                    CreateSettingsViewModel();
                }

                return _settingsViewModel;
            }
        }

        /// <summary>
        /// Gets the SettingsViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return SettingsViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the SettingsViewModel property.
        /// </summary>
        public static void ClearSettingsViewModel()
        {
            _settingsViewModel.Cleanup();
            _settingsViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the SettingsViewModel property.
        /// </summary>
        public static void CreateSettingsViewModel()
        {
            if (_settingsViewModel == null)
            {
                _settingsViewModel = new SettingsViewModel();
            }
        }

        #endregion SettingsViewModel

        #region CardListViewModel

        private static CardListViewModel _gameCardList;

        /// <summary>
        /// Gets the CardListViewModel property.
        /// </summary>
        public static CardListViewModel CardListViewModelStatic
        {
            get
            {
                if (_gameCardList == null)
                {
                    CreateCardListViewModel();
                }

                return _gameCardList;
            }
        }

        /// <summary>
        /// Gets the CardListViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CardListViewModel CardListViewModel
        {
            get
            {
                return CardListViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the CardListViewModel property.
        /// </summary>
        public static void ClearCardListViewModel()
        {
            _gameCardList.Cleanup();
            _gameCardList = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the CardListViewModel property.
        /// </summary>
        public static void CreateCardListViewModel()
        {
            if (_gameCardList == null)
            {
                _gameCardList = new CardListViewModel();
            }
        }

        #endregion CardListViewModel

        #endregion ViewModels

        internal void LoadState()
        {
            if (ViewModelBase.IsInDesignModeStatic)
                return;

            string data;

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(STR_CardListViewModel))
                {
                    using (var stream = store.OpenFile(STR_CardListViewModel, FileMode.Open))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            data = reader.ReadToEnd();
                        }
                    }
                    _gameCardList = JsonConvert.DeserializeObject<CardListViewModel>(data);
                }
                if (store.FileExists(STR_SettingsViewModel))
                {
                    using (var stream = store.OpenFile(STR_SettingsViewModel, FileMode.Open))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            data = reader.ReadToEnd();
                        }
                    }
                    _settingsViewModel = JsonConvert.DeserializeObject<SettingsViewModel>(data);
                }
            }
        }

        internal void SaveState(bool SaveCardList = true, bool SaveSettings = true)
        {
            if (ViewModelBase.IsInDesignModeStatic)
                return;

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(STR_CardListViewModel))
                    store.DeleteFile(STR_CardListViewModel);

                if (SaveCardList)
                {
                    using (var fs = store.CreateFile(STR_CardListViewModel))
                    using (var sw = new StreamWriter(fs))
                        sw.Write(JsonConvert.SerializeObject(CardListViewModel));
                }

                if (store.FileExists(STR_SettingsViewModel))
                    store.DeleteFile(STR_SettingsViewModel);
                if (SaveSettings)
                {
                    using (var fs = store.CreateFile(STR_SettingsViewModel))
                    using (var sw = new StreamWriter(fs))
                        sw.Write(JsonConvert.SerializeObject(SettingsViewModel));
                }
            }
        }
    }
}