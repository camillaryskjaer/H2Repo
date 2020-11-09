using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Machines.Accessories
{
    class Pot
    {
        // tells the size of the pot
        public double CupSize;

        // tells the amount of content in the pot
        private double _contentAmount;

        // gets or sets the content of the pot
        public string Content { get; set; }

        // constructor for the pot
        public Pot(double cupSize)
        {
            CupSize = cupSize;
        }

        // adds content to pot
        public bool AddContent(double amount, string content)
        {
            Content = content;
            if (_contentAmount + amount <= CupSize)
            {
                _contentAmount += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        // pours content
        public double PourContent(double amount)
        {
            if (_contentAmount - amount >= 0)
            {
                _contentAmount -= amount;
                return amount;
            }
            else
            {
                double all = _contentAmount;
                _contentAmount = 0;
                return all;
            }

        }

        public string[] CheckContent()
        {
            return new string[] { Content, _contentAmount.ToString() };
        }
    }
}
