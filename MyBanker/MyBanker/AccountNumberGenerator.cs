using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class AccountNumberGenerator
    {
        Random random = new Random();
        public string GenerateAccountNumber(string prefix)
        {
            while (prefix.Length < 14)
            {
                prefix += random.Next(0, 10).ToString();
            }
            return prefix;
        }
    }
}
