using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

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

        /// <summary>
        /// This method ads a card instance to the T[] cards within this generic class.
        /// </summary>
        /// <param name="card">Card instance to add</param>
        public void AddToDeck(T card)
        {
            if (count == cards.Length)
            {
                Array.Resize(ref cards, cards.Length * 2);
            }

            cards[count++] = card;
        }

        /// <summary>
        /// This method removes a card from the deck.
        /// </summary>
        /// <param name="card">Card instance to remove</param>
        /// <returns>Deck of cards without the removed card</returns>
        public T[] RemoveFromDeck(T card)
        {
            Type t = card.GetType();
            PropertyInfo value = t.GetProperty("Value");
            PropertyInfo suit = t.GetProperty("Suit");

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != null)
                {
                    bool equalValues = string.Equals(value.GetValue(card).ToString(), value.GetValue(cards[i]).ToString(), StringComparison.CurrentCultureIgnoreCase);
                    bool equalSuits = string.Equals(suit.GetValue(card).ToString(), suit.GetValue(cards[i]).ToString(), StringComparison.CurrentCultureIgnoreCase);

                    // if property of generic type object == property of generic type in card deck
                    if (equalValues && equalSuits) cards.SetValue(null, i);
                }
            }

            return cards;
        }

        /// <summary>
        /// This method returns an array of a generic type. 
        /// </summary>
        /// <param name="card">Card instance to remove</param>
        /// <returns>Array of generic objects</returns>
        public T[] ReturnSuit(T card)
        {
            Type t = card.GetType();
            PropertyInfo value = t.GetProperty("Value");
            PropertyInfo suit = t.GetProperty("Suit");
            T[] cardsOfSameSuit = new T[cards.Length];

            int counter = 0;

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != null)
                {
                    bool equalSuits = string.Equals(suit.GetValue(card).ToString(), suit.GetValue(cards[i]).ToString(), StringComparison.CurrentCultureIgnoreCase);

                    if (equalSuits)
                    {
                        cardsOfSameSuit[counter] = cards[i];
                        counter++;
                    }
                }
            }

            return cardsOfSameSuit;
        }

        /// <summary>
        /// Helper method to test whether T[] cards has a card I am looking for.
        /// </summary>
        /// <returns>true or false</returns>
        public bool Contains(Card card)
        {
            Card[] listCards = (Card[])Convert.ChangeType(cards, typeof(Card[]));
            return listCards.Contains(card);
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
