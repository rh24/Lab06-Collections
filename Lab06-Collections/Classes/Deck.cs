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
                bool equalValues = value.GetValue(card) == value.GetValue(cards[i]);
                bool equalSuits = suit.GetValue(card) == suit.GetValue(cards[i]);

                // if property of generic type object == property of generic type in card deck
                if (!equalValues && !equalSuits) cards[i] = card;
                else continue;
            }



            //for (int i = 0; i < cards.Length; i++)
            //{
            //    Type tDeck = cards[i].GetType();
            //    PropertyInfo deckVal = tDeck.GetProperty("Value");
            //    PropertyInfo deckSuit = tDeck.GetProperty("Suit");

            //    /// yayyyyyy
            //    Console.WriteLine(deckSuit.GetValue(cards[i]));
            //    if (!cards[i].Equals(card))
            //    {
            //        cards.SetValue(null, i);
            //    }
            //    else cards[i] = card;
            //}

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
