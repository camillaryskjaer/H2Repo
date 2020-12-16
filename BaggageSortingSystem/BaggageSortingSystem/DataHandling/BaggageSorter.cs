using BaggageSortingSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaggageSortingSystem.DataHandling
{
    public static class BaggageSorter
    {
        public static Queue<Baggage> WaitingBaggage = new Queue<Baggage>(200);
        public static List<Gate> Gates = new List<Gate>();
        public static object _lock = new object();
        public static int BaggageNumber = 0;

        public static void SortBaggage()
        {
            Baggage baggage;
            // thread method
            while (true)
            {
                lock (WaitingBaggage)
                {
                    if (Monitor.TryEnter(WaitingBaggage))
                    {
                        baggage = WaitingBaggage.Dequeue();
                    }
                    else
                    {
                        Monitor.Wait(WaitingBaggage);
                        baggage = WaitingBaggage.Dequeue();
                    }
                    Monitor.PulseAll(WaitingBaggage);
                    Monitor.Exit(WaitingBaggage);
                }
                // find the gate that has flightnumber
                // if none cw to lost and found
            }
        }
    }
}
