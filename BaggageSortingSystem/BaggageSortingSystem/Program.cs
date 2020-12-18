using BaggageSortingSystem.DataConsumers;
using BaggageSortingSystem.DataHandling;
using BaggageSortingSystem.DataProducers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BaggageSortingSystem
{
    class Program
    {
        // lists for manual
        public static List<CheckIn> checkIns = new List<CheckIn>();
        public static List<Gate> gates = new List<Gate>();

        // to keep the console alive
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            // would like this explained
            Console.CancelKeyPress += (sender, eArgs) =>
            {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            Thread t = new Thread(() => BaggageSorter.SortBaggage());
            t.Start();

            // thread for keyinput
            t = new Thread(() => new KeyboardListener().Listen());
            t.Start();
            
            // creates i checkins for the system
            for (int i = 1; i < 5; i++)
            {
                // creates new checkin with number i
                CheckIn checkIn = new CheckIn(i);
                // creates new thread from checkin.produce
                t = new Thread(() => checkIn.Produce());
                // starts thread
                t.Start();
                // sleeps to avoid multiple threads being called the same
                // yes have tried that
                Thread.Sleep(10);
            }
            // creates i gates for the system
            for (int i = 1; i < 5; i++)
            {
                // creates new gate with number i
                Gate gate = new Gate(i);
                // creates new thread from gate.fillflight
                t = new Thread(() => gate.FillFlight());
                // starts thread
                t.Start();
                // sleps to avoid multiple threads being called the same
                // yes have tried that
                Thread.Sleep(10);
            }

            // blocks the thread
            _quitEvent.WaitOne();
        }
    }
}
