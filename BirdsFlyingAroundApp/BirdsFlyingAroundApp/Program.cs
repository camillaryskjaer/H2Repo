using BirdsFlyingAroundApp.Birds;
using BirdsFlyingAroundApp.Interfaces;
using System;
using System.Collections.Generic;

namespace BirdsFlyingAroundApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bird> birds = new List<Bird>();
            birds.Add(new Penguin());
            birds.Add(new Crow());

            foreach (Bird bird in birds)
            {
                if (bird is IFly)
                {
                    Console.WriteLine(bird.GetType() + " and i can fly");
                }
                else
                {
                    Console.WriteLine(bird.GetType() + " i cant fly");
                }
            }
            Console.ReadKey();
        }
    }
}
