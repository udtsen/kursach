namespace ClinicApp.Forms
{
    partial class DoctorWeeklyPatientListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvWeeklyPatients = new System.Windows.Forms.ListView();
            this.cbDoctors = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lvWeeklyPatients
            // 
            this.lvWeeklyPatients.HideSelection = false;
            this.lvWeeklyPatients.Location = new System.Drawing.Point(188, 146);
            this.lvWeeklyPatients.Name = "lvWeeklyPatients";
            this.lvWeeklyPatients.Size = new System.Drawing.Size(403, 175);
            this.lvWeeklyPatients.TabIndex = 0;
            this.lvWeeklyPatients.UseCompatibleStateImageBehavior = false;
            // 
            // cbDoctors
            // 
            this.cbDoctors.FormattingEnabled = true;
            this.cbDoctors.Location = new System.Drawing.Point(378, 73);
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.Size = new System.Drawing.Size(121, 21);
            this.cbDoctors.TabIndex = 1;
            // 
            // DoctorWeeklyPatientListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbDoctors);
            this.Controls.Add(this.lvWeeklyPatients);
            this.Name = "DoctorWeeklyPatientListForm";
            this.Text = "DoctorWeeklyPatientListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvWeeklyPatients;
        private System.Windows.Forms.ComboBox cbDoctors;
    }
}