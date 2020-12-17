using BaggageSortingSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaggageSortingSystem.DataProducers
{
    public class PlaneFactory
    {
        private static PlaneFactory _instance;
        private int _flightNumber = 0;
        private Random random = new Random();

        private PlaneFactory()
        { }

        public static PlaneFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlaneFactory();
                }
                return _instance;
            }
        }

        public Flight NewFlight()
        {
            Flight flight = new Flight(random.Next(50, 201), _flightNumber, random.Next(5000, 10001));
            _flightNumber++;
            return flight;
        }
    }
}
