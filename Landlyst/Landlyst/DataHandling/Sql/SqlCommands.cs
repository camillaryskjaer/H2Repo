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
    }
}
