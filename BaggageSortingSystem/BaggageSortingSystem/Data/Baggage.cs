using System;
using System.Collections.Generic;
using System.Text;

namespace BaggageSortingSystem.Data
{
 // class to simulate baggage
    public class Baggage
    {
        private int _baggageNumber;
        private int _flightNumber;

        // constructor that requires two numbers for identification
        public Baggage(int baggagenumber, int flightnumber)
        {
            _baggageNumber = baggagenumber;
            _flightNumber = flightnumber;
        }

        // returns the flightnumber of the baggage
        public int GetFlightNumber
        {
            get { return _flightNumber; }
        }

        // returns the baggagenumber of the baggage
        public int GetBaggageNumber
        {
            get { return _baggageNumber; }
        }
    }
}
