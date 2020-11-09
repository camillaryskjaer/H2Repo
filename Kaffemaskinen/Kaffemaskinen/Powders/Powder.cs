using Kaffemaskinen.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Powders
{
    class Powder : IPowder
    {
        private string _name;

        public Powder(string Name)
        {
            _name = Name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
