using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.DataModel
{
    public class Utility
    {
        private int _pricePrDay;
        private string _name;

        public Utility(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
    }
}
