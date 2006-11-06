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
	/// Summary description for ascxRecommendations.
	/// </summary>
	public class ascxRecommendations : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btSelectNextTag;
		private System.Windows.Forms.Button btInsertNewLine;
		private System.Windows.Forms.Button btInsertImageFromClipboard;
		private System.Windows.Forms.Button btSaveRecommendations;
		private System.Windows.Forms.Button btSelectPreviousTag;
		private System.Windows.Forms.Button btReloadDB;
		private System.Windows.Forms.Label lbRecommendationsSaved;
		private System.Windows.Forms.Label lbUnsavedData;
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_Recomendations;

        private UserProfile upCurrentUser = UserProfile.GetUserProfile();
        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxRecommendations()
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
				axAuthentic_Recomendations.Dispose();
				axAuthentic_Recomendations.ContainingControl = null;
				if(null != axAuthentic_Recomendations && null != components )
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ascxRecommendations));
			this.axAuthentic_Recomendations = new AxXMLSPYPLUGINLib.AxAuthentic();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btReloadDB = new System.Windows.Forms.Button();
			this.btSelectNextTag = new System.Windows.Forms.Button();
			this.btInsertNewLine = new System.Windows.Forms.Button();
			this.btInsertImageFromClipboard = new System.Windows.Forms.Button();
			this.btSaveRecommendations = new System.Windows.Forms.Button();
			this.btSelectPreviousTag = new System.Windows.Forms.Button();
			this.lbRecommendationsSaved = new System.Windows.Forms.Label();
			this.lbUnsavedData = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Recomendations)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// axAuthentic_Recomendations
			// 
			this.axAuthentic_Recomendations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.axAuthentic_Recomendations.Enabled = true;
			this.axAuthentic_Recomendations.Location = new System.Drawing.Point(8, 80);
			this.axAuthentic_Recomendations.Name = "axAuthentic_Recomendations";
			this.axAuthentic_Recomendations.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_Recomendations.OcxState")));
			this.axAuthentic_Recomendations.Size = new System.Drawing.Size(576, 256);
			this.axAuthentic_Recomendations.TabIndex = 18;
			this.axAuthentic_Recomendations.SelectionChanged += new System.EventHandler(this.axAuthentic1_SelectionChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lbRecommendationsSaved);
			this.groupBox1.Controls.Add(this.lbUnsavedData);
			this.groupBox1.Controls.Add(this.btReloadDB);
			this.groupBox1.Controls.Add(this.btSelectNextTag);
			this.groupBox1.Controls.Add(this.btInsertNewLine);
			this.groupBox1.Controls.Add(this.btInsertImageFromClipboard);
			this.groupBox1.Controls.Add(this.btSaveRecommendations);
			this.groupBox1.Controls.Add(this.btSelectPreviousTag);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(576, 64);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			// 
			// btReloadDB
			// 
			this.btReloadDB.Location = new System.Drawing.Point(240, 16);
			this.btReloadDB.Name = "btReloadDB";
			this.btReloadDB.Size = new System.Drawing.Size(48, 40);
			this.btReloadDB.TabIndex = 20;
			this.btReloadDB.Text = "Reload DB";
			this.btReloadDB.Click += new System.EventHandler(this.btReloadDB_Click);
			// 
			// btSelectNextTag
			// 
			this.btSelectNextTag.Location = new System.Drawing.Point(32, 16);
			this.btSelectNextTag.Name = "btSelectNextTag";
			this.btSelectNextTag.Size = new System.Drawing.Size(16, 40);
			this.btSelectNextTag.TabIndex = 5;
			this.btSelectNextTag.Text = ">";
			this.btSelectNextTag.Click += new System.EventHandler(this.btSelectNextTag_Click);
			// 
			// btInsertNewLine
			// 
			this.btInsertNewLine.Location = new System.Drawing.Point(56, 16);
			this.btInsertNewLine.Name = "btInsertNewLine";
			this.btInsertNewLine.Size = new System.Drawing.Size(64, 40);
			this.btInsertNewLine.TabIndex = 4;
			this.btInsertNewLine.Text = "Insert New Line";
			this.btInsertNewLine.Click += new System.EventHandler(this.btInsertNewLine_Click);
			// 
			// btInsertImageFromClipboard
			// 
			this.btInsertImageFromClipboard.Location = new System.Drawing.Point(128, 16);
			this.btInsertImageFromClipboard.Name = "btInsertImageFromClipboard";
			this.btInsertImageFromClipboard.Size = new System.Drawing.Size(104, 40);
			this.btInsertImageFromClipboard.TabIndex = 4;
			this.btInsertImageFromClipboard.Text = "Paste Image from Clipboard";
			this.btInsertImageFromClipboard.Visible = false;
			// 
			// btSaveRecommendations
			// 
			this.btSaveRecommendations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSaveRecommendations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btSaveRecommendations.Location = new System.Drawing.Point(424, 16);
			this.btSaveRecommendations.Name = "btSaveRecommendations";
			this.btSaveRecommendations.Size = new System.Drawing.Size(136, 40);
			this.btSaveRecommendations.TabIndex = 3;
			this.btSaveRecommendations.Text = "Save Recommendations";
			this.btSaveRecommendations.Click += new System.EventHandler(this.btSaveRecommendations_Click);
			// 
			// btSelectPreviousTag
			// 
			this.btSelectPreviousTag.Location = new System.Drawing.Point(8, 16);
			this.btSelectPreviousTag.Name = "btSelectPreviousTag";
			this.btSelectPreviousTag.Size = new System.Drawing.Size(16, 40);
			this.btSelectPreviousTag.TabIndex = 5;
			this.btSelectPreviousTag.Text = "<";
			this.btSelectPreviousTag.Click += new System.EventHandler(this.btSelectPreviousTag_Click);
			// 
			// lbRecommendationsSaved
			// 
			this.lbRecommendationsSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbRecommendationsSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbRecommendationsSaved.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.lbRecommendationsSaved.Location = new System.Drawing.Point(360, 24);
			this.lbRecommendationsSaved.Name = "lbRecommendationsSaved";
			this.lbRecommendationsSaved.Size = new System.Drawing.Size(56, 24);
			this.lbRecommendationsSaved.TabIndex = 21;
			this.lbRecommendationsSaved.Text = "Findings Saved";
			this.lbRecommendationsSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbRecommendationsSaved.Visible = false;
			// 
			// lbUnsavedData
			// 
			this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
			this.lbUnsavedData.Location = new System.Drawing.Point(360, 24);
			this.lbUnsavedData.Name = "lbUnsavedData";
			this.lbUnsavedData.Size = new System.Drawing.Size(56, 24);
			this.lbUnsavedData.TabIndex = 22;
			this.lbUnsavedData.Text = "Unsaved Data";
			this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbUnsavedData.Visible = false;
			// 
			// ascxRecommendations
			// 
			this.Controls.Add(this.axAuthentic_Recomendations);
			this.Controls.Add(this.groupBox1);
			this.Name = "ascxRecommendations";
			this.Size = new System.Drawing.Size(592, 344);
			((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Recomendations)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void loadRecommendationsXmlFileIntoAuthenticEditor()
		{
            string recommendationsDBPath = Path.GetFullPath(Path.Combine(upCurrentUser.ProjectFilesPath,
                                                                         ConfigurationManager.AppSettings["recommendationsDatabase"])); ;

            checkForUnSavedDataAndPromptForSave();

            if (!Directory.Exists(Path.GetDirectoryName(recommendationsDBPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(recommendationsDBPath));
            }

			utils.authentic.loadXmlFileInTargetAuthenticView( axAuthentic_Recomendations,
                                                              recommendationsDBPath,
                                                              obpPaths.RecommendationSchemaPath, 
                                                              obpPaths.SpsRecommendationsDbPath);
			axAuthentic_Recomendations.SetUnmodified();
			lbUnsavedData.Visible = false;
		}	

		private void btSaveRecommendations_Click(object sender, System.EventArgs e)
		{
            saveCurrentData();			
			lbRecommendationsSaved.Visible= true;
			lbUnsavedData.Visible= false;		
		}

		private void axAuthentic1_SelectionChanged(object sender, System.EventArgs e)
		{			
			axAuthentic_Recomendations.Select();
			lbRecommendationsSaved.Visible = false;
			if (axAuthentic_Recomendations.Modified)
				lbUnsavedData.Visible = true;
		}

		private void btSelectPreviousTag_Click(object sender, System.EventArgs e)
		{
			utils.authentic.authentic_SelectPreviousTag(axAuthentic_Recomendations);
		}

		private void btSelectNextTag_Click(object sender, System.EventArgs e)
		{
			utils.authentic.authentic_SelectNextTag(axAuthentic_Recomendations);
		}

		private void btInsertNewLine_Click(object sender, System.EventArgs e)
		{
			utils.authentic.authentic_InsertNewLine(axAuthentic_Recomendations);
		}

		private void btReloadDB_Click(object sender, System.EventArgs e)
		{
			loadRecommendationsXmlFileIntoAuthenticEditor();
		}

        /// <summary>
        /// This method saves the current data.
        /// </summary>
        private void saveCurrentData()
        {
            axAuthentic_Recomendations.Save();
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
            if (axAuthentic_Recomendations.Modified)
            {
                promptUserToSaveData();
            }
        }
	}
}
