using System;
using System.Collections.Generic;
using System.Text;

//Create a custom generic collection named Deck<T>.
//Your Generic collection should hold Cards. (You will need to create a custom Card class)
//Create an Enum to hold the different card suits(Hearts, Diamonds, Spades, Clubs)
//The methods within your Deck class should contain at minimum:
//Add
//Remove
//ReturnSuit
//This method will return all of the cards in that suit within the deck.

namespace Lab06_Collections.Classes
{
    public class Card
    {
        public CardValues Value { get; set; }
        public CardSuits Suit { get; set; }

        public Card(CardSuits suit, CardValues value)
        {
            Value = value;
            Suit = suit;
        }
    }

    public enum CardSuits
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades,
    }

    public enum CardValues
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
