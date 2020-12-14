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
            while (true)
            {
                Thread t = new Thread(CountUp);
                t.Start();
                t = new Thread(CountDown);
                t.Start();
                Console.WriteLine(counter);
                Thread.Sleep(1000);
            }
        }

        static void CountUp(object callback)
        {
            Monitor.Enter(_lock);
            counter += 2;
            Monitor.Exit(_lock);
        }

        static void CountDown(object callback)
        {
            Monitor.Enter(_lock);
            counter--;
            Monitor.Exit(_lock);
        }
    }
}
