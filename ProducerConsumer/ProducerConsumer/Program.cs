using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static Queue<int> numbers = new Queue<int>(5);
        static void Main(string[] args)
        {
            Thread t = new Thread(Producer);
            t.Start();
            for (int i = 0; i < 6; i++)
            {
                t = new Thread(() => Consumer(i));
                t.Start();
                Thread.Sleep(10);
            }

            while (true)
            {
            }
        }

        static void Consumer(int threadnumber)
        {
            lock (numbers)
            {
                while (true)
                {
                    if (Monitor.Wait(numbers))
                    {
                        if (numbers.Count == 0)
                        {
                            Monitor.PulseAll(numbers);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(threadnumber + " took " + numbers.Dequeue());
                            Monitor.PulseAll(numbers);
                        }
                    }                    
                }
            }
        }

        static void Producer()
        {
            int produce;
            Random random = new Random();
            if (numbers.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(200);
                    produce = random.Next(1, 11);
                    numbers.Enqueue(produce);
                }
            }
            lock (numbers)
            {
                while (true)
                {
                    Monitor.PulseAll(numbers);
                    if (Monitor.Wait(numbers))
                    {
                        while (numbers.Count < 5)
                        {
                            Thread.Sleep(200);
                            produce = random.Next(1, 11);
                            numbers.Enqueue(produce);
                            Console.WriteLine("Producer made " + produce);
                        }
                    }
                }
            }
        }
    }
}
