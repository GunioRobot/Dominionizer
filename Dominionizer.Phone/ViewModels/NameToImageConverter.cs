using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Dominionizer.Phone.Core;

namespace Dominionizer.ViewModels
{
    public class NameToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Card card = value as Card;
            if (card == null)
                return null;
            var path = String.Format("/Images/Cards/{0}/{1}.jpg", card.Set, card.Name.Replace(" ", "").ToLower());
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}