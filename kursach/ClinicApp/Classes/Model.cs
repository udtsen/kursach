using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    abstract class Model : DB
    {
        public string tableName;

        protected List<string> getAll()
        {
            List<string> data = new List<string>();

            try
            {
                MySqlConnection connection = DB.getConnection();
                connection.Open();

                string query = "SELECT * FROM " + this.tableName;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Assuming you want to get the first column from the result
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

        protected List<string> getById(int id)
        {
            List<string> data = new List<string>();

            try
            {
                MySqlConnection connection = DB.getConnection();
                connection.Open();

                string query = "SELECT * FROM " + this.tableName + " WHERE id=" + id;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Assuming you want to get the first column from the result
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

        protected void delete(int id)
        {
            bool deletionSuccess = false; // Declare deletionSuccess within the delete method

            try
            {
                MySqlConnection connection = DB.getConnection();
                connection.Open();

                string query = "DELETE FROM " + this.tableName + " WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                int rowsAffected = command.ExecuteNonQuery();
                deletionSuccess = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DB.closeConnection(); // Close the connection in the finally block
            }
        }
        protected void Save(string surname, string name, int experience, string specialization, string category)
        {
            try
            {
                MySqlConnection connection = DB.getConnection();
                connection.Open();

                // Save doctor information
                string queryDoctor = "INSERT INTO Doctors (Surname, Name, Experience, Category) " +
                                     "VALUES (@surname, @name, @experience, @category)";

                MySqlCommand commandDoctor = new MySqlCommand(queryDoctor, connection);
                commandDoctor.Parameters.AddWithValue("@surname", surname);
                commandDoctor.Parameters.AddWithValue("@name", name);
                commandDoctor.Parameters.AddWithValue("@experience", experience);
                commandDoctor.Parameters.AddWithValue("@category", category);

                int rowsAffectedDoctor = commandDoctor.ExecuteNonQuery();

                // Save specialization into 'profiles' table with column 'title'
                string queryProfile = "INSERT INTO profiles (title) VALUES (@title)";
                MySqlCommand commandProfile = new MySqlCommand(queryProfile, connection);
                commandProfile.Parameters.AddWithValue("@title", specialization); // Using 'title' for doctor's specialization in 'profiles' table

                int rowsAffectedProfile = commandProfile.ExecuteNonQuery();

                if (rowsAffectedDoctor > 0 && rowsAffectedProfile > 0)
                {
                    // Both doctor info and specialization saved successfully
                    // Handle success message or any further logic
                }
                else
                {
                    // Handle if either doctor info or specialization fails to save
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DB.closeConnection(); // Close the connection in the finally block
            }
        }
    }
}
