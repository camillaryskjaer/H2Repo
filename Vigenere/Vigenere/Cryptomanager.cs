using System;
using System.Collections.Generic;
using System.Text;
using Vigenere.Algorithm;

namespace Vigenere
{
    class Cryptomanager
    {
        public string Encrypt(ICrypto Algorithm, string Message, string Code)
        {
            return Algorithm.Encrypt(Message, Code, new StringBuilder());
        }

        public string Decrypt(ICrypto Algorithm, string Message, string Code)
        {
            return Algorithm.Decrypt(Message, Code, new StringBuilder());
        }
    }
}
