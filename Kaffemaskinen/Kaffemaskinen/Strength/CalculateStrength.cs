using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Strength
{
    class CalculateStrength
    {
        public string CalculateBrewStrength(double waterAmount)
        {
            if (waterAmount <= 1)
            {
                return "espresso";
            }
            else if (waterAmount > 1 && waterAmount <= 3)
            {
                return "strong";
            }
            else if (waterAmount > 3 && waterAmount <= 6)
            {
                return "medium";
            }
            else if (waterAmount > 6)
            {
                return "mild";
            }
            return "unknown";
        }
    }
}
