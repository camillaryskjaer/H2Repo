using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.DataModel.TempModel
{
    public class TempRoom
    {
        private int _number;
        private int _basePrice;
        private int _status;

        public TempRoom(int number, int baseprice, int status)
        {
            _number = number;
            _basePrice = baseprice;
            _status = status;
        }

        public int Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        public int BasePrice
        {
            get { return _basePrice; }
            private set { _basePrice = value; }
        }

        public int Number
        {
            get { return _number; }
            private set { _number = value; }
        }
    }
}
