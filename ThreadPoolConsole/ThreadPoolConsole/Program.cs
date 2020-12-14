using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadPoolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 2; i++)
            //{
            //    //ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            //    //ThreadPool.QueueUserWorkItem(new WaitCallback(Task2));
            //    ThreadPool.QueueUserWorkItem(Task1);
            //    ThreadPool.QueueUserWorkItem(Task2);
            //// Forskellen er at vew awaitcallback bliver tråden afviklet færdig inden den næste tråd tager over.
            //// Uden awaitcallback kørrer trådene som det passer dem.
            //}

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Threadpool execution");
            stopwatch.Start();
            ProcessWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by processwiththreadpool is : " + stopwatch.ElapsedMilliseconds + " milliseconds");
            stopwatch.Reset();

            Console.WriteLine("Thread execution");
            stopwatch.Start();
            ProcessWithThreadMethod();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by processwiththread is : " + stopwatch.ElapsedMilliseconds + " milliseconds");
            // ø1
            // Process methoden skal have object med, da threadpool skal bruge en waitcallback for at kunne køre
            // Det virker til at den waitcallback godt kan være tom
            // ø2
            // Tiden det tager bliver meget længere for almendelig tråd, hvor threadpool ændres tiden ikke ret meget.

            Console.ReadLine();
        }

        static void ProcessWithThreadPool()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int k = 0; k < 100000; k++)
                {

                }
            }
        }

        //static void Task1(object obj)
        //{
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        Console.WriteLine("Task 1 is being executed");
        //    }
        //}

        //static void Task2(object obj)
        //{
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        Console.WriteLine("Task 2 is being xecuted");
        //    }
        //}
    }
}
