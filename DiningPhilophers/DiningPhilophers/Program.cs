using System;
using System.Threading;

namespace DiningPhilophers
{
    class Program
    {

        static bool[] forks = new bool[5] { false, false, false, false, false };
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                Thread t = new Thread(() => Philosopher(i));
                t.Start();
                Thread.Sleep(10);
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
                if (number + 1 == 5)
                {
                    if (forks[number] == false && forks[0] == false)
                    {
                        lock (forks)
                        {
                            forks[number] = true;
                            forks[0] = true;
                            Console.WriteLine(number + " is eating");
                        }
                        Thread.Sleep(random.Next(1000, 2000));
                        lock (forks)
                        {
                            forks[number] = false;
                            forks[0] = false;
                            Console.WriteLine(number + " is thinking");
                        }
                        Thread.Sleep(random.Next(1000, 2000));
                        continue;
                    }
                }
                else if (forks[number] == false && forks[number + 1] == false)
                {
                    lock (forks)
                    {
                        forks[number] = true;
                        forks[number + 1] = true;
                        Console.WriteLine(number + " is eating");
                    }
                    Thread.Sleep(random.Next(1000, 2000));
                    lock (forks)
                    {
                        forks[number] = false;
                        forks[number + 1] = false;
                        Console.WriteLine(number + " is thinking");
                    }
                    Thread.Sleep(random.Next(1000, 2000));
                    continue;
                }
                Console.WriteLine(number + " is waiting for a fork");
                Thread.Sleep(random.Next(1000, 2000));
            }
        }
    }
}