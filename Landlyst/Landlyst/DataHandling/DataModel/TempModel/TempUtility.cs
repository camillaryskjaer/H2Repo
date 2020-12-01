using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.Models.TempModels
{
    public class TempUtility
    {
        private int _id;
        private string _name;

        public TempUtility(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
    }
}
