using BaggageSortingSystem.Data;
using BaggageSortingSystem.DataHandling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaggageSortingSystem.DataProducers
{
    // class to simulate check ins at the airport
    public class CheckIn
    {
        private int _number;

        // constructor that requires a number
        public CheckIn(int number)
        {
            _number = number;
        }

        // method to generate baggage
        public void Produce()
        {
            Random random = new Random();
            Baggage baggage = null;
            // thread method
            while (true)
            {
                // locks to the bagagge sorter
                lock (BaggageSorter._lock)
                {
                    // try to get the lock
                    if (Monitor.TryEnter(BaggageSorter._lock))
                    {
                        // locks to the gates
                        lock (BaggageSorter.Gates)
                        {
                            // try to get the lock
                            if (Monitor.TryEnter(BaggageSorter.Gates))
                            {
                                // if there is an open gate, produce baggage
                                if (BaggageSorter.Gates.Count != 0)
                                {
                                    baggage = new Baggage(BaggageSorter.BaggageNumber, BaggageSorter.Gates[random.Next(0, BaggageSorter.Gates.Count)].GetFlightNumber());
                                    BaggageSorter.BaggageNumber++;
                                }
                            }
                            else
                            {
                                // waits to get the lock on gates
                                Monitor.Wait(BaggageSorter.Gates);

                                // if there is a gate produce baggage
                                if (BaggageSorter.Gates.Count != 0)
                                {
                                    baggage = new Baggage(BaggageSorter.BaggageNumber, BaggageSorter.Gates[random.Next(0, BaggageSorter.Gates.Count)].GetFlightNumber());
                                    BaggageSorter.BaggageNumber++;
                                }
                            }
                            Monitor.PulseAll(BaggageSorter.Gates);
                            Monitor.Exit(BaggageSorter.Gates);
                        }
                    }
                    else
                    {
                        // waits to get the lock on baggagesorter
                        Monitor.Wait(BaggageSorter._lock);

                        // locks to gates
                        lock (BaggageSorter.Gates)
                        {
                            // try to get the lock on gates
                            if (Monitor.TryEnter(BaggageSorter.Gates))
                            {
                                // if there is an open gate produce baggage
                                if (BaggageSorter.Gates.Count != 0)
                                {
                                    baggage = new Baggage(BaggageSorter.BaggageNumber, BaggageSorter.Gates[random.Next(0, BaggageSorter.Gates.Count)].GetFlightNumber());
                                    BaggageSorter.BaggageNumber++;
                                }
                            }
                            else
                            {
                                // wait for the lock on gates
                                Monitor.Wait(BaggageSorter.Gates);

                                // if there is an open gate produce baggage
                                if (BaggageSorter.Gates.Count != 0)
                                {
                                    baggage = new Baggage(BaggageSorter.BaggageNumber, BaggageSorter.Gates[random.Next(0, BaggageSorter.Gates.Count)].GetFlightNumber());
                                    BaggageSorter.BaggageNumber++;
                                }
                            }
                            // tells all waiting threads this one is done
                            Monitor.PulseAll(BaggageSorter.Gates);

                            // release the lock
                            Monitor.Exit(BaggageSorter.Gates);
                        }
                    }
                    // tells all waiting thread this one is done
                    Monitor.PulseAll(BaggageSorter._lock);

                    // release the lock
                    Monitor.Exit(BaggageSorter._lock);
                }

                // if baggage is produced
                if (baggage != null)
                {
                    // locks to baggage
                    lock (BaggageSorter.WaitingBaggage)
                    {
                        // if there is less then 200 pieces of baggage
                        if (BaggageSorter.WaitingBaggage.Count < 201)
                        {
                            // try to get the lock on baggage
                            if (Monitor.TryEnter(BaggageSorter.WaitingBaggage))
                            {
                                // inserts the baggage
                                BaggageSorter.WaitingBaggage.Enqueue(baggage);
                                Console.WriteLine("Checkin " + _number + " made " + baggage.GetBaggageNumber + " for " + baggage.GetFlightNumber);
                            }
                            else
                            {
                                // waits for the lock on baggage
                                Monitor.Wait(BaggageSorter.WaitingBaggage);

                                // inserts the baggage
                                BaggageSorter.WaitingBaggage.Enqueue(baggage);
                                Console.WriteLine("Checkin " + _number + " made " + baggage.GetBaggageNumber + " for " + baggage.GetFlightNumber);
                            }

                        }
                        // resets the baggage
                        baggage = null;

                        // tells other thread this one is done
                        Monitor.PulseAll(BaggageSorter.WaitingBaggage);

                        // release the lock on baggage and waits for it to be free again
                        Monitor.Wait(BaggageSorter.WaitingBaggage);
                    }
                }
            }
        }
    }
}
