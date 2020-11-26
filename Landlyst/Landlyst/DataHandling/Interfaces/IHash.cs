using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Interfaces
{
    interface IHash
    {
        public byte[] GetHash(byte[] input);
    }
}
