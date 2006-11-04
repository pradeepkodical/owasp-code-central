using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxViewFindingsBydate.
	/// </summary>
	public class ascxViewFindingsBydate : System.Windows.Forms.UserControl
	{
		string strPathToSelectedProject = "";
		string strPathToUnzipSelectedFinding = "";
		string strFullPathToSelectedFinding = "";
		string strPathToXmlFile = "";
        private UserProfile upCurrentUser = UserProfile.GetUserProfile();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbCurrentProjects;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lvFindingsInProject;
		private System.Windows.Forms.ColumnHeader chFinding;
		private System.Windows.Forms.ColumnHeader chDateModified;
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_SelectedFinding;
		private System.Windows.Forms.Button btReloadFindingFromTempFile;
		private System.Windows.Forms.Label lbTempFileLocation;
		private System.Windows.Forms.Button btSaveFinding;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbUnsavedData;
		private System.Windows.Forms.Label lblFindingSaved;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbEditMode;
		private System.Windows.Forms.TextBox txtSelectedFinding;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxViewFindingsBydate()
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
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ascxViewFindingsBydate));
			this.axAuthentic_SelectedFinding = new AxXMLSPYPLUGINLib.AxAuthentic();
			this.label1 = new System.Windows.Forms.Label();
			this.cbCurrentProjects = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lvFindingsInProject = new System.Windows.Forms.ListView();
			this.chDateModified = new System.Windows.Forms.ColumnHeader();
			this.chFinding = new System.Windows.Forms.ColumnHeader();
			this.btReloadFindingFromTempFile = new System.Windows.Forms.Button();
			this.lbTempFileLocation = new System.Windows.Forms.Label();
			this.btSaveFinding = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lbUnsavedData = new System.Windows.Forms.Label();
			this.lblFindingSaved = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbEditMode = new System.Windows.Forms.ComboBox();
			this.txtSelectedFinding = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.axAuthentic_SelectedFinding)).BeginInit();
			this.SuspendLayout();
			// 
			// axAuthentic_SelectedFinding
			// 
			this.axAuthentic_SelectedFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.axAuthentic_SelectedFinding.Enabled = true;
			this.axAuthentic_SelectedFinding.Location = new System.Drawing.Point(336, 64);
			this.axAuthentic_SelectedFinding.Name = "axAuthentic_SelectedFinding";
			this.axAuthentic_SelectedFinding.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_SelectedFinding.OcxState")));
			this.axAuthentic_SelectedFinding.Size = new System.Drawing.Size(760, 288);
			this.axAuthentic_SelectedFinding.TabIndex = 25;
			this.axAuthentic_SelectedFinding.SelectionChanged += new System.EventHandler(this.axAuthentic_SelectedFinding_SelectionChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(336, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 24);
			this.label1.TabIndex = 26;
			this.label1.Text = "Finding:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbCurrentProjects
			// 
			this.cbCurrentProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCurrentProjects.Location = new System.Drawing.Point(0, 32);
			this.cbCurrentProjects.Name = "cbCurrentProjects";
			this.cbCurrentProjects.Size = new System.Drawing.Size(328, 21);
			this.cbCurrentProjects.TabIndex = 27;
			this.cbCurrentProjects.SelectedIndexChanged += new System.EventHandler(this.cbCurrentProjects_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(0, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 24);
			this.label2.TabIndex = 26;
			this.label2.Text = "Select Project";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvFindingsInProject
			// 
			this.lvFindingsInProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.lvFindingsInProject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.chDateModified,
																								  this.chFinding});
			this.lvFindingsInProject.FullRowSelect = true;
			this.lvFindingsInProject.Location = new System.Drawing.Point(0, 64);
			this.lvFindingsInProject.MultiSelect = false;
			this.lvFindingsInProject.Name = "lvFindingsInProject";
			this.lvFindingsInProject.Size = new System.Drawing.Size(328, 288);
			this.lvFindingsInProject.Sorting = System.Windows.Forms.SortOrder.Descending;
			this.lvFindingsInProject.TabIndex = 28;
			this.lvFindingsInProject.View = System.Windows.Forms.View.Details;
			this.lvFindingsInProject.SelectedIndexChanged += new System.EventHandler(this.lvFindingsInProject_SelectedIndexChanged);
			// 
			// chDateModified
			// 
			this.chDateModified.Text = "Date Modified";
			this.chDateModified.Width = 100;
			// 
			// chFinding
			// 
			this.chFinding.Text = "Finding";
			this.chFinding.Width = 224;
			// 
			// btReloadFindingFromTempFile
			// 
			this.btReloadFindingFromTempFile.Location = new System.Drawing.Point(552, 8);
			this.btReloadFindingFromTempFile.Name = "btReloadFindingFromTempFile";
			this.btReloadFindingFromTempFile.Size = new System.Drawing.Size(168, 24);
			this.btReloadFindingFromTempFile.TabIndex = 29;
			this.btReloadFindingFromTempFile.Text = "Reload Finding from Temp File";
			this.btReloadFindingFromTempFile.Click += new System.EventHandler(this.btReloadFindingFromTempFile_Click);
			// 
			// lbTempFileLocation
			// 
			this.lbTempFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbTempFileLocation.Location = new System.Drawing.Point(400, 32);
			this.lbTempFileLocation.Name = "lbTempFileLocation";
			this.lbTempFileLocation.Size = new System.Drawing.Size(512, 32);
			this.lbTempFileLocation.TabIndex = 30;
			this.lbTempFileLocation.Text = "...";
			this.lbTempFileLocation.Click += new System.EventHandler(this.lbTempFileLocation_Click);
			// 
			// btSaveFinding
			// 
			this.btSaveFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSaveFinding.Location = new System.Drawing.Point(992, 8);
			this.btSaveFinding.Name = "btSaveFinding";
			this.btSaveFinding.Size = new System.Drawing.Size(104, 32);
			this.btSaveFinding.TabIndex = 29;
			this.btSaveFinding.Text = "Save Finding";
			this.btSaveFinding.Click += new System.EventHandler(this.btSaveFinding_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(728, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(176, 32);
			this.label3.TabIndex = 30;
			this.label3.Text = "use this if you want to change the xml file externaly (for example to spell check" +
				" it)";
			// 
			// lbUnsavedData
			// 
			this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
			this.lbUnsavedData.Location = new System.Drawing.Point(912, 16);
			this.lbUnsavedData.Name = "lbUnsavedData";
			this.lbUnsavedData.Size = new System.Drawing.Size(56, 24);
			this.lbUnsavedData.TabIndex = 31;
			this.lbUnsavedData.Text = "Unsaved Data";
			this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbUnsavedData.Visible = false;
			// 
			// lblFindingSaved
			// 
			this.lblFindingSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFindingSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFindingSaved.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.lblFindingSaved.Location = new System.Drawing.Point(912, 16);
			this.lblFindingSaved.Name = "lblFindingSaved";
			this.lblFindingSaved.Size = new System.Drawing.Size(56, 24);
			this.lblFindingSaved.TabIndex = 32;
			this.lblFindingSaved.Text = "Findings Saved";
			this.lblFindingSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblFindingSaved.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(336, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 33;
			this.label4.Text = "Edit Mode:";
			// 
			// cbEditMode
			// 
			this.cbEditMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEditMode.Items.AddRange(new object[] {
															"Authentic",
															"Notepad"});
			this.cbEditMode.Location = new System.Drawing.Point(408, 9);
			this.cbEditMode.Name = "cbEditMode";
			this.cbEditMode.Size = new System.Drawing.Size(81, 21);
			this.cbEditMode.TabIndex = 34;
			this.cbEditMode.SelectedIndexChanged += new System.EventHandler(this.cbEditMode_SelectedIndexChanged);
			// 
			// txtSelectedFinding
			// 
			this.txtSelectedFinding.AcceptsReturn = true;
			this.txtSelectedFinding.AcceptsTab = true;
			this.txtSelectedFinding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSelectedFinding.Location = new System.Drawing.Point(336, 64);
			this.txtSelectedFinding.Multiline = true;
			this.txtSelectedFinding.Name = "txtSelectedFinding";
			this.txtSelectedFinding.Size = new System.Drawing.Size(760, 288);
			this.txtSelectedFinding.TabIndex = 35;
			this.txtSelectedFinding.Text = "";
			// 
			// ascxViewFindingsBydate
			// 
			this.Controls.Add(this.txtSelectedFinding);
			this.Controls.Add(this.cbEditMode);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblFindingSaved);
			this.Controls.Add(this.lbUnsavedData);
			this.Controls.Add(this.lbTempFileLocation);
			this.Controls.Add(this.btReloadFindingFromTempFile);
			this.Controls.Add(this.lvFindingsInProject);
			this.Controls.Add(this.cbCurrentProjects);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.axAuthentic_SelectedFinding);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btSaveFinding);
			this.Controls.Add(this.label3);
			this.Name = "ascxViewFindingsBydate";
			this.Size = new System.Drawing.Size(1104, 360);
			this.Load += new System.EventHandler(this.ascxViewFindingsBydate_Load);
			((System.ComponentModel.ISupportInitialize)(this.axAuthentic_SelectedFinding)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void loadAvailableProjects()
		{
			utils.windowsForms.loadDirectoriesIntoComboBox(cbCurrentProjects,upCurrentUser.ProjectFilesPath,"*");			
			cbEditMode.SelectedIndex=0;
		}

		private void cbCurrentProjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadAllFindingsIntoListView();
		}

		private void loadAllFindingsIntoListView()
		{
			try
			{
				strPathToSelectedProject = Path.Combine(upCurrentUser.ProjectFilesPath, cbCurrentProjects.Text);
				string strSearchPattern = "*";
				string strFileFilter = "*.zip";
				lvFindingsInProject.Items.Clear();
				foreach(DirectoryInfo diToProcess in new DirectoryInfo(strPathToSelectedProject).GetDirectories(strSearchPattern))
					if (diToProcess.Name.Substring(0,1) != "_")						// hide all dirs that start with an _
					{
						foreach(FileInfo fiToProcess in new DirectoryInfo(diToProcess.FullName).GetFiles(strFileFilter))
						{
							string strFindingNameWithTarget = fiToProcess.FullName.Replace(strPathToSelectedProject,"");
							lvFindingsInProject.Items.Add( new ListViewItem(new string[2] {fiToProcess.LastWriteTimeUtc.ToString(),strFindingNameWithTarget}));							
							lvFindingsInProject.Sort();
						}
					}						
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in loadAllFindingsIntoListView:" + ex.Message);				
			}			
		}
					
		
		string strPathToImageDirectoryInUnzipedFolder;

		private void lvFindingsInProject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( lvFindingsInProject.SelectedItems.Count>0)
			{			
				string strPathToTempFileFolder = upCurrentUser.TempDirectoryPath;

				deleteCurrentFindingsTempFolder();
				strFullPathToSelectedFinding = Path.GetFullPath(strPathToSelectedProject + lvFindingsInProject.SelectedItems[0].SubItems[1].Text);
				strPathToUnzipSelectedFinding = strPathToTempFileFolder + "\\" + Path.GetFileNameWithoutExtension(strFullPathToSelectedFinding);
				utils.zip.unzipFile(strFullPathToSelectedFinding,strPathToTempFileFolder);
			
				string strXmlFileToLoad =  Path.GetFileNameWithoutExtension(strFullPathToSelectedFinding)+ ".xml"; 
				strPathToXmlFile = Path.Combine(strPathToUnzipSelectedFinding , strXmlFileToLoad);			

				strPathToImageDirectoryInUnzipedFolder = Path.Combine(strPathToUnzipSelectedFinding,Path.GetFileNameWithoutExtension(strPathToXmlFile));
				utils.authentic.strPathToSaveClipboardImage = strPathToImageDirectoryInUnzipedFolder;
				utils.authentic.strPathToUnzipSelectedFinding = strPathToUnzipSelectedFinding;
				switch (cbEditMode.Text)
				{
					case "Authentic":	
						axAuthentic_SelectedFinding.Visible = true;
						txtSelectedFinding.Visible= false;
						utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_SelectedFinding,strPathToXmlFile,GlobalVariables.strPathToProjectSchema,GlobalVariables.strPathToSPS_Findings);							
						break;
					case "Notepad":
						axAuthentic_SelectedFinding.Visible = false;
						txtSelectedFinding.Visible= true;
						txtSelectedFinding.Text =  utils.files.GetFileContents(strPathToXmlFile);
						break;
					default:
						MessageBox.Show("Unrecognized Edit Mode");
						break;
				}
				
				lbTempFileLocation.Text = strPathToXmlFile;
				lbUnsavedData.Visible = false;
				axAuthentic_SelectedFinding.Visible = true;
			}
		
		}

		public void deleteCurrentFindingsTempFolder()
		{
			while (true)
			{
				try
				{
					if (null != strPathToUnzipSelectedFinding && "" != strPathToUnzipSelectedFinding)
						Directory.Delete(strPathToUnzipSelectedFinding,true);
					break;
				}
				catch (DirectoryNotFoundException)
				{
					break;
				}		// if it is FileNotFoundException don't do anything since the file has already been deleted
				catch (Exception ex)
				{
					if (MessageBox.Show("Error occours while delete Current Findings Temp Folder (" +  ex.Message +")" + Environment.NewLine + Environment.NewLine + 
						"Do you want to try again?", "Error Message",MessageBoxButtons.YesNo) == DialogResult.No)
						break;
				}
			}
		}

		private void ascxViewFindingsBydate_Load(object sender, System.EventArgs e)
		{
			axAuthentic_SelectedFinding.Visible = false;
		}

		private void btSaveFinding_Click(object sender, System.EventArgs e)
		{
			try
			{
				switch (cbEditMode.Text)
				{
					case "Authentic":	
						axAuthentic_SelectedFinding.Save();						
						break;
					case "Notepad":				
						utils.files.SaveFileWithStringContents(strPathToXmlFile,txtSelectedFinding.Text );						
						break;
					default:
						MessageBox.Show("Unrecognized Edit Mode");
						break;
				}	
				
				utils.zip.zipFolder(strPathToUnzipSelectedFinding,strFullPathToSelectedFinding);
				lblFindingSaved.Visible = true;
				lbUnsavedData.Visible = false;
				//MessageBox.Show("Findings Saved");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving file:" + ex.Message);
			}
		}

		private void axAuthentic_SelectedFinding_SelectionChanged(object sender, System.EventArgs e)
		{
			lblFindingSaved.Visible = false;
			if (axAuthentic_SelectedFinding.Modified)
				lbUnsavedData.Visible = true;
		}

		private void btReloadFindingFromTempFile_Click(object sender, System.EventArgs e)
		{
			switch (cbEditMode.Text)
			{
				case "Authentic":	
					utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_SelectedFinding,strPathToXmlFile,GlobalVariables.strPathToProjectSchema,GlobalVariables.strPathToSPS_Findings);			
					break;
				case "Notepad":					
					txtSelectedFinding.Text =  utils.files.GetFileContents(strPathToXmlFile);
					break;
				default:
					MessageBox.Show("Unrecognized Edit Mode");
					break;
			}			
		}

		private void lbTempFileLocation_Click(object sender, System.EventArgs e)
		{
			Clipboard.SetDataObject(lbTempFileLocation.Text);
			MessageBox.Show("value '" + lbTempFileLocation.Text + "' copied to the clipboard");
		}

		private void cbEditMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lvFindingsInProject_SelectedIndexChanged(null,null);
		}
	}
}
