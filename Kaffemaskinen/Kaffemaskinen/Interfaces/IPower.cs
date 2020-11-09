using System;
using System.Collections.Generic;
using System.Text;

namespace Kaffemaskinen.Interfaces
{
    // interface for electric machines
    interface IPower
    {
        public void PowerOn();
        public void PowerOff();
    }
}
