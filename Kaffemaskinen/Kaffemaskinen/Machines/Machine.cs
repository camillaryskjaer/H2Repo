using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Machines
{
    // template for machines
    public abstract class Machine
    {
        private string _name;

        // constructor for the machine
        public Machine(string Name)
        {
            _name = Name;
        }

        // method to get the name
        public string Name()
        {
            return _name;
        }
    }
}
