using Landlyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Managers
{
    public class TempUserHandler
    {
        private User User;

        public TempUserHandler(User user)
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
