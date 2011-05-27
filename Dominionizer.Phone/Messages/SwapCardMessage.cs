using System;
using Dominionizer.Phone.Core;

namespace Dominionizer.Messages
{
    public class SwapCardMessage
    {
        public SwapCardMessage(Card card)
        {
            this.SelectedCard = card;
        }

        public Card SelectedCard { get; set; }
    }
}