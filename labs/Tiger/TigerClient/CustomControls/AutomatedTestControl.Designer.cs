namespace TigerClient.CustomControls
{
    partial class AutomatedTestControl
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
            this.lblTestDisplayName = new System.Windows.Forms.Label();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestDisplayName
            // 
            this.lblTestDisplayName.AutoSize = true;
            this.lblTestDisplayName.Location = new System.Drawing.Point(17, 4);
            this.lblTestDisplayName.Name = "lblTestDisplayName";
            this.lblTestDisplayName.Size = new System.Drawing.Size(28, 13);
            this.lblTestDisplayName.TabIndex = 0;
            this.lblTestDisplayName.Text = "Test";
            // 
            // picStatus
            // 
            this.picStatus.Location = new System.Drawing.Point(0, 2);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(16, 16);
            this.picStatus.TabIndex = 1;
            this.picStatus.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // AutomatedTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.lblTestDisplayName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AutomatedTestControl";
            this.Size = new System.Drawing.Size(55, 21);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestDisplayName;
        private System.Windows.Forms.PictureBox picStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
