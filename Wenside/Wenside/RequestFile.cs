using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wenside
{
    class RequestFile : IRequest
    {
        public string RequestData(string path)
        {
            string response = File.ReadAllText(path);
            return response;
        }
    }
}
