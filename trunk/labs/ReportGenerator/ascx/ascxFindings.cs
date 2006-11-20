using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for ascxFindings.
	/// </summary>
	public class ascxFindings : System.Windows.Forms.UserControl
	{		
		int iCurrentFindingsSelectedIndex = 0;
		int iCurrentTargetSelectedIndex = 0;
		private string strCurrentProject;
		private string strFullPathToCurrentProject;
		private string strPathToProjectFiles;
		private string strFullPathToSelectedTarget;
		private string strFullPathToSelectedFinding; 
		private string strPathToTempFileFolder;
		private string strPathToImageDirectoryInUnzipedFolder;
		private string strPathToUnzipSelectedFinding;
		private string strSpsTemplateToUseToEditFindings;
        private UserProfile upCurrentUser = UserProfile.GetUserProfile();
        private utils.authentic authUtils = new utils.authentic();
        private Project currentProject = Project.GetProject();
        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbCurrentProject;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lbTargetsInCurrentProject;
		private System.Windows.Forms.ListBox lbFindingsInCurrentTarget;
		private System.Windows.Forms.Button btSaveFinding;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btDeleteSelectedFinding;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtNewFindingName;
		private System.Windows.Forms.Button btAddNewFinding;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btAddNewTarget;
		private System.Windows.Forms.TextBox txtNewTargetName;
		private System.Windows.Forms.Label lblFindingSaved;
		private System.Windows.Forms.Button btDeleteSelectedTarget;		
		private AxSHDocVw.AxWebBrowser axWebBrowser_Targets;
		private System.Windows.Forms.Label lbUnsavedData;
		private System.Windows.Forms.Button btAssignIdToFinding;
		private System.Windows.Forms.Label lbNextIdToBeAssigned;
		private System.Windows.Forms.Label lblAssignIdWarning;
        private System.Windows.Forms.Button btReloadTargetsList;
		private System.Windows.Forms.Label lbNextIdLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbTemplateToUse;
		public AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_Findings;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btRenameFinding;
        private System.Windows.Forms.TextBox txtRenameFinding;
        private AxSHDocVw.AxWebBrowser axWebBrowser_WindowsExplorer;
		/// <summary> 
		/// Required designer variable.
		/// </summary>		
		private System.ComponentModel.Container components = null;

		public ascxFindings()
		{									
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				axAuthentic_Findings.Dispose();
				axWebBrowser_Targets.Dispose();
				axAuthentic_Findings.ContainingControl = null;
				axWebBrowser_Targets.ContainingControl = null;
				if(null != axAuthentic_Findings && null != axWebBrowser_Targets &&null != components )
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );		
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxFindings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCurrentProject = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTargetsInCurrentProject = new System.Windows.Forms.ListBox();
            this.lbFindingsInCurrentTarget = new System.Windows.Forms.ListBox();
            this.axAuthentic_Findings = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.btSaveFinding = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            this.lblAssignIdWarning = new System.Windows.Forms.Label();
            this.btAssignIdToFinding = new System.Windows.Forms.Button();
            this.lbNextIdToBeAssigned = new System.Windows.Forms.Label();
            this.lbNextIdLabel = new System.Windows.Forms.Label();
            this.lblFindingSaved = new System.Windows.Forms.Label();
            this.btDeleteSelectedFinding = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btAddNewFinding = new System.Windows.Forms.Button();
            this.txtNewFindingName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btAddNewTarget = new System.Windows.Forms.Button();
            this.txtNewTargetName = new System.Windows.Forms.TextBox();
            this.btDeleteSelectedTarget = new System.Windows.Forms.Button();
            this.axWebBrowser_Targets = new AxSHDocVw.AxWebBrowser();
            this.btReloadTargetsList = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTemplateToUse = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btRenameFinding = new System.Windows.Forms.Button();
            this.txtRenameFinding = new System.Windows.Forms.TextBox();
            this.axWebBrowser_WindowsExplorer = new AxSHDocVw.AxWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Findings)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_Targets)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_WindowsExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Project";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Findings in Current Target";
            // 
            // lbCurrentProject
            // 
            this.lbCurrentProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentProject.Location = new System.Drawing.Point(96, 1);
            this.lbCurrentProject.Name = "lbCurrentProject";
            this.lbCurrentProject.Size = new System.Drawing.Size(424, 16);
            this.lbCurrentProject.TabIndex = 0;
            this.lbCurrentProject.Text = "...";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Targets in Current Project:";
            // 
            // lbTargetsInCurrentProject
            // 
            this.lbTargetsInCurrentProject.Location = new System.Drawing.Point(14, 67);
            this.lbTargetsInCurrentProject.Name = "lbTargetsInCurrentProject";
            this.lbTargetsInCurrentProject.Size = new System.Drawing.Size(160, 56);
            this.lbTargetsInCurrentProject.TabIndex = 1;
            this.lbTargetsInCurrentProject.SelectedIndexChanged += new System.EventHandler(this.lbTargetsInCurrentProject_SelectedIndexChanged);
            // 
            // lbFindingsInCurrentTarget
            // 
            this.lbFindingsInCurrentTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFindingsInCurrentTarget.Location = new System.Drawing.Point(14, 244);
            this.lbFindingsInCurrentTarget.Name = "lbFindingsInCurrentTarget";
            this.lbFindingsInCurrentTarget.Size = new System.Drawing.Size(160, 121);
            this.lbFindingsInCurrentTarget.TabIndex = 1;
            this.lbFindingsInCurrentTarget.SelectedIndexChanged += new System.EventHandler(this.lbFindingsInCurrentTarget_SelectedIndexChanged);
            // 
            // axAuthentic_Findings
            // 
            this.axAuthentic_Findings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_Findings.Enabled = true;
            this.axAuthentic_Findings.Location = new System.Drawing.Point(182, 170);
            this.axAuthentic_Findings.Name = "axAuthentic_Findings";
            this.axAuthentic_Findings.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_Findings.OcxState")));
            this.axAuthentic_Findings.Size = new System.Drawing.Size(612, 334);
            this.axAuthentic_Findings.TabIndex = 2;
            this.axAuthentic_Findings.Enter += new System.EventHandler(this.axAuthentic1_Enter);
            this.axAuthentic_Findings.SelectionChanged += new System.EventHandler(this.axAuthentic1_SelectionChanged);
            // 
            // btSaveFinding
            // 
            this.btSaveFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveFinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveFinding.Location = new System.Drawing.Point(712, 10);
            this.btSaveFinding.Name = "btSaveFinding";
            this.btSaveFinding.Size = new System.Drawing.Size(93, 24);
            this.btSaveFinding.TabIndex = 3;
            this.btSaveFinding.Text = "Save Finding";
            this.btSaveFinding.Click += new System.EventHandler(this.btSaveFinding_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbNextIdToBeAssigned);
            this.groupBox1.Controls.Add(this.lbNextIdLabel);
            this.groupBox1.Controls.Add(this.btAssignIdToFinding);
            this.groupBox1.Controls.Add(this.lblAssignIdWarning);
            this.groupBox1.Location = new System.Drawing.Point(505, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 86);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(650, 4);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(66, 37);
            this.lbUnsavedData.TabIndex = 6;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // lblAssignIdWarning
            // 
            this.lblAssignIdWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignIdWarning.Location = new System.Drawing.Point(7, 63);
            this.lblAssignIdWarning.Name = "lblAssignIdWarning";
            this.lblAssignIdWarning.Size = new System.Drawing.Size(155, 15);
            this.lblAssignIdWarning.TabIndex = 7;
            this.lblAssignIdWarning.Text = "* Data will be saved when clicked";
            // 
            // btAssignIdToFinding
            // 
            this.btAssignIdToFinding.Location = new System.Drawing.Point(7, 38);
            this.btAssignIdToFinding.Name = "btAssignIdToFinding";
            this.btAssignIdToFinding.Size = new System.Drawing.Size(125, 24);
            this.btAssignIdToFinding.TabIndex = 4;
            this.btAssignIdToFinding.Text = "Assign Id To Finding*";
            this.btAssignIdToFinding.Click += new System.EventHandler(this.btAssignIdToFinding_Click);
            // 
            // lbNextIdToBeAssigned
            // 
            this.lbNextIdToBeAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNextIdToBeAssigned.ForeColor = System.Drawing.Color.Black;
            this.lbNextIdToBeAssigned.Location = new System.Drawing.Point(74, 16);
            this.lbNextIdToBeAssigned.Name = "lbNextIdToBeAssigned";
            this.lbNextIdToBeAssigned.Size = new System.Drawing.Size(88, 16);
            this.lbNextIdToBeAssigned.TabIndex = 6;
            this.lbNextIdToBeAssigned.Text = "..";
            this.lbNextIdToBeAssigned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNextIdLabel
            // 
            this.lbNextIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNextIdLabel.ForeColor = System.Drawing.Color.Black;
            this.lbNextIdLabel.Location = new System.Drawing.Point(6, 16);
            this.lbNextIdLabel.Name = "lbNextIdLabel";
            this.lbNextIdLabel.Size = new System.Drawing.Size(88, 16);
            this.lbNextIdLabel.TabIndex = 6;
            this.lbNextIdLabel.Text = "Next ID:";
            this.lbNextIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNextIdLabel.Click += new System.EventHandler(this.lbNextIdLabel_Click);
            // 
            // lblFindingSaved
            // 
            this.lblFindingSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFindingSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindingSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblFindingSaved.Location = new System.Drawing.Point(650, 8);
            this.lblFindingSaved.Name = "lblFindingSaved";
            this.lblFindingSaved.Size = new System.Drawing.Size(56, 29);
            this.lblFindingSaved.TabIndex = 6;
            this.lblFindingSaved.Text = "Findings Saved";
            this.lblFindingSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFindingSaved.Visible = false;
            // 
            // btDeleteSelectedFinding
            // 
            this.btDeleteSelectedFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeleteSelectedFinding.Location = new System.Drawing.Point(14, 488);
            this.btDeleteSelectedFinding.Name = "btDeleteSelectedFinding";
            this.btDeleteSelectedFinding.Size = new System.Drawing.Size(160, 20);
            this.btDeleteSelectedFinding.TabIndex = 6;
            this.btDeleteSelectedFinding.Text = "Delete Selected Finding";
            this.btDeleteSelectedFinding.Click += new System.EventHandler(this.btDeleteSelectedFinding_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btAddNewFinding);
            this.groupBox2.Controls.Add(this.txtNewFindingName);
            this.groupBox2.Location = new System.Drawing.Point(13, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 40);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Finding";
            // 
            // btAddNewFinding
            // 
            this.btAddNewFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddNewFinding.Location = new System.Drawing.Point(120, 16);
            this.btAddNewFinding.Name = "btAddNewFinding";
            this.btAddNewFinding.Size = new System.Drawing.Size(34, 20);
            this.btAddNewFinding.TabIndex = 1;
            this.btAddNewFinding.Text = "Add";
            this.btAddNewFinding.Click += new System.EventHandler(this.btAddNewFinding_Click);
            // 
            // txtNewFindingName
            // 
            this.txtNewFindingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewFindingName.Location = new System.Drawing.Point(4, 16);
            this.txtNewFindingName.Name = "txtNewFindingName";
            this.txtNewFindingName.Size = new System.Drawing.Size(104, 20);
            this.txtNewFindingName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btAddNewTarget);
            this.groupBox3.Controls.Add(this.txtNewTargetName);
            this.groupBox3.Location = new System.Drawing.Point(14, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 40);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Target";
            // 
            // btAddNewTarget
            // 
            this.btAddNewTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddNewTarget.Location = new System.Drawing.Point(120, 16);
            this.btAddNewTarget.Name = "btAddNewTarget";
            this.btAddNewTarget.Size = new System.Drawing.Size(32, 20);
            this.btAddNewTarget.TabIndex = 1;
            this.btAddNewTarget.Text = "Add";
            this.btAddNewTarget.Click += new System.EventHandler(this.btAddNewTarget_Click);
            // 
            // txtNewTargetName
            // 
            this.txtNewTargetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewTargetName.Location = new System.Drawing.Point(8, 16);
            this.txtNewTargetName.Name = "txtNewTargetName";
            this.txtNewTargetName.Size = new System.Drawing.Size(104, 20);
            this.txtNewTargetName.TabIndex = 0;
            // 
            // btDeleteSelectedTarget
            // 
            this.btDeleteSelectedTarget.Location = new System.Drawing.Point(14, 172);
            this.btDeleteSelectedTarget.Name = "btDeleteSelectedTarget";
            this.btDeleteSelectedTarget.Size = new System.Drawing.Size(160, 20);
            this.btDeleteSelectedTarget.TabIndex = 16;
            this.btDeleteSelectedTarget.Text = "Delete Selected Target";
            // 
            // axWebBrowser_Targets
            // 
            this.axWebBrowser_Targets.Enabled = true;
            this.axWebBrowser_Targets.Location = new System.Drawing.Point(182, 43);
            this.axWebBrowser_Targets.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser_Targets.OcxState")));
            this.axWebBrowser_Targets.Size = new System.Drawing.Size(323, 80);
            this.axWebBrowser_Targets.TabIndex = 17;
            // 
            // btReloadTargetsList
            // 
            this.btReloadTargetsList.Location = new System.Drawing.Point(14, 43);
            this.btReloadTargetsList.Name = "btReloadTargetsList";
            this.btReloadTargetsList.Size = new System.Drawing.Size(160, 20);
            this.btReloadTargetsList.TabIndex = 16;
            this.btReloadTargetsList.Text = "Reload Target\'s List";
            this.btReloadTargetsList.Click += new System.EventHandler(this.btReloadTargetsList_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(180, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Editor Template To Use:";
            // 
            // cbTemplateToUse
            // 
            this.cbTemplateToUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplateToUse.Items.AddRange(new object[] {
            "Authentic - Simple Mode",
            "Authentic - All Fields Mode",
            "Windows Explorer"});
            this.cbTemplateToUse.Location = new System.Drawing.Point(336, 135);
            this.cbTemplateToUse.Name = "cbTemplateToUse";
            this.cbTemplateToUse.Size = new System.Drawing.Size(259, 21);
            this.cbTemplateToUse.TabIndex = 18;
            this.cbTemplateToUse.SelectedIndexChanged += new System.EventHandler(this.cbTemplateToUse_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.btRenameFinding);
            this.groupBox4.Controls.Add(this.txtRenameFinding);
            this.groupBox4.Location = new System.Drawing.Point(14, 416);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 64);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rename Finding";
            // 
            // btRenameFinding
            // 
            this.btRenameFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRenameFinding.Location = new System.Drawing.Point(96, 40);
            this.btRenameFinding.Name = "btRenameFinding";
            this.btRenameFinding.Size = new System.Drawing.Size(56, 20);
            this.btRenameFinding.TabIndex = 1;
            this.btRenameFinding.Text = "Rename";
            this.btRenameFinding.Click += new System.EventHandler(this.btRenameFinding_Click);
            // 
            // txtRenameFinding
            // 
            this.txtRenameFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRenameFinding.Location = new System.Drawing.Point(8, 16);
            this.txtRenameFinding.Name = "txtRenameFinding";
            this.txtRenameFinding.Size = new System.Drawing.Size(144, 20);
            this.txtRenameFinding.TabIndex = 0;
            // 
            // axWebBrowser_WindowsExplorer
            // 
            this.axWebBrowser_WindowsExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axWebBrowser_WindowsExplorer.Enabled = true;
            this.axWebBrowser_WindowsExplorer.Location = new System.Drawing.Point(182, 170);
            this.axWebBrowser_WindowsExplorer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser_WindowsExplorer.OcxState")));
            this.axWebBrowser_WindowsExplorer.Size = new System.Drawing.Size(611, 334);
            this.axWebBrowser_WindowsExplorer.TabIndex = 17;
            this.axWebBrowser_WindowsExplorer.Visible = false;
            // 
            // ascxFindings
            // 
            this.Controls.Add(this.btSaveFinding);
            this.Controls.Add(this.lbUnsavedData);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblFindingSaved);
            this.Controls.Add(this.cbTemplateToUse);
            this.Controls.Add(this.axWebBrowser_Targets);
            this.Controls.Add(this.btDeleteSelectedTarget);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btDeleteSelectedFinding);
            this.Controls.Add(this.lbTargetsInCurrentProject);
            this.Controls.Add(this.lbCurrentProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbFindingsInCurrentTarget);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axAuthentic_Findings);
            this.Controls.Add(this.btReloadTargetsList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.axWebBrowser_WindowsExplorer);
            this.Name = "ascxFindings";
            this.Size = new System.Drawing.Size(812, 512);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Findings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_Targets)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_WindowsExplorer)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		public void loadProjectData(string strProjectToLoad)
		{
			if (!this.DesignMode)
			{
				axAuthentic_Findings.Visible = false;
				axWebBrowser_Targets.Visible = false;
				btRenameFinding.Enabled= false;
				btAddNewFinding.Enabled = false;
				btDeleteSelectedFinding.Enabled = false;
				txtRenameFinding.Text = "";
				cbTemplateToUse.SelectedIndex = 0;
				this.strPathToProjectFiles  = upCurrentUser.ProjectFilesPath;
				this.strPathToTempFileFolder = upCurrentUser.TempDirectoryPath;
				this.strCurrentProject = strProjectToLoad;
				strFullPathToCurrentProject = Path.GetFullPath(Path.Combine(strPathToProjectFiles, strCurrentProject));
				lbCurrentProject.Text = strCurrentProject ;
                lbFindingsInCurrentTarget.Items.Clear();
				loadTargetsIntoListBox();
                //  patch to solve weird VS bug
                axWebBrowser_Targets.Width = 311;
                axWebBrowser_Targets.Height = 70;
			}
		}
		
		private void loadTargetsIntoListBox()
		{
			if (!this.DesignMode)
				utils.windowsForms.loadDirectoriesIntoListBox(lbTargetsInCurrentProject,strFullPathToCurrentProject,"*");
		}

		private void lbTargetsInCurrentProject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            checkForUnsavedData();

			axWebBrowser_Targets.Visible = true;
			btAddNewFinding.Enabled = true;			
			strFullPathToSelectedTarget = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject,lbTargetsInCurrentProject.SelectedItem.ToString()));

			string strSelectedTarget = lbTargetsInCurrentProject.SelectedItem.ToString();
			string strXmlFileToLoad = Path.GetFileNameWithoutExtension(strSelectedTarget) + ".xml"; 
			string strPathToXmlFile = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject,Path.Combine(strSelectedTarget , strXmlFileToLoad)));			
			string strPathToTempConvertedFile = Path.GetTempFileName().Replace(".tmp",".htm");
			utils.xml.returnXmlXslTransformation(strPathToXmlFile, obpPaths.XsltTargetDetailPath, strPathToTempConvertedFile);
			utils.webBrowser.openFileInWebBrowser(axWebBrowser_Targets,strPathToTempConvertedFile);	
			
    		strFullPathToSelectedTarget = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject, lbTargetsInCurrentProject.SelectedItem.ToString()));
			utils.windowsForms.loadFilesIntoListBox(lbFindingsInCurrentTarget,strFullPathToSelectedTarget,"*.zip");		
			iCurrentTargetSelectedIndex = lbTargetsInCurrentProject.SelectedIndex;

		}

		private void lbFindingsInCurrentTarget_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (null != strFullPathToSelectedTarget)
            {
                string pastFindings = strPathToUnzipSelectedFinding;

                // see if there is unsaved data
                checkForUnsavedData();

                strFullPathToSelectedFinding = Path.GetFullPath(Path.Combine(strFullPathToSelectedTarget, lbFindingsInCurrentTarget.SelectedItem.ToString()));
                // unzip new finding into temp folder
                strPathToUnzipSelectedFinding = strPathToTempFileFolder + "\\" + Path.GetFileNameWithoutExtension(strFullPathToSelectedFinding);
                utils.zip.unzipFile(strFullPathToSelectedFinding, strPathToTempFileFolder);

                // invoke this drop down to load the correct template
                cbTemplateToUse_SelectedIndexChanged(null, null);

                // clean up previous findings
                if ((pastFindings != null) && !pastFindings.Equals(strPathToUnzipSelectedFinding))
                {
                    deletePastFindingsTempFolder(pastFindings);
                }
            }
		}

        private void loadSelectedFindingInAuthenticView()
        {
            if (null != strFullPathToSelectedFinding)
            {
                string strXmlFileToLoad = Path.GetFileNameWithoutExtension(strFullPathToSelectedFinding) + ".xml";
                string strPathToXmlFile = Path.Combine(strPathToUnzipSelectedFinding, strXmlFileToLoad);
                strPathToImageDirectoryInUnzipedFolder = Path.Combine(strPathToUnzipSelectedFinding, Path.GetFileNameWithoutExtension(strPathToXmlFile));
                utils.authentic.strPathToSaveClipboardImage = strPathToImageDirectoryInUnzipedFolder;
                utils.authentic.strPathToUnzipSelectedFinding = strPathToUnzipSelectedFinding;

                utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_Findings, strPathToXmlFile, obpPaths.ProjectSchemaPath, strSpsTemplateToUseToEditFindings);
                axAuthentic_Findings.Visible = true;
                lbUnsavedData.Visible = false;
                axAuthentic_Findings.SetUnmodified();

                iCurrentFindingsSelectedIndex = lbFindingsInCurrentTarget.SelectedIndex;

                refreshNextIdToBeAssigned();
                btRenameFinding.Enabled = true;
                btDeleteSelectedFinding.Enabled = true;
                txtRenameFinding.Text = lbFindingsInCurrentTarget.SelectedItem.ToString();
            }
        }

		private void btSaveFinding_Click(object sender, System.EventArgs e)
		{
            try
            {
                if (axWebBrowser_Targets.Visible)
                    saveCurrentData();

                if (File.Exists(strPathToUnzipSelectedFinding))
                {
                    utils.zip.zipFolder(strPathToUnzipSelectedFinding, strFullPathToSelectedFinding);
                    lblFindingSaved.Visible = true;
                    lbUnsavedData.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An issue occured while trying to save findings: " + ex.Message);
            }
		}

		public void deleteCurrentFindingsTempFolder()
		{
            if ((strPathToUnzipSelectedFinding != null) && 
                (strPathToUnzipSelectedFinding.Trim() != "") && 
                Directory.Exists(strPathToUnzipSelectedFinding))
            {
                Directory.Delete(strPathToUnzipSelectedFinding, true);
            }
		}

        private void deletePastFindingsTempFolder(string folderToRemove)
        {
            if ((folderToRemove != null) &&
                (folderToRemove.Trim() != "") &&
                Directory.Exists(folderToRemove))
            {
                Directory.Delete(folderToRemove, true);
            }
        }

		private void btDeleteSelectedFinding_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.Yes ==  MessageBox.Show("Are you sure you want to delete the finding '" + lbFindingsInCurrentTarget.SelectedItem.ToString()+ "'","Delete confirmation Message",MessageBoxButtons.YesNo))
			{
				File.Delete(strFullPathToSelectedFinding);
				deleteCurrentFindingsTempFolder();
				lbTargetsInCurrentProject_SelectedIndexChanged(null,null);
				txtRenameFinding.Text= "";
			}
			
		}

		private void btAddNewFinding_Click(object sender, System.EventArgs e)
		{
            try
            {
                if ("" == txtNewFindingName.Text)
                    MessageBox.Show("New Finding name cannot be empty!");
                else
                {
                    string strNewFindingName = txtNewFindingName.Text + ".zip";
                    if (lbFindingsInCurrentTarget.Items.Contains(strNewFindingName))
                    {
                        MessageBox.Show("Finding already exists, you cannot create a duplicating findings!");
                        return;
                    }
                    int iNumberOfCurrentFindings = lbFindingsInCurrentTarget.Items.Count;
                    createNewFindingInSelectedTargetDirectory(txtNewFindingName.Text);
                    lbFindingsInCurrentTarget.Items.Add(strNewFindingName);
                    lbFindingsInCurrentTarget.SelectedIndex = iNumberOfCurrentFindings;
                    txtNewFindingName.Text = "";
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show( string.Format("An issue occured while trying to add a new Finding {0}", ex.Message));
            }

		}
		private void createNewFindingInSelectedTargetDirectory(string strNewFindingName)
		{
				string strPathToUnzipTemplateFindings = Path.GetFullPath(Path.Combine( upCurrentUser.TempDirectoryPath,
                                                                                       Path.GetFileNameWithoutExtension(obpPaths.FindingsPath)));
				string strPathToNewFindingsDirectoryWithTemplateDate =  Path.GetFullPath(Path.Combine(upCurrentUser.TempDirectoryPath,strNewFindingName));
				string strPathToNewFindingInTargetDirectory = Path.GetFullPath(Path.Combine(strFullPathToSelectedTarget, txtNewFindingName.Text + ".zip"	));	

				utils.zip.unzipFile(obpPaths.FindingsPath,upCurrentUser.TempDirectoryPath);
			
				string strPathToTemplateXmlFile =  Path.GetFullPath(Path.Combine(strPathToUnzipTemplateFindings,Path.GetFileNameWithoutExtension(obpPaths.FindingsPath) + ".xml"));
				string strPathToNewFindingXmlFile = Path.GetFullPath(Path.Combine(strPathToUnzipTemplateFindings, strNewFindingName+".xml"));
            try
            {
				File.Move(strPathToTemplateXmlFile,strPathToNewFindingXmlFile);
				Directory.Move(strPathToUnzipTemplateFindings,strPathToNewFindingsDirectoryWithTemplateDate);
				utils.zip.zipFolder(strPathToNewFindingsDirectoryWithTemplateDate,strPathToNewFindingInTargetDirectory);
				Directory.Delete(strPathToNewFindingsDirectoryWithTemplateDate,true);
			}
			catch (IOException ex)
			{
				MessageBox.Show("An issue occured ttrying to create findings folder {0}", ex.Message);
			}
		}
		
		private void btAddNewTarget_Click(object sender, System.EventArgs e)
		{
			if ("" == txtNewTargetName.Text) 
				MessageBox.Show("New Target name cannot be empty!");
			else
			{
				VulnReportHelpers.createNewTargetAndAddItToListBox(lbTargetsInCurrentProject,txtNewTargetName.Text,strFullPathToCurrentProject);
				txtNewTargetName.Text = "";
			}
		}

		private void axAuthentic1_Enter(object sender, System.EventArgs e)
		{
			lblFindingSaved.Visible = false;
		}

		private void axAuthentic1_SelectionChanged(object sender, System.EventArgs e)
		{
			axAuthentic_Findings.Select();
			lblFindingSaved.Visible = false;
			if (axAuthentic_Findings.Modified)
				lbUnsavedData.Visible = true;
		}

		public void configVariablesForKeyboardHook()
		{
			if ((authUtils.CurrentKeyboardHook == null) || (!authUtils.CurrentKeyboardHook.IsInstalled))
				authUtils.installKeyboardHookInCurrentThread();
            authUtils.AuthenticObject = axAuthentic_Findings;
            authUtils.CurrentControl = (ContainerControl)this;
            
		}

		public void refreshNextIdToBeAssigned()
		{
			if (currentProject.ProjectNumber !=  "")
				lbNextIdToBeAssigned.Text = currentProject.ProjectNumber + "-" + currentProject.FindingId.ToString();			
			else
				lbNextIdToBeAssigned.Text = currentProject.FindingId.ToString();			
		}

		private void btAssignIdToFinding_Click(object sender, System.EventArgs e)
		{
            XMLSPYPLUGINLib.XMLData xdXmlData = axAuthentic_Findings.AuthenticView.WholeDocument.FirstXMLData;
            while (xdXmlData.Name != "Finding")
            {
                xdXmlData = xdXmlData.Parent;
            }
            if (xdXmlData.HasChildren)
            {
                XMLSPYPLUGINLib.XMLData xdXmlDataAttr = xdXmlData.GetFirstChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
                for (int i = 0; i < xdXmlData.CountChildren(); i++)
                {
                    if ((xdXmlDataAttr != null) && 
                        (xdXmlDataAttr.Name.ToUpper() != Project.FindingIDAttributeName.ToUpper()))
                    {
                        xdXmlDataAttr = xdXmlData.GetChildKind(i, XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
                    }
                    else
                    {
                        break;
                    }
                }

                if ((xdXmlDataAttr != null) && 
                    (xdXmlDataAttr.Name.ToUpper() == Project.FindingIDAttributeName.ToUpper()) &&
                    (MessageBox.Show("Alert: This Finding already contains an ID, do you want to overwrite it?",
                                     "btAssignIdToFinding_Click",
                                     MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    xdXmlDataAttr.TextValue = lbNextIdToBeAssigned.Text;
                }
                else
                {

                    xdXmlDataAttr = axAuthentic_Findings.CreateChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
                    xdXmlDataAttr.Name = Project.FindingIDAttributeName;
                    xdXmlDataAttr.TextValue = lbNextIdToBeAssigned.Text;
                    xdXmlData.InsertChild(xdXmlDataAttr);
                }
                incrementNextIdToBeAssignedAndSaveBothFindingsAndProjects();
            }
		}

		public void incrementNextIdToBeAssignedAndSaveBothFindingsAndProjects()
		{
			currentProject.FindingId += 1;
			refreshNextIdToBeAssigned();	
			btSaveFinding_Click(null,null);
			frmCurrentAndArchivedProjects.cAscxProjects.updateProjectNextFindingIdValue();
		}

		private void btReloadTargetsList_Click(object sender, System.EventArgs e)
		{
			loadTargetsIntoListBox();
		}

		private void lbNextIdLabel_Click(object sender, System.EventArgs e)
		{
			refreshNextIdToBeAssigned();
		}

		private void cbTemplateToUse_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (cbTemplateToUse.Text)
			{
				case "Authentic - Simple Mode":
					strSpsTemplateToUseToEditFindings = obpPaths.SpsSimpleModeFindingsPath;
                    axWebBrowser_WindowsExplorer.Visible = false;
                    axAuthentic_Findings.Visible = true;
                    loadSelectedFindingInAuthenticView();               // load data
					break;
                case "Authentic - All Fields Mode":
					strSpsTemplateToUseToEditFindings = obpPaths.SpsFindingsPath;
                    axWebBrowser_WindowsExplorer.Visible = false;
                    axAuthentic_Findings.Visible = true;
                    loadSelectedFindingInAuthenticView();               // load data
					break;
                case "Windows Explorer":
                    axWebBrowser_WindowsExplorer.Visible = true;
                    axAuthentic_Findings.Visible = false;
                    axWebBrowser_WindowsExplorer.Navigate(strPathToUnzipSelectedFinding);                                        
                    break;
                default:
                    MessageBox.Show("Un-recognized drop-down menu item");
                    break;
			}             
		}

		private void btRenameFinding_Click(object sender, System.EventArgs e)
		{
            checkForUnsavedData();

			if (Path.GetExtension(txtRenameFinding.Text)!=".zip")
				txtRenameFinding.Text += ".zip";
			string strFullPathToOriginalFinding = "";
			string strFullPathToRenamedFinding = "";
			try
			{
				strFullPathToOriginalFinding = Path.GetFullPath(Path.Combine(strFullPathToSelectedTarget, lbFindingsInCurrentTarget.SelectedItem.ToString()));
				strFullPathToRenamedFinding = Path.GetFullPath(Path.Combine(strFullPathToSelectedTarget, txtRenameFinding.Text));
				Directory.Move(strFullPathToOriginalFinding,strFullPathToRenamedFinding);				
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not rename the Finding zip file:" +  strFullPathToOriginalFinding + " : " + ex.Message);
				return;
			}
			string strPathToOriginalXmlFile = "";
			try
			{			
				string strPathToUnzipRenamedFinding = strPathToTempFileFolder + "\\" + Path.GetFileNameWithoutExtension(strFullPathToRenamedFinding);
				utils.zip.unzipFile(strFullPathToRenamedFinding ,strPathToTempFileFolder);
			
				string strOriginalUnzipFolder =  Path.Combine(strPathToTempFileFolder,Path.GetFileNameWithoutExtension(lbFindingsInCurrentTarget.SelectedItem.ToString()));
				string strRenamedUnzipFolder =  Path.Combine(strPathToTempFileFolder,Path.GetFileNameWithoutExtension(txtRenameFinding.Text));
				Directory.Move(strOriginalUnzipFolder,strRenamedUnzipFolder);
				
				string strOriginalXmlFile =  Path.GetFileNameWithoutExtension(strFullPathToOriginalFinding)+ ".xml"; 
				string strRenamedXmlFile =  Path.GetFileNameWithoutExtension(txtRenameFinding.Text)+ ".xml"; 

				strPathToOriginalXmlFile = Path.Combine(strRenamedUnzipFolder , strOriginalXmlFile);			
				string strPathToRenamedXmlFile = Path.Combine(strRenamedUnzipFolder , strRenamedXmlFile);			
				File.Move(strPathToOriginalXmlFile,strPathToRenamedXmlFile);
				utils.zip.zipFolder(strPathToUnzipRenamedFinding,strFullPathToRenamedFinding);
				lbTargetsInCurrentProject_SelectedIndexChanged(null,null);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not rename the Finding xml file:" +  strPathToOriginalXmlFile + " : " + ex.Message);
				return;
			}	
		}

        /// <summary>
        /// This method checks for unsaved data if something is not saved the user 
        /// is prompted and asked if they want to save the data or not.
        /// </summary>
		public void checkForUnsavedData()
		{
			if (axAuthentic_Findings.Modified)
			{
                promptUserToSaveData();
			}		
		}

        /// <summary>
        /// This method saves the current data.
        /// </summary>
        private void saveCurrentData()
        {
            if ( (axAuthentic_Findings != null) && 
                 (axAuthentic_Findings.Modified) )
            {
                axAuthentic_Findings.Save();
                utils.zip.zipFolder(strPathToUnzipSelectedFinding, strFullPathToSelectedFinding);
                lblFindingSaved.Visible = true;
                lbUnsavedData.Visible = false;
            }
        }

        /// <summary>
        /// This method asks the user if they wish to save there data if they do then
        /// it saves it for them.  
        /// </summary>
        private void promptUserToSaveData()
        {
            if (MessageBox.Show("Unsaved data exists do you wish to save it?",
                                "Unsaved Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveCurrentData();
            }
        }
	}
}
