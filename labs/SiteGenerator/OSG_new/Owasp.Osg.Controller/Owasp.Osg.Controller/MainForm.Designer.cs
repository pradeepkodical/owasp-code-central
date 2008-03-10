namespace Owasp.Osg.Controller
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.mnuHelpUserManual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnFileNew = new System.Windows.Forms.ToolStripButton();
            this.tbtnFileOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnFileSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnProjectRun = new System.Windows.Forms.ToolStripButton();
            this.tbtnProjectStop = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.horizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.siteTreeControl1 = new Owasp.Osg.Controller.Controls.SiteTreeControl();
            this.fileTransformationListControl1 = new Owasp.Osg.Controller.Controls.FileTransformationListControl();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.horizontalSplitContainer.Panel1.SuspendLayout();
            this.horizontalSplitContainer.Panel2.SuspendLayout();
            this.horizontalSplitContainer.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 1;
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
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(163, 22);
            this.mnuFileNew.Text = "&New...";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
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
            // 
            // mnuViewPropertiesWindow
            // 
            this.mnuViewPropertiesWindow.Name = "mnuViewPropertiesWindow";
            this.mnuViewPropertiesWindow.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuViewPropertiesWindow.Size = new System.Drawing.Size(242, 22);
            this.mnuViewPropertiesWindow.Text = "Properties Window";
            // 
            // mnuViewShowTargetsInFolders
            // 
            this.mnuViewShowTargetsInFolders.Name = "mnuViewShowTargetsInFolders";
            this.mnuViewShowTargetsInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowTargetsInFolders.Text = "Show &Targets in Folders";
            // 
            // mnuViewShowTestsInFolders
            // 
            this.mnuViewShowTestsInFolders.Name = "mnuViewShowTestsInFolders";
            this.mnuViewShowTestsInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowTestsInFolders.Text = "Show T&ests in Folders";
            // 
            // mnuViewShowTestParametersInFolders
            // 
            this.mnuViewShowTestParametersInFolders.Name = "mnuViewShowTestParametersInFolders";
            this.mnuViewShowTestParametersInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowTestParametersInFolders.Text = "Show Test &Parameters in Folders";
            // 
            // mnuViewShowAlertsInFolders
            // 
            this.mnuViewShowAlertsInFolders.Name = "mnuViewShowAlertsInFolders";
            this.mnuViewShowAlertsInFolders.Size = new System.Drawing.Size(242, 22);
            this.mnuViewShowAlertsInFolders.Text = "Show &Alerts in Folders";
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
            // 
            // mnuProjectRun
            // 
            this.mnuProjectRun.Name = "mnuProjectRun";
            this.mnuProjectRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuProjectRun.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectRun.Text = "&Run";
            // 
            // mnuProjectStop
            // 
            this.mnuProjectStop.Enabled = false;
            this.mnuProjectStop.Name = "mnuProjectStop";
            this.mnuProjectStop.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectStop.Text = "&Stop";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuProjectAddTarget
            // 
            this.mnuProjectAddTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuProjectAddTarget.Name = "mnuProjectAddTarget";
            this.mnuProjectAddTarget.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectAddTarget.Text = "Add Tar&get";
            // 
            // mnuProjectAddTest
            // 
            this.mnuProjectAddTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuProjectAddTest.Name = "mnuProjectAddTest";
            this.mnuProjectAddTest.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectAddTest.Text = "Add &Test";
            // 
            // mnuProjectAddTestParameter
            // 
            this.mnuProjectAddTestParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuProjectAddTestParameter.Name = "mnuProjectAddTestParameter";
            this.mnuProjectAddTestParameter.Size = new System.Drawing.Size(181, 22);
            this.mnuProjectAddTestParameter.Text = "Add Test &Parameter";
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
            // mnuHelpUserManual
            // 
            this.mnuHelpUserManual.Name = "mnuHelpUserManual";
            this.mnuHelpUserManual.Size = new System.Drawing.Size(211, 22);
            this.mnuHelpUserManual.Text = "User Manual at owasp.org";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(208, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(211, 22);
            this.mnuHelpAbout.Text = "&About OWASP Tiger";
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
            this.toolStrip1.Size = new System.Drawing.Size(893, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnFileNew
            // 
            this.tbtnFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFileNew.Image = ((System.Drawing.Image)(resources.GetObject("tbtnFileNew.Image")));
            this.tbtnFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFileNew.Name = "tbtnFileNew";
            this.tbtnFileNew.Size = new System.Drawing.Size(23, 22);
            this.tbtnFileNew.Text = "New";
            this.tbtnFileNew.Click += new System.EventHandler(this.tbtnFileNew_Click);
            // 
            // tbtnFileOpen
            // 
            this.tbtnFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbtnFileOpen.Image")));
            this.tbtnFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFileOpen.Name = "tbtnFileOpen";
            this.tbtnFileOpen.Size = new System.Drawing.Size(23, 22);
            this.tbtnFileOpen.Text = "Open";
            this.tbtnFileOpen.Click += new System.EventHandler(this.tbtnFileOpen_Click);
            // 
            // tbtnFileSave
            // 
            this.tbtnFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFileSave.Image = ((System.Drawing.Image)(resources.GetObject("tbtnFileSave.Image")));
            this.tbtnFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFileSave.Name = "tbtnFileSave";
            this.tbtnFileSave.Size = new System.Drawing.Size(23, 22);
            this.tbtnFileSave.Text = "Save";
            this.tbtnFileSave.Click += new System.EventHandler(this.tbtnFileSave_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnProjectRun
            // 
            this.tbtnProjectRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnProjectRun.Image = ((System.Drawing.Image)(resources.GetObject("tbtnProjectRun.Image")));
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
            this.tbtnProjectStop.Image = ((System.Drawing.Image)(resources.GetObject("tbtnProjectStop.Image")));
            this.tbtnProjectStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnProjectStop.Name = "tbtnProjectStop";
            this.tbtnProjectStop.Size = new System.Drawing.Size(23, 22);
            this.tbtnProjectStop.Text = "toolStripButton1";
            this.tbtnProjectStop.ToolTipText = "Stop";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 622);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(893, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // horizontalSplitContainer
            // 
            this.horizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalSplitContainer.Location = new System.Drawing.Point(0, 49);
            this.horizontalSplitContainer.Name = "horizontalSplitContainer";
            this.horizontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // horizontalSplitContainer.Panel1
            // 
            this.horizontalSplitContainer.Panel1.Controls.Add(this.siteTreeControl1);
            // 
            // horizontalSplitContainer.Panel2
            // 
            this.horizontalSplitContainer.Panel2.Controls.Add(this.fileTransformationListControl1);
            this.horizontalSplitContainer.Size = new System.Drawing.Size(893, 573);
            this.horizontalSplitContainer.SplitterDistance = 334;
            this.horizontalSplitContainer.TabIndex = 6;
            this.horizontalSplitContainer.TabStop = false;
            // 
            // siteTreeControl1
            // 
            this.siteTreeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siteTreeControl1.Location = new System.Drawing.Point(0, 0);
            this.siteTreeControl1.Name = "siteTreeControl1";
            this.siteTreeControl1.Project = null;
            this.siteTreeControl1.Size = new System.Drawing.Size(893, 334);
            this.siteTreeControl1.TabIndex = 0;
            // 
            // fileTransformationListControl1
            // 
            this.fileTransformationListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTransformationListControl1.Location = new System.Drawing.Point(0, 0);
            this.fileTransformationListControl1.Name = "fileTransformationListControl1";
            this.fileTransformationListControl1.Size = new System.Drawing.Size(893, 235);
            this.fileTransformationListControl1.TabIndex = 0;
            this.fileTransformationListControl1.CloseButtonClick += new System.EventHandler(this.fileTransformationListControl1_CloseButtonClick);
            // 
            // openDialog
            // 
            this.openDialog.Filter = "OSG Files (*.osgp;*.osgpz)|*.osgp;*.osgpz|All Files (*.*)|*.*";
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "OSG Files (*.osgp;*.osgpz)|*.osgp;*.osgpz|All Files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 644);
            this.Controls.Add(this.horizontalSplitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "OWASP Site Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.horizontalSplitContainer.Panel1.ResumeLayout(false);
            this.horizontalSplitContainer.Panel2.ResumeLayout(false);
            this.horizontalSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewProjectExplorer;
        private System.Windows.Forms.ToolStripMenuItem mnuViewPropertiesWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowTargetsInFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowTestsInFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowTestParametersInFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShowAlertsInFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuProject;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectRun;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectAddTarget;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectAddTest;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectAddTestParameter;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsTemplates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpUserManual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnFileNew;
        private System.Windows.Forms.ToolStripButton tbtnFileOpen;
        private System.Windows.Forms.ToolStripButton tbtnFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbtnProjectRun;
        private System.Windows.Forms.ToolStripButton tbtnProjectStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer horizontalSplitContainer;
        private Owasp.Osg.Controller.Controls.FileTransformationListControl fileTransformationListControl1;
        private Owasp.Osg.Controller.Controls.SiteTreeControl siteTreeControl1;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}

