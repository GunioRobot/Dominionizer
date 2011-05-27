using System;
using System.Windows.Data;

namespace Dominionizer.ViewModels
{
    using System.Windows;
    using System.Windows.Media;

    public class CardSetImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var theme = PhoneUtil.DetectTheme() == PhoneTheme.Dark ? "Dark" : "Light";

            return string.Format("/Images/Sets/{0}/{1}.png", theme, value.ToString().ToLower());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}