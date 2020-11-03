using MyBanker.Cards;
using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            // card generator
            CardGenerator generator = new CardGenerator();
            // empty card
            Card card;

            // proof of concept, sortering ud fra interface ÍDebtable
            //List<ICard> cards = new List<ICard>();

            //Customer test = new Customer("kagemand", 20);
            //for (int i = 0; i < 10; i++)
            //{
            //    cards.Add(generator.GenerateCard(test));
            //}
            //foreach (Card item in cards)
            //{
            //    if (item is IDebtable)
            //    {
            //    Console.WriteLine(item.ToString());
            //    Console.WriteLine();
            //                        }
            //}
            //Console.ReadLine();

            // prevents program from stopping
            string response = "1";
            while (response == "1")
            {
                // prompts user for name and age
                Console.Clear();
                Console.WriteLine("insert name: ");
                string name = Console.ReadLine();
                Console.WriteLine("insert age");
                int age = int.Parse(Console.ReadLine());

                // creates a customer from user input
                Customer customer = new Customer(name, age);

                // generates a card from customer
                card = generator.GenerateCard(customer);

                // displays card information
                Console.Clear();
                Console.WriteLine("Your card:");
                Console.WriteLine(card.ToString());
                Console.WriteLine();

                // enables user to start over or stop
                Console.WriteLine("Press 1 for new user and card");
                Console.WriteLine("Press anything else to exit");

                response = Console.ReadLine();
            }
        }
    }
}
