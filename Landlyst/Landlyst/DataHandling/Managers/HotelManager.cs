using Landlyst.DataHandling.DataModel;
using Landlyst.DataHandling.Sql;
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

        public Rooms GetRooms(string searchBy)
        {
            // if there is searched for nothing
            // return all rooms again
            if (searchBy == null || searchBy == string.Empty)
            {
                return GetRooms();
            }

            Rooms rooms = GetRooms();

            List<Room> searchResult = new List<Room>();

            string[] searchBySplit = searchBy.Split(',');
            IEnumerable<string> searchFor = searchBySplit.SkipLast(1);
            foreach (Room r in rooms.rooms)
            {
                bool all = false;
                foreach (string s in searchFor)
                {
                    if (r.GetUtilities().Contains(s))
                    {
                        all = true;
                    }
                    else
                    {
                        all = false;
                        break;
                    }
                }
                if (all)
                {
                    searchResult.Add(r);
                }

            }
            rooms.rooms = searchResult;
            return rooms;
        }

        public Rooms GetRooms(int[] numbers)
        {
            if (numbers.Count() > 0 && numbers != null)
            {
                Rooms rooms = GetRooms();
                List<Room> searchResult = new List<Room>();

                foreach (int number in numbers)
                {
                    searchResult.Add(rooms.rooms.Where(x => x.Number == number).FirstOrDefault());
                }
                rooms.rooms = searchResult;
                return rooms;

            }
            else
            {
                return null;
            }
        }

        public void BookRooms(string data, string rooms)
        {
            SQL sQL = new SQL();
            SqlCommands sqlCommands = new SqlCommands();

            // data:
            // 0 : name - string
            // 1 : address - string
            // 2 : zipcode - int
            // 3 : city - string
            // 4 : phone - int
            // 5 : email - string
            // 6 : from date - datetime
            // 7 : to date - datetime
            // last string in data is empty
            string[] x = data.Split(',');
            sqlCommands.InsertBooking(sQL.getConnection(), x[0], x[1], int.Parse(x[2]), x[3], int.Parse(x[4]), x[5], DateTime.Parse(x[6]), DateTime.Parse(x[7]));

            // rooms : number - string
            // last string in rooms is empty
            DataRowCollection dataRows = sqlCommands.GetReservationId(sQL.getConnection(), x[0], int.Parse(x[4]));
            DataRow dataRow = dataRows[0];
            int y = (int)dataRow[0];
            string[] roomnumbers = rooms.Split(',');
            for (int i = 0; i < roomnumbers.Length - 1; i++)
            {
                sqlCommands.InsertReservatedRooms(sQL.getConnection(), y, int.Parse(roomnumbers[i]));
            }
        }

        public Rooms GetRooms()
        {
            Rooms rooms = new Rooms();
            SQL sQL = new SQL();
            SqlCommands sqlCommands = new SqlCommands();

            DataRowCollection data = sqlCommands.GetAllRooms(sQL.getConnection());
            foreach (DataRow row in data)
            {
                // rewrite to handle total price, and utilities
                // 0 = number
                // 1 = price pr day
                // 2 = status
                Room room = new Room((int)row[0], (int)row[1], (int)row[2]);

                DataRowCollection foundUtilities = sqlCommands.GetUtilities(sQL.getConnection(), (int)row[0]);
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
            SqlCommands sqlCommands = new SqlCommands();
            Rinjdael rinjdael = new Rinjdael();
            Sha256 sha = new Sha256();

            try
            {
                // converts salt to string
                DataRow row = sqlCommands.GetSalt(sQL.getConnection(), initials)[0];
                string salt = row[0].ToString();

                row = sqlCommands.GetInitials(sQL.getConnection(), Convert.ToBase64String(sha.GetHash(Convert.FromBase64String(rinjdael.Encrypt(password, "Landlyst", Convert.FromBase64String(salt))))))[0];
                string ini = row[0].ToString();

                if (initials == ini)
                {
                    row = sqlCommands.GetPosition(sQL.getConnection(), ini)[0];
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

        public int[] SplitNumbers(string input)
        {
            string[] inputsplit = input.Split(',');

            int[] res = new int[inputsplit.Length - 1];
            for (int i = 0; i < inputsplit.Length - 1; i++)
            {
                res[i] = int.Parse(inputsplit[i]);
            }
            return res;
        }
    }
}
