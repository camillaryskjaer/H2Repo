using System;
using System.Collections.Generic;
using System.Text;

namespace Wenside
{
    public class Factory
    {
        public IRequest RequestWebsite()
        {
            return new RequestWeb();
        }
        public IRequest RequestFile()
        {
            return new RequestFile();
        }
    }
}
