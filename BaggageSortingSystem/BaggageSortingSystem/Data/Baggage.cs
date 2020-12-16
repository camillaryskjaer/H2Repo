using System;
using System.Collections.Generic;
using System.Text;

namespace BaggageSortingSystem.Data
{
    public class Baggage
    {
        private int _baggageNumber;
        private int _flightNumber;

        public Baggage(int baggagenumber, int flightnumber)
        {
            _baggageNumber = baggagenumber;
            _flightNumber = flightnumber;
        }

        public int GetFlightNumber
        {
            get { return _flightNumber; }
        }

        public int GetBaggageNumber
        {
            get { return _baggageNumber; }
        }
    }
}
