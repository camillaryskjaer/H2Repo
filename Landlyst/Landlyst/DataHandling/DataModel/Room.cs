using Landlyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.DataModel
{
    public class Room
    {
        private int _number;
        private int _price;
        private int _status;
        private List<string> utilities;

        public Room(int number, int baseprice, int status)
        {
            _number = number;
            _price = baseprice;
            _status = status;
        }

        public int Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        public int Price
        {
            get { return _price; }
            private set { _price = value; }
        }
        public void AddPrice(int price)
        {
            _price += price;
        }

        public void SetUtilities(List<string> utils)
        {
            utilities = utils;
        }

        public List<string> GetUtilities()
        {
            return utilities;
        }

        public int Number
        {
            get { return _number; }
            private set { _number = value; }
        }
    }
}
