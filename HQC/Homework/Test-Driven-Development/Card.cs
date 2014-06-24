using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.Face.ToString());
            result.AppendFormat(" of {0}", this.Suit.ToString());
            return result.ToString();
        }
    }
}
