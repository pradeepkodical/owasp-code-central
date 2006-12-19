using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxTargetTasks.
	/// </summary>
	public class ascxTargetTasks : System.Windows.Forms.UserControl
	{
        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

        private string strSpsTargetTasksPath = "";

		private string strFullPathToSelectedTarget;
		private string strPathToProjectFiles;
		private string strPathToTempFileFolder;
		private string strCurrentProject;
		private string strFullPathToCurrentProject;
        private bool unsavedDataExists = false;

		private System.Windows.Forms.ListBox lbTargetsInCurrentProject;
		private System.Windows.Forms.Label lbCurrentProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTargetTasksSaved;
        private System.Windows.Forms.Button btSaveTasks;
		private System.Windows.Forms.Label lbUnsavedData;
		private System.Windows.Forms.Button btReloadTargetsList;
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_TargetTasks;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxTargetTasks()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            // loading this here this was crashing VS2005 when we opened a form that contained this ascx           
            //spsTargetTasksPath = Path.GetFullPath(Path.Combine(obpPaths.PathToSpsFiles,
            //                                               ConfigurationManager.AppSettings["defaultSpsFile_TargetTasks"]));                
            //}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				axAuthentic_TargetTasks.Dispose();
				axAuthentic_TargetTasks.ContainingControl = null;
				if(null != axAuthentic_TargetTasks && null != components )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxTargetTasks));
            this.lbTargetsInCurrentProject = new System.Windows.Forms.ListBox();
            this.lbCurrentProject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTargetTasksSaved = new System.Windows.Forms.Label();
            this.btSaveTasks = new System.Windows.Forms.Button();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            this.axAuthentic_TargetTasks = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.btReloadTargetsList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_TargetTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTargetsInCurrentProject
            // 
            this.lbTargetsInCurrentProject.Location = new System.Drawing.Point(24, 88);
            this.lbTargetsInCurrentProject.Name = "lbTargetsInCurrentProject";
            this.lbTargetsInCurrentProject.Size = new System.Drawing.Size(160, 147);
            this.lbTargetsInCurrentProject.TabIndex = 15;
            this.lbTargetsInCurrentProject.SelectedIndexChanged += new System.EventHandler(this.lbTargetsInCurrentProject_SelectedIndexChanged);
            // 
            // lbCurrentProject
            // 
            this.lbCurrentProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentProject.Location = new System.Drawing.Point(96, 8);
            this.lbCurrentProject.Name = "lbCurrentProject";
            this.lbCurrentProject.Size = new System.Drawing.Size(312, 16);
            this.lbCurrentProject.TabIndex = 14;
            this.lbCurrentProject.Text = "...";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Current Project";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Targets in Current Project:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblTargetTasksSaved);
            this.groupBox1.Controls.Add(this.btSaveTasks);
            this.groupBox1.Controls.Add(this.lbUnsavedData);
            this.groupBox1.Location = new System.Drawing.Point(192, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 64);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lblTargetTasksSaved
            // 
            this.lblTargetTasksSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetTasksSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetTasksSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTargetTasksSaved.Location = new System.Drawing.Point(280, 24);
            this.lblTargetTasksSaved.Name = "lblTargetTasksSaved";
            this.lblTargetTasksSaved.Size = new System.Drawing.Size(80, 24);
            this.lblTargetTasksSaved.TabIndex = 9;
            this.lblTargetTasksSaved.Text = "Targets Tasks Saved";
            this.lblTargetTasksSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTargetTasksSaved.Visible = false;
            // 
            // btSaveTasks
            // 
            this.btSaveTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveTasks.Location = new System.Drawing.Point(368, 16);
            this.btSaveTasks.Name = "btSaveTasks";
            this.btSaveTasks.Size = new System.Drawing.Size(80, 40);
            this.btSaveTasks.TabIndex = 3;
            this.btSaveTasks.Text = "Save Tasks";
            this.btSaveTasks.Click += new System.EventHandler(this.btSaveTasks_Click);
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(304, 24);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(56, 24);
            this.lbUnsavedData.TabIndex = 10;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // axAuthentic_TargetTasks
            // 
            this.axAuthentic_TargetTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_TargetTasks.Enabled = true;
            this.axAuthentic_TargetTasks.Location = new System.Drawing.Point(192, 88);
            this.axAuthentic_TargetTasks.Name = "axAuthentic_TargetTasks";
            this.axAuthentic_TargetTasks.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_TargetTasks.OcxState")));
            this.axAuthentic_TargetTasks.Size = new System.Drawing.Size(464, 320);
            this.axAuthentic_TargetTasks.TabIndex = 16;
            this.axAuthentic_TargetTasks.SelectionChanged += new System.EventHandler(this.axAuthentic_TargetTasks_SelectionChanged);
            // 
            // btReloadTargetsList
            // 
            this.btReloadTargetsList.Location = new System.Drawing.Point(24, 64);
            this.btReloadTargetsList.Name = "btReloadTargetsList";
            this.btReloadTargetsList.Size = new System.Drawing.Size(160, 20);
            this.btReloadTargetsList.TabIndex = 18;
            this.btReloadTargetsList.Text = "Reload Target\'s List";
            this.btReloadTargetsList.Click += new System.EventHandler(this.btReloadTargetsList_Click);
            // 
            // ascxTargetTasks
            // 
            this.Controls.Add(this.btReloadTargetsList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axAuthentic_TargetTasks);
            this.Controls.Add(this.lbTargetsInCurrentProject);
            this.Controls.Add(this.lbCurrentProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "ascxTargetTasks";
            this.Size = new System.Drawing.Size(664, 416);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_TargetTasks)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void loadProjectData(string strProjectToLoad)
		{
            checkForUnSavedDataAndPromptForSave();
            UserProfile up = UserProfile.GetUserProfile();
			axAuthentic_TargetTasks.Visible = false;
			this.strPathToProjectFiles  = up.ProjectFilesPath;
			this.strPathToTempFileFolder = up.TempDirectoryPath;
			this.strCurrentProject = strProjectToLoad;
			this.strFullPathToCurrentProject = Path.GetFullPath(Path.Combine(strPathToProjectFiles, strCurrentProject));
            this.strSpsTargetTasksPath = obpPaths.SpsTargetTasksPath;
			lbCurrentProject.Text = strCurrentProject ;			
			loadTargetsIntoListBox();
            unsavedDataExists = false;
		}

		private void loadTargetsIntoListBox()
		{
			if (!this.DesignMode)
				utils.windowsForms.loadDirectoriesIntoListBox(lbTargetsInCurrentProject,strFullPathToCurrentProject,"*");
		}

		private void lbTargetsInCurrentProject_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			axAuthentic_TargetTasks.Visible= false;
			strFullPathToSelectedTarget = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject,lbTargetsInCurrentProject.SelectedItem.ToString()));

			string strSelectedTarget = lbTargetsInCurrentProject.SelectedItem.ToString();
			string strXmlFileToLoad = Path.GetFileNameWithoutExtension(strSelectedTarget) + ".xml"; 
			string strPathToXmlFile = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject,Path.Combine(strSelectedTarget , strXmlFileToLoad)));

            utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_TargetTasks, strPathToXmlFile, obpPaths.ProjectSchemaPath, strSpsTargetTasksPath);						
		}

		private void btSaveTasks_Click(object sender, System.EventArgs e)
		{
            saveCurrentData();
			lblTargetTasksSaved.Visible= true;
			lbUnsavedData.Visible= false;
            unsavedDataExists = false;
		}

		private void axAuthentic_TargetTasks_SelectionChanged(object sender, System.EventArgs e)
		{
			axAuthentic_TargetTasks.Select();
			lblTargetTasksSaved.Visible = false;
            if (axAuthentic_TargetTasks.Modified)
            {
                lbUnsavedData.Visible = true;
                unsavedDataExists = true;
            }
		}

		private void btReloadTargetsList_Click(object sender, System.EventArgs e)
		{
			loadTargetsIntoListBox();
		}

        /// <summary>
        /// This method saves the current data.
        /// </summary>
        private void saveCurrentData()
        {
            axAuthentic_TargetTasks.Save();
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

        /// <summary>
        /// This method checks to see if there is any unsaved data for the user and if 
        /// there is then we ask the user if they want the data saved.
        /// </summary>
        public void checkForUnSavedDataAndPromptForSave()
        {
            if (unsavedDataExists)
            {
                promptUserToSaveData();
            }
        }
	}
}
