using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Machines.Accessories
{
    class FilterHolder
    {
        // size of the holder
        private double _size;

        // filter in the holder;
        public Filter Filter;

        public FilterHolder(double Size)
        {
            _size = Size;
        }

        public double CheckSize()
        {
            return _size;
        }

        public bool AddFilter(Filter filter)
        {
            if (filter.CheckSize() != _size)
            {
                return false;
            }
            else
            {
                Filter = filter;
                return true;
            }
        }

        public void RemoveFilter()
        {
            Filter = null;
        }
    }
}
