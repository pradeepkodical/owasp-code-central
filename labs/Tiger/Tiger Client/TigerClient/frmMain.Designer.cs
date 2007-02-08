namespace TigerClient
{
    partial class frmMain
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewProjectExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewPropertiesWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewShowTargetsInFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewShowTestsInFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewShowTestParametersInFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewShowAlertsInFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProjectAddTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectAddTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectAddTestParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnFileNew = new System.Windows.Forms.ToolStripButton();
            this.tbtnFileOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnFileSave = new System.Windows.Forms.ToolStripButton();
            this.tbtnProjectRun = new System.Windows.Forms.ToolStripButton();
            this.tbtnProjectStop = new System.Windows.Forms.ToolStripButton();
            this.mnuHelpUserManual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.projectExplorerControl1 = new TigerClient.CustomControls.ProjectExplorerControl();
            this.propertiesControl1 = new TigerClient.CustomControls.PropertiesControl();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuProject,
            this.mnuTools,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "&File";
            this.mnuFile.DropDownOpening += new System.EventHandler(this.mnuFile_DropDownOpening);
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Image = global::TigerClient.Properties.Resources.DocumentHS;
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(163, 22);
            this.mnuFileNew.Text = "&New...";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Image = global::TigerClient.Properties.Resources.openHS;
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Image = global::TigerClient.Properties.Resources.saveHS;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "Save &As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(163, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewProjectExplorer,
            this.mnuViewPropertiesWindow,
            toolStripSeparator2,
            this.mnuViewShowTargetsInFolders,
            this.mnuViewShowTestsInFolders,
            this.mnuViewShowTestParametersInFolders,
            this.mnuViewShowAlertsInFolders});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(41, 20);
            this.mnuView.Text = "&View";
            // 
            // mnuViewProjectExplorer
            // 
            this.mnuViewProjectExplorer.Name = "mnuViewProjectExplorer";
            this.mnuViewProjectExplorer.Size = new System.Drawing.Size(242, 22);
            this.mnuViewProjectExplorer.Text = "&Project Explorer";
            this.mnuViewProjectExplorer.Click += new System.EventHandler(this.mnuViewProjectExplorer_Click);
            // 
            // mnuViewPropertiesWindow
            // 
            this.mnuViewPropertiesWindow.Image = global::TigerClient.Properties.Resources.PropertiesHS;
            this.mnuViewPropertiesWindow.Name = "mnuViewPropertiesWindow";
            this.mnuViewPropertiesWindow.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuViewPropertiesWindow.Size = new System.Drawing.Size(242, 22);
            this.mnuViewPropertiesWindow.Text = "Properties Window";
            this.mnuViewPropertiesWindow.Click += new System.EventHandler(this.mnuViewPropertiesWindow_Click);
            // 
            // mnuViewShowTargetsInFolders
            // 
            this.mnuViewShowTargetsInFolders.Name = "mnuViewShowTargetsInFolders";
            this.mnuViewShowTargetsInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowTargetsInFolders.Text = "Show &Targets in Folders";
            this.mnuViewShowTargetsInFolders.Click += new System.EventHandler(this.mnuViewShowTargetsInFolders_Click);
            // 
            // mnuViewShowTestsInFolders
            // 
            this.mnuViewShowTestsInFolders.Name = "mnuViewShowTestsInFolders";
            this.mnuViewShowTestsInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowTestsInFolders.Text = "Show T&ests in Folders";
            this.mnuViewShowTestsInFolders.Click += new System.EventHandler(this.mnuViewShowTestsInFolders_Click);
            // 
            // mnuViewShowTestParametersInFolders
            // 
            this.mnuViewShowTestParametersInFolders.Name = "mnuViewShowTestParametersInFolders";
            this.mnuViewShowTestParametersInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowTestParametersInFolders.Text = "Show Test &Parameters in Folders";
            this.mnuViewShowTestParametersInFolders.Click += new System.EventHandler(this.mnuViewShowTestParametersInFolders_Click);
            // 
            // mnuViewShowAlertsInFolders
            // 
            this.mnuViewShowAlertsInFolders.Name = "mnuViewShowAlertsInFolders";
            this.mnuViewShowAlertsInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowAlertsInFolders.Text = "Show &Alerts in Folders";
            this.mnuViewShowAlertsInFolders.Click += new System.EventHandler(this.mnuViewShowAlertsInFolders_Click);
            // 
            // mnuProject
            // 
            this.mnuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProjectRun,
            this.mnuProjectStop,
            this.toolStripSeparator4,
            this.mnuProjectAddTarget,
            this.mnuProjectAddTest,
            this.mnuProjectAddTestParameter});
            this.mnuProject.Name = "mnuProject";
            this.mnuProject.Size = new System.Drawing.Size(53, 20);
            this.mnuProject.Text = "&Project";
            this.mnuProject.DropDownOpening += new System.EventHandler(this.mnuProject_DropDownOpening);
            // 
            // mnuProjectRun
            // 
            this.mnuProjectRun.Image = global::TigerClient.Properties.Resources.PlayHS;
            this.mnuProjectRun.Name = "mnuProjectRun";
            this.mnuProjectRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuProjectRun.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectRun.Text = "&Run";
            this.mnuProjectRun.Click += new System.EventHandler(this.mnuProjectRun_Click);
            // 
            // mnuProjectStop
            // 
            this.mnuProjectStop.Enabled = false;
            this.mnuProjectStop.Image = global::TigerClient.Properties.Resources.StopHS;
            this.mnuProjectStop.Name = "mnuProjectStop";
            this.mnuProjectStop.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectStop.Text = "&Stop";
            this.mnuProjectStop.Click += new System.EventHandler(this.mnuProjectStop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuProjectAddTarget
            // 
            this.mnuProjectAddTarget.Image = global::TigerClient.Properties.Resources.Add_Target_2;
            this.mnuProjectAddTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuProjectAddTarget.Name = "mnuProjectAddTarget";
            this.mnuProjectAddTarget.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectAddTarget.Text = "Add Tar&get";
            this.mnuProjectAddTarget.Click += new System.EventHandler(this.mnuProjectAddTarget_Click);
            // 
            // mnuProjectAddTest
            // 
            this.mnuProjectAddTest.Image = global::TigerClient.Properties.Resources.AddTest;
            this.mnuProjectAddTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuProjectAddTest.Name = "mnuProjectAddTest";
            this.mnuProjectAddTest.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectAddTest.Text = "Add &Test";
            this.mnuProjectAddTest.Click += new System.EventHandler(this.mnuProjectAddTest_Click);
            // 
            // mnuProjectAddTestParameter
            // 
            this.mnuProjectAddTestParameter.Image = global::TigerClient.Properties.Resources.AddParameter;
            this.mnuProjectAddTestParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuProjectAddTestParameter.Name = "mnuProjectAddTestParameter";
            this.mnuProjectAddTestParameter.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectAddTestParameter.Text = "Add Test &Parameter";
            this.mnuProjectAddTestParameter.Click += new System.EventHandler(this.mnuProjectAddTestParameter_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsTemplates,
            this.toolStripSeparator3,
            this.optionsToolStripMenuItem});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "&Tools";
            this.mnuTools.Visible = false;
            // 
            // mnuToolsTemplates
            // 
            this.mnuToolsTemplates.Name = "mnuToolsTemplates";
            this.mnuToolsTemplates.Size = new System.Drawing.Size(146, 22);
            this.mnuToolsTemplates.Text = "&Templates...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpUserManual,
            this.toolStripSeparator6,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(211, 22);
            this.mnuHelpAbout.Text = "&About OWASP Tiger";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(905, 574);
            this.splitContainer1.SplitterDistance = 658;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.projectExplorerControl1);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertiesControl1);
            this.splitContainer2.Size = new System.Drawing.Size(243, 574);
            this.splitContainer2.SplitterDistance = 282;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 623);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(905, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openDialog
            // 
            this.openDialog.Filter = "Tiger Files (*.tgp;*.tgpt)|*.tgp;*.tgpt|Tiger Project Files (*.tgp)|*.tgp|Tiger P" +
                "roject Template Files (*.tgpt)|*.tgpt|All Files (*.*)|*.*";
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Tiger Project Files (*.tgp)|*.tgp|Tiger Project Template Files (*.tgpt)|*.tgpt|Al" +
                "l Files (*.*)|*.*";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnFileNew,
            this.tbtnFileOpen,
            this.tbtnFileSave,
            this.toolStripSeparator5,
            this.tbtnProjectRun,
            this.tbtnProjectStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(905, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnFileNew
            // 
            this.tbtnFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFileNew.Image = global::TigerClient.Properties.Resources.DocumentHS;
            this.tbtnFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFileNew.Name = "tbtnFileNew";
            this.tbtnFileNew.Size = new System.Drawing.Size(23, 22);
            this.tbtnFileNew.Text = "New";
            this.tbtnFileNew.Click += new System.EventHandler(this.tbtnFileNew_Click);
            // 
            // tbtnFileOpen
            // 
            this.tbtnFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFileOpen.Image = global::TigerClient.Properties.Resources.openHS;
            this.tbtnFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFileOpen.Name = "tbtnFileOpen";
            this.tbtnFileOpen.Size = new System.Drawing.Size(23, 22);
            this.tbtnFileOpen.Text = "Open";
            this.tbtnFileOpen.Click += new System.EventHandler(this.tbtnFileOpen_Click);
            // 
            // tbtnFileSave
            // 
            this.tbtnFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFileSave.Image = global::TigerClient.Properties.Resources.saveHS;
            this.tbtnFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFileSave.Name = "tbtnFileSave";
            this.tbtnFileSave.Size = new System.Drawing.Size(23, 22);
            this.tbtnFileSave.Text = "Save";
            this.tbtnFileSave.Click += new System.EventHandler(this.tbtnFileSave_Click);
            // 
            // tbtnProjectRun
            // 
            this.tbtnProjectRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnProjectRun.Image = global::TigerClient.Properties.Resources.PlayHS;
            this.tbtnProjectRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnProjectRun.Name = "tbtnProjectRun";
            this.tbtnProjectRun.Size = new System.Drawing.Size(23, 22);
            this.tbtnProjectRun.Text = "&Run";
            this.tbtnProjectRun.Click += new System.EventHandler(this.tbtnProjectRun_Click);
            // 
            // tbtnProjectStop
            // 
            this.tbtnProjectStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnProjectStop.Enabled = false;
            this.tbtnProjectStop.Image = global::TigerClient.Properties.Resources.StopHS;
            this.tbtnProjectStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnProjectStop.Name = "tbtnProjectStop";
            this.tbtnProjectStop.Size = new System.Drawing.Size(23, 22);
            this.tbtnProjectStop.Text = "toolStripButton1";
            this.tbtnProjectStop.ToolTipText = "Stop";
            this.tbtnProjectStop.Click += new System.EventHandler(this.tbtnProjectStop_Click);
            // 
            // mnuHelpUserManual
            // 
            this.mnuHelpUserManual.Name = "mnuHelpUserManual";
            this.mnuHelpUserManual.Size = new System.Drawing.Size(211, 22);
            this.mnuHelpUserManual.Text = "User Manual at owasp.org";
            this.mnuHelpUserManual.Click += new System.EventHandler(this.mnuHelpUserManual_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(208, 6);
            // 
            // projectExplorerControl1
            // 
            this.projectExplorerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectExplorerControl1.Location = new System.Drawing.Point(0, 0);
            this.projectExplorerControl1.Name = "projectExplorerControl1";
            this.projectExplorerControl1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.projectExplorerControl1.Project = null;
            this.projectExplorerControl1.Size = new System.Drawing.Size(239, 281);
            this.projectExplorerControl1.TabIndex = 0;
            this.projectExplorerControl1.SelectedObjectChanged += new System.EventHandler(this.projectExplorerControl1_SelectedObjectChanged);
            this.projectExplorerControl1.CloseButtonClick += new System.EventHandler(this.projectExplorerControl1_CloseButtonClick);
            // 
            // propertiesControl1
            // 
            this.propertiesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesControl1.Location = new System.Drawing.Point(0, 0);
            this.propertiesControl1.Name = "propertiesControl1";
            this.propertiesControl1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.propertiesControl1.SelectedObject = null;
            this.propertiesControl1.Size = new System.Drawing.Size(243, 288);
            this.propertiesControl1.TabIndex = 0;
            this.propertiesControl1.CloseButtonClick += new System.EventHandler(this.propertiesControl1_CloseButtonClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 645);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "OWASP Tiger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuProject;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewProjectExplorer;
        private System.Windows.Forms.ToolStripMenuItem mnuViewPropertiesWindow;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private TigerClient.CustomControls.PropertiesControl propertiesControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private TigerClient.CustomControls.ProjectExplorerControl projectExplorerControl1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowTargetsInFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowTestsInFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowTestParametersInFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectAddTarget;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectAddTest;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectAddTestParameter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectRun;
        private System.Windows.Forms.ToolStripButton tbtnFileNew;
        private System.Windows.Forms.ToolStripButton tbtnFileOpen;
        private System.Windows.Forms.ToolStripButton tbtnFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbtnProjectRun;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowAlertsInFolders;
        private System.Windows.Forms.ToolStripButton tbtnProjectStop;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectStop;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsTemplates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpUserManual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

