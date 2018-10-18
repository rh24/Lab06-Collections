using System;
using Xunit;
using Lab06_Collections.Classes;
using System.Collections.Generic;
using System.Linq;

//Tests
//Your tests should cover the following functionality:

//Getter/Setters of your properties from your Card class

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

        public static List<Card> cards = new List<Card> { card2, card3, card4, card5, card6, card7, card8 };

        Deck<Card> deckOfCards = new Deck<Card>();


        /// <summary>
        /// Tests that I can grab the Card instance's Suit property which is set by an enum, a set of named constants, called CardSuits.
        /// </summary>
        [Fact]
        public void TestGetter()
        {
            CardSuits cardSuitProperty = card2.Suit;
            Assert.IsType<CardSuits>(cardSuitProperty);
        }

        /// <summary>
        /// Tests that the current card4's value, CardValues.Ten, can be reset to CardValues.Ace.
        /// </summary>
        [Fact]
        public void TestSetter()
        {
            CardValues currentCard4Value = card4.Value;
            card4.Value = CardValues.Ace;

            Assert.NotEqual(currentCard4Value, card4.Value);
        }

        /// <summary>
        /// Test that a card is added and contained in deck.
        /// </summary>
        [Fact]
        public void AddToDeck()
        {
            deckOfCards.AddToDeck(card2);
            bool isContained = deckOfCards.Contains(card2);
            Assert.True(isContained);
        }


        /// <summary>
        /// Remove a card that does exist. Verify that the remaining cards are correct number of cards left in collection. 
        /// </summary>
        [Fact]
        public void RemoveExistingCardFromDeck()
        {
            deckOfCards.AddToDeck(card2);
            deckOfCards.AddToDeck(card3);
            deckOfCards.AddToDeck(card4);

            deckOfCards.RemoveFromDeck(card3);

            bool isContained = deckOfCards.Contains(card3);
            int numberOfCardsLeft = deckOfCards.Count();

            Assert.False(isContained);
            Assert.Equal(2, numberOfCardsLeft);
        }

        /// <summary>
        /// If a card does not exist in the deck, no item will have been removed, and the deck of cards will remain untouched. Test that the returned deck after removing non-existing card has the same number of cards as the original deck.
        /// </summary>
        [Fact]
        public void RemoveNonExistingCardFromDeck()
        {
            deckOfCards.AddToDeck(card6);
            deckOfCards.AddToDeck(card7);

            int originalCount = deckOfCards.Count();

            deckOfCards.RemoveFromDeck(card5);

            int newCount = deckOfCards.Count();

            Assert.Equal(originalCount, newCount);
        }
    }
}
