﻿namespace ClinicApp.Forms
{
    partial class AttendanceReportForm
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
            this.lvAttendance = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvAttendance
            // 
            this.lvAttendance.HideSelection = false;
            this.lvAttendance.Location = new System.Drawing.Point(196, 155);
            this.lvAttendance.Name = "lvAttendance";
            this.lvAttendance.Size = new System.Drawing.Size(343, 97);
            this.lvAttendance.TabIndex = 0;
            this.lvAttendance.UseCompatibleStateImageBehavior = false;
            // 
            // AttendanceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvAttendance);
            this.Name = "AttendanceReportForm";
            this.Text = "AttendanceReportForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAttendance;
    }
}