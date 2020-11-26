using System;
using System.Collections.Generic;
using System.Text;

namespace LandlystUsers
{
    class User
    {
        public string Name { get; private set; }
        public string Initials { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public int Position { get; private set; }

        public User(string name, string initials, string password, string salt, int position)
        {
            Name = name;
            Initials = initials;
            Password = password;
            Salt = salt;
            Position = position;
        }
    }
}
