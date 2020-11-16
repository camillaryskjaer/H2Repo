using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Vigenere.Algorithm;

namespace Vigenere
{
    class Cryptomanager
    {
        public byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[1024];
            rng.GetBytes(buffer);
            return buffer;
        }
        public string Encrypt(string Message, string Code, byte[] Salt)
        {
            return new Rinjdael().Encrypt(Message, Code, Salt);
        }

        public string Decrypt(string Message, string Code, byte[] Salt)
        {
            return new Rinjdael().Decrypt(Message, Code, Salt);
        }
    }
}
