using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsValidHandTestWith5DifferentCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            bool expectedValidHand = true;
            bool actual;
            actual = checker.IsValidHand(hand);
            Assert.AreEqual(expectedValidHand, actual);
        }

        [TestMethod]
        public void IsValidHandTestWith5DifferentCardsTwoSameFaces()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            bool expectedValidHand = true;
            bool actual;
            actual = checker.IsValidHand(hand);
            Assert.AreEqual(expectedValidHand, actual);
        }

        [TestMethod]
        public void IsValidHandTestWith5DifferentCardsAllSameSiuts()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            bool expectedValidHand = true;
            bool actual;
            actual = checker.IsValidHand(hand);
            Assert.AreEqual(expectedValidHand, actual);
        }

        [TestMethod]
        public void IsValidHandTestWithZeroCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>());
            bool expectedValidHand = false;
            bool actual;
            actual = checker.IsValidHand(hand);
            Assert.AreEqual(expectedValidHand, actual);
        }

        [TestMethod]
        public void IsValidHandTestWithOneCard()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts)
            });
            bool expectedValidHand = false;
            bool actual;
            actual = checker.IsValidHand(hand);
            Assert.AreEqual(expectedValidHand, actual);
        }

        [TestMethod]
        public void IsValidHandTestWithFourCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            });
            bool expectedValidHand = false;
            bool actual;
            actual = checker.IsValidHand(hand);
            Assert.AreEqual(expectedValidHand, actual);
        }

        [TestMethod]
        public void IsValidHandTestWithFiveSameCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            bool expectedValidHand = false;
            bool actual;
            actual = checker.IsValidHand(hand);
            Assert.AreEqual(expectedValidHand, actual);
        }

        [TestMethod]
        public void IsFourOfAKindTestNotValidHand()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            bool expectedFourOfAKindHand = false;
            bool actual;
            actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expectedFourOfAKindHand, actual);
        }

        [TestMethod]
        public void IsFourOfAKindTestValidHandTwoPairs()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            bool expectedFourOfAKindHand = false;
            bool actual;
            actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expectedFourOfAKindHand, actual);
        }

        [TestMethod]
        public void IsFourOfAKindTestValidHand()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts)
            });

            bool expectedFourOfAKindHand = true;
            bool actual;
            actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(expectedFourOfAKindHand, actual);
        }

        [TestMethod]
        public void IsFlushTestValidHand()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            });

            bool expectedIsFlush = true;
            bool actual;
            actual = checker.IsFlush(hand);
            Assert.AreEqual(expectedIsFlush, actual);
        }

        [TestMethod]
        public void IsNotFlushTest()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades)
            });

            bool expectedIsFlush = false;
            bool actual;
            actual = checker.IsFlush(hand);
            Assert.AreEqual(expectedIsFlush, actual);
        }

        [TestMethod]
        public void IsFlushTestNotValidHand()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            });

            bool expectedIsFlush = false;
            bool actual;
            actual = checker.IsFlush(hand);
            Assert.AreEqual(expectedIsFlush, actual);
        }
    }
}
