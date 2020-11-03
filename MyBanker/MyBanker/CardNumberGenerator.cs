using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    class CardNumberGenerator
    {
        Random random = new Random();

        public string GenerateCardNumber(string prefix, int length)
        {
            while (prefix.Length > length)
            {
                prefix += random.Next(0, 10).ToString();
            }
            return prefix;
        }
    }
}
