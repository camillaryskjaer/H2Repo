using MyBanker.Cards;
using System;
using System.Threading;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            CardGenerator generator = new CardGenerator();
            Card card;
            
            string response = "1";
            while (response == "1")
            {
                Console.Clear();
                Console.WriteLine("insert name: ");
                string name = Console.ReadLine();
                Console.WriteLine("insert age");
                int age = int.Parse(Console.ReadLine());
                Customer customer = new Customer(name, age);

                card = generator.GenerateCard(customer);

                Console.Clear();
                Console.WriteLine("Your card:");
                Console.WriteLine(card.ToString());
                Console.WriteLine();

                Console.WriteLine("Press 1 for new user and card");
                Console.WriteLine("Press anything else to exit");

                response = Console.ReadLine();
            }
        }
    }
}
