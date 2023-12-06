using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    class DB
    {
        private static MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=clinic;Uid=root;");

        public static void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public static void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public static MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
