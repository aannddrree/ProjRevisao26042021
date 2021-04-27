using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DB : IDisposable
    {
        private SqlConnection conn;

        public DB()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionSQLServer"].ConnectionString);
            conn.Open();
        }


        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public bool ExecQuery(string query)
        {
            var cmd = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conn
            };

            return (cmd.ExecuteNonQuery() == 1) ? true : false;
        }

        public SqlDataReader ExecQueryReturn(string query) 
        {
            var cmd = new SqlCommand(query, conn);
            return cmd.ExecuteReader();
        }
    }
}
