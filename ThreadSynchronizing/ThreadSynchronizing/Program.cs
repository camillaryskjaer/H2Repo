using System;
using System.Threading;

namespace ThreadSynchronizing
{
    class Program
    {
        static int counter = 0;
        static object _lock = new object();
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    Thread t = new Thread(CountUp);
            //    t.Start();
            //    t = new Thread(CountDown);
            //    t.Start();
            //    Console.WriteLine(counter);
            //    Thread.Sleep(1000);
            //}

            while (true)
            {
                ThreadPool.QueueUserWorkItem(Stars);
                ThreadPool.QueueUserWorkItem(Hashtags);
            }
        }

        static void Stars(object callback)
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 60; i++)
            {
                counter++;
                Console.Write('*');
            }
            Console.Write(" " + counter);
            Console.WriteLine();
            Monitor.Exit(_lock);
        }

        static void Hashtags(object callback)
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 60; i++)
            {
                counter++;
                Console.Write('#');
            }
            Console.Write(" " + counter);
            Console.WriteLine();
            Monitor.Exit(_lock);
        }

        //static void CountUp(object callback)
        //{
        //    Monitor.Enter(_lock);
        //    counter += 2;
        //    Monitor.Exit(_lock);
        //}

        //static void CountDown(object callback)
        //{
        //    Monitor.Enter(_lock);
        //    counter--;
        //    Monitor.Exit(_lock);
        //}
    }
}
