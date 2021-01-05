using System;
using System.Collections.Generic;
using System.Text;

namespace HashedLogin
{
    public class File
    {
        string username;
        string hashedpassword;
        string salt;

        public void SetAccount(string uname, string hash, string salty)
        {
            username = uname;
            hashedpassword = hash;
            salt = salty;
        }

        public string GetSalt()
        {
            return salt;
        }

        public bool VerifyLogin(string uname, string password)
        {
            if (uname == username && hashedpassword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
