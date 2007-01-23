namespace TigerClient.CustomControls
{
    partial class ProjectRunnerControl
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
            this.targetsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // targetsPanel
            // 
            this.targetsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetsPanel.AutoScroll = true;
            this.targetsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.targetsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.targetsPanel.Location = new System.Drawing.Point(4, 4);
            this.targetsPanel.Name = "targetsPanel";
            this.targetsPanel.Padding = new System.Windows.Forms.Padding(2);
            this.targetsPanel.Size = new System.Drawing.Size(569, 379);
            this.targetsPanel.TabIndex = 1;
            this.targetsPanel.WrapContents = false;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(495, 390);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateReport.Enabled = false;
            this.btnCreateReport.Location = new System.Drawing.Point(400, 390);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(89, 23);
            this.btnCreateReport.TabIndex = 3;
            this.btnCreateReport.Text = "&View Report";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // ProjectRunnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreateReport);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.targetsPanel);
            this.Name = "ProjectRunnerControl";
            this.Size = new System.Drawing.Size(575, 418);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TestRunnerControl_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel targetsPanel;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCreateReport;

    }
}
