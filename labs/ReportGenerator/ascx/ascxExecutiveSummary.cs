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
        public string strReportContentsTemplatePluginPath;
        
        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();
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
        private OrgBasePaths obpCurrentPaths = OrgBasePaths.GetPaths();
        private ComboBox cbReportContentsTemplates;
        private Label lbReportContentsTemplateLabel;
        private GroupBox groupBox2;
        private Button btReportContents_UseTemplate;

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
            this.cbReportContentsTemplates = new System.Windows.Forms.ComboBox();
            this.lbReportContentsTemplateLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btReportContents_UseTemplate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_ExecutiveSummary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.btSaveReportContents.Location = new System.Drawing.Point(123, 16);
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
            this.lblReportContentsSaved.Location = new System.Drawing.Point(11, 24);
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
            this.groupBox1.Location = new System.Drawing.Point(333, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 64);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(19, 24);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(56, 24);
            this.lbUnsavedData.TabIndex = 20;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // cbReportContentsTemplates
            // 
            this.cbReportContentsTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReportContentsTemplates.FormattingEnabled = true;
            this.cbReportContentsTemplates.Location = new System.Drawing.Point(9, 35);
            this.cbReportContentsTemplates.Name = "cbReportContentsTemplates";
            this.cbReportContentsTemplates.Size = new System.Drawing.Size(163, 21);
            this.cbReportContentsTemplates.TabIndex = 22;
            // 
            // lbReportContentsTemplateLabel
            // 
            this.lbReportContentsTemplateLabel.AutoSize = true;
            this.lbReportContentsTemplateLabel.Location = new System.Drawing.Point(6, 19);
            this.lbReportContentsTemplateLabel.Name = "lbReportContentsTemplateLabel";
            this.lbReportContentsTemplateLabel.Size = new System.Drawing.Size(102, 13);
            this.lbReportContentsTemplateLabel.TabIndex = 21;
            this.lbReportContentsTemplateLabel.Text = "Available Templates";
            this.lbReportContentsTemplateLabel.Click += new System.EventHandler(this.lbReportContentsTemplateLabel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btReportContents_UseTemplate);
            this.groupBox2.Controls.Add(this.lbReportContentsTemplateLabel);
            this.groupBox2.Controls.Add(this.cbReportContentsTemplates);
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 66);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Contents Templates";
            // 
            // btReportContents_UseTemplate
            // 
            this.btReportContents_UseTemplate.Location = new System.Drawing.Point(179, 35);
            this.btReportContents_UseTemplate.Name = "btReportContents_UseTemplate";
            this.btReportContents_UseTemplate.Size = new System.Drawing.Size(104, 23);
            this.btReportContents_UseTemplate.TabIndex = 23;
            this.btReportContents_UseTemplate.Text = "Use Template";
            this.btReportContents_UseTemplate.UseVisualStyleBackColor = true;
            this.btReportContents_UseTemplate.Click += new System.EventHandler(this.btReportContents_UseTemplate_Click);
            // 
            // ascxExecutiveSummary
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.axAuthentic_ExecutiveSummary);
            this.Controls.Add(this.groupBox1);
            this.Name = "ascxExecutiveSummary";
            this.Size = new System.Drawing.Size(600, 376);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_ExecutiveSummary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
			utils.authentic.loadXmlFileInTargetAuthenticView( axAuthentic_ExecutiveSummary,
                                                              strFullPathToCurrentProjectXmlFile,
                                                              obpCurrentPaths.ProjectSchemaPath,
                                                              obpCurrentPaths.SpsExecutiveSummaryPath);
			axAuthentic_ExecutiveSummary.SetUnmodified();
			lbUnsavedData.Visible = false;
            loadPlugInReportContentTemplates();
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
            try
            {
                if (!File.Exists(this.strFullPathToCurrentProjectXmlFile))
                {
                    File.Copy(obpCurrentPaths.EmptyProjectFilePath, strFullPathToCurrentProjectXmlFile);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(string.Format("An issue occured while trying to check If Report Contents File Exists() {0}", ex.Message));
            }
        }

        /// <summary>
        /// Loads current "Report Content" templates if plug-in exists
        /// </summary>
        private void loadPlugInReportContentTemplates()
        {
            strReportContentsTemplatePluginPath = Path.Combine(obpPaths.PluginsPath, "Template_ReportContents//xml"); // Hardcode this for now
            if (true == Directory.Exists(strReportContentsTemplatePluginPath))
            {
                utils.windowsForms.loadFilesIntoComboBox(cbReportContentsTemplates, strReportContentsTemplatePluginPath, "*.xml");
                cbReportContentsTemplates.Enabled = true;
            }
            else
                cbReportContentsTemplates.Enabled = false;
        }

        private void lbReportContentsTemplateLabel_Click(object sender, EventArgs e)
        {
            loadPlugInReportContentTemplates();
        }

        private void btReportContents_UseTemplate_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to use this template? You will lose the current 'Report Contents' data below", "Use 'Report Contents' template", MessageBoxButtons.YesNo))
            {
                string strPathToReportContentsToUse = Path.Combine(strReportContentsTemplatePluginPath, cbReportContentsTemplates.Text);
                utils.files.SaveFileWithStringContents(this.strFullPathToCurrentProjectXmlFile, utils.files.GetFileContents(strPathToReportContentsToUse));
                axAuthentic_ExecutiveSummary.SetUnmodified();
                loadProjectData(this.strCurrentProject);
            }
        }
	}
}
