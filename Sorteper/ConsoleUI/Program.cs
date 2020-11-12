using SorteperLibrary;
using SorteperLibrary.Cards.Interfaces;
using SorteperLibrary.Generators;
using SorteperLibrary.Players;
using SorteperLibrary.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();

            Console.WriteLine("Enter number of players");
            for (int i = 0; i < int.Parse(Console.ReadLine()); i++)
            {
                Console.Clear();
                Console.WriteLine("Write name of player");
                manager.CreatePlayer(Console.ReadLine());
            }
            manager.DealCards();



            Console.ReadLine();
        }
    }
}
