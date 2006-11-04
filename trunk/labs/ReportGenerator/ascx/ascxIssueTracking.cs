using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxIssueTracking.
	/// </summary>
	public class ascxIssueTracking : System.Windows.Forms.UserControl
	{
		private string strTemplateToUse = "";
		private bool bRefreshView = true;
        private UserProfile upCurrentUser = UserProfile.GetUserProfile();
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_IssueTracking;
		private System.Windows.Forms.Button btDeleteSelectedIssueTrackingFiles;
		private System.Windows.Forms.ListBox lbCurrentIssueTrackingFiles;
		private System.Windows.Forms.Button btSaveFinding;
		private System.Windows.Forms.Label lbIssueTrackingFileSaved;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbTemplateToUse;
        private System.Windows.Forms.Label lbUnsavedData;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxIssueTracking()
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
				axAuthentic_IssueTracking.Dispose();
				axAuthentic_IssueTracking.ContainingControl = null;
				if(null != axAuthentic_IssueTracking && null != components )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxIssueTracking));
            this.axAuthentic_IssueTracking = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.btDeleteSelectedIssueTrackingFiles = new System.Windows.Forms.Button();
            this.lbCurrentIssueTrackingFiles = new System.Windows.Forms.ListBox();
            this.lbIssueTrackingFileSaved = new System.Windows.Forms.Label();
            this.btSaveFinding = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTemplateToUse = new System.Windows.Forms.ComboBox();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_IssueTracking)).BeginInit();
            this.SuspendLayout();
            // 
            // axAuthentic_IssueTracking
            // 
            this.axAuthentic_IssueTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_IssueTracking.Enabled = true;
            this.axAuthentic_IssueTracking.Location = new System.Drawing.Point(192, 48);
            this.axAuthentic_IssueTracking.Name = "axAuthentic_IssueTracking";
            this.axAuthentic_IssueTracking.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_IssueTracking.OcxState")));
            this.axAuthentic_IssueTracking.Size = new System.Drawing.Size(688, 400);
            this.axAuthentic_IssueTracking.TabIndex = 21;
            this.axAuthentic_IssueTracking.SelectionChanged += new System.EventHandler(this.axAuthentic_IssueTracking_SelectionChanged);
            // 
            // btDeleteSelectedIssueTrackingFiles
            // 
            this.btDeleteSelectedIssueTrackingFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeleteSelectedIssueTrackingFiles.Location = new System.Drawing.Point(0, 371);
            this.btDeleteSelectedIssueTrackingFiles.Name = "btDeleteSelectedIssueTrackingFiles";
            this.btDeleteSelectedIssueTrackingFiles.Size = new System.Drawing.Size(192, 32);
            this.btDeleteSelectedIssueTrackingFiles.TabIndex = 20;
            this.btDeleteSelectedIssueTrackingFiles.Text = "Delete Selected Issue Tracking File";
            this.btDeleteSelectedIssueTrackingFiles.Click += new System.EventHandler(this.btDeleteSelectedIssueTrackingFiles_Click);
            // 
            // lbCurrentIssueTrackingFiles
            // 
            this.lbCurrentIssueTrackingFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCurrentIssueTrackingFiles.Location = new System.Drawing.Point(0, 48);
            this.lbCurrentIssueTrackingFiles.Name = "lbCurrentIssueTrackingFiles";
            this.lbCurrentIssueTrackingFiles.Size = new System.Drawing.Size(184, 316);
            this.lbCurrentIssueTrackingFiles.TabIndex = 19;
            this.lbCurrentIssueTrackingFiles.SelectedIndexChanged += new System.EventHandler(this.lbCurrentIssueTrackingFiles_SelectedIndexChanged);
            // 
            // lbIssueTrackingFileSaved
            // 
            this.lbIssueTrackingFileSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIssueTrackingFileSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueTrackingFileSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbIssueTrackingFileSaved.Location = new System.Drawing.Point(584, 8);
            this.lbIssueTrackingFileSaved.Name = "lbIssueTrackingFileSaved";
            this.lbIssueTrackingFileSaved.Size = new System.Drawing.Size(136, 24);
            this.lbIssueTrackingFileSaved.TabIndex = 23;
            this.lbIssueTrackingFileSaved.Text = "Findings Saved";
            this.lbIssueTrackingFileSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbIssueTrackingFileSaved.Visible = false;
            // 
            // btSaveFinding
            // 
            this.btSaveFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveFinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveFinding.Location = new System.Drawing.Point(728, 8);
            this.btSaveFinding.Name = "btSaveFinding";
            this.btSaveFinding.Size = new System.Drawing.Size(152, 24);
            this.btSaveFinding.TabIndex = 22;
            this.btSaveFinding.Text = "Save Issue Tracking File";
            this.btSaveFinding.Click += new System.EventHandler(this.btSaveFinding_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Template To Use";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // cbTemplateToUse
            // 
            this.cbTemplateToUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplateToUse.Items.AddRange(new object[] {
            "Issue Tracking - Just Items and Status",
            "Issue Tracking - With Resolution Info",
            "Edit Project Data",
            "Edit Findings Data",
            "Edit Executive Summary",
            "Edit Targets"});
            this.cbTemplateToUse.Location = new System.Drawing.Point(0, 24);
            this.cbTemplateToUse.Name = "cbTemplateToUse";
            this.cbTemplateToUse.Size = new System.Drawing.Size(184, 21);
            this.cbTemplateToUse.TabIndex = 24;
            this.cbTemplateToUse.SelectedIndexChanged += new System.EventHandler(this.cbTemplateToUse_SelectedIndexChanged);
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(600, 8);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(112, 24);
            this.lbUnsavedData.TabIndex = 25;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // ascxIssueTracking
            // 
            this.Controls.Add(this.lbUnsavedData);
            this.Controls.Add(this.cbTemplateToUse);
            this.Controls.Add(this.lbIssueTrackingFileSaved);
            this.Controls.Add(this.btSaveFinding);
            this.Controls.Add(this.axAuthentic_IssueTracking);
            this.Controls.Add(this.btDeleteSelectedIssueTrackingFiles);
            this.Controls.Add(this.lbCurrentIssueTrackingFiles);
            this.Controls.Add(this.label1);
            this.Name = "ascxIssueTracking";
            this.Size = new System.Drawing.Size(888, 456);
            this.Load += new System.EventHandler(this.ascxIssueTracking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_IssueTracking)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ascxIssueTracking_Load(object sender, System.EventArgs e)
		{
			cbTemplateToUse.SelectedIndex = 0;
		}

		public void loadReportFilesIntoListbox()
		{
            if (Directory.Exists(upCurrentUser.ConsolidatedReportsPath))
            {
                utils.windowsForms.loadFilesIntoListBox(lbCurrentIssueTrackingFiles,
                                                        upCurrentUser.ConsolidatedReportsPath,
                                                        "*.xml");
            }
		}		

		private void lbCurrentIssueTrackingFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			bRefreshView = false;								// don't refresh (if this was true this would cause an infinite loop)
			cbTemplateToUse_SelectedIndexChanged(null,null);	// ensure the value is populated
			bRefreshView = true;								// reset the Refresh view flag
			string strPathToXmlFile = Path.Combine(upCurrentUser.ConsolidatedReportsPath , lbCurrentIssueTrackingFiles.Text);						
			utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_IssueTracking,strPathToXmlFile,GlobalVariables.strPathToProjectSchema,strTemplateToUse);
			lbUnsavedData.Visible = false;
		}

		private void btDeleteSelectedIssueTrackingFiles_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Not Implemented yet, delete the file manually");
		}

		private void btSaveFinding_Click(object sender, System.EventArgs e)
		{
            saveCurrentData();
			lbIssueTrackingFileSaved.Visible = true;
			lbUnsavedData.Visible = false;
		}

		private void axAuthentic_IssueTracking_SelectionChanged(object sender, System.EventArgs e)
		{
			lbIssueTrackingFileSaved.Visible = false;
			lbUnsavedData.Visible = true;
		}

		private void cbTemplateToUse_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (cbTemplateToUse.Text)
			{
				case "Issue Tracking - Just Items and Status":
					strTemplateToUse = GlobalVariables.strPathToSPS_IssueTracking_JustItemsAndStatus;
					break;
				case "Issue Tracking - With Resolution Info":
					strTemplateToUse = GlobalVariables.strPathToSPS_IssueTracking_WithResolutionInfo;
					break;
				case "Edit Project Data":
					strTemplateToUse = GlobalVariables.strPathToSPS_Projects;
					break;
				case "Edit Findings Data":
					strTemplateToUse = GlobalVariables.strPathToSPS_Findings;
					break;
				case "Edit Executive Summary":
					strTemplateToUse = GlobalVariables.strPathToSPS_ExecutiveSummary;
					break;
				case "Edit Targets":
					strTemplateToUse = GlobalVariables.strPathToSPS_Targets;
					break;

			}
			if (true == bRefreshView && lbCurrentIssueTrackingFiles.Text != "")
				lbCurrentIssueTrackingFiles_SelectedIndexChanged(null,null);			
		}

        /// <summary>
        /// This method saves the current data.
        /// </summary>
        private void saveCurrentData()
        {
            if ((axAuthentic_IssueTracking != null) &&
                (axAuthentic_IssueTracking.Modified))
            {
                axAuthentic_IssueTracking.Save();
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

        /// <summary>
        /// This method checks to see if there is any unsaved data for the user and if 
        /// there is then we ask the user if they want the data saved.
        /// </summary>
        public void checkForUnSavedDataAndPromptForSave()
        {
            if (axAuthentic_IssueTracking.Modified)
            {
                promptUserToSaveData();
            }
        }
	}
}
