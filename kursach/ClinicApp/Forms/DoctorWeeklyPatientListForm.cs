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
    public partial class DoctorWeeklyPatientListForm : Form
    {
        private MySqlConnection connection;
        private int doctorId; // Assuming you'll pass the doctor's ID to this form
        private int selectedDoctorId;

        public DoctorWeeklyPatientListForm(int selectedDoctorId)
        {
            InitializeComponent();
            doctorId = selectedDoctorId;
            InitializeDatabaseConnection();
            GetWeeklyPatientList();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=clinic;Uid=root;";
            connection = new MySqlConnection(connectionString);
        }
        private void ComboBoxDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDoctors.SelectedItem != null)
            {
                selectedDoctorId = (int)cbDoctors.SelectedValue;
                GetWeeklyPatientList();
            }
        }

        private void GetWeeklyPatientList()
        {
            try
            {
                connection.Open();

                DateTime today = DateTime.Today;
                DateTime nextWeek = today.AddDays(7);

                string weeklyPatientQuery = "SELECT p.name, p.surname " +
                                            "FROM Patients p " +
                                            "INNER JOIN Consultations c ON p.id = c.patient_id " +
                                            "INNER JOIN Schedules s ON c.schedule_id = s.id " +
                                            "WHERE s.doctor_id = @doctorId AND s.date BETWEEN @startDate AND @endDate";

                MySqlCommand command = new MySqlCommand(weeklyPatientQuery, connection);
                command.Parameters.AddWithValue("@doctorId", doctorId);
                command.Parameters.AddWithValue("@startDate", today);
                command.Parameters.AddWithValue("@endDate", nextWeek);

                MySqlDataReader reader = command.ExecuteReader();

                List<string[]> patientList = new List<string[]>();

                while (reader.Read())
                {
                    string patientName = reader["name"].ToString();
                    string patientSurname = reader["surname"].ToString();

                    string[] row = { patientName, patientSurname };
                    patientList.Add(row);
                }

                reader.Close();

                foreach (string[] row in patientList)
                {
                    ListViewItem item = new ListViewItem(row);
                    lvWeeklyPatients.Items.Add(item);
                }
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
