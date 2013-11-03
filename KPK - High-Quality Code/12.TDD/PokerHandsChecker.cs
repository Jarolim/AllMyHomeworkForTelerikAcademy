using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        //Could not fix it to work properly and I am out of time :)
        public bool IsFourOfAKind(IHand hand)
        {
            if (this.IsValidHand(hand))
            {
                IHand orderedHand = this.OrderHand(hand);
                IList<ICard> orderedCards = orderedHand.Cards;
                ICard currentCard = null;
                int count = 0;

                for (int i = 0; i < orderedCards.Count; i++)
                {
                    if (currentCard == null)
                    {
                        currentCard = orderedCards[i];
                        count++;
                    }
                    else if (currentCard.Face == orderedCards[0].Face)
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        currentCard = orderedCards[i];
                        count = 0;
                    }
                }

                return false;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (this.IsValidHand(hand) && this.HaveSameSuit(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool HaveSameSuit(IHand hand)
        {
            if (this.IsValidHand(hand))
            {
                IList<ICard> cards = hand.Cards;

                for (int i = 0; i < cards.Count - 1; i++)
                {
                    if (cards[i].Suit != cards[i+1].Suit)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private IHand OrderHand(IHand hand)
        {
            IList<ICard> orderedCards = new List<ICard>();
            IList<ICard> cards = hand.Cards.ToList();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var weakestCard = cards.Min();
                orderedCards.Add(weakestCard);
                cards.Remove(weakestCard);
            }

            IHand orderedHand = new Hand(orderedCards);
            return orderedHand;
        }
    }
}
