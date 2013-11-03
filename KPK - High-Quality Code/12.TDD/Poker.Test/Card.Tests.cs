using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardToStringTestAceOfHearts()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            string expected = "A♥";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTestTwoOfSpades()
        {
            Card card = new Card(CardFace.Two, CardSuit.Spades);
            string expected = "2♠";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTestJackOfSpades()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Spades);
            string expected = "J♠";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTestFiveOfSpades()
        {
            Card card = new Card(CardFace.Five, CardSuit.Spades);
            string expected = "5♠";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTestTenOfDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♦";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTestNineOfClubs()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Clubs);
            string expected = "9♣";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTestQueenOfDiamonds()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Diamonds);
            string expected = "Q♦";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
