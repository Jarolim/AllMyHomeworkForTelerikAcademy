using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Tests
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandToStringTestZeroCards()
        {
            Hand hand = new Hand(new List<ICard>());
            string actual = hand.ToString();
        }

        [TestMethod]
        public void HandToStringTestOneCard()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts)
            });
            string expected = "9♥";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HandToStringTestThreeCards()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades)
            });
            string expected = "2♥ 3♦ 4♠";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HandToStringTestFourCards()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades)
            });
            string expected = "5♥ 6♦ 8♠ K♠";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HandToStringTestFiveDifferentCards()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });
            string expected = "A♥ 2♠ 10♣ 7♦ J♥";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HandToStringTestFiveSameCards()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            });
            string expected = "A♥ A♥ A♥ A♥ A♥";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
