using Kaffemaskinen.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Machines.Accessories
{
    class Filter
    {
        // tells the size of the filter
        private double _size;

        public IPowder Content { get; private set; }

        // constructor for the filter
        public Filter(double Size)
        {
            _size = Size;
        }

        // method to add coffee beans to the filter
        public void AddContent(IPowder content)
        {
            Content = content;
        }

        public double CheckSize()
        {
            return _size;
        }

        // method to check if there is ceffee beens in the filter
        public string CheckForContent()
        {
            return Content.GetName();
        }
    }
}
