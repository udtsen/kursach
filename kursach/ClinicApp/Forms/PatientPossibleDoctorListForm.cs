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
    public partial class PatientPossibleDoctorListForm : Form
    {
        private MySqlConnection connection;
        private string patientSpecialization; // Assuming you have this value for patient's preferred specialization
        private string patientGender; // Assuming you have this value for patient's gender

        public PatientPossibleDoctorListForm(string specialization, string gender)
        {
            InitializeComponent();
            patientSpecialization = specialization;
            patientGender = gender;
            InitializeDatabaseConnection();
            GetPossibleDoctorsList();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=clinic;Uid=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void GetPossibleDoctorsList()
        {
            try
            {
                connection.Open();

                // Assuming you have a table 'Schedules' with available doctors and their schedules
                string query = "SELECT DISTINCT d.name, d.surname " +
                               "FROM Doctors d " +
                               "INNER JOIN Schedules s ON d.id = s.doctor_id " +
                               "INNER JOIN Profiles p ON d.profile_id = p.id " +
                               "WHERE p.title = @patientSpecialization AND gender = @patientGender";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@patientSpecialization", patientSpecialization);
                command.Parameters.AddWithValue("@patientGender", patientGender);

                MySqlDataReader reader = command.ExecuteReader();

                List<string> doctorsList = new List<string>();

                while (reader.Read())
                {
                    string doctorName = reader["name"].ToString();
                    string doctorSurname = reader["surname"].ToString();
                    string fullName = $"{doctorName} {doctorSurname}";
                    doctorsList.Add(fullName);
                }

                reader.Close();

                lbPossibleDoctors.Items.AddRange(doctorsList.ToArray());
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
