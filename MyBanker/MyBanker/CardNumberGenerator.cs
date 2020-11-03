using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    class CardNumberGenerator
    {
        // random number generator
        Random random = new Random();

        // method to generate card number
        public string GenerateCardNumber(string prefix, int length)
        {
            // runs till the number is long enough
            while (prefix.Length > length)
            {
                // adds generated number to string
                prefix += random.Next(0, 10).ToString();
            }
            // returns the card number
            return prefix;
        }
    }
}
