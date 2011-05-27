using System;
using System.Windows.Data;

namespace Dominionizer.ViewModels
{
    using Dominionizer.Phone.Core;

    public class CardTypeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Card card = value as Card;
            if (card == null)
                return string.Empty;

            var cardType = Enum.GetName(typeof(CardType), card.Type).ToLower();

            var theme = PhoneUtil.DetectTheme() == PhoneTheme.Dark ? "Dark" : "Light";
            return String.Format("/Images/Types/{0}/{1}.png", theme, cardType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}