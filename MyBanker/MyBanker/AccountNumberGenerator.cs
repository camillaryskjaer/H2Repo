using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class AccountNumberGenerator
    {
        // random number generator
        Random random = new Random();

        // method to generate account number
        public string GenerateAccountNumber(string prefix)
        {
            // ensures the number gets the correct length
            while (prefix.Length < 14)
            {
                // adds random number to account number
                prefix += random.Next(0, 10).ToString();
            }
            // returns account number
            return prefix;
        }
    }
}
