using Landlyst.DataHandling.DataModel;
using Landlyst.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Managers
{
    public class HotelManager
    {
        private static HotelManager instance;
        private UserHandler userHandler;
        private HotelManager() { }

        public static HotelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HotelManager();
                }
                return instance;
            }
        }

        public Rooms GetRooms()
        {
            Rooms rooms = new Rooms();
            SQL sQL = new SQL();
            SqlCommand command = sQL.CreateCommand();
            command.CommandText = "Select * From Rooms";
            DataRowCollection data = sQL.SqlSelectCommand(command);
            foreach (DataRow row in data)
            {
                // rewrite to handle total price, and utilities
                // 0 = number
                // 1 = price pr day
                // 2 = status
                command = sQL.CreateCommand();
                command.CommandText = "Select Name, PricePrDay From Utility Where Id In (Select UtilityId From Utilities Where RoomNumber = @roomnumber)";
                command.Parameters.AddWithValue("@roomnumber", (int)row[0]);

                Room room = new Room((int)row[0], (int)row[1], (int)row[2]);

                DataRowCollection foundUtilities = sQL.SqlSelectCommand(command);
                List<string> utils = new List<string>();
                foreach (DataRow util in foundUtilities)
                {
                    utils.Add((string)util[0]);
                    room.AddPrice((int)util[1]);
                }
                room.SetUtilities(utils);
                rooms.rooms.Add(room);
            }
            return rooms;
        }

        public bool ConfirmUser(string initials, string password)
        {
            SQL sQL = new SQL();
            Rinjdael rinjdael = new Rinjdael();
            Sha256 sha = new Sha256();

            try
            {
                // creates sqlcommand to get the salt of user logging in
                SqlCommand command = sQL.CreateCommand();
                command.CommandText = @"Select Salt From Users Where Initials=@initials";
                command.Parameters.AddWithValue("@initials", initials);

                // converts salt to string
                DataRow row = sQL.SqlSelectCommand(command)[0];
                string salt = row[0].ToString();

                // "creates" sqlcommand to get the initials of the user logging in, based on the password entered.
                command.Parameters.Clear();
                command.CommandText = @"Select Initials From Users Where Password=@password";
                command.Parameters.AddWithValue("@password", Convert.ToBase64String(sha.GetHash(Convert.FromBase64String(rinjdael.Encrypt(password, "Landlyst", Convert.FromBase64String(salt))))));
                row = sQL.SqlSelectCommand(command)[0];
                string ini = row[0].ToString();

                if (initials == ini)
                {
                    // "creates" sqlcommand to get the position of the user loggin in
                    command.Parameters.Clear();
                    command.CommandText = @"Select Position From Users Where Initials=@initials";
                    command.Parameters.AddWithValue("@initials", ini);

                    row = sQL.SqlSelectCommand(command)[0];
                    int pos = int.Parse(row[0].ToString());

                    userHandler = new UserHandler(new User(ini, pos));

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        public int GetUserPosition()
        {
            return userHandler.GetPosition();
        }
    }
}
