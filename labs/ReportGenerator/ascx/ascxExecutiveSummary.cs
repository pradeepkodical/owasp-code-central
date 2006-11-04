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
	/// Summary description for ascxExecutiveSummary.
	/// </summary>
	public class ascxExecutiveSummary : System.Windows.Forms.UserControl
	{
        private utils.authentic authUtils = new utils.authentic();
		private string strPathToProjectFiles;
		private string strCurrentProject;
		private string strFullPathToCurrentProject;
        private string strFullPathToCurrentProjectXmlFile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbUnsavedData;
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_ExecutiveSummary;
		private System.Windows.Forms.Button btSaveReportContents;
		private System.Windows.Forms.Label lblReportContentsSaved;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxExecutiveSummary()
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
				axAuthentic_ExecutiveSummary.Dispose();
				axAuthentic_ExecutiveSummary.ContainingControl = null;
				if(null != axAuthentic_ExecutiveSummary && null != components )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxExecutiveSummary));
            this.axAuthentic_ExecutiveSummary = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.btSaveReportContents = new System.Windows.Forms.Button();
            this.lblReportContentsSaved = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_ExecutiveSummary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axAuthentic_ExecutiveSummary
            // 
            this.axAuthentic_ExecutiveSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_ExecutiveSummary.Enabled = true;
            this.axAuthentic_ExecutiveSummary.Location = new System.Drawing.Point(8, 84);
            this.axAuthentic_ExecutiveSummary.Name = "axAuthentic_ExecutiveSummary";
            this.axAuthentic_ExecutiveSummary.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_ExecutiveSummary.OcxState")));
            this.axAuthentic_ExecutiveSummary.Size = new System.Drawing.Size(584, 280);
            this.axAuthentic_ExecutiveSummary.TabIndex = 18;
            this.axAuthentic_ExecutiveSummary.SelectionChanged += new System.EventHandler(this.axAuthentic_ExecutiveSummary_SelectionChanged);
            // 
            // btSaveReportContents
            // 
            this.btSaveReportContents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveReportContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveReportContents.Location = new System.Drawing.Point(448, 16);
            this.btSaveReportContents.Name = "btSaveReportContents";
            this.btSaveReportContents.Size = new System.Drawing.Size(120, 40);
            this.btSaveReportContents.TabIndex = 3;
            this.btSaveReportContents.Text = "Save Report Contents";
            this.btSaveReportContents.Click += new System.EventHandler(this.btSaveExecutiveSummary_Click);
            // 
            // lblReportContentsSaved
            // 
            this.lblReportContentsSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportContentsSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportContentsSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblReportContentsSaved.Location = new System.Drawing.Point(336, 24);
            this.lblReportContentsSaved.Name = "lblReportContentsSaved";
            this.lblReportContentsSaved.Size = new System.Drawing.Size(104, 24);
            this.lblReportContentsSaved.TabIndex = 19;
            this.lblReportContentsSaved.Text = "Report Contents Saved";
            this.lblReportContentsSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReportContentsSaved.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btSaveReportContents);
            this.groupBox1.Controls.Add(this.lblReportContentsSaved);
            this.groupBox1.Controls.Add(this.lbUnsavedData);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 64);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(344, 24);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(56, 24);
            this.lbUnsavedData.TabIndex = 20;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // ascxExecutiveSummary
            // 
            this.Controls.Add(this.axAuthentic_ExecutiveSummary);
            this.Controls.Add(this.groupBox1);
            this.Name = "ascxExecutiveSummary";
            this.Size = new System.Drawing.Size(600, 376);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_ExecutiveSummary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public void loadProjectData(string strProjectToLoad)
		{
            checkForUnSavedDataAndPromptForSave();
            UserProfile up = UserProfile.GetUserProfile();
			this.strPathToProjectFiles  = up.ProjectFilesPath;
			this.strCurrentProject = strProjectToLoad;
			this.strFullPathToCurrentProject = Path.GetFullPath(Path.Combine(strPathToProjectFiles, strCurrentProject));								
			this.strFullPathToCurrentProjectXmlFile = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject , strCurrentProject + "_ReportContents.xml"));
            checkIfReportContentsFileExists();
			utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_ExecutiveSummary,strFullPathToCurrentProjectXmlFile,GlobalVariables.strPathToProjectSchema,GlobalVariables.strPathToSPS_ExecutiveSummary);
			axAuthentic_ExecutiveSummary.SetUnmodified();
			lbUnsavedData.Visible = false;
		}

		private void btSaveExecutiveSummary_Click(object sender, System.EventArgs e)
		{
            saveCurrentData();
			lblReportContentsSaved.Visible= true;
			lbUnsavedData.Visible= false;
		}

		private void axAuthentic_ExecutiveSummary_SelectionChanged(object sender, System.EventArgs e)
		{
			axAuthentic_ExecutiveSummary.Select();
			lblReportContentsSaved.Visible = false;
			if (axAuthentic_ExecutiveSummary.Modified)
				lbUnsavedData.Visible = true;
		}

		public void configVariablesForKeyboardHook()
		{			
			if ((authUtils.CurrentKeyboardHook == null) || (!authUtils.CurrentKeyboardHook.IsInstalled))
				authUtils.installKeyboardHookInCurrentThread();		
			authUtils.AuthenticObject = axAuthentic_ExecutiveSummary;
			authUtils.CurrentControl = (ContainerControl)this;		
		}

        /// <summary>
        /// This method saves the current data.
        /// </summary>
        private void saveCurrentData()
        {
            axAuthentic_ExecutiveSummary.Save();
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
            if (axAuthentic_ExecutiveSummary.Modified)
            {
                promptUserToSaveData();
            }
        }

        /// <summary>
        /// This method checks to see if the {Project Name}_ReportContents.xml exists, and 
        /// if it doesn't it creates it based on the path in
        /// GlobalVariables.strPathToTemplateFile_EmptyProjectXmlFile
        /// </summary>
        private void checkIfReportContentsFileExists() 
        {
            if (! File.Exists(this.strFullPathToCurrentProjectXmlFile))
            {
                File.Copy(GlobalVariables.strPathToTemplateFile_EmptyProjectXmlFile, strFullPathToCurrentProjectXmlFile);
            }
        }
	}
}
