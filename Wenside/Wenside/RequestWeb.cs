using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Wenside
{
    public class RequestWeb : IRequest
    {
        public string RequestData(string url)
        {
            string responseFromWeb;
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                responseFromWeb = reader.ReadToEnd();
            }
            response.Close();
            return responseFromWeb;
        }
    }
}
