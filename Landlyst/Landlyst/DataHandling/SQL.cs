using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Landlyst.DataHandling
{
    public class SQL
    {
        // Connection string to local database
        string conn = @"Server=DESKTOP-2D6TKBJ;Database=LandLyst;Trusted_Connection=True;";
        public DataRowCollection SqlSelectCommand(SqlCommand command)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            // Need sql credentials in the sql connection
            var sqlcon = new SqlConnection(conn);
            DataSet ds = new DataSet();
            command.Connection = sqlcon;
            da.SelectCommand = command;

            // Opens connection to database, and fills a dataset
            sqlcon.Open();
            da.Fill(ds);
            sqlcon.Close();

            // Collection containing found rows from sql command
            DataRowCollection rows = ds.Tables[0].Rows;

            // Used to manually check the incomming data from database(Debugging)
            //foreach (DataRow r in rows)
            //{
            //    var id = r[1];
            //    var name = r[0];
            //}

            return rows;
        }

        public void SqlInsertCommand(SqlCommand command)
        {
            var sqlcon = new SqlConnection(conn); ;
            sqlcon.Open();
            command.Connection = sqlcon;
            command.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
