using SorteperLibrary.Cards.Interfaces;
using SorteperLibrary.Generators;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICard> cards;
            CardGenerator generator = new CardGenerator();
            cards = generator.GenerateCards();

            foreach (ICard card in cards)
            {
                Console.WriteLine(card.GetSuit() + " : " + card.GetValue());
            }
            Console.ReadLine();
        }
    }
}
