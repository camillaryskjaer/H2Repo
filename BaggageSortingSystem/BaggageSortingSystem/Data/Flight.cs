using System;
using System.Collections.Generic;
using System.Text;

namespace BaggageSortingSystem.Data
{
    // class to simulate planes
    public class Flight
    {
        private int _flightNumber;
        private int _waitTime;

        // constructor that requires 2 numbers for identification and life time
        public Flight(int flightnumber, int waittime)
        {
            _flightNumber = flightnumber;
            _waitTime = waittime;
        }

        // returns the wait time of the plane
        public int GetWaitTime
        {
            get { return _waitTime; }
        }

        // returns the planes number
        public int GetFlightNumber
        {
            get { return _flightNumber; }
        }
    }
}
