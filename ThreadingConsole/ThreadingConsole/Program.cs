using System;
using System.Threading;

namespace ThreadingConsole
{
    class Program
    {
        static char ch = '*';
        static void Main(string[] args)
        {
            //    // creates a thread that runs workthreadfunction
            //    Thread t = new Thread(WorkThreadFunction);
            //    // sets the threads name to tone
            //    t.Name = "tOne";
            //    // starts the thread
            //    t.Start();

            //    // sleeps main thread for better visuals
            //    Thread.Sleep(100);
            //    // creates new thread that runs workthreadfunction
            //    t = new Thread(WorkThreadFunction);
            //    // names the thread to ttwo
            //    t.Name = "tTwo";
            //    // starts the thread
            //    t.Start();

            //Thread tEasy = new Thread(Easy);
            //tEasy.Start();
            //Thread tMultiple = new Thread(Multiple);
            //tMultiple.Start();
            //tEasy.Join();
            //tMultiple.Join();

            //Thread temp = new Thread(TempGen);
            //temp.Start();

            //while (true)
            //{
            //    Thread.Sleep(10000);
            //    if (!temp.IsAlive)
            //    {
            //        Console.WriteLine("Alarm-tråd termineret!!");
            //        break;
            //    }
            //}

            Thread t = new Thread(Print);
            t.Name = "printer";
            t.Start();

            t = new Thread(Read);
            t.Start();

            while (true)
            {

            }
        }

        static void Read()
        {
            while (true)
            {
                // try catch to stop program from breaking if no key was entered
                try
                {
                    ch = Console.ReadLine()[0];
                }
                catch
                {
                }
            }
        }

        static void Print()
        {
            while (true)
            {
                Console.Write(ch);
                Thread.Sleep(500);
            }
        }

        //static void TempGen()
        //{
        //    Random random = new Random();
        //    int alarmCount = 0;
        //    int gen;
        //    while (alarmCount < 2)
        //    {
        //        gen = random.Next(-20, 121);
        //        if (gen < 0)
        //        {
        //            Console.WriteLine("Temp er: {0}", gen);
        //            Console.WriteLine("!Alarm temp er for lav!");
        //            alarmCount++;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Temp er {0}", gen);
        //        }
        //        Thread.Sleep(2000);
        //    }
        //}

        //static void Easy()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("C#-trådning er nemt!");
        //        Thread.Sleep(500);
        //    }
        //}

        //static void Multiple()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("Også med flere tråde...");
        //        Thread.Sleep(500);
        //    }
        //}

        //static void WorkThreadFunction()
        //{
        //    // runs loop 5 times
        //    for (int i = 0; i < 5; i++)
        //    {
        //        // prints simple thread and thread name
        //        Console.WriteLine("Simple Thread");
        //        Console.WriteLine(Thread.CurrentThread.Name);
        //        // sleeps thread for better visuals
        //        Thread.Sleep(100);
        //    }
        //}
    }
}
