using System;
using Dominionizer.Phone.Core;

namespace Dominionizer.Models
{
    public class SortStrategy
    {
        public string SortField { get; set; }

        public int DisplayIndex { get; set; }

        //public Func<Card, object> SortRoutine { get; set; }
    }
}