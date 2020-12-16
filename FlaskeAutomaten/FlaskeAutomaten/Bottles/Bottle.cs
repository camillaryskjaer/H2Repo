using System;
using System.Collections.Generic;
using System.Text;

namespace FlaskeAutomaten.Bottles
{
    public abstract class Bottle
    {
        private string _bottleContent;
        private string _serialNumber;
        public Bottle(string content, string serialnumber)
        {
            _bottleContent = content;
            _serialNumber = serialnumber;
        }
        public string GetBottleContent()
        {
            return _bottleContent;
        }

        public string GetSerialNumber()
        {
            return _serialNumber;
        }
    }
}
