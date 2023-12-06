namespace ClinicApp.Forms
{
    partial class MostPopularDoctorForm
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
            this.lblPopularDoctor = new System.Windows.Forms.Label();
            this.lblConsultations = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPopularDoctor
            // 
            this.lblPopularDoctor.AutoSize = true;
            this.lblPopularDoctor.Location = new System.Drawing.Point(281, 101);
            this.lblPopularDoctor.Name = "lblPopularDoctor";
            this.lblPopularDoctor.Size = new System.Drawing.Size(35, 13);
            this.lblPopularDoctor.TabIndex = 0;
            this.lblPopularDoctor.Text = "label1";
            // 
            // lblConsultations
            // 
            this.lblConsultations.AutoSize = true;
            this.lblConsultations.Location = new System.Drawing.Point(281, 151);
            this.lblConsultations.Name = "lblConsultations";
            this.lblConsultations.Size = new System.Drawing.Size(35, 13);
            this.lblConsultations.TabIndex = 1;
            this.lblConsultations.Text = "label2";
            // 
            // MostPopularDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblConsultations);
            this.Controls.Add(this.lblPopularDoctor);
            this.Name = "MostPopularDoctorForm";
            this.Text = "MostPopularDoctorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPopularDoctor;
        private System.Windows.Forms.Label lblConsultations;
    }
}