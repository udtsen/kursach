using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    abstract class Doctor : Model
    {
        public string tableName = "Doctors";
        private string name;
        private string surname;
        private int experience;
        private string category;
        private string profile;


        public List<string> getPopularDoctor()
        {
            List<string> data = new List<string>();

            try
            {
                MySqlConnection connection = DB.getConnection();
                connection.Open();

                string query = "SELECT s.doctor_id, COUNT(s.doctor_id) as consultations_quantity " +
                               "FROM Schedules s " +
                               "RIGHT JOIN Consultations c ON c.schedule_id = s.id " +
                               "GROUP BY s.doctor_id " +
                               "ORDER BY consultations_quantity DESC " +
                               "LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(reader[0].ToString());
                }

                reader.Close(); // Close the reader
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DB.closeConnection(); // Close the connection in the finally block
            }

            return data;
        }

    }
}
