using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab06_Collections.Classes
{
    public class Deck<T> : IEnumerable
    {
        // Methods:
        // Add
        // Remove
        // Return suit

        T[] cards = new T[52];
        int count = 0;

        public void AddToDeck(T card)
        {
            if (count == cards.Length)
            {
                Array.Resize(ref cards, cards.Length * 2);
            }

            cards[count++] = card;
        }

        public void RemoveFromDeck(T card)
        {

        }

        public string ReturnSuit(T card)
        {
            return card.CardSuit;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // the underlying loop that allows foreach loop to run
            for (int i = 0; i < count; i++)
            {
                // what does this yield to?
                yield return cards[i];
            }

        }

        // don't touch this
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
