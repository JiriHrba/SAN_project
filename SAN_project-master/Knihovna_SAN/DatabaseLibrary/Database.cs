using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace DatabaseLibrary 
{
    public class Database:IDisposable
    {
        private static String ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        private SqlConnection connection = new SqlConnection(ConnectionString);

        public Database()
        {
            connection.Open();
        }

        public SqlCommand CreateCmd(String command)
        {

            return new SqlCommand(command, connection);
        }

        public SqlDataReader Select(SqlCommand command)
        {
            command.Prepare();
            return command.ExecuteReader();
        }

        public void NonQuery(SqlCommand command)
        {
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
