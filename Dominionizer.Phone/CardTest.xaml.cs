using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dominionizer.Phone.Core;
using Microsoft.Phone.Controls;

namespace Dominionizer
{
    public partial class CardTest : PhoneApplicationPage
    {
        public CardTest()
        {
            InitializeComponent();
            this.DataContext = new Cards();
        }
    }
}