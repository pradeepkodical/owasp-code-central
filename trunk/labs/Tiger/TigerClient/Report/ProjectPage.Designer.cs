namespace TigerClient.Report
{
    partial class ProjectPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProjectDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTesterName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTestersComments = new System.Windows.Forms.TextBox();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.groupBoxTimes = new System.Windows.Forms.GroupBox();
            this.groupBoxTester = new System.Windows.Forms.GroupBox();
            this.groupBoxGeneral.SuspendLayout();
            this.groupBoxTimes.SuspendLayout();
            this.groupBoxTester.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project &name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectName.Location = new System.Drawing.Point(120, 25);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(236, 20);
            this.txtProjectName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project &description:";
            // 
            // txtProjectDescription
            // 
            this.txtProjectDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectDescription.Location = new System.Drawing.Point(120, 51);
            this.txtProjectDescription.Multiline = true;
            this.txtProjectDescription.Name = "txtProjectDescription";
            this.txtProjectDescription.Size = new System.Drawing.Size(236, 40);
            this.txtProjectDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tests &started:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(120, 25);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "at";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(256, 25);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(100, 20);
            this.dtpStartTime.TabIndex = 7;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(256, 51);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(100, 20);
            this.dtpEndTime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "at";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(120, 51);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tests &finished:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "&Tester\'s name:";
            // 
            // txtTesterName
            // 
            this.txtTesterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTesterName.Location = new System.Drawing.Point(120, 25);
            this.txtTesterName.Name = "txtTesterName";
            this.txtTesterName.Size = new System.Drawing.Size(236, 20);
            this.txtTesterName.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tester\'s &comments:";
            // 
            // txtTestersComments
            // 
            this.txtTestersComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestersComments.Location = new System.Drawing.Point(120, 51);
            this.txtTestersComments.Multiline = true;
            this.txtTestersComments.Name = "txtTestersComments";
            this.txtTestersComments.Size = new System.Drawing.Size(236, 40);
            this.txtTestersComments.TabIndex = 15;
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGeneral.Controls.Add(this.txtProjectDescription);
            this.groupBoxGeneral.Controls.Add(this.label1);
            this.groupBoxGeneral.Controls.Add(this.txtProjectName);
            this.groupBoxGeneral.Controls.Add(this.label2);
            this.groupBoxGeneral.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(375, 111);
            this.groupBoxGeneral.TabIndex = 16;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General";
            // 
            // groupBoxTimes
            // 
            this.groupBoxTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimes.Controls.Add(this.dtpStartDate);
            this.groupBoxTimes.Controls.Add(this.label3);
            this.groupBoxTimes.Controls.Add(this.label4);
            this.groupBoxTimes.Controls.Add(this.dtpStartTime);
            this.groupBoxTimes.Controls.Add(this.label6);
            this.groupBoxTimes.Controls.Add(this.dtpEndDate);
            this.groupBoxTimes.Controls.Add(this.dtpEndTime);
            this.groupBoxTimes.Controls.Add(this.label5);
            this.groupBoxTimes.Location = new System.Drawing.Point(0, 117);
            this.groupBoxTimes.Name = "groupBoxTimes";
            this.groupBoxTimes.Size = new System.Drawing.Size(375, 93);
            this.groupBoxTimes.TabIndex = 17;
            this.groupBoxTimes.TabStop = false;
            this.groupBoxTimes.Text = "Date and time";
            // 
            // groupBoxTester
            // 
            this.groupBoxTester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTester.Controls.Add(this.txtTestersComments);
            this.groupBoxTester.Controls.Add(this.label7);
            this.groupBoxTester.Controls.Add(this.txtTesterName);
            this.groupBoxTester.Controls.Add(this.label8);
            this.groupBoxTester.Location = new System.Drawing.Point(0, 216);
            this.groupBoxTester.Name = "groupBoxTester";
            this.groupBoxTester.Size = new System.Drawing.Size(375, 111);
            this.groupBoxTester.TabIndex = 18;
            this.groupBoxTester.TabStop = false;
            this.groupBoxTester.Text = "Tester";
            // 
            // ProjectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTester);
            this.Controls.Add(this.groupBoxTimes);
            this.Controls.Add(this.groupBoxGeneral);
            this.Name = "ProjectPage";
            this.Size = new System.Drawing.Size(375, 327);
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            this.groupBoxTimes.ResumeLayout(false);
            this.groupBoxTimes.PerformLayout();
            this.groupBoxTester.ResumeLayout(false);
            this.groupBoxTester.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjectDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTesterName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTestersComments;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.GroupBox groupBoxTimes;
        private System.Windows.Forms.GroupBox groupBoxTester;

    }
}
