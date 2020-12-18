using BaggageSortingSystem.Data;
using BaggageSortingSystem.DataHandling;
using BaggageSortingSystem.DataProducers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaggageSortingSystem.DataConsumers
{
    // class to simulate a gate in the airport
    public class Gate
    {
        private Flight _flight;
        public Queue<Baggage> WaitingBaggage = new Queue<Baggage>(50);
        private System.Timers.Timer timer = new System.Timers.Timer();
        private int _gateNumber;

        // method to handle baggage to the gate.
        public void FillFlight()
        {
            timer.Elapsed += Timer_Elapsed;
            // thread method
            while (true)
            {
                // if gate is open add to baggagesorters list of open gates
                if (GetStatus)
                {
                    lock (BaggageSorter.Gates)
                    {
                        if (Monitor.TryEnter(BaggageSorter.Gates))
                        {
                            BaggageSorter.Gates.Add(this);
                        }
                        else
                        {
                            Monitor.Wait(BaggageSorter.Gates);
                            BaggageSorter.Gates.Add(this);
                        }
                        Monitor.PulseAll(BaggageSorter.Gates);
                        Monitor.Exit(BaggageSorter.Gates);
                    }
                    // while the gate is open, get baggage to th plane
                    while (GetStatus)
                    {
                        if (WaitingBaggage.Count != 0)
                        {
                            Baggage baggage = WaitingBaggage.Dequeue();
                            Console.WriteLine(baggage.GetBaggageNumber + " made it to flight " + baggage.GetFlightNumber);
                        }
                    }

                }
                // if gate is closed remove from baggagesorters list of gates
                else
                {
                    lock (BaggageSorter.Gates)
                    {
                        // removes gate from gates list
                        if (Monitor.TryEnter(BaggageSorter.Gates))
                        {
                            BaggageSorter.Gates.Remove(this);
                        }
                        else
                        {
                            Monitor.Wait(BaggageSorter.Gates);
                            BaggageSorter.Gates.Remove(this);
                        }
                        Monitor.PulseAll(BaggageSorter.Gates);
                        Monitor.Exit(BaggageSorter.Gates);
                    }
                    // get new timer interval and flight
                    lock (PlaneFactory.Instance)
                    {
                        if (Monitor.TryEnter(PlaneFactory.Instance))
                        {
                            _flight = PlaneFactory.Instance.NewFlight();
                        }
                        else
                        {
                            Monitor.Wait(PlaneFactory.Instance);
                            _flight = PlaneFactory.Instance.NewFlight();
                        }
                        try
                        {
                            // SynchronizationLockException
                            // object sync method was called from an unsynced block of code
                            Monitor.PulseAll(PlaneFactory.Instance);
                            Monitor.Exit(PlaneFactory.Instance);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    // starts the timer and opens the gate
                    Console.WriteLine("new flight on gate " + _gateNumber);
                    // exception can come on set interval
                    timer.Interval = _flight.GetWaitTime;
                    timer.Start();
                    GetStatus = true;
                }
            }
        }

        // returns the gatenumber
        public Gate(int gatenumber)
        {
            _gateNumber = gatenumber;
        }

        // timer elapsed evetn
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // closes the gate
            GetStatus = false;
            timer.Stop();
        }

        // returns the status of the gate open/closed
        public bool GetStatus { get; private set; }

        // returns the current flights number
        public int GetFlightNumber()
        {
            return _flight.GetFlightNumber;
        }

        // returns the gate number
        public int GetGateNumber()
        {
            return _gateNumber;
        }
    }
}
