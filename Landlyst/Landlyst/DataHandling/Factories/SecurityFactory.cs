using Landlyst.DataHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Factories
{
    public class SecurityFactory
    {
        private static SecurityFactory _instance;
        private SecurityFactory() { }

        public static SecurityFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SecurityFactory();
                }
                return _instance;
            }
        }

        public Rinjdael GetRinjdael()
        {
            return new Rinjdael();
        }

        public IHash GetHashing()
        {
            return new Sha256();
        }
    }
}
