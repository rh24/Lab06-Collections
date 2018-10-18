using System;
using Lab06_Collections.Classes;
using System.Collections.Generic;

namespace Lab06_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card2 = new Card(CardSuits.Hearts, CardValues.Three);
            Card card3 = new Card(CardSuits.Spades, CardValues.Jack);
            Card card4 = new Card(CardSuits.Diamonds, CardValues.Ten);
            Card card5 = new Card(CardSuits.Clubs, CardValues.Two);
            Card card6 = new Card(CardSuits.Diamonds, CardValues.Ace);
            Card card7 = new Card(CardSuits.Diamonds, CardValues.Queen);
            Card card8 = new Card(CardSuits.Diamonds, CardValues.King);

            List<Card> cards = new List<Card> { card2, card3, card4, card5, card6, card7, card8 };

            Deck<Card> deckOfCards = new Deck<Card>();

            foreach (var card in cards)
            {
                deckOfCards.AddToDeck(card);
            }


            // Removing Jack of Spades
            foreach (var cardInDeck in deckOfCards.RemoveFromDeck(card3))
            {
                if (cardInDeck != null) Console.WriteLine($"{cardInDeck.Value.ToString()} of {cardInDeck.Suit.ToString()}");
            }


            // Return same suit
            var cardsOfSameSuit = deckOfCards.ReturnSuit(card8);

            foreach (var card in cardsOfSameSuit)
            {
                if (card != null) Console.WriteLine($"These are allthe cards of {card?.Suit.ToString()}:" +
                    $"{card?.Value.ToString()} of {card?.Suit.ToString()}");
            }
        }
    }
}
