using BaggageSortingSystem.Data;
using BaggageSortingSystem.DataConsumers;
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
                // if gate with baggage flightnumber exists
                if (Gates.Exists(x => x.GetFlightNumber() == baggage.GetFlightNumber))
                {
                    lock (Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage)
                    {
                        if (Monitor.TryEnter(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage))
                        {
                            Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                        }
                        else
                        {
                            Monitor.Wait(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);
                            Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                        }
                    }
                }
                else
                {
                    // cw to lost and found
                }
            }
        }
    }
}
