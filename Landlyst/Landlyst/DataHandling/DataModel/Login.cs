using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.DataModel
{
    // object class to handle user logins
    public class Login
    {
        private string _initials;
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

    }
}
