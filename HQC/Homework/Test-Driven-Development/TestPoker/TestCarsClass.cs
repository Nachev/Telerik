using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TestPoker
{
    [TestClass]
    public class TestCarsClass
    {
        [TestMethod]
        public void TestFaceGetProperty()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.AreEqual(CardFace.Ace, card.Face, string.Format("Face number for ace should be {0}", CardFace.Ace));
        }

        [TestMethod]
        public void TestSuitGetProperty()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.AreEqual(CardSuit.Spades, card.Suit, string.Format("Face number for ace should be {0}", CardSuit.Spades));
        }

        [TestMethod]
        public void TestToStringMethodShouldReturnCorrectValues()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.AreEqual("Ace of Spades", card.ToString(), "To string should return Ace of Spades");
        }
    }
}
