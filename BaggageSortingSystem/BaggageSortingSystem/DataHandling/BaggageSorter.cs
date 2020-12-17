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
            Baggage baggage = null;
            // thread method
            while (true)
            {
                lock (WaitingBaggage)
                {
                    if (WaitingBaggage.Count != 0)
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
                    }
                    // unsync code block
                    Monitor.PulseAll(WaitingBaggage);
                    Monitor.Wait(WaitingBaggage);
                    // becomes too slow
                    // Monitor.Exit(WaitingBaggage);
                }
                // if there was any baggage
                if (baggage != null)
                {
                    // if gate with baggage flightnumber exists
                    if (Gates.Exists(x => x.GetFlightNumber() == baggage.GetFlightNumber))
                    {
                        lock (Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage)
                        {
                            try
                            {
                                if (Monitor.TryEnter(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage))
                                {
                                    if (Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Count < 50)
                                    {
                                        Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                                        Console.WriteLine("Sorter passed baggage " + baggage.GetBaggageNumber + " to gate " + Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).GetGateNumber());
                                    }
                                    else
                                    {
                                        Monitor.Wait(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);
                                        Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                                        Console.WriteLine("Sorter passed baggage " + baggage.GetBaggageNumber + " to gate " + Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).GetGateNumber());
                                    }
                                }
                                else
                                {
                                    Monitor.Wait(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);
                                    Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                                    Console.WriteLine("Sorter passed baggage " + baggage.GetBaggageNumber + " to gate " + Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).GetGateNumber());
                                }
                                try
                                {
                                    // object red not set to instance of object // null ref
                                    Monitor.PulseAll(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);
                                    Monitor.Exit(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(baggage.GetBaggageNumber + "for flight " + baggage.GetFlightNumber + " was sent to lost and found");
                                Monitor.PulseAll(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);
                                Monitor.Exit(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);
                                baggage = null;
                            }
                        }
                        baggage = null;
                    }
                    else
                    {
                        Console.WriteLine(baggage.GetBaggageNumber + " for flight " + baggage.GetFlightNumber + " was sent to lost and found");
                        baggage = null;
                        // cw to lost and found
                    }
                }
            }
        }
    }
}
