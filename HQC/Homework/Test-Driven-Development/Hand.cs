using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public IList<ICard> Cards
        {
            get
            {
                var listCopy = new List<ICard>(this.cards.Count);
                foreach (var card in this.cards)
                {
                    listCopy.Add(new Card(card.Face, card.Suit));
                }

                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cards list cannot be null.");
                }

                if (value.Count < 5 || value.Count > 5)
                {
                    throw new ApplicationException("Incorrect cards number in list, should be five.");
                }

                if (EqualCardsExistsInList(value))
                {
                    throw new ApplicationException("There are equal cards in the hand. Do not cheat.");
                }

                this.cards = value;
            }
        }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var card in this.Cards)
            {
                result.AppendLine(card.ToString());                
            }

            return result.ToString();
        }

        private bool EqualCardsExistsInList(IList<ICard> listOfCards)
        {
            bool result = new bool();
            for (int i = 0; i < listOfCards.Count; i++)
            {
                for (int j = i; j < listOfCards.Count; j++)
                {
                    if (listOfCards[i].Suit == listOfCards[j].Suit && 
                        listOfCards[i].Face == listOfCards[j].Face)
                    {
                        result = true;
                        return result;
                    }
                }
            }

            return result;
        }
    }
}
