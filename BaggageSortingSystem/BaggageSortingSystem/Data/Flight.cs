using System;
using System.Collections.Generic;
using System.Text;

namespace BaggageSortingSystem.Data
{
    public class Flight
    {
        private int _maxPassengers;
        private int _flightNumber;
        private int _waitTime;

        public Flight(int maxpassengers, int flightnumber, int waittime)
        {
            _maxPassengers = maxpassengers;
            _flightNumber = flightnumber;
            _waitTime = waittime;
        }

        public int GetWaitTime
        {
            get { return _waitTime; }
        }

        public int GetFlightNumber
        {
            get { return _flightNumber; }
        }

        public int CurrentPassengers { get; set; }

        public int GetMaxPassengers
        {
            get { return _maxPassengers; }
        }

    }
}
