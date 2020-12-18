using BaggageSortingSystem.DataConsumers;
using BaggageSortingSystem.DataHandling;
using BaggageSortingSystem.DataProducers;
using System.Collections.Generic;
using System.Threading;

namespace BaggageSortingSystem
{
    class Program
    {
        // testing purpose
        public static List<Thread> checkIns = new List<Thread>();
        public static List<Thread> gates = new List<Thread>();
        //
        static void Main(string[] args)
        {
            // thread on keys open close gates
            // no auto
            // open close gates and check ins


            Thread t = new Thread(() => BaggageSorter.SortBaggage());
            t.Start();

            // testing purpose
            t = new Thread(() => new KeyboardListener().Listen());
            t.Start();
            //

            //// creates i checkins for the system
            //for (int i = 1; i < 11; i++)
            //{
            //    // creates new checkin with number i
            //    CheckIn checkIn = new CheckIn(i);
            //    // creates new thread from checkin.produce
            //    t = new Thread(() => checkIn.Produce());
            //    // starts thread
            //    t.Start();
            //    // sleeps to avoid multiple threads being called the same
            //    // yes have tried that
            //    Thread.Sleep(10);
            //}
            //// creates i gates for the system
            //for (int i = 1; i < 11; i++)
            //{
            //    // creates new gate with number i
            //    Gate gate = new Gate(i);
            //    // creates new thread from gate.fillflight
            //    t = new Thread(() => gate.FillFlight());
            //    // starts thread
            //    t.Start();
            //    // sleps to avoid multiple threads being called the same
            //    // yes have tried that
            //    Thread.Sleep(10);
            //}

            while (true)
            {

            }
        }
    }
}
