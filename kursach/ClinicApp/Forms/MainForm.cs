using ClinicApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDoctorInfo_Click(object sender, EventArgs e)
        {
            DoctorInformationForm doctorInformationForm = new DoctorInformationForm();
            doctorInformationForm.Show();
        }

        private void btnPatientRegistration_Click(object sender, EventArgs e)
        {
            PatientRegistrationForm patientRegistrationForm = new PatientRegistrationForm();
            patientRegistrationForm.Show();
        }

        private void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            AttendanceReportForm attendanceReportForm = new AttendanceReportForm();
            attendanceReportForm.Show();
        }

        private void btnMostPopularDoctor_Click(object sender, EventArgs e)
        {
            MostPopularDoctorForm mostPopularDoctorForm = new MostPopularDoctorForm();
            mostPopularDoctorForm.Show();
        }

        private void btnDoctorWeeklyPatientList_Click(object sender, EventArgs e)
        {
            // Replace 1 with the actual doctor's ID
            int selectedDoctorId = 1; // Replace this with the actual ID selected by the user or retrieved from your data

            DoctorWeeklyPatientListForm doctorWeeklyPatientListForm = new DoctorWeeklyPatientListForm(selectedDoctorId);
            doctorWeeklyPatientListForm.Show();
        }

        private void btnPatientPossibleDoctorList_Click(object sender, EventArgs e)
        {
            // Assuming you have the patient's specialization and gender stored in variables
            string patientSpecialization = "YourPatientSpecialization"; // Replace with actual patient's specialization
            string patientGender = "YourPatientGender"; // Replace with actual patient's gender

            PatientPossibleDoctorListForm patientPossibleDoctorListForm = new PatientPossibleDoctorListForm(patientSpecialization, patientGender);
            patientPossibleDoctorListForm.Show();
        }

    }
}
