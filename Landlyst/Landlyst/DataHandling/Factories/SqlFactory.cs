using Landlyst.DataHandling.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Factories
{
    public class SqlFactory
    {
        private static SqlFactory _instance;
        private SqlFactory() { }

        public static SqlFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlFactory();
                }
                return _instance;
            }
        }

        // this method needs to be reworked, to remove the new inside SQL class
        public SqlConnection GetSqlConnection()
        {
            return new SQL().GetConnection();
        }

        // this method needs to be reworked, to remove news inside of sqlcommands class
        public SqlCommands GetSqlCommands()
        {
            return new SqlCommands();
        }
    }
}
