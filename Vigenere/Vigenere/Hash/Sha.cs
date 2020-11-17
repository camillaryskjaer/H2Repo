using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Vigenere.Hash
{
    public class Sha
    {
        public byte[] Hashing(byte[] ToBeHashed)
        {
            SHA256Managed hasher = new SHA256Managed();
            return hasher.ComputeHash(ToBeHashed);
        }
    }
}
