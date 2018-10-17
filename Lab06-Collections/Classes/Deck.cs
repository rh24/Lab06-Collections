using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

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
            Type t = card.GetType();
            PropertyInfo value = t.GetProperty("Value");
            PropertyInfo suit = t.GetProperty("Suit");

            for (int i = 0; i < cards.Length; i++)
            {
                Type tDeck = cards[i].GetType();
                PropertyInfo deckVal = tDeck.GetProperty("Value");
                PropertyInfo deckSuit = tDeck.GetProperty("Suit");

                // if property of generic type object == property of generic type in card deck
                if (value == deckVal)
                {
                    if (suit == deckSuit) continue;
                    else cards[i] = card;
                }
            }
        }

        public string ReturnSuit(Card card)
        {
            return card.Suit;
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
