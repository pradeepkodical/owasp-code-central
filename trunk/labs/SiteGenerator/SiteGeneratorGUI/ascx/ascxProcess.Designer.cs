namespace Owasp.SiteGenerator.ascx
{
    partial class ascxProcess
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
            this.chHook = new System.Windows.Forms.ColumnHeader();
            this.chProgId = new System.Windows.Forms.ColumnHeader();
            this.v0 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvProcess_Others = new System.Windows.Forms.ListView();
            this.v1 = new System.Windows.Forms.ColumnHeader();
            this.v2 = new System.Windows.Forms.ColumnHeader();
            this.v3 = new System.Windows.Forms.ColumnHeader();
            this.v4 = new System.Windows.Forms.ColumnHeader();
            this.v5 = new System.Windows.Forms.ColumnHeader();
            this.v6 = new System.Windows.Forms.ColumnHeader();
            this.v7 = new System.Windows.Forms.ColumnHeader();
            this.tbFiles = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.tabPage2.SuspendLayout();
            this.tbFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // chHook
            // 
            this.chHook.Text = "Hook";
            this.chHook.Width = 72;
            // 
            // chProgId
            // 
            this.chProgId.Text = "Proc ID";
            this.chProgId.Width = 59;
            // 
            // v0
            // 
            this.v0.Text = "v0";
            this.v0.Width = 113;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvProcess_Others);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(917, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Others (Process related)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvProcess_Others
            // 
            this.lvProcess_Others.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProcess_Others.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chHook,
            this.chProgId,
            this.v0,
            this.v1,
            this.v2,
            this.v3,
            this.v4,
            this.v5,
            this.v6,
            this.v7});
            this.lvProcess_Others.FullRowSelect = true;
            this.lvProcess_Others.Location = new System.Drawing.Point(6, 5);
            this.lvProcess_Others.Name = "lvProcess_Others";
            this.lvProcess_Others.Size = new System.Drawing.Size(905, 253);
            this.lvProcess_Others.TabIndex = 5;
            this.lvProcess_Others.UseCompatibleStateImageBehavior = false;
            this.lvProcess_Others.View = System.Windows.Forms.View.Details;
            // 
            // v1
            // 
            this.v1.Text = "v1";
            this.v1.Width = 110;
            // 
            // v2
            // 
            this.v2.Text = "v2";
            this.v2.Width = 88;
            // 
            // v3
            // 
            this.v3.Text = "v3";
            this.v3.Width = 94;
            // 
            // v4
            // 
            this.v4.Text = "v4";
            this.v4.Width = 88;
            // 
            // v5
            // 
            this.v5.Text = "v5";
            this.v5.Width = 77;
            // 
            // v6
            // 
            this.v6.Text = "v6";
            this.v6.Width = 55;
            // 
            // v7
            // 
            this.v7.Text = "v7";
            this.v7.Width = 87;
            // 
            // tbFiles
            // 
            this.tbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFiles.Controls.Add(this.tabPage2);
            this.tbFiles.Location = new System.Drawing.Point(4, 4);
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.SelectedIndex = 0;
            this.tbFiles.Size = new System.Drawing.Size(925, 288);
            this.tbFiles.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Raw Data";
            // 
            // txtProcess
            // 
            this.txtProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcess.Location = new System.Drawing.Point(1, 311);
            this.txtProcess.Multiline = true;
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(928, 73);
            this.txtProcess.TabIndex = 7;
            // 
            // Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProcess);
            this.Name = "Process";
            this.Size = new System.Drawing.Size(930, 387);
            this.tabPage2.ResumeLayout(false);
            this.tbFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader chHook;
        private System.Windows.Forms.ColumnHeader chProgId;
        private System.Windows.Forms.ColumnHeader v0;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListView lvProcess_Others;
        private System.Windows.Forms.ColumnHeader v1;
        private System.Windows.Forms.ColumnHeader v2;
        private System.Windows.Forms.ColumnHeader v3;
        private System.Windows.Forms.ColumnHeader v4;
        private System.Windows.Forms.ColumnHeader v5;
        private System.Windows.Forms.ColumnHeader v6;
        private System.Windows.Forms.ColumnHeader v7;
        private System.Windows.Forms.TabControl tbFiles;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtProcess;
    }
}
