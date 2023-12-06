namespace ClinicApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDoctorInfo = new System.Windows.Forms.Button();
            this.btnPatientRegistration = new System.Windows.Forms.Button();
            this.btnAttendanceReport = new System.Windows.Forms.Button();
            this.btnMostPopularDoctor = new System.Windows.Forms.Button();
            this.btnDoctorWeeklyPatientList = new System.Windows.Forms.Button();
            this.btnPatientPossibleDoctorList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoctorInfo
            // 
            this.btnDoctorInfo.Location = new System.Drawing.Point(306, 79);
            this.btnDoctorInfo.Name = "btnDoctorInfo";
            this.btnDoctorInfo.Size = new System.Drawing.Size(75, 23);
            this.btnDoctorInfo.TabIndex = 0;
            this.btnDoctorInfo.Text = "button1";
            this.btnDoctorInfo.UseVisualStyleBackColor = true;
            this.btnDoctorInfo.Click += new System.EventHandler(this.btnDoctorInfo_Click);
            // 
            // btnPatientRegistration
            // 
            this.btnPatientRegistration.Location = new System.Drawing.Point(306, 153);
            this.btnPatientRegistration.Name = "btnPatientRegistration";
            this.btnPatientRegistration.Size = new System.Drawing.Size(75, 23);
            this.btnPatientRegistration.TabIndex = 1;
            this.btnPatientRegistration.Text = "button1";
            this.btnPatientRegistration.UseVisualStyleBackColor = true;
            this.btnPatientRegistration.Click += new System.EventHandler(this.btnPatientRegistration_Click);
            // 
            // btnAttendanceReport
            // 
            this.btnAttendanceReport.Location = new System.Drawing.Point(306, 214);
            this.btnAttendanceReport.Name = "btnAttendanceReport";
            this.btnAttendanceReport.Size = new System.Drawing.Size(75, 23);
            this.btnAttendanceReport.TabIndex = 2;
            this.btnAttendanceReport.Text = "button1";
            this.btnAttendanceReport.UseVisualStyleBackColor = true;
            this.btnAttendanceReport.Click += new System.EventHandler(this.btnAttendanceReport_Click);
            // 
            // btnMostPopularDoctor
            // 
            this.btnMostPopularDoctor.Location = new System.Drawing.Point(306, 270);
            this.btnMostPopularDoctor.Name = "btnMostPopularDoctor";
            this.btnMostPopularDoctor.Size = new System.Drawing.Size(75, 23);
            this.btnMostPopularDoctor.TabIndex = 3;
            this.btnMostPopularDoctor.Text = "button1";
            this.btnMostPopularDoctor.UseVisualStyleBackColor = true;
            this.btnMostPopularDoctor.Click += new System.EventHandler(this.btnMostPopularDoctor_Click);
            // 
            // btnDoctorWeeklyPatientList
            // 
            this.btnDoctorWeeklyPatientList.Location = new System.Drawing.Point(306, 322);
            this.btnDoctorWeeklyPatientList.Name = "btnDoctorWeeklyPatientList";
            this.btnDoctorWeeklyPatientList.Size = new System.Drawing.Size(75, 23);
            this.btnDoctorWeeklyPatientList.TabIndex = 4;
            this.btnDoctorWeeklyPatientList.Text = "button1";
            this.btnDoctorWeeklyPatientList.UseVisualStyleBackColor = true;
            this.btnDoctorWeeklyPatientList.Click += new System.EventHandler(this.btnDoctorWeeklyPatientList_Click);
            // 
            // btnPatientPossibleDoctorList
            // 
            this.btnPatientPossibleDoctorList.Location = new System.Drawing.Point(306, 364);
            this.btnPatientPossibleDoctorList.Name = "btnPatientPossibleDoctorList";
            this.btnPatientPossibleDoctorList.Size = new System.Drawing.Size(75, 23);
            this.btnPatientPossibleDoctorList.TabIndex = 5;
            this.btnPatientPossibleDoctorList.Text = "button1";
            this.btnPatientPossibleDoctorList.UseVisualStyleBackColor = true;
            this.btnPatientPossibleDoctorList.Click += new System.EventHandler(this.btnPatientPossibleDoctorList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPatientPossibleDoctorList);
            this.Controls.Add(this.btnDoctorWeeklyPatientList);
            this.Controls.Add(this.btnMostPopularDoctor);
            this.Controls.Add(this.btnAttendanceReport);
            this.Controls.Add(this.btnPatientRegistration);
            this.Controls.Add(this.btnDoctorInfo);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDoctorInfo;
        private System.Windows.Forms.Button btnPatientRegistration;
        private System.Windows.Forms.Button btnAttendanceReport;
        private System.Windows.Forms.Button btnMostPopularDoctor;
        private System.Windows.Forms.Button btnDoctorWeeklyPatientList;
        private System.Windows.Forms.Button btnPatientPossibleDoctorList;
    }
}

