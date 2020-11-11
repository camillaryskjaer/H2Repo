using System;
using System.Collections.Generic;
using System.Text;

namespace Wenside
{
    public interface IRequest
    {
        string RequestData(string path);
    }
}
