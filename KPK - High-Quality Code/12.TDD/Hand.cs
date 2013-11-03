using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            if (this.Cards.Count == 0)
            {
                throw new ArgumentOutOfRangeException("There are no cards to display!");
            }

            StringBuilder sb = new StringBuilder();

            foreach (Card card in this.Cards)
            {
                sb.Append(card.ToString() + " ");
            }

            return sb.ToString().Trim();
        }
    }
}
