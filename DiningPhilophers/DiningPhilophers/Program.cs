using System;
using System.Threading;

namespace DiningPhilophers
{
    class Program
    {
        static bool[] forks = new bool[5] { false, false, false, false, false };
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                Thread t = new Thread(() => Philosopher(i));
                t.Start();
            }
            while (true)
            {

            }
        }

        static void Philosopher(int number)
        {
            Random random = new Random();

            while (true)
            {

            }
        }
    }
}
