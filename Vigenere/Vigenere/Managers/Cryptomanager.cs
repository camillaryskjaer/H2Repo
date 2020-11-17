using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Vigenere.Algorithm;
using Vigenere.Hash;

namespace Vigenere
{
    class Cryptomanager
    {
        public byte[] GetHash(byte[] ToBeHashed)
        {
            Sha sha = new Sha();
            return sha.Hashing(ToBeHashed);
        }

        public string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[1024];
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
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
