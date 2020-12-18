using BaggageSortingSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaggageSortingSystem.DataProducers
{
    // singleton factory to create planes
    public class PlaneFactory
    {
        private static PlaneFactory _instance;
        private int _flightNumber = 0;
        private Random random = new Random();

        // constructor - no requirements
        private PlaneFactory()
        { }

        // returns the instance of the factory
        public static PlaneFactory Instance
        {
            get
            {
                // if there isnt a factory, create one
                if (_instance == null)
                {
                    _instance = new PlaneFactory();
                }
                return _instance;
            }
        }

        // creates a new plane
        public Flight NewFlight()
        {
            // creates a new plane, with flightnumber and a random life time
            Flight flight = new Flight(_flightNumber, random.Next(5000, 10001));
            _flightNumber++;
            return flight;
        }
    }
}
