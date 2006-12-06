using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmCurrentAndArchivedProjects: System.Windows.Forms.Form
	{			
		private bool bProjectSelectedIndexChanged = false;
		private int iCurrentProjectSelectedIndex = 0;
		private bool bFirstTimeThisFormIsLoaded = true;
        private UserProfile upCurrentUser = UserProfile.GetUserProfile();
        private OrgBasePaths obpCurrentPaths = OrgBasePaths.GetPaths();
        public static ascxProjects cAscxProjects;	 

		private string strBaseDir = Path.Combine( Application.StartupPath,"ProjectsDatabase");
		private System.Windows.Forms.TabPage tbProjectMetadata;		
		private System.Windows.Forms.ComboBox cbCurrentOrArchivedProjects;
		private System.Windows.Forms.ListBox lbCurrentProjects;
		private System.Windows.Forms.GroupBox gbAddProject;
		private System.Windows.Forms.TextBox tbNewProjectName;
		private System.Windows.Forms.Button btCreateNewProject;
		private System.Windows.Forms.Button btDeleteSelectedTarget;
		private System.Windows.Forms.TabControl tbProjectData;
		private System.Windows.Forms.TabPage tpProjectMetadata;
		private Owasp.VulnReport.ascxProjects ascxProjects;
		private System.Windows.Forms.TabPage tpTargets;
		private Owasp.VulnReport.ascx.ascxTargets ascxTargets;
		private System.Windows.Forms.TabPage tpFindings;
		public Owasp.VulnReport.ascxFindings ascxFindings;
		private System.Windows.Forms.TabPage tbExecutiveSummary;
		private Owasp.VulnReport.ascxExecutiveSummary ascxExecutiveSummary;
		private System.Windows.Forms.TabPage tbReportPdf;
		private System.Windows.Forms.TabPage tbTargetTasks;
		private Owasp.VulnReport.ascx.ascxTargetTasks ascxTargetTasks;
		private Owasp.VulnReport.ascx.ascxReportPdf ascxReportPdf;
        private SplitContainer splitContainer1;
        //private ascxProjects ascxProjects;			
		
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCurrentAndArchivedProjects()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();	
			frmCurrentAndArchivedProjects.cAscxProjects = ascxProjects;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{		
			if( disposing )
			{				
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tbProjectMetadata = new System.Windows.Forms.TabPage();
            this.cbCurrentOrArchivedProjects = new System.Windows.Forms.ComboBox();
            this.lbCurrentProjects = new System.Windows.Forms.ListBox();
            this.gbAddProject = new System.Windows.Forms.GroupBox();
            this.tbNewProjectName = new System.Windows.Forms.TextBox();
            this.btCreateNewProject = new System.Windows.Forms.Button();
            this.btDeleteSelectedTarget = new System.Windows.Forms.Button();
            this.tbProjectData = new System.Windows.Forms.TabControl();
            this.tpProjectMetadata = new System.Windows.Forms.TabPage();
            this.tpTargets = new System.Windows.Forms.TabPage();
            this.ascxTargets = new Owasp.VulnReport.ascx.ascxTargets();
            this.tbTargetTasks = new System.Windows.Forms.TabPage();
            this.ascxTargetTasks = new Owasp.VulnReport.ascx.ascxTargetTasks();
            this.tpFindings = new System.Windows.Forms.TabPage();
            this.ascxFindings = new Owasp.VulnReport.ascxFindings();
            this.tbExecutiveSummary = new System.Windows.Forms.TabPage();
            this.ascxExecutiveSummary = new Owasp.VulnReport.ascxExecutiveSummary();
            this.tbReportPdf = new System.Windows.Forms.TabPage();
            this.ascxReportPdf = new Owasp.VulnReport.ascx.ascxReportPdf();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ascxProjects = new Owasp.VulnReport.ascxProjects();
            this.gbAddProject.SuspendLayout();
            this.tbProjectData.SuspendLayout();
            this.tpProjectMetadata.SuspendLayout();
            this.tpTargets.SuspendLayout();
            this.tbTargetTasks.SuspendLayout();
            this.tpFindings.SuspendLayout();
            this.tbExecutiveSummary.SuspendLayout();
            this.tbReportPdf.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbProjectMetadata
            // 
            this.tbProjectMetadata.Location = new System.Drawing.Point(0, 0);
            this.tbProjectMetadata.Name = "tbProjectMetadata";
            this.tbProjectMetadata.Size = new System.Drawing.Size(200, 100);
            this.tbProjectMetadata.TabIndex = 0;
            // 
            // cbCurrentOrArchivedProjects
            // 
            this.cbCurrentOrArchivedProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCurrentOrArchivedProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrentOrArchivedProjects.ItemHeight = 13;
            this.cbCurrentOrArchivedProjects.Items.AddRange(new object[] {
            "Current Projects",
            "Archived Projects",
            "Future Projects"});
            this.cbCurrentOrArchivedProjects.Location = new System.Drawing.Point(3, 4);
            this.cbCurrentOrArchivedProjects.Name = "cbCurrentOrArchivedProjects";
            this.cbCurrentOrArchivedProjects.Size = new System.Drawing.Size(172, 21);
            this.cbCurrentOrArchivedProjects.TabIndex = 22;
            this.cbCurrentOrArchivedProjects.SelectedIndexChanged += new System.EventHandler(this.cbCurrentOrArchivedProjects_SelectedIndexChanged);
            // 
            // lbCurrentProjects
            // 
            this.lbCurrentProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurrentProjects.Location = new System.Drawing.Point(3, 28);
            this.lbCurrentProjects.Name = "lbCurrentProjects";
            this.lbCurrentProjects.Size = new System.Drawing.Size(172, 368);
            this.lbCurrentProjects.Sorted = true;
            this.lbCurrentProjects.TabIndex = 19;
            this.lbCurrentProjects.SelectedIndexChanged += new System.EventHandler(this.lbCurrentProjects_SelectedIndexChanged);
            // 
            // gbAddProject
            // 
            this.gbAddProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddProject.Controls.Add(this.tbNewProjectName);
            this.gbAddProject.Controls.Add(this.btCreateNewProject);
            this.gbAddProject.Location = new System.Drawing.Point(3, 404);
            this.gbAddProject.Name = "gbAddProject";
            this.gbAddProject.Size = new System.Drawing.Size(172, 48);
            this.gbAddProject.TabIndex = 20;
            this.gbAddProject.TabStop = false;
            this.gbAddProject.Text = "Add Project";
            // 
            // tbNewProjectName
            // 
            this.tbNewProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewProjectName.Location = new System.Drawing.Point(8, 16);
            this.tbNewProjectName.Name = "tbNewProjectName";
            this.tbNewProjectName.Size = new System.Drawing.Size(103, 20);
            this.tbNewProjectName.TabIndex = 5;
            // 
            // btCreateNewProject
            // 
            this.btCreateNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateNewProject.Location = new System.Drawing.Point(117, 16);
            this.btCreateNewProject.Name = "btCreateNewProject";
            this.btCreateNewProject.Size = new System.Drawing.Size(49, 20);
            this.btCreateNewProject.TabIndex = 6;
            this.btCreateNewProject.Text = "Add";
            this.btCreateNewProject.Click += new System.EventHandler(this.btCreateNewProject_Click);
            // 
            // btDeleteSelectedTarget
            // 
            this.btDeleteSelectedTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeleteSelectedTarget.Location = new System.Drawing.Point(3, 458);
            this.btDeleteSelectedTarget.Name = "btDeleteSelectedTarget";
            this.btDeleteSelectedTarget.Size = new System.Drawing.Size(172, 24);
            this.btDeleteSelectedTarget.TabIndex = 21;
            this.btDeleteSelectedTarget.Text = "Delete Selected Project";
            this.btDeleteSelectedTarget.Click += new System.EventHandler(this.btDeleteSelectedTarget_Click);
            // 
            // tbProjectData
            // 
            this.tbProjectData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProjectData.Controls.Add(this.tpProjectMetadata);
            this.tbProjectData.Controls.Add(this.tpTargets);
            this.tbProjectData.Controls.Add(this.tbTargetTasks);
            this.tbProjectData.Controls.Add(this.tpFindings);
            this.tbProjectData.Controls.Add(this.tbExecutiveSummary);
            this.tbProjectData.Controls.Add(this.tbReportPdf);
            this.tbProjectData.Location = new System.Drawing.Point(3, 4);
            this.tbProjectData.Name = "tbProjectData";
            this.tbProjectData.SelectedIndex = 0;
            this.tbProjectData.Size = new System.Drawing.Size(683, 488);
            this.tbProjectData.TabIndex = 18;
            this.tbProjectData.SelectedIndexChanged += new System.EventHandler(this.tbProjectData_SelectedIndexChanged);
            // 
            // tpProjectMetadata
            // 
            this.tpProjectMetadata.Controls.Add(this.ascxProjects);
            this.tpProjectMetadata.Location = new System.Drawing.Point(4, 22);
            this.tpProjectMetadata.Name = "tpProjectMetadata";
            this.tpProjectMetadata.Size = new System.Drawing.Size(675, 462);
            this.tpProjectMetadata.TabIndex = 3;
            this.tpProjectMetadata.Text = "Project Metadata";
            // 
            // tpTargets
            // 
            this.tpTargets.Controls.Add(this.ascxTargets);
            this.tpTargets.Location = new System.Drawing.Point(4, 22);
            this.tpTargets.Name = "tpTargets";
            this.tpTargets.Size = new System.Drawing.Size(675, 462);
            this.tpTargets.TabIndex = 2;
            this.tpTargets.Text = "Targets";
            this.tpTargets.Visible = false;
            // 
            // ascxTargets
            // 
            this.ascxTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxTargets.Location = new System.Drawing.Point(8, 8);
            this.ascxTargets.Name = "ascxTargets";
            this.ascxTargets.Size = new System.Drawing.Size(659, 456);
            this.ascxTargets.TabIndex = 0;
            // 
            // tbTargetTasks
            // 
            this.tbTargetTasks.Controls.Add(this.ascxTargetTasks);
            this.tbTargetTasks.Location = new System.Drawing.Point(4, 22);
            this.tbTargetTasks.Name = "tbTargetTasks";
            this.tbTargetTasks.Size = new System.Drawing.Size(675, 462);
            this.tbTargetTasks.TabIndex = 6;
            this.tbTargetTasks.Text = "Target Tasks";
            // 
            // ascxTargetTasks
            // 
            this.ascxTargetTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxTargetTasks.Location = new System.Drawing.Point(8, 8);
            this.ascxTargetTasks.Name = "ascxTargetTasks";
            this.ascxTargetTasks.Size = new System.Drawing.Size(659, 448);
            this.ascxTargetTasks.TabIndex = 0;
            // 
            // tpFindings
            // 
            this.tpFindings.Controls.Add(this.ascxFindings);
            this.tpFindings.Location = new System.Drawing.Point(4, 22);
            this.tpFindings.Name = "tpFindings";
            this.tpFindings.Size = new System.Drawing.Size(675, 462);
            this.tpFindings.TabIndex = 1;
            this.tpFindings.Text = "Findings";
            this.tpFindings.Visible = false;
            // 
            // ascxFindings
            // 
            this.ascxFindings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxFindings.Location = new System.Drawing.Point(8, 8);
            this.ascxFindings.Name = "ascxFindings";
            this.ascxFindings.Size = new System.Drawing.Size(659, 448);
            this.ascxFindings.TabIndex = 0;
            // 
            // tbExecutiveSummary
            // 
            this.tbExecutiveSummary.Controls.Add(this.ascxExecutiveSummary);
            this.tbExecutiveSummary.Location = new System.Drawing.Point(4, 22);
            this.tbExecutiveSummary.Name = "tbExecutiveSummary";
            this.tbExecutiveSummary.Size = new System.Drawing.Size(675, 462);
            this.tbExecutiveSummary.TabIndex = 4;
            this.tbExecutiveSummary.Text = "Report Contents";
            this.tbExecutiveSummary.Visible = false;
            // 
            // ascxExecutiveSummary
            // 
            this.ascxExecutiveSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxExecutiveSummary.Location = new System.Drawing.Point(8, 8);
            this.ascxExecutiveSummary.Name = "ascxExecutiveSummary";
            this.ascxExecutiveSummary.Size = new System.Drawing.Size(659, 448);
            this.ascxExecutiveSummary.TabIndex = 0;
            // 
            // tbReportPdf
            // 
            this.tbReportPdf.Controls.Add(this.ascxReportPdf);
            this.tbReportPdf.Location = new System.Drawing.Point(4, 22);
            this.tbReportPdf.Name = "tbReportPdf";
            this.tbReportPdf.Size = new System.Drawing.Size(675, 462);
            this.tbReportPdf.TabIndex = 5;
            this.tbReportPdf.Text = "Report Pdf";
            this.tbReportPdf.Visible = false;
            // 
            // ascxReportPdf
            // 
            this.ascxReportPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxReportPdf.Location = new System.Drawing.Point(8, 8);
            this.ascxReportPdf.Name = "ascxReportPdf";
            this.ascxReportPdf.Size = new System.Drawing.Size(667, 448);
            this.ascxReportPdf.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 5);
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbCurrentOrArchivedProjects);
            this.splitContainer1.Panel1.Controls.Add(this.btDeleteSelectedTarget);
            this.splitContainer1.Panel1.Controls.Add(this.lbCurrentProjects);
            this.splitContainer1.Panel1.Controls.Add(this.gbAddProject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbProjectData);
            this.splitContainer1.Size = new System.Drawing.Size(873, 492);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 23;
            // 
            // ascxProjects
            // 
            this.ascxProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxProjects.Location = new System.Drawing.Point(3, 3);
            this.ascxProjects.Name = "ascxProjects";
            this.ascxProjects.Size = new System.Drawing.Size(669, 456);
            this.ascxProjects.TabIndex = 0;
            // 
            // frmCurrentAndArchivedProjects
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(878, 502);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCurrentAndArchivedProjects";
            this.Text = "Current and Archived Projects";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCurrentAndArchivedProjects_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbAddProject.ResumeLayout(false);
            this.gbAddProject.PerformLayout();
            this.tbProjectData.ResumeLayout(false);
            this.tpProjectMetadata.ResumeLayout(false);
            this.tpTargets.ResumeLayout(false);
            this.tbTargetTasks.ResumeLayout(false);
            this.tpFindings.ResumeLayout(false);
            this.tbExecutiveSummary.ResumeLayout(false);
            this.tbReportPdf.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Form1_Load(object sender, System.EventArgs e)
		{			
			loadAvailableProjects();		
			bFirstTimeThisFormIsLoaded = true;
			cbCurrentOrArchivedProjects.SelectedIndex= 0;		
		}

		private void loadAvailableProjects()
		{
			utils.windowsForms.loadDirectoriesIntoListBox(lbCurrentProjects,upCurrentUser.ProjectFilesPath,"*");			
		}

		private void flbProjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
		private void loadXmlFileInTargetAuthenticView(AxXMLSPYPLUGINLib.AxAuthentic axTargetAuthenticObject,string urlToXml,string urlToXsd,string urlToSps)
		{
			axTargetAuthenticObject.SchemaLoadObject.URL =  urlToXsd;
			axTargetAuthenticObject.DesignDataLoadObject.URL = urlToSps;
			axTargetAuthenticObject.XMLDataLoadObject.URL = urlToXml;
			axTargetAuthenticObject.XMLDataSaveUrl = urlToXml;
			axTargetAuthenticObject.EntryHelpersEnabled = true;
			axTargetAuthenticObject.AllowDrop = true;
			axTargetAuthenticObject.StartEditing();
		}

		private void btCreateNewProject_Click(object sender, System.EventArgs e)
		{            
			if (tbNewProjectName.Text == "")
				MessageBox.Show("You must enter a new project name");
			else
			{
				if (lbCurrentProjects.Items.Contains(tbNewProjectName.Text))
					MessageBox.Show("A project with that name already exists");
				else
				{
					VulnReportHelpers.createNewProjectAndAddItToListBox(lbCurrentProjects,tbNewProjectName.Text);
					tbNewProjectName.Text = "";
				}
			}

		}

		private void lbCurrentProjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (bFirstTimeThisFormIsLoaded == true)
            {
                lbCurrentProjects.SelectedIndex = -1;			// don't make any selection, this will make loading faster			
                bFirstTimeThisFormIsLoaded = false;
            }
            else
            {

                if (true == ascxFindings.axAuthentic_Findings.Modified)
                {
                    if (bProjectSelectedIndexChanged)		// this only happens if the user clicks on the current item, or after the lbFindingsInCurrentTarget.SelectedIndex has been corrected in the case bellow
                    {
                        bProjectSelectedIndexChanged = false;
                        return;
                    }
                    if (MessageBox.Show("Current Findings contains unsaved data!" + Environment.NewLine + Environment.NewLine +
                        "are you sure you to continue?", "Confirmation Message", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        bProjectSelectedIndexChanged = true;
                        lbCurrentProjects.SelectedIndex = iCurrentProjectSelectedIndex;
                        return;
                    }
                    else
                    {
                        ascxFindings.axAuthentic_Findings.SetUnmodified();
                    }
                }
                // comment the following lines to disable autoloading of autentic pages
                ascxProjects.loadProjectData(lbCurrentProjects.Text);
                ascxTargets.loadProjectData(lbCurrentProjects.Text);
                ascxTargetTasks.loadProjectData(lbCurrentProjects.Text);
                ascxFindings.loadProjectData(lbCurrentProjects.Text);
                ascxExecutiveSummary.loadProjectData(lbCurrentProjects.Text);
                ascxReportPdf.loadProjectData(lbCurrentProjects.Text);
                iCurrentProjectSelectedIndex = lbCurrentProjects.SelectedIndex;
            }
		}


        private void btDeleteSelectedTarget_Click(object sender, System.EventArgs e)
        {
            if (null != lbCurrentProjects.SelectedItem)
            {
                string strFullPathToCurrentProject = Path.GetFullPath(Path.Combine(upCurrentUser.ProjectFilesPath, lbCurrentProjects.SelectedItem.ToString()));
                if (utils.files.deleteDirectoryAfterConfirmation(
                    "Are you sure you want to delete the Target '" + lbCurrentProjects.SelectedItem.ToString() + "'"
                    , "Are you REALLY sure? This will delete all files from this project!!!",
                    strFullPathToCurrentProject))
                {
                    loadAvailableProjects();
                }
            }
            else
                MessageBox.Show("No Project Selected");
        }


		private void cbCurrentOrArchivedProjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            gbAddProject.Enabled = true;
            btDeleteSelectedTarget.Enabled = true;

            // Set folders and UI objects to there proper settings before we load the projects
			switch (cbCurrentOrArchivedProjects.SelectedItem.ToString())
			{
				case "Current Projects":					
				{
                    upCurrentUser.SwitchToCurrentProjects();
					break;
				}
				case "Archived Projects":
				{					
					gbAddProject.Enabled = false;
					btDeleteSelectedTarget.Enabled = false;
                    upCurrentUser.SwitchToArchivedProjects();
					break;
				}
				case "Future Projects":
				{
                    upCurrentUser.SwitchToFutureProjects();
					break;
				}
			}
            loadAvailableProjects();
		}

		private void tbProjectData_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (tbProjectData.SelectedTab.Text )
			{
				case "Findings":
					ascxFindings.configVariablesForKeyboardHook();									
					ascxFindings.refreshNextIdToBeAssigned();
					break;
				case "Report Contents":
					ascxExecutiveSummary.configVariablesForKeyboardHook();
					break;
			}
		}

		private void miReloadGlobalVariables_Click(object sender, System.EventArgs e)
		{
            obpCurrentPaths.initiatePaths();
		}

		private void miExit(object sender, System.EventArgs e)
		{
			VulnReportHelpers.deleteTempFilesAndTerminateProcess();
		}

        /// <summary>
        /// This method handles making sure all the sub-user controls have all there data saved.
        /// If they do not we will prompt the user to save the information.
        /// 
        /// Dev Note: This could potentially be a inconvenience to the users if they get prompted
        /// for 6 different user controls.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCurrentAndArchivedProjects_FormClosing(object sender, FormClosingEventArgs e)
        {
            ascxProjects.CheckForUnSavedDataAndPromptUserToSave();
            ascxTargets.checkForUnSavedDataAndPromptForSave();
            ascxTargetTasks.checkForUnSavedDataAndPromptForSave();
            ascxFindings.checkForUnsavedData();
            ascxFindings.axAuthentic_Findings.Dispose();
            while (ascxFindings.axAuthentic_Findings.Disposing) { }
            ascxExecutiveSummary.checkForUnSavedDataAndPromptForSave();
        }

	}
}
