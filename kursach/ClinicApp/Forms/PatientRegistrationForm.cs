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
    public partial class PatientRegistrationForm : Form
    {
        private MySqlConnection connection;

        public PatientRegistrationForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=clinic;Uid=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string surname = tbSurname.Text;
            int age = (int)nudAge.Value;
            int gender = rbMale.Checked ? 2 : (rbFemale.Checked ? 1 : 0);

            if (gender == 0)
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            try
            {
                connection.Open();

                string insertPatientQuery = "INSERT INTO Patients (name, surname, age, gender) " +
                                            "VALUES (@name, @surname, @age, @gender)";
                MySqlCommand insertPatientCommand = new MySqlCommand(insertPatientQuery, connection);
                insertPatientCommand.Parameters.AddWithValue("@name", name);
                insertPatientCommand.Parameters.AddWithValue("@surname", surname);
                insertPatientCommand.Parameters.AddWithValue("@age", age);
                insertPatientCommand.Parameters.AddWithValue("@gender", gender);

                int rowsAffected = insertPatientCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Patient application saved.");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to save patient application.");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            tbName.Text = "";
            tbSurname.Text = "";
            nudAge.Value = 0;
            rbMale.Checked = false;
            rbFemale.Checked = false;
        }
    }
}

