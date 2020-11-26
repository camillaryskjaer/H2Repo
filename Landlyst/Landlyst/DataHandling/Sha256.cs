using Landlyst.DataHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Landlyst.DataHandling
{
    public class Sha256 : IHash
    {
        public byte[] GetHash(byte[] input)
        {
            SHA256Managed hasher = new SHA256Managed();
            return hasher.ComputeHash(input);
        }
    }
}
