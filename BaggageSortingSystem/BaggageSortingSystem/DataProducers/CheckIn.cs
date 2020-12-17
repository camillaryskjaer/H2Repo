using BaggageSortingSystem.Data;
using BaggageSortingSystem.DataHandling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaggageSortingSystem.DataProducers
{
    public class CheckIn
    {
        private int _number;

        public CheckIn(int number)
        {
            _number = number;
        }

        public void Produce()
        {
            Random random = new Random();
            Baggage baggage = null;
            // thread method
            while (true)
            {
                lock (BaggageSorter._lock)
                {
                    if (Monitor.TryEnter(BaggageSorter._lock))
                    {
                        lock (BaggageSorter.Gates)
                        {
                            if (Monitor.TryEnter(BaggageSorter.Gates))
                            {
                                if (BaggageSorter.Gates.Count != 0)
                                {
                                    baggage = new Baggage(BaggageSorter.BaggageNumber, BaggageSorter.Gates[random.Next(0, BaggageSorter.Gates.Count)].GetFlightNumber());
                                    BaggageSorter.BaggageNumber++;
                                }
                            }
                            else
                            {
                                Monitor.Wait(BaggageSorter.Gates);
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
                        Monitor.Wait(BaggageSorter._lock);
                        lock (BaggageSorter.Gates)
                        {
                            if (Monitor.TryEnter(BaggageSorter.Gates))
                            {
                                if (BaggageSorter.Gates.Count != 0)
                                {
                                    baggage = new Baggage(BaggageSorter.BaggageNumber, BaggageSorter.Gates[random.Next(0, BaggageSorter.Gates.Count)].GetFlightNumber());
                                    BaggageSorter.BaggageNumber++;
                                }
                            }
                            else
                            {
                                Monitor.Wait(BaggageSorter.Gates);
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
                    Monitor.PulseAll(BaggageSorter._lock);
                    Monitor.Exit(BaggageSorter._lock);
                }

                if (baggage != null)
                {
                    lock (BaggageSorter.WaitingBaggage)
                    {
                        if (BaggageSorter.WaitingBaggage.Count < 201)
                        {
                            if (Monitor.TryEnter(BaggageSorter.WaitingBaggage))
                            {
                                BaggageSorter.WaitingBaggage.Enqueue(baggage);
                                Console.WriteLine("Checkin " + _number + " made " + baggage.GetBaggageNumber + " for " + baggage.GetFlightNumber);
                            }
                            else
                            {
                                Monitor.Wait(BaggageSorter.WaitingBaggage);
                                BaggageSorter.WaitingBaggage.Enqueue(baggage);
                                Console.WriteLine("Checkin " + _number + " made " + baggage.GetBaggageNumber + " for " + baggage.GetFlightNumber);
                            }

                        }
                        baggage = null;
                        Monitor.PulseAll(BaggageSorter.WaitingBaggage);
                                                Monitor.Wait(BaggageSorter.WaitingBaggage);
                    }
                }
            }
        }
    }
}
