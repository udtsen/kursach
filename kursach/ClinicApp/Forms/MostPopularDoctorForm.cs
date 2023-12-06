using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    public partial class MostPopularDoctorForm : Form
    {
        private MySqlConnection connection;

        public MostPopularDoctorForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            GetMostPopularDoctor();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=clinic;Uid=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void GetMostPopularDoctor()
        {
            try
            {
                connection.Open();

                string popularDoctorQuery = "SELECT CONCAT(d.surname, ' ', d.name) AS full_name, COUNT(c.id) AS consultations_quantity " +
                                            "FROM Doctors d " +
                                            "LEFT JOIN Schedules s ON d.id = s.doctor_id " +
                                            "LEFT JOIN Consultations c ON s.id = c.schedule_id " +
                                            "GROUP BY full_name " +
                                            "ORDER BY consultations_quantity DESC " +
                                            "LIMIT 1";

                MySqlCommand command = new MySqlCommand(popularDoctorQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string fullName = reader["full_name"].ToString();
                    string consultationsQuantity = reader["consultations_quantity"].ToString();

                    lblPopularDoctor.Text = "Most Popular Doctor: " + fullName;
                    lblConsultations.Text = "Consultations Quantity: " + consultationsQuantity;
                }
                else
                {
                    lblPopularDoctor.Text = "No data available";
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
