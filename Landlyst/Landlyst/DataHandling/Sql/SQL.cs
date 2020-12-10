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
        private string _con = @"Server=DESKTOP-2D6TKBJ;Database=LandLyst;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(_con);
            return con;
        }
    }
}
