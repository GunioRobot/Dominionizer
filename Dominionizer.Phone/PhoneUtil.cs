namespace Dominionizer
{
    using System.Windows;
    using System.Windows.Media;

    public enum PhoneTheme
    {
        Light,
        Dark
    }

    public static class PhoneUtil
    {
        private static Color darkThemeBackground = Color.FromArgb(255, 0, 0, 0); 
        public static PhoneTheme DetectTheme()
        {
            var backgroundBrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            return backgroundBrush.Color == darkThemeBackground ? PhoneTheme.Dark : PhoneTheme.Light;
        }
    }
}