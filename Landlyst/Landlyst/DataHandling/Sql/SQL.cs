using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Landlyst.DataHandling.Sql
{
    public class SQL
    {
        // Connection string to local database
        private string conn = @"Server=DESKTOP-2D6TKBJ;Database=LandLyst;Trusted_Connection=True;";


        // move to sqlcommands
        public void SqlInsertCommand(SqlCommand command)
        {
            var sqlcon = new SqlConnection(conn); ;
            sqlcon.Open();
            command.Connection = sqlcon;
            command.ExecuteNonQuery();
            sqlcon.Close();
        }

        public SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(conn);
            return con;
        }
    }
}
