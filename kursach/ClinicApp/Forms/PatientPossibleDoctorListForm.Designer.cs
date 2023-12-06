namespace ClinicApp.Forms
{
    partial class PatientPossibleDoctorListForm
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
            this.lbPossibleDoctors = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbPossibleDoctors
            // 
            this.lbPossibleDoctors.FormattingEnabled = true;
            this.lbPossibleDoctors.Location = new System.Drawing.Point(443, 185);
            this.lbPossibleDoctors.Name = "lbPossibleDoctors";
            this.lbPossibleDoctors.Size = new System.Drawing.Size(120, 95);
            this.lbPossibleDoctors.TabIndex = 0;
            // 
            // PatientPossibleDoctorListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbPossibleDoctors);
            this.Name = "PatientPossibleDoctorListForm";
            this.Text = "PatientPossibleDoctorListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbPossibleDoctors;
    }
}