using System;
using System.Collections.Generic;
using System.Text;

namespace BirdsFlyingAroundApp
{
    // class for all types of birds
    public abstract class Bird
    {
        // fields for location
        private double _longitude;
        private double _latitude;

        public void SetLocation(double longitude, double latitude)
        {
            _longitude = longitude;
            _latitude = latitude;
        }

        public abstract void Draw();
    }
}
