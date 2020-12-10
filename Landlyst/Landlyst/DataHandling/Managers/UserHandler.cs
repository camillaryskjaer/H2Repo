using Landlyst.DataHandling.DataModel;
using Landlyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Managers
{
    public class UserHandler
    {
        private User _user;

        public UserHandler(User user)
        {
            _user = user;
        }

        public int GetPosition()
        {
            return _user.Position;
        }

        public string GetInitials()
        {
            return _user.Initials;
        }
    }
}
