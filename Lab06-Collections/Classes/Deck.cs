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

        T[] cards = new T[4];
        int count = 0;

        public void AddToDeck(T card)
        {
            if (count == cards.Length)
            {
                Array.Resize(ref cards, cards.Length * 2);
            }

            cards[count++] = card;
        }

        public T[] RemoveFromDeck(T card)
        {
            Type t = card.GetType();
            PropertyInfo value = t.GetProperty("Value");
            PropertyInfo suit = t.GetProperty("Suit");

            for (int i = 0; i < cards.Length; i++)
            {
                bool equalValues = string.Equals(value.GetValue(card).ToString(), value.GetValue(cards[i]).ToString(), StringComparison.CurrentCultureIgnoreCase);
                bool equalSuits = string.Equals(suit.GetValue(card).ToString(), suit.GetValue(cards[i]).ToString(), StringComparison.CurrentCultureIgnoreCase);

                // if property of generic type object == property of generic type in card deck
                if (equalValues && equalSuits)
                {
                    cards.SetValue(null, i);
                    Console.WriteLine("Yay the strings are equal!");
                }
            }

            return cards;
        }

        public T[] ReturnSuit(T card)
        {
            Type t = card.GetType();
            PropertyInfo value = t.GetProperty("Value");
            PropertyInfo suit = t.GetProperty("Suit");
            T[] cardsOfSameSuit = new T[cards.Length];

            int counter = 0;

            for (int i = 0; i < cards.Length; i++)
            {
                Type cT = cards[i].GetType();
                PropertyInfo cVal = t.GetProperty("Value");
                PropertyInfo cSuit = t.GetProperty("Suit");
                if (cSuit == suit)
                {
                    cardsOfSameSuit[counter] = cards[i];
                    counter++;
                }
            }

            return cardsOfSameSuit;
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
