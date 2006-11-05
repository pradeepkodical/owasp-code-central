namespace Owasp.SiteGenerator.ascx
{
    partial class IIS_hooking
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
            this.btRefreshProcess = new System.Windows.Forms.Button();
            this.lbW3wpAlert = new System.Windows.Forms.Label();
            this.btAttemptToCreateW3WP = new System.Windows.Forms.Button();
            this.btKillSelectedProcess = new System.Windows.Forms.Button();
            this.lvCurrentProcesses = new System.Windows.Forms.ListView();
            this.chProcessName = new System.Windows.Forms.ColumnHeader();
            this.chID = new System.Windows.Forms.ColumnHeader();
            this.gbW3wpHooking = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUrlToLoad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLoadUrlInWebBrowser = new System.Windows.Forms.Button();
            this.wbW3wpHooking = new System.Windows.Forms.WebBrowser();
            this.lvW3wpInstances = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btInjectDllIntoProcess = new System.Windows.Forms.Button();
            this.gbSelectedProcessInformation = new System.Windows.Forms.GroupBox();
            this.lvSelectedProcessInfo = new System.Windows.Forms.ListView();
            this.chModuleName = new System.Windows.Forms.ColumnHeader();
            this.chFileName = new System.Windows.Forms.ColumnHeader();
            this.lbDllInjectedIntoThisProcess = new System.Windows.Forms.Label();
            this.btCreateNotepad = new System.Windows.Forms.Button();
            this.btCreateCmd = new System.Windows.Forms.Button();
            this.gbW3wpHooking.SuspendLayout();
            this.gbSelectedProcessInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRefreshProcess
            // 
            this.btRefreshProcess.Location = new System.Drawing.Point(3, 23);
            this.btRefreshProcess.Name = "btRefreshProcess";
            this.btRefreshProcess.Size = new System.Drawing.Size(181, 24);
            this.btRefreshProcess.TabIndex = 1;
            this.btRefreshProcess.Text = "Refresh Process Data";
            this.btRefreshProcess.UseVisualStyleBackColor = true;
            this.btRefreshProcess.Click += new System.EventHandler(this.btRefreshProcess_Click);
            // 
            // lbW3wpAlert
            // 
            this.lbW3wpAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbW3wpAlert.AutoSize = true;
            this.lbW3wpAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbW3wpAlert.ForeColor = System.Drawing.Color.Red;
            this.lbW3wpAlert.Location = new System.Drawing.Point(3, 294);
            this.lbW3wpAlert.Name = "lbW3wpAlert";
            this.lbW3wpAlert.Size = new System.Drawing.Size(118, 13);
            this.lbW3wpAlert.TabIndex = 2;
            this.lbW3wpAlert.Text = " No W3WP process";
            this.lbW3wpAlert.Visible = false;
            // 
            // btAttemptToCreateW3WP
            // 
            this.btAttemptToCreateW3WP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAttemptToCreateW3WP.Location = new System.Drawing.Point(6, 310);
            this.btAttemptToCreateW3WP.Name = "btAttemptToCreateW3WP";
            this.btAttemptToCreateW3WP.Size = new System.Drawing.Size(115, 36);
            this.btAttemptToCreateW3WP.TabIndex = 3;
            this.btAttemptToCreateW3WP.Text = "Attempt to Create W3WP";
            this.btAttemptToCreateW3WP.UseVisualStyleBackColor = true;
            this.btAttemptToCreateW3WP.Visible = false;
            this.btAttemptToCreateW3WP.Click += new System.EventHandler(this.btAttemptToCreateW3WP_Click);
            // 
            // btKillSelectedProcess
            // 
            this.btKillSelectedProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btKillSelectedProcess.Location = new System.Drawing.Point(51, 287);
            this.btKillSelectedProcess.Name = "btKillSelectedProcess";
            this.btKillSelectedProcess.Size = new System.Drawing.Size(181, 24);
            this.btKillSelectedProcess.TabIndex = 4;
            this.btKillSelectedProcess.Text = "Kill Selected Process";
            this.btKillSelectedProcess.UseVisualStyleBackColor = true;
            this.btKillSelectedProcess.Click += new System.EventHandler(this.btKillSelectedProcess_Click);
            // 
            // lvCurrentProcesses
            // 
            this.lvCurrentProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvCurrentProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProcessName,
            this.chID});
            this.lvCurrentProcesses.FullRowSelect = true;
            this.lvCurrentProcesses.HideSelection = false;
            this.lvCurrentProcesses.Location = new System.Drawing.Point(6, 53);
            this.lvCurrentProcesses.MultiSelect = false;
            this.lvCurrentProcesses.Name = "lvCurrentProcesses";
            this.lvCurrentProcesses.Size = new System.Drawing.Size(178, 237);
            this.lvCurrentProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCurrentProcesses.TabIndex = 5;
            this.lvCurrentProcesses.UseCompatibleStateImageBehavior = false;
            this.lvCurrentProcesses.View = System.Windows.Forms.View.Details;
            this.lvCurrentProcesses.SelectedIndexChanged += new System.EventHandler(this.lvCurrentProcesses_SelectedIndexChanged);
            // 
            // chProcessName
            // 
            this.chProcessName.Text = "Process Name";
            this.chProcessName.Width = 112;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            // 
            // gbW3wpHooking
            // 
            this.gbW3wpHooking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbW3wpHooking.Controls.Add(this.label2);
            this.gbW3wpHooking.Controls.Add(this.cbUrlToLoad);
            this.gbW3wpHooking.Controls.Add(this.label1);
            this.gbW3wpHooking.Controls.Add(this.btLoadUrlInWebBrowser);
            this.gbW3wpHooking.Controls.Add(this.wbW3wpHooking);
            this.gbW3wpHooking.Controls.Add(this.lvW3wpInstances);
            this.gbW3wpHooking.Location = new System.Drawing.Point(485, 23);
            this.gbW3wpHooking.Name = "gbW3wpHooking";
            this.gbW3wpHooking.Size = new System.Drawing.Size(218, 323);
            this.gbW3wpHooking.TabIndex = 6;
            this.gbW3wpHooking.TabStop = false;
            this.gbW3wpHooking.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Current w3wp instances:";
            // 
            // cbUrlToLoad
            // 
            this.cbUrlToLoad.FormattingEnabled = true;
            this.cbUrlToLoad.Items.AddRange(new object[] {
            "Http://127.0.0.1"});
            this.cbUrlToLoad.Location = new System.Drawing.Point(6, 135);
            this.cbUrlToLoad.Name = "cbUrlToLoad";
            this.cbUrlToLoad.Size = new System.Drawing.Size(203, 21);
            this.cbUrlToLoad.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Url to Load:";
            // 
            // btLoadUrlInWebBrowser
            // 
            this.btLoadUrlInWebBrowser.Location = new System.Drawing.Point(7, 162);
            this.btLoadUrlInWebBrowser.Name = "btLoadUrlInWebBrowser";
            this.btLoadUrlInWebBrowser.Size = new System.Drawing.Size(202, 20);
            this.btLoadUrlInWebBrowser.TabIndex = 7;
            this.btLoadUrlInWebBrowser.Text = "Load Url In Web Browser";
            this.btLoadUrlInWebBrowser.UseVisualStyleBackColor = true;
            this.btLoadUrlInWebBrowser.Click += new System.EventHandler(this.btLoadUrlInWebBrowser_Click);
            // 
            // wbW3wpHooking
            // 
            this.wbW3wpHooking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbW3wpHooking.Location = new System.Drawing.Point(6, 188);
            this.wbW3wpHooking.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbW3wpHooking.Name = "wbW3wpHooking";
            this.wbW3wpHooking.Size = new System.Drawing.Size(203, 129);
            this.wbW3wpHooking.TabIndex = 6;
            // 
            // lvW3wpInstances
            // 
            this.lvW3wpInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvW3wpInstances.FullRowSelect = true;
            this.lvW3wpInstances.Location = new System.Drawing.Point(6, 30);
            this.lvW3wpInstances.MultiSelect = false;
            this.lvW3wpInstances.Name = "lvW3wpInstances";
            this.lvW3wpInstances.Size = new System.Drawing.Size(152, 73);
            this.lvW3wpInstances.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvW3wpInstances.TabIndex = 5;
            this.lvW3wpInstances.UseCompatibleStateImageBehavior = false;
            this.lvW3wpInstances.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Instance";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            // 
            // btInjectDllIntoProcess
            // 
            this.btInjectDllIntoProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btInjectDllIntoProcess.Location = new System.Drawing.Point(6, 258);
            this.btInjectDllIntoProcess.Name = "btInjectDllIntoProcess";
            this.btInjectDllIntoProcess.Size = new System.Drawing.Size(267, 23);
            this.btInjectDllIntoProcess.TabIndex = 7;
            this.btInjectDllIntoProcess.Text = "InjectDllIntoProcess";
            this.btInjectDllIntoProcess.UseVisualStyleBackColor = true;
            this.btInjectDllIntoProcess.Click += new System.EventHandler(this.btInjectDllIntoProcess_Click);
            // 
            // gbSelectedProcessInformation
            // 
            this.gbSelectedProcessInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSelectedProcessInformation.Controls.Add(this.lvSelectedProcessInfo);
            this.gbSelectedProcessInformation.Controls.Add(this.btInjectDllIntoProcess);
            this.gbSelectedProcessInformation.Controls.Add(this.btKillSelectedProcess);
            this.gbSelectedProcessInformation.Controls.Add(this.lbDllInjectedIntoThisProcess);
            this.gbSelectedProcessInformation.Location = new System.Drawing.Point(200, 23);
            this.gbSelectedProcessInformation.Name = "gbSelectedProcessInformation";
            this.gbSelectedProcessInformation.Size = new System.Drawing.Size(279, 317);
            this.gbSelectedProcessInformation.TabIndex = 8;
            this.gbSelectedProcessInformation.TabStop = false;
            this.gbSelectedProcessInformation.Text = "Selected Process Information";
            // 
            // lvSelectedProcessInfo
            // 
            this.lvSelectedProcessInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSelectedProcessInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chModuleName,
            this.chFileName});
            this.lvSelectedProcessInfo.FullRowSelect = true;
            this.lvSelectedProcessInfo.Location = new System.Drawing.Point(6, 30);
            this.lvSelectedProcessInfo.Name = "lvSelectedProcessInfo";
            this.lvSelectedProcessInfo.Size = new System.Drawing.Size(267, 222);
            this.lvSelectedProcessInfo.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSelectedProcessInfo.TabIndex = 8;
            this.lvSelectedProcessInfo.UseCompatibleStateImageBehavior = false;
            this.lvSelectedProcessInfo.View = System.Windows.Forms.View.Details;
            this.lvSelectedProcessInfo.Resize += new System.EventHandler(this.lvSelectedProcessInfo_Resize);
            // 
            // chModuleName
            // 
            this.chModuleName.Text = "ModuleName";
            this.chModuleName.Width = 113;
            // 
            // chFileName
            // 
            this.chFileName.Text = "FileName (Full Path)";
            this.chFileName.Width = 150;
            // 
            // lbDllInjectedIntoThisProcess
            // 
            this.lbDllInjectedIntoThisProcess.AutoSize = true;
            this.lbDllInjectedIntoThisProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDllInjectedIntoThisProcess.ForeColor = System.Drawing.Color.Red;
            this.lbDllInjectedIntoThisProcess.Location = new System.Drawing.Point(6, 14);
            this.lbDllInjectedIntoThisProcess.Name = "lbDllInjectedIntoThisProcess";
            this.lbDllInjectedIntoThisProcess.Size = new System.Drawing.Size(175, 13);
            this.lbDllInjectedIntoThisProcess.TabIndex = 2;
            this.lbDllInjectedIntoThisProcess.Text = "Dll Injected Into This Process";
            this.lbDllInjectedIntoThisProcess.Visible = false;
            // 
            // btCreateNotepad
            // 
            this.btCreateNotepad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateNotepad.Location = new System.Drawing.Point(128, 296);
            this.btCreateNotepad.Name = "btCreateNotepad";
            this.btCreateNotepad.Size = new System.Drawing.Size(56, 23);
            this.btCreateNotepad.TabIndex = 9;
            this.btCreateNotepad.Text = "Notepad";
            this.btCreateNotepad.UseVisualStyleBackColor = true;
            this.btCreateNotepad.Click += new System.EventHandler(this.btCreateNotepad_Click);
            // 
            // btCreateCmd
            // 
            this.btCreateCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateCmd.Location = new System.Drawing.Point(128, 323);
            this.btCreateCmd.Name = "btCreateCmd";
            this.btCreateCmd.Size = new System.Drawing.Size(56, 23);
            this.btCreateCmd.TabIndex = 9;
            this.btCreateCmd.Text = "cmd.exe";
            this.btCreateCmd.UseVisualStyleBackColor = true;
            this.btCreateCmd.Click += new System.EventHandler(this.btCreateCmd_Click);
            // 
            // IIS_hooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btCreateCmd);
            this.Controls.Add(this.btCreateNotepad);
            this.Controls.Add(this.gbSelectedProcessInformation);
            this.Controls.Add(this.gbW3wpHooking);
            this.Controls.Add(this.lvCurrentProcesses);
            this.Controls.Add(this.btAttemptToCreateW3WP);
            this.Controls.Add(this.lbW3wpAlert);
            this.Controls.Add(this.btRefreshProcess);
            this.Name = "IIS_hooking";
            this.Size = new System.Drawing.Size(706, 349);
            this.gbW3wpHooking.ResumeLayout(false);
            this.gbW3wpHooking.PerformLayout();
            this.gbSelectedProcessInformation.ResumeLayout(false);
            this.gbSelectedProcessInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRefreshProcess;
        private System.Windows.Forms.Label lbW3wpAlert;
        private System.Windows.Forms.Button btAttemptToCreateW3WP;
        private System.Windows.Forms.Button btKillSelectedProcess;
        private System.Windows.Forms.ListView lvCurrentProcesses;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chProcessName;
        private System.Windows.Forms.GroupBox gbW3wpHooking;
        private System.Windows.Forms.ListView lvW3wpInstances;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.WebBrowser wbW3wpHooking;
        private System.Windows.Forms.ComboBox cbUrlToLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLoadUrlInWebBrowser;
        private System.Windows.Forms.Button btInjectDllIntoProcess;
        private System.Windows.Forms.GroupBox gbSelectedProcessInformation;
        private System.Windows.Forms.ListView lvSelectedProcessInfo;
        private System.Windows.Forms.ColumnHeader chModuleName;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.Label lbDllInjectedIntoThisProcess;
        private System.Windows.Forms.Button btCreateNotepad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCreateCmd;
    }
}
