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
using System.Xml.Linq;

namespace ClinicApp.Forms
{
    public partial class DoctorInformationForm : Form
    {
        private MySqlConnection connection;

        public DoctorInformationForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();

            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            LoadSpecializations();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=clinic;Uid=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void LoadSpecializations()
        {
            try
            {
                string query = "SELECT title FROM Profiles";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cmbSpecialization.Items.Add(reader["title"].ToString());
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string surname = tbSurname.Text;
            string name = tbName.Text;
            int experience = (int)nudExperience.Value;
            string category = cmbCategory.Text;
            string specialization = cmbSpecialization.Text;

            try
            {
                connection.Open();

                // Check if the specialization exists in profiles table
                string checkSpecializationQuery = "SELECT COUNT(*) FROM profiles WHERE title = @title";
                MySqlCommand checkSpecializationCommand = new MySqlCommand(checkSpecializationQuery, connection);
                checkSpecializationCommand.Parameters.AddWithValue("@title", specialization);

                int specializationCount = Convert.ToInt32(checkSpecializationCommand.ExecuteScalar());
                if (specializationCount == 0)
                {
                    // If the specialization doesn't exist, insert it into the profiles table
                    string insertSpecializationQuery = "INSERT INTO profiles (title) VALUES (@title)";
                    MySqlCommand insertSpecializationCommand = new MySqlCommand(insertSpecializationQuery, connection);
                    insertSpecializationCommand.Parameters.AddWithValue("@title", specialization);

                    int rowsAffected = insertSpecializationCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Specialization added to the profiles table.");
                        // Now proceed to retrieve the profile ID
                    }
                    else
                    {
                        MessageBox.Show("Failed to add specialization to the profiles table.");
                        return; // Exit without proceeding further
                    }
                }

                // Retrieve the profile ID
                string getProfileIdQuery = "SELECT id FROM profiles WHERE title = @title";
                MySqlCommand getProfileIdCommand = new MySqlCommand(getProfileIdQuery, connection);
                getProfileIdCommand.Parameters.AddWithValue("@title", specialization);

                object profileIdObj = getProfileIdCommand.ExecuteScalar();
                if (profileIdObj != null)
                {
                    int profileId = Convert.ToInt32(profileIdObj);

                    // Insert into Doctors table with the retrieved profile_id
                    string insertDoctorQuery = "INSERT INTO Doctors (Surname, Name, Experience, Category, profile_id) " +
                                               "VALUES (@surname, @name, @experience, @category, @profileId)";
                    MySqlCommand insertDoctorCommand = new MySqlCommand(insertDoctorQuery, connection);
                    insertDoctorCommand.Parameters.AddWithValue("@surname", surname);
                    insertDoctorCommand.Parameters.AddWithValue("@name", name);
                    insertDoctorCommand.Parameters.AddWithValue("@experience", experience);
                    insertDoctorCommand.Parameters.AddWithValue("@category", category);
                    insertDoctorCommand.Parameters.AddWithValue("@profileId", profileId);

                    int rowsAffected = insertDoctorCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Doctor information saved.");
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save doctor information.");
                    }
                }
                else
                {
                    MessageBox.Show("Specialization not found in profiles table.");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Implement update functionality
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Implement delete functionality
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            tbSurname.Text = "";
            tbName.Text = "";
            nudExperience.Value = 0;
            cmbSpecialization.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
        }
    }
}