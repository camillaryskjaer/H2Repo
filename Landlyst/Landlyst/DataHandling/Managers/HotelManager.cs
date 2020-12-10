using Landlyst.DataHandling.DataModel;
using Landlyst.DataHandling.Factories;
using Landlyst.DataHandling.Interfaces;
using Landlyst.DataHandling.Sql;
using Landlyst.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Landlyst.DataHandling.Managers
{
    public class HotelManager
    {
        private static HotelManager _instance;
        private UserHandler _userHandler;
        private HotelManager() { }

        public static HotelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HotelManager();
                }
                return _instance;
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

        public Rooms GetRooms()
        {
            Rooms rooms = new Rooms();
            SqlConnection sqlConnection = SqlFactory.Instance.GetSqlConnection();
            SqlCommands sqlCommands = new SqlCommands();

            DataRowCollection data = sqlCommands.GetAllRooms(sqlConnection);
            foreach (DataRow row in data)
            {
                // rewrite to handle total price, and utilities
                // 0 = number
                // 1 = price pr day
                // 2 = status
                Room room = new Room((int)row[0], (int)row[1], (int)row[2]);

                DataRowCollection foundUtilities = sqlCommands.GetUtilities(sqlConnection, (int)row[0]);
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

        public void BookRooms(string data, string rooms)
        {
            SqlConnection sqlConnection = SqlFactory.Instance.GetSqlConnection();
            SqlCommands sqlCommands = SqlFactory.Instance.GetSqlCommands();

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
            sqlCommands.InsertBooking(sqlConnection, x[0], x[1], int.Parse(x[2]), x[3], int.Parse(x[4]), x[5], DateTime.Parse(x[6]), DateTime.Parse(x[7]));

            // rooms : number - string
            // last string in rooms is empty
            DataRowCollection dataRows = sqlCommands.GetReservationId(sqlConnection, x[0], int.Parse(x[4]));
            DataRow dataRow = dataRows[0];
            int y = (int)dataRow[0];
            string[] roomnumbers = rooms.Split(',');
            for (int i = 0; i < roomnumbers.Length - 1; i++)
            {
                sqlCommands.InsertReservatedRooms(sqlConnection, y, int.Parse(roomnumbers[i]));
            }
        }

        public bool ConfirmUser(string initials, string password)
        {
            SqlConnection sqlConnection = SqlFactory.Instance.GetSqlConnection();
            SqlCommands sqlCommands = SqlFactory.Instance.GetSqlCommands();
            Rinjdael rinjdael = SecurityFactory.Instance.GetRinjdael();
            IHash sha = SecurityFactory.Instance.GetHashing();

            try
            {
                // converts salt to string
                DataRow row = sqlCommands.GetSalt(sqlConnection, initials)[0];
                string salt = row[0].ToString();

                row = sqlCommands.GetInitials(sqlConnection, Convert.ToBase64String(sha.GetHash(Convert.FromBase64String(rinjdael.Encrypt(password, "Landlyst", Convert.FromBase64String(salt))))))[0];
                string ini = row[0].ToString();

                if (initials == ini)
                {
                    row = sqlCommands.GetPosition(sqlConnection, ini)[0];
                    int pos = int.Parse(row[0].ToString());

                    _userHandler = new UserHandler(new User(ini, pos));

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
            return _userHandler.GetPosition();
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
