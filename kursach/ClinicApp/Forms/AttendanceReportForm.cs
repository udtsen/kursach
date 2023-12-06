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
    public partial class AttendanceReportForm : Form
    {
        private MySqlConnection connection;

        public AttendanceReportForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            GenerateReport();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=clinic;Uid=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void GenerateReport()
        {
            try
            {
                connection.Open();

                string attendanceQuery = "SELECT d.id, d.surname, COUNT(c.id) AS appointments " +
                                         "FROM Doctors d " +
                                         "LEFT JOIN Schedules s ON d.id = s.doctor_id " +
                                         "LEFT JOIN Consultations c ON s.id = c.schedule_id " +
                                         "GROUP BY d.id, d.surname";

                MySqlCommand command = new MySqlCommand(attendanceQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<string[]> attendanceList = new List<string[]>();

                while (reader.Read())
                {
                    string doctorId = reader["id"].ToString();
                    string doctorSurname = reader["surname"].ToString();
                    string appointments = reader["appointments"].ToString();

                    string[] row = { doctorId, doctorSurname, appointments };
                    attendanceList.Add(row);
                }

                reader.Close();

                foreach (string[] row in attendanceList)
                {
                    ListViewItem item = new ListViewItem(row);
                    lvAttendance.Items.Add(item);
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
