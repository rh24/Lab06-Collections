using System;
using Xunit;
using Lab06_Collections.Classes;
using System.Collections.Generic;

//Tests
//Your tests should cover the following functionality:

//Add a card to your deck
//Getter/Setters of your properties from your Card class
//Remove a card from your deck that exists
//Remove a card from your deck that does not exist

namespace Lab06_Tests
{
    public class UnitTest1
    {
        public static Card card2 = new Card(CardSuits.Hearts, CardValues.Three);
        public static Card card3 = new Card(CardSuits.Spades, CardValues.Jack);
        public static Card card4 = new Card(CardSuits.Diamonds, CardValues.Ten);
        public static Card card5 = new Card(CardSuits.Clubs, CardValues.Two);
        public static Card card6 = new Card(CardSuits.Diamonds, CardValues.Ace);
        public static Card card7 = new Card(CardSuits.Diamonds, CardValues.Queen);
        public static Card card8 = new Card(CardSuits.Diamonds, CardValues.King);

        List<Card> cards = new List<Card> { card2, card3, card4, card5, card6, card7, card8 };

        Deck<Card> deckOfCards = new Deck<Card>();

        [Fact]
        public void Test1()
        {
            foreach (var card in cards)
            {
                deckOfCards.AddToDeck(card);
            }
        }
    }
}
