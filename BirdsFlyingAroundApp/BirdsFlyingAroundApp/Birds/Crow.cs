using BirdsFlyingAroundApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdsFlyingAroundApp.Birds
{
    class Crow : Bird, IFly
    {
        private double _altitude;
        public override void Draw()
        {
            // draws this bird on screen
        }

        public void SetAltitude(double altitude)
        {
            _altitude = altitude;
        }
    }
}
