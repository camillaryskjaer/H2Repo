using Kaffemaskinen.Interfaces;
using Kaffemaskinen.Machines.Accessories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Machines
{
    // template for a coffee machine
    class CoffeeMachine : Machine, IPower
    {
        // indicates if power is on of off
        private bool _power;

        // amount of water in the coffee machine
        private double _waterAmount;

        // pot to hold the coffee
        public Pot Pot;

        // holder for the filter
        public FilterHolder filterHolder;

        // constructor for a coffee machine
        public CoffeeMachine(string Name) : base(Name)
        {

        }

        // method to add a pot
        public void AddPot(Pot pot)
        {
            Pot = pot;
        }

        // method to remove the pot
        public Pot RemovePot()
        {
            Pot pot = Pot;
            Pot = null;
            return pot;
        }

        // method to add a filterholder
        public void AddFilterHolder(FilterHolder holder)
        {
            filterHolder = holder;
        }

        // method to remove the filterholder
        public FilterHolder RemoveFilterHolder()
        {
            FilterHolder holder = filterHolder;
            filterHolder = null;
            return holder;
        }

        // method to add water to coffee machine
        public void AddWater(Pot pot, double amount)
        {
            _waterAmount = pot.PourContent(amount);
        }

        // method to see if power is on or off
        public string CheckPower()
        {
            if (_power)
            {
                return "Power is on";
            }
            else
            {
                return "Power is off";
            }
        }

        // method to turn power off
        public void PowerOff()
        {
            _power = false;
        }

        // method to turn power on
        public void PowerOn()
        {
            _power = true;
            Brew();
        }

        private void Brew()
        {
            if (this.filterHolder.Filter != null)
            {
                Pot.AddContent(_waterAmount, filterHolder.Filter.Content.GetName());
            }
            else if (this.filterHolder.Filter == null)
            {
                Pot.AddContent(_waterAmount, filterHolder.Filter.Content.GetName() + " ground");
            }
            else
            {
                Pot.AddContent(_waterAmount, "Water");
            }
        }
    }
}
