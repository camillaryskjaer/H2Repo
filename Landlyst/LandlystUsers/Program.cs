﻿using Landlyst.DataHandling;
using Landlyst.DataHandling.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LandlystUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();
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
                rooms.Add(room);
            }
            List<Room> test = new List<Room>();
            string[] ar = new string[] { "Balcony", "Multiple beds" };
            foreach (Room r in rooms)
            {
                bool all = false;
                foreach (string s in ar)
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
                    test.Add(r);
                }
            }
            Console.ReadLine();

            //        while (true)
            //    {
            //        SQL sQL = new SQL();
            //        Rinjdael rinjdael = new Rinjdael();
            //        Sha256 sha = new Sha256();
            //        string code = "Landlyst";

            //        Console.WriteLine("Press 1 for new user");
            //        Console.WriteLine("Press 2 for edit user");
            //        Console.WriteLine("Press 3 for delete user");

            //        switch (int.Parse(Console.ReadLine()))
            //        {

            //            case 1:
            //                Console.Clear();

            //                // Generate salt
            //                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            //                byte[] buffer = new byte[128];
            //                rng.GetBytes(buffer);

            //                // prompts for username
            //                Console.WriteLine("Enter name of user");
            //                string name = Console.ReadLine();

            //                // prompts for initials
            //                Console.WriteLine("Enter initials of user");
            //                string initials = Console.ReadLine();

            //                // prompts for password
            //                Console.WriteLine("Enter users password");
            //                string pass = Console.ReadLine();
            //                pass = rinjdael.Encrypt(pass, code, buffer);
            //                pass = Convert.ToBase64String(sha.GetHash(Convert.FromBase64String(pass)));

            //                // prompts for position
            //                Console.WriteLine("Enter position code for user");
            //                int pos = int.Parse(Console.ReadLine());


            //                User user = new User(name, initials, pass, Convert.ToBase64String(buffer), pos);

            //                SqlCommand command = new SqlCommand();
            //                command.CommandText = "insert into Users(Name, Initials, Password, Salt, Position) values (@Name, @Initials, @Password, @Salt, @Position)";
            //                command.Parameters.AddWithValue("@Name", user.Name);
            //                command.Parameters.AddWithValue("@Initials", user.Initials);
            //                command.Parameters.AddWithValue("@Password", user.Password);
            //                command.Parameters.AddWithValue("@Salt", user.Salt);
            //                command.Parameters.AddWithValue("@Position", user.Position);

            //                sQL.SqlInsertCommand(command);
            //                break;
            //            case 2:
            //                Console.Clear();
            //                break;
            //            case 3:
            //                Console.Clear();
            //                break;
            //            default:
            //                Console.Clear();
            //                Console.WriteLine("Input error occurred");
            //                Console.WriteLine("Press enter to close program");
            //                Console.ReadLine();
            //                break;
            //        }
            //    }
        }
    }
}
