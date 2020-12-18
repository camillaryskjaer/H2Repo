using BaggageSortingSystem.Data;
using BaggageSortingSystem.DataConsumers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaggageSortingSystem.DataHandling
{
    // class to simulate the baggage sorting system in the airport
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
                // locks to baggage
                lock (WaitingBaggage)
                {
                    // if there is any baggage
                    if (WaitingBaggage.Count != 0)
                    {
                        // try to get the lock
                        if (Monitor.TryEnter(WaitingBaggage))
                        {
                            // get baggage
                            baggage = WaitingBaggage.Dequeue();
                        }
                        else
                        {
                            // wait for baggage lock
                            Monitor.Wait(WaitingBaggage);

                            // get baggage
                            baggage = WaitingBaggage.Dequeue();
                        }
                    }
                    // tell other threads this one is done
                    Monitor.PulseAll(WaitingBaggage);

                    // release the lock and waits for it to be free again
                    Monitor.Wait(WaitingBaggage);
                }
                // if there was any baggage
                if (baggage != null)
                {
                    // if gate with baggage flightnumber exists
                    if (Gates.Exists(x => x.GetFlightNumber() == baggage.GetFlightNumber))
                    {
                        // locks to gate
                        lock (Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage)
                        {
                            // error handling
                            try
                            {
                                // try to get lock on gates baggage
                                if (Monitor.TryEnter(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage))
                                {
                                    // if the gate has less then 50 pieces of baggage
                                    if (Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Count < 50)
                                    {
                                        // insert baggage
                                        Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                                        Console.WriteLine("Sorter passed baggage " + baggage.GetBaggageNumber + " to gate " + Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).GetGateNumber());
                                    }
                                    else
                                    {
                                        // wait for the lock
                                        Monitor.Wait(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);

                                        // insert baggage 
                                        Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                                        Console.WriteLine("Sorter passed baggage " + baggage.GetBaggageNumber + " to gate " + Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).GetGateNumber());
                                    }
                                }
                                else
                                {
                                    // wait for the lock
                                    Monitor.Wait(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);

                                    // insert baggage
                                    Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage.Enqueue(baggage);
                                    Console.WriteLine("Sorter passed baggage " + baggage.GetBaggageNumber + " to gate " + Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).GetGateNumber());
                                }
                            }
                            catch (Exception)
                            {
                                // if the gate is closed throw the baggage out to lost and found
                                Console.WriteLine(baggage.GetBaggageNumber + "for flight " + baggage.GetFlightNumber + " was sent to lost and found");

                                // tells waiting threads this one is done
                                Monitor.PulseAll(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);

                                // exit the lock
                                Monitor.Exit(Gates.Find(x => x.GetFlightNumber() == baggage.GetFlightNumber).WaitingBaggage);

                                // resets the baggage
                                baggage = null;
                            }
                        }
                        // resets the baggage
                        baggage = null;
                    }
                    else
                    {
                        // if the gate is closed throw baggage to lost and found
                        Console.WriteLine(baggage.GetBaggageNumber + " for flight " + baggage.GetFlightNumber + " was sent to lost and found");

                        // resets the baggage
                        baggage = null;
                    }
                }
            }
        }
    }
}
