using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Sql
{
    public class SqlCommands
    {
        public DataRowCollection GetAllRooms(SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec SelectAllRooms", sqlcon);
            da.SelectCommand = command;

            // Opens connection to database, and fills a dataset
            sqlcon.Open();
            da.Fill(ds);
            sqlcon.Close();

            // Collection containing found rows from sql command
            DataRowCollection rows = ds.Tables[0].Rows;

            return rows;
        }

        public DataRowCollection GetUtilities(SqlConnection con, int roomnumber)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec SelectUtilities @roomnumber", sqlcon);
            command.Parameters.AddWithValue("@roomnumber", roomnumber);
            da.SelectCommand = command;

            sqlcon.Open();
            da.Fill(ds);
            sqlcon.Close();

            DataRowCollection rows = ds.Tables[0].Rows;
            return rows;
        }

        public DataRowCollection GetSalt(SqlConnection con, string initials)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec SelectSalt @initials", sqlcon);
            command.Parameters.AddWithValue("@initials", initials);
            da.SelectCommand = command;

            sqlcon.Open();
            da.Fill(ds);
            sqlcon.Close();

            DataRowCollection rows = ds.Tables[0].Rows;
            return rows;
        }

        public DataRowCollection GetInitials(SqlConnection con, string password)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec SelectInitials @password", sqlcon);
            command.Parameters.AddWithValue("@password", password);
            da.SelectCommand = command;

            sqlcon.Open();
            da.Fill(ds);
            sqlcon.Close();

            DataRowCollection rows = ds.Tables[0].Rows;
            return rows;
        }

        public DataRowCollection GetPosition(SqlConnection con, string initials)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec SelectPosition @initials", sqlcon);
            command.Parameters.AddWithValue("@initials", initials);
            da.SelectCommand = command;

            sqlcon.Open();
            da.Fill(ds);
            sqlcon.Close();

            DataRowCollection rows = ds.Tables[0].Rows;
            return rows;
        }

        public void InsertBooking(SqlConnection con, string name, string address, int zipcode, string city, int phone, string email, DateTime rentedfrom, DateTime rentedto)
        {
            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec InsertBooking @name, @address, @zipcode, @city, @phone, @email, @rentedfrom, @rentedto", sqlcon);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@zipcode", zipcode);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@rentedfrom", rentedfrom);
            command.Parameters.AddWithValue("@rentedto", rentedto);

            sqlcon.Open();
            command.ExecuteNonQuery();
            sqlcon.Close();
        }

        public void InsertReservatedRooms(SqlConnection con, int reservationId, int roomNumber)
        {
            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec InsertReservatedRooms @reservationId, @roomNumber", sqlcon);
            command.Parameters.AddWithValue("@reservationId", reservationId);
            command.Parameters.AddWithValue("@roomNumber", roomNumber);

            sqlcon.Open();
            command.ExecuteNonQuery();
            sqlcon.Close();
        }

        public DataRowCollection GetReservationId(SqlConnection con, string name, int phone)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            SqlConnection sqlcon = con;
            SqlCommand command = new SqlCommand("exec SelectReservationId @name, @phone", sqlcon);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone", phone);
            da.SelectCommand = command;

            sqlcon.Open();
            da.Fill(ds);
            sqlcon.Close();

            return ds.Tables[0].Rows;
        }
    }
}
