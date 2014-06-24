using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class TestHandClass
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHandConstructorWithNullArgumentShouldThrowAnException()
        {
            List<ICard> testList = null;
            var hand = new Hand(testList);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestHandConstructorShouldNotRecieveLessThanFiveCards()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var card4 = new Card(CardFace.Ace, CardSuit.Hearts);
            var cardsList = new List<ICard>() { card1, card2, card3, card4 };
            var hand = new Hand(cardsList);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestHandConstructorShouldNotRecieveMoreThanFiveCards()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var card4 = new Card(CardFace.Ace, CardSuit.Hearts);
            var card5 = new Card(CardFace.Two, CardSuit.Spades);
            var card6 = new Card(CardFace.Two, CardSuit.Hearts);
            var cardsList = new List<ICard>() { card1, card2, card3, card4, card5, card6 };
            var hand = new Hand(cardsList);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestHandConstructorShouldNotRecieveCardsWithEqualCards()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var card4 = new Card(CardFace.Ace, CardSuit.Hearts);
            var card5 = new Card(CardFace.Ace, CardSuit.Spades);
            var cardsList = new List<ICard>() { card1, card2, card3, card4, card5 };
            var hand = new Hand(cardsList);
        }

        [TestMethod]
        public void TestToStringShouldReturnProperValue()
        {
            var card1 = new Card(CardFace.Ace, CardSuit.Spades);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            var card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            var card4 = new Card(CardFace.Ace, CardSuit.Hearts);
            var card5 = new Card(CardFace.Two, CardSuit.Spades);
            var cardsList = new List<ICard>() { card1, card2, card3, card4, card5 };
            var hand = new Hand(cardsList);
            Assert.AreEqual(
                "Ace of Spades\nAce of Clubs\nAce of Diamonds\nAce of Hearts\nTwo of Spades\n", 
                hand.ToString(), 
                "To string method does not work correctly"
                );
        }
    }
}
