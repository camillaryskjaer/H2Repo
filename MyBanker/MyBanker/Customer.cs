using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class Customer
    {
        // properties
        private string _name;
        private int _age;

        // constructor for customer class
        public Customer(string Name, int Age)
        {
            _name = Name;
            _age = Age;
        }

        // method to get the age
        public int Age
        {
            get { return _age; }
            private set { _age = value; }
        }

        // method to get the name
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

    }
}
