using System;
using Lab06_Collections.Classes;
using System.Collections.Generic;

namespace Lab06_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate 10 card instances
            Card card1 = new Card(CardSuits.Clubs, CardValues.Nine);
            Card card2 = new Card(CardSuits.Hearts, CardValues.Three);
            Card card3 = new Card(CardSuits.Spades, CardValues.Jack);
            Card card4 = new Card(CardSuits.Diamonds, CardValues.Ten);
            Card card5 = new Card(CardSuits.Clubs, CardValues.Two);
            Card card6 = new Card(CardSuits.Diamonds, CardValues.Ace);
            Card card7 = new Card(CardSuits.Diamonds, CardValues.Queen);
            Card card8 = new Card(CardSuits.Diamonds, CardValues.King);
            Card card9 = new Card(CardSuits.Hearts, CardValues.Seven);
            Card card10 = new Card(CardSuits.Spades, CardValues.Eight);

            // Instantiate generic List collection of Card types to enumerate over with foreach loop
            List<Card> cards = new List<Card> { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };

            // Instantiate deck of cards
            Deck<Card> deckOfCards = new Deck<Card>();

            // Enumerate over List of cards and add them to the deck
            foreach (var card in cards)
            {
                deckOfCards.AddToDeck(card);
            }

            // Display added cards to the console. It is a deck of 10 cards.
            Console.WriteLine("----- My current deck is" + Environment.NewLine);
            foreach (var card in deckOfCards)
            {
                Console.WriteLine($"{card.Value.ToString()} of {card.Suit.ToString()}" + Environment.NewLine);
            }

            // Removing Jack of Spades
            Console.WriteLine("----- I'm going to remove the Jack of Spades: " + Environment.NewLine);
            foreach (var cardInDeck in deckOfCards.RemoveFromDeck(card3))
            {
                if (cardInDeck != null) Console.WriteLine($"{cardInDeck.Value.ToString()} of {cardInDeck.Suit.ToString()}\n");
            }

            // Return same suit
            Console.WriteLine("----- I'm going to pick out all the cards that are Clubs:" + Environment.NewLine);
            var cardsOfSameSuit = deckOfCards.ReturnSuit(card5);

            foreach (var card in cardsOfSameSuit)
            {
                if (card != null) Console.WriteLine($"{card?.Value.ToString()} of {card?.Suit.ToString()}");
            }
        }
    }
}
