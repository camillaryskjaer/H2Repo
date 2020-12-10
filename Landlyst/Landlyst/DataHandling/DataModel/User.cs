using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.DataModel
{
    public class User
    {
        private string _initials;
        private int _position;

        public User(string Initials, int Position)
        {
            _initials = Initials;
            _position = Position;
        }

        public int Position
        {
            get { return _position; }
            private set
            {
                if (_position == 0)
                {
                    _position = value;
                }
            }
        }

        public string Initials
        {
            get { return _initials; }
            private set
            {
                if (_initials == null || _initials == string.Empty)
                {
                    _initials = value;
                }
            }
        }

    }
}
