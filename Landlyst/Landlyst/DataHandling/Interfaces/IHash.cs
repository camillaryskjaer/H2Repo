using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Interfaces
{
    public interface IHash
    {
        public byte[] GetHash(byte[] input);
    }
}
