using System;
using Lab06_Collections.Classes;
using System.Collections.Generic;

namespace Lab06_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Card card2 = new Card(CardSuits.Hearts, CardValues.Three);
            Card card3 = new Card(CardSuits.Spades, CardValues.Jack);
            Card card4 = new Card(CardSuits.Diamonds, CardValues.Ten);
            Card card5 = new Card(CardSuits.Clubs, CardValues.Two);

            List<Card> cardsToAdd = new List<Card> { card2, card3, card4, card5 };

            Console.WriteLine($"Suit: {card2.Suit}, Value: {card2.Value}");

            Deck<Card> deckOfCards = new Deck<Card>();

            foreach (var card in cardsToAdd)
            {
                deckOfCards.AddToDeck(card);
            }

            deckOfCards.RemoveFromDeck(card2);

            foreach (var cardInDeck in deckOfCards)
            {
                Console.WriteLine($"{cardInDeck.Value.ToString()} of {cardInDeck.Suit.ToString()}");
            }
        }
    }
}
