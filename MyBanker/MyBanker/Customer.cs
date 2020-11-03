using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class Customer
    {
        private string _name;
        private int _age;

        public Customer(string Name, int Age)
        {
            _name = Name;
            _age = Age;
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

    }
}
