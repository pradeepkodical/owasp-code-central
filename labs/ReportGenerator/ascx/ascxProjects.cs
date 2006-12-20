using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for ascxProjects.
	/// </summary>
	public class ascxProjects : System.Windows.Forms.UserControl
	{
		private string strPathToProjectFiles;
		private string strCurrentProject;
		private string strFullPathToCurrentProject;
		private string strFullPathToCurrentProjectXmlFile;
        private bool unsavedDataExists = false;
        private Project currentProject = Project.GetProject();
        private OrgBasePaths obpCurrentPaths = OrgBasePaths.GetPaths();

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSaveProjectMetadata;
		private System.Windows.Forms.Label lbUnsavedData;
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_Project;
		private System.Windows.Forms.Label lblProjectsSaved;
        private Label lbXmlBreaksXsdSchema;
        private ToolTip toolTip1;
        private IContainer components;

		public ascxProjects()
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
				axAuthentic_Project.Dispose();
				axAuthentic_Project.ContainingControl = null;
				if(null != axAuthentic_Project && null != components )
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxProjects));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbXmlBreaksXsdSchema = new System.Windows.Forms.Label();
            this.btSaveProjectMetadata = new System.Windows.Forms.Button();
            this.lblProjectsSaved = new System.Windows.Forms.Label();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            this.axAuthentic_Project = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Project)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbXmlBreaksXsdSchema);
            this.groupBox1.Controls.Add(this.btSaveProjectMetadata);
            this.groupBox1.Controls.Add(this.lblProjectsSaved);
            this.groupBox1.Controls.Add(this.lbUnsavedData);
            this.groupBox1.Location = new System.Drawing.Point(250, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 64);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // lbXmlBreaksXsdSchema
            // 
            this.lbXmlBreaksXsdSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbXmlBreaksXsdSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXmlBreaksXsdSchema.ForeColor = System.Drawing.Color.Red;
            this.lbXmlBreaksXsdSchema.Location = new System.Drawing.Point(14, 14);
            this.lbXmlBreaksXsdSchema.Name = "lbXmlBreaksXsdSchema";
            this.lbXmlBreaksXsdSchema.Size = new System.Drawing.Size(105, 40);
            this.lbXmlBreaksXsdSchema.TabIndex = 7;
            this.lbXmlBreaksXsdSchema.Text = "Xml breaks XSD schema!!";
            this.lbXmlBreaksXsdSchema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lbXmlBreaksXsdSchema, "Click to view XSD errors");
            this.lbXmlBreaksXsdSchema.Visible = false;
            this.lbXmlBreaksXsdSchema.Click += new System.EventHandler(this.lbXmlBreaksXsdSchema_Click);
            // 
            // btSaveProjectMetadata
            // 
            this.btSaveProjectMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveProjectMetadata.Enabled = false;
            this.btSaveProjectMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveProjectMetadata.Location = new System.Drawing.Point(190, 16);
            this.btSaveProjectMetadata.Name = "btSaveProjectMetadata";
            this.btSaveProjectMetadata.Size = new System.Drawing.Size(136, 40);
            this.btSaveProjectMetadata.TabIndex = 3;
            this.btSaveProjectMetadata.Text = "Save Project Metadata";
            this.btSaveProjectMetadata.Click += new System.EventHandler(this.btSaveProjectMetadata_Click);
            // 
            // lblProjectsSaved
            // 
            this.lblProjectsSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjectsSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectsSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblProjectsSaved.Location = new System.Drawing.Point(124, 15);
            this.lblProjectsSaved.Name = "lblProjectsSaved";
            this.lblProjectsSaved.Size = new System.Drawing.Size(56, 37);
            this.lblProjectsSaved.TabIndex = 8;
            this.lblProjectsSaved.Text = "Projects Saved";
            this.lblProjectsSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProjectsSaved.Visible = false;
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(119, 12);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(65, 40);
            this.lbUnsavedData.TabIndex = 7;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // axAuthentic_Project
            // 
            this.axAuthentic_Project.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_Project.Enabled = true;
            this.axAuthentic_Project.Location = new System.Drawing.Point(8, 80);
            this.axAuthentic_Project.Name = "axAuthentic_Project";
            this.axAuthentic_Project.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_Project.OcxState")));
            this.axAuthentic_Project.Size = new System.Drawing.Size(584, 296);
            this.axAuthentic_Project.TabIndex = 16;
            this.axAuthentic_Project.SelectionChanged += new System.EventHandler(this.axAuthentic_Project_SelectionChanged);
            // 
            // ascxProjects
            // 
            this.Controls.Add(this.axAuthentic_Project);
            this.Controls.Add(this.groupBox1);
            this.Name = "ascxProjects";
            this.Size = new System.Drawing.Size(600, 384);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Project)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	


		public void loadProjectData(string strProjectToLoad)
		{
            btSaveProjectMetadata.Enabled = false;
            // Check to see if we are loading over a currently open and modified project
            CheckForUnSavedDataAndPromptUserToSave();
          

            UserProfile up = UserProfile.GetUserProfile();
			this.strPathToProjectFiles  = Path.GetFullPath(up.ProjectFilesPath);
			this.strCurrentProject = strProjectToLoad;
			this.strFullPathToCurrentProject = Path.GetFullPath(Path.Combine(strPathToProjectFiles, strCurrentProject));								
			this.strFullPathToCurrentProjectXmlFile = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject, strCurrentProject + ".xml"));								

			utils.authentic.loadXmlFileInTargetAuthenticView( axAuthentic_Project,
                                                              strFullPathToCurrentProjectXmlFile,
                                                              obpCurrentPaths.ProjectSchemaPath,
                                                              obpCurrentPaths.SpsProjectPath );
			axAuthentic_Project.SetUnmodified();
			setCurrentProjectsFindingIdValue();
			setCurrentProjectNumberValue();
			lbUnsavedData.Visible = false;
            // Check if the current file breaks the schema but don't show MessageBox
            new utils.xml.xsdVerification(strFullPathToCurrentProjectXmlFile, obpCurrentPaths.ProjectSchemaPath, lbXmlBreaksXsdSchema, false);
            unsavedDataExists = false;
            btSaveProjectMetadata.Enabled = true;
		}

		private void btSaveProjectMetadata_Click(object sender, System.EventArgs e)
		{
            
            setCurrentProjectsFindingIdValue();
            saveCurrentProject();
            setCurrentProjectNumberValue();

			lblProjectsSaved.Visible= true;
			lbUnsavedData.Visible= false;
            unsavedDataExists = false;

            // Verify file against schema and show a MessageBox with any errors
            new utils.xml.xsdVerification(strFullPathToCurrentProjectXmlFile, obpCurrentPaths.ProjectSchemaPath, lbXmlBreaksXsdSchema, true);
		}

        /// <summary>
        /// This is used to save the current project.  It will save the data back to the file
        /// it orginated from.  
        /// </summary>
        private void saveCurrentProject() 
        {
            axAuthentic_Project.Save();
        }

		private void axAuthentic_Project_SelectionChanged(object sender, System.EventArgs e)
		{
			axAuthentic_Project.Select();
			lblProjectsSaved.Visible = false;
            if (axAuthentic_Project.Modified)
            {
                lbUnsavedData.Visible = true;
                unsavedDataExists = true;
            }
		}

		public void setCurrentProjectsFindingIdValue()
		{
			currentProject.FindingId = returnLoadedProjectNextFindingIdValue();
		}

		private  int returnLoadedProjectNextFindingIdValue()
		{
            try
            {
                XMLSPYPLUGINLib.XMLData xdXmlData = axAuthentic_Project.AuthenticView.WholeDocument.FirstXMLData;
                while (xdXmlData.Name != "Metadata")
                {
                    if (xdXmlData.Name == "Project")
                    {
                        xdXmlData = xdXmlData.GetFirstChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataElement);
                        break;
                    }
                    xdXmlData = xdXmlData.Parent;
                }
                if (xdXmlData.HasChildren)
                {
                    XMLSPYPLUGINLib.XMLData xdXmlDataAttr;
                    xdXmlDataAttr = xdXmlData.GetFirstChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
                    while (xdXmlDataAttr.Name != "next_ID_Number")
                    {
                        xdXmlDataAttr = xdXmlData.GetNextChild();
                    }
                    return Int32.Parse(xdXmlDataAttr.TextValue);
                }

            }
            // Swallow these errors.  This is from having stuff like an invalid range.
            // Since there is no way to validate the range in the authentic control 
            // we have to do this for right now, YUCK!
            catch (System.Runtime.InteropServices.COMException) { }
            catch (System.FormatException) {}
			return -1;			
		}			

		public void updateProjectNextFindingIdValue()
		{
			XMLSPYPLUGINLib.XMLData xdXmlData =  axAuthentic_Project.AuthenticView.WholeDocument.FirstXMLData;
			while (xdXmlData.Name != "Metadata")
			{
				xdXmlData = xdXmlData.Parent;
			}	
			if (xdXmlData.HasChildren)
			{
				XMLSPYPLUGINLib.XMLData xdXmlDataAttr;
				try
				{
					xdXmlDataAttr = xdXmlData.GetFirstChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
					Console.WriteLine(xdXmlDataAttr.Name.ToString());
					while( xdXmlDataAttr.Name != "next_ID_Number")
					{					
						xdXmlDataAttr = xdXmlData.GetNextChild();												
					}
					xdXmlDataAttr.TextValue = currentProject.FindingId.ToString();
						
				}
				catch (Exception ex)
				{
					MessageBox.Show("in updateProjectNextFindingIdValue : " + ex.Message);					
				}
				btSaveProjectMetadata_Click(null,null);
			}
		}

		private void setCurrentProjectNumberValue()
		{
			if (!File.Exists(strFullPathToCurrentProjectXmlFile))
			{
				MessageBox.Show("Could not find file: '" + strFullPathToCurrentProjectXmlFile + "'");
				return;
			}
			XmlDocument xdCurrentProject = new XmlDocument();
			xdCurrentProject.Load(strFullPathToCurrentProjectXmlFile);
			XmlNodeList xnlProjectNumber = xdCurrentProject.GetElementsByTagName("project_number");
			if (xnlProjectNumber.Count > 0)
				currentProject.ProjectNumber = xnlProjectNumber[0].InnerText;
		}

        /// <summary>
        /// This prompts the user and sees if they wish to save there unsaved data.  There are
        /// two times when this should happen.
        /// 1) When they try to close the form.
        /// 2) When they try to open a new report over the currently modified one.
        /// </summary>
        private void promptToSave()
        {
            if (MessageBox.Show("Unsaved data exists do you wish to save it?",
                                "Unsaved Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveCurrentProject();
            }
        }

        /// <summary>
        /// This method checks to see if there is any unsaved data and if there is 
        /// asks the user if they wish to save it.
        /// </summary>
        public void CheckForUnSavedDataAndPromptUserToSave()
        {
            if (unsavedDataExists)
            {
                promptToSave();
            }
        }

        private void lbXmlBreaksXsdSchema_Click(object sender, EventArgs e)
        {
            new utils.xml.xsdVerification(strFullPathToCurrentProjectXmlFile, obpCurrentPaths.ProjectSchemaPath, lbXmlBreaksXsdSchema, true);
        }

     
	}
}
