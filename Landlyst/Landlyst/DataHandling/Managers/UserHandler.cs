using Landlyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Managers
{
    public class UserHandler
    {
        private User User;

        public UserHandler(User user)
        {
            User = user;
        }

        public int GetPosition()
        {
            return User.Position;
        }

        public string GetInitials()
        {
            return User.Initials;
        }
    }
}
