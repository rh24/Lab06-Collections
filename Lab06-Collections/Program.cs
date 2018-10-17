using System;
using Lab06_Collections.Classes;

namespace Lab06_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Card card = new Card("Heart", 3);

            Console.WriteLine($"Suit: {card.Suit}, Value: {card.Value}");
        }
    }
}
