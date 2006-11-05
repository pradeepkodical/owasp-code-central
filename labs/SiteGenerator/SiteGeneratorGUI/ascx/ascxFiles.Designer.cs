namespace Owasp.SiteGenerator.ascx
{
    partial class ascxFiles
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
            this.txtFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvFiles_CreateFileW = new System.Windows.Forms.ListView();
            this.Hook = new System.Windows.Forms.ColumnHeader();
            this.iProcID = new System.Windows.Forms.ColumnHeader();
            this.lpFileName = new System.Windows.Forms.ColumnHeader();
            this.dwDesiredAccess = new System.Windows.Forms.ColumnHeader();
            this.dwShareMode = new System.Windows.Forms.ColumnHeader();
            this.lpSecurityAttributes = new System.Windows.Forms.ColumnHeader();
            this.dwCreationDisposition = new System.Windows.Forms.ColumnHeader();
            this.dwFlagsAndAttributes = new System.Windows.Forms.ColumnHeader();
            this.hTemplateFile = new System.Windows.Forms.ColumnHeader();
            this.ReturnValue = new System.Windows.Forms.ColumnHeader();
            this.tbFiles = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvFiles_Others = new System.Windows.Forms.ListView();
            this.chHook = new System.Windows.Forms.ColumnHeader();
            this.chProgId = new System.Windows.Forms.ColumnHeader();
            this.v0 = new System.Windows.Forms.ColumnHeader();
            this.v1 = new System.Windows.Forms.ColumnHeader();
            this.v2 = new System.Windows.Forms.ColumnHeader();
            this.v3 = new System.Windows.Forms.ColumnHeader();
            this.v4 = new System.Windows.Forms.ColumnHeader();
            this.v5 = new System.Windows.Forms.ColumnHeader();
            this.v6 = new System.Windows.Forms.ColumnHeader();
            this.v7 = new System.Windows.Forms.ColumnHeader();
            this.tbFiles.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiles
            // 
            this.txtFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiles.Location = new System.Drawing.Point(6, 310);
            this.txtFiles.Multiline = true;
            this.txtFiles.Name = "txtFiles";
            this.txtFiles.Size = new System.Drawing.Size(928, 85);
            this.txtFiles.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Raw Data";
            // 
            // lvFiles_CreateFileW
            // 
            this.lvFiles_CreateFileW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles_CreateFileW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Hook,
            this.iProcID,
            this.lpFileName,
            this.dwDesiredAccess,
            this.dwShareMode,
            this.lpSecurityAttributes,
            this.dwCreationDisposition,
            this.dwFlagsAndAttributes,
            this.hTemplateFile,
            this.ReturnValue});
            this.lvFiles_CreateFileW.FullRowSelect = true;
            this.lvFiles_CreateFileW.Location = new System.Drawing.Point(6, 6);
            this.lvFiles_CreateFileW.Name = "lvFiles_CreateFileW";
            this.lvFiles_CreateFileW.Size = new System.Drawing.Size(905, 253);
            this.lvFiles_CreateFileW.TabIndex = 4;
            this.lvFiles_CreateFileW.UseCompatibleStateImageBehavior = false;
            this.lvFiles_CreateFileW.View = System.Windows.Forms.View.Details;
            // 
            // Hook
            // 
            this.Hook.Text = "Hook";
            this.Hook.Width = 72;
            // 
            // iProcID
            // 
            this.iProcID.Text = "Proc ID";
            this.iProcID.Width = 50;
            // 
            // lpFileName
            // 
            this.lpFileName.Text = "lpFileName";
            this.lpFileName.Width = 500;
            // 
            // dwDesiredAccess
            // 
            this.dwDesiredAccess.Text = "dwDesiredAccess";
            this.dwDesiredAccess.Width = 100;
            // 
            // dwShareMode
            // 
            this.dwShareMode.Text = "dwShareMode";
            this.dwShareMode.Width = 20;
            // 
            // lpSecurityAttributes
            // 
            this.lpSecurityAttributes.Text = "lpSecurityAttributes";
            this.lpSecurityAttributes.Width = 20;
            // 
            // dwCreationDisposition
            // 
            this.dwCreationDisposition.Text = "dwCreationDisposition";
            this.dwCreationDisposition.Width = 20;
            // 
            // dwFlagsAndAttributes
            // 
            this.dwFlagsAndAttributes.Text = "dwFlagsAndAttributes";
            this.dwFlagsAndAttributes.Width = 20;
            // 
            // hTemplateFile
            // 
            this.hTemplateFile.Text = "hTemplateFile";
            this.hTemplateFile.Width = 20;
            // 
            // ReturnValue
            // 
            this.ReturnValue.Text = "(ReturnValue)";
            this.ReturnValue.Width = 50;
            // 
            // tbFiles
            // 
            this.tbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFiles.Controls.Add(this.tabPage1);
            this.tbFiles.Controls.Add(this.tabPage2);
            this.tbFiles.Location = new System.Drawing.Point(9, 3);
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.SelectedIndex = 0;
            this.tbFiles.Size = new System.Drawing.Size(925, 288);
            this.tbFiles.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvFiles_CreateFileW);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(917, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CreateFileW";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvFiles_Others);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(917, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Others";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvFiles_Others
            // 
            this.lvFiles_Others.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles_Others.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lvFiles_Others.FullRowSelect = true;
            this.lvFiles_Others.Location = new System.Drawing.Point(6, 5);
            this.lvFiles_Others.Name = "lvFiles_Others";
            this.lvFiles_Others.Size = new System.Drawing.Size(905, 253);
            this.lvFiles_Others.TabIndex = 5;
            this.lvFiles_Others.UseCompatibleStateImageBehavior = false;
            this.lvFiles_Others.View = System.Windows.Forms.View.Details;
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
            // ascxFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiles);
            this.Name = "ascxFiles";
            this.Size = new System.Drawing.Size(934, 398);
            this.tbFiles.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtFiles;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView lvFiles_CreateFileW;
        private System.Windows.Forms.ColumnHeader Hook;
        private System.Windows.Forms.ColumnHeader iProcID;
        private System.Windows.Forms.ColumnHeader lpFileName;
        private System.Windows.Forms.ColumnHeader dwDesiredAccess;
        private System.Windows.Forms.ColumnHeader dwShareMode;
        private System.Windows.Forms.ColumnHeader lpSecurityAttributes;
        private System.Windows.Forms.ColumnHeader dwFlagsAndAttributes;
        private System.Windows.Forms.ColumnHeader hTemplateFile;
        private System.Windows.Forms.ColumnHeader ReturnValue;
        private System.Windows.Forms.ColumnHeader dwCreationDisposition;
        private System.Windows.Forms.TabControl tbFiles;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListView lvFiles_Others;
        private System.Windows.Forms.ColumnHeader chHook;
        private System.Windows.Forms.ColumnHeader chProgId;
        private System.Windows.Forms.ColumnHeader v0;
        private System.Windows.Forms.ColumnHeader v1;
        private System.Windows.Forms.ColumnHeader v2;
        private System.Windows.Forms.ColumnHeader v3;
        private System.Windows.Forms.ColumnHeader v4;
        private System.Windows.Forms.ColumnHeader v5;
        private System.Windows.Forms.ColumnHeader v6;
        private System.Windows.Forms.ColumnHeader v7;        
    }
}
