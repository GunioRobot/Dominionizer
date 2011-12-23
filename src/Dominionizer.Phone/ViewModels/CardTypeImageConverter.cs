using System;
using System.Windows.Data;
using Dominionizer.Phone.Core;

namespace Dominionizer.ViewModels
{
    public class CardTypeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Card card = value as Card;
            if (card == null)
                return string.Empty;

            var cardType = Enum.GetName(typeof(CardType), card.Type).ToLower();

            var result = String.Format("/Images/Types/{0}.png", cardType);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}