using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxPlugIns.
	/// </summary>
	public class ascxPlugIns : System.Windows.Forms.UserControl
	{
		private string strPlugInFileToLoad;
		private string strPathToLoadedPlugInXmlFolder;
		private string strPathToCurrentPluginFiles;

		private string strPathToSpsFile;
		private string strPathToXsdFile;
		private string strTemplateXmlFile;
		private string strPathToXmlFiles;
		private string strActionSourceCode;
		private string[] strReferenceAssemblies;

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpPlugIn;
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_Plugin;
		private System.Windows.Forms.GroupBox gbPlugInActions;
		private System.Windows.Forms.Button btExecuteAction;
		private System.Windows.Forms.ListBox lbPlugInXmlFiles;
		private System.Windows.Forms.ComboBox cbCurrentPlugIns;
		private System.Windows.Forms.TabPage tpEditPlugIn;
		private System.Windows.Forms.Label lbUnsavedData;
		private System.Windows.Forms.Button btSavePlugIn;
		private ICSharpCode.TextEditor.TextEditorControl tecPlugIns;
		private System.Windows.Forms.TextBox txtNewPlugInName;
		private System.Windows.Forms.Button btDeletePlugIn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbAvailablePlugIns;
		private System.Windows.Forms.Button btCreateNewPlugIn;
		private System.Windows.Forms.Label lbPlugInFileSaved;
		private System.Windows.Forms.Button btReloadPluginData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDebugMessages;
		private System.Windows.Forms.TextBox txtPlugInArguments;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btPlugInCompile;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxPlugIns()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ascxPlugIns));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpPlugIn = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.btReloadPluginData = new System.Windows.Forms.Button();
			this.axAuthentic_Plugin = new AxXMLSPYPLUGINLib.AxAuthentic();
			this.gbPlugInActions = new System.Windows.Forms.GroupBox();
			this.btExecuteAction = new System.Windows.Forms.Button();
			this.lbPlugInXmlFiles = new System.Windows.Forms.ListBox();
			this.cbCurrentPlugIns = new System.Windows.Forms.ComboBox();
			this.tpEditPlugIn = new System.Windows.Forms.TabPage();
			this.lbUnsavedData = new System.Windows.Forms.Label();
			this.btSavePlugIn = new System.Windows.Forms.Button();
			this.tecPlugIns = new ICSharpCode.TextEditor.TextEditorControl();
			this.txtNewPlugInName = new System.Windows.Forms.TextBox();
			this.btDeletePlugIn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lbAvailablePlugIns = new System.Windows.Forms.ListBox();
			this.btCreateNewPlugIn = new System.Windows.Forms.Button();
			this.lbPlugInFileSaved = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDebugMessages = new System.Windows.Forms.TextBox();
			this.txtPlugInArguments = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btPlugInCompile = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tpPlugIn.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Plugin)).BeginInit();
			this.gbPlugInActions.SuspendLayout();
			this.tpEditPlugIn.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tpPlugIn);
			this.tabControl1.Controls.Add(this.tpEditPlugIn);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(824, 360);
			this.tabControl1.TabIndex = 2;
			// 
			// tpPlugIn
			// 
			this.tpPlugIn.Controls.Add(this.label1);
			this.tpPlugIn.Controls.Add(this.btReloadPluginData);
			this.tpPlugIn.Controls.Add(this.axAuthentic_Plugin);
			this.tpPlugIn.Controls.Add(this.gbPlugInActions);
			this.tpPlugIn.Controls.Add(this.lbPlugInXmlFiles);
			this.tpPlugIn.Controls.Add(this.cbCurrentPlugIns);
			this.tpPlugIn.Location = new System.Drawing.Point(4, 22);
			this.tpPlugIn.Name = "tpPlugIn";
			this.tpPlugIn.Size = new System.Drawing.Size(816, 342);
			this.tpPlugIn.TabIndex = 1;
			this.tpPlugIn.Text = "Plug-Ins";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(200, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Authentic View";
			// 
			// btReloadPluginData
			// 
			this.btReloadPluginData.Location = new System.Drawing.Point(172, 8);
			this.btReloadPluginData.Name = "btReloadPluginData";
			this.btReloadPluginData.Size = new System.Drawing.Size(20, 20);
			this.btReloadPluginData.TabIndex = 4;
			this.btReloadPluginData.Text = "R";
			this.btReloadPluginData.Click += new System.EventHandler(this.btReloadPluginData_Click);
			// 
			// axAuthentic_Plugin
			// 
			this.axAuthentic_Plugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.axAuthentic_Plugin.ContainingControl = this;
			this.axAuthentic_Plugin.Enabled = true;
			this.axAuthentic_Plugin.Location = new System.Drawing.Point(200, 32);
			this.axAuthentic_Plugin.Name = "axAuthentic_Plugin";
			this.axAuthentic_Plugin.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_Plugin.OcxState")));
			this.axAuthentic_Plugin.Size = new System.Drawing.Size(608, 304);
			this.axAuthentic_Plugin.TabIndex = 3;
			// 
			// gbPlugInActions
			// 
			this.gbPlugInActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.gbPlugInActions.Controls.Add(this.label4);
			this.gbPlugInActions.Controls.Add(this.txtPlugInArguments);
			this.gbPlugInActions.Controls.Add(this.btExecuteAction);
			this.gbPlugInActions.Location = new System.Drawing.Point(8, 160);
			this.gbPlugInActions.Name = "gbPlugInActions";
			this.gbPlugInActions.Size = new System.Drawing.Size(184, 176);
			this.gbPlugInActions.TabIndex = 2;
			this.gbPlugInActions.TabStop = false;
			this.gbPlugInActions.Text = "Actions";
			// 
			// btExecuteAction
			// 
			this.btExecuteAction.Location = new System.Drawing.Point(8, 24);
			this.btExecuteAction.Name = "btExecuteAction";
			this.btExecuteAction.Size = new System.Drawing.Size(168, 24);
			this.btExecuteAction.TabIndex = 0;
			this.btExecuteAction.Text = "Execute Action";
			this.btExecuteAction.Click += new System.EventHandler(this.btExecuteAction_Click);
			// 
			// lbPlugInXmlFiles
			// 
			this.lbPlugInXmlFiles.Location = new System.Drawing.Point(8, 32);
			this.lbPlugInXmlFiles.Name = "lbPlugInXmlFiles";
			this.lbPlugInXmlFiles.Size = new System.Drawing.Size(184, 121);
			this.lbPlugInXmlFiles.TabIndex = 1;
			this.lbPlugInXmlFiles.SelectedIndexChanged += new System.EventHandler(this.lbPlugInXmlFiles_SelectedIndexChanged);
			// 
			// cbCurrentPlugIns
			// 
			this.cbCurrentPlugIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCurrentPlugIns.Location = new System.Drawing.Point(8, 8);
			this.cbCurrentPlugIns.Name = "cbCurrentPlugIns";
			this.cbCurrentPlugIns.Size = new System.Drawing.Size(160, 21);
			this.cbCurrentPlugIns.TabIndex = 0;
			this.cbCurrentPlugIns.SelectedIndexChanged += new System.EventHandler(this.cbCurrentPlugIns_SelectedIndexChanged);
			// 
			// tpEditPlugIn
			// 
			this.tpEditPlugIn.Controls.Add(this.btPlugInCompile);
			this.tpEditPlugIn.Controls.Add(this.lbUnsavedData);
			this.tpEditPlugIn.Controls.Add(this.btSavePlugIn);
			this.tpEditPlugIn.Controls.Add(this.tecPlugIns);
			this.tpEditPlugIn.Controls.Add(this.txtNewPlugInName);
			this.tpEditPlugIn.Controls.Add(this.btDeletePlugIn);
			this.tpEditPlugIn.Controls.Add(this.label2);
			this.tpEditPlugIn.Controls.Add(this.lbAvailablePlugIns);
			this.tpEditPlugIn.Controls.Add(this.btCreateNewPlugIn);
			this.tpEditPlugIn.Controls.Add(this.lbPlugInFileSaved);
			this.tpEditPlugIn.Location = new System.Drawing.Point(4, 22);
			this.tpEditPlugIn.Name = "tpEditPlugIn";
			this.tpEditPlugIn.Size = new System.Drawing.Size(816, 334);
			this.tpEditPlugIn.TabIndex = 0;
			this.tpEditPlugIn.Text = "Edit Plug-In";
			this.tpEditPlugIn.Visible = false;
			// 
			// lbUnsavedData
			// 
			this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
			this.lbUnsavedData.Location = new System.Drawing.Point(592, 5);
			this.lbUnsavedData.Name = "lbUnsavedData";
			this.lbUnsavedData.Size = new System.Drawing.Size(112, 24);
			this.lbUnsavedData.TabIndex = 27;
			this.lbUnsavedData.Text = "Unsaved Data";
			this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbUnsavedData.Visible = false;
			// 
			// btSavePlugIn
			// 
			this.btSavePlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSavePlugIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btSavePlugIn.Location = new System.Drawing.Point(712, 4);
			this.btSavePlugIn.Name = "btSavePlugIn";
			this.btSavePlugIn.Size = new System.Drawing.Size(96, 24);
			this.btSavePlugIn.TabIndex = 26;
			this.btSavePlugIn.Text = "Save Plug-In ";
			this.btSavePlugIn.Click += new System.EventHandler(this.btSavePlugIn_Click);
			// 
			// tecPlugIns
			// 
			this.tecPlugIns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tecPlugIns.Encoding = ((System.Text.Encoding)(resources.GetObject("tecPlugIns.Encoding")));
			this.tecPlugIns.Location = new System.Drawing.Point(160, 32);
			this.tecPlugIns.Name = "tecPlugIns";
			this.tecPlugIns.ShowEOLMarkers = true;
			this.tecPlugIns.ShowSpaces = true;
			this.tecPlugIns.ShowTabs = true;
			this.tecPlugIns.ShowVRuler = true;
			this.tecPlugIns.Size = new System.Drawing.Size(648, 264);
			this.tecPlugIns.TabIndex = 4;
			this.tecPlugIns.Load += new System.EventHandler(this.tecPlugIns_Load);
			this.tecPlugIns.Enter += new System.EventHandler(this.tecPlugIns_Enter);
			// 
			// txtNewPlugInName
			// 
			this.txtNewPlugInName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtNewPlugInName.Location = new System.Drawing.Point(8, 275);
			this.txtNewPlugInName.Name = "txtNewPlugInName";
			this.txtNewPlugInName.Size = new System.Drawing.Size(72, 20);
			this.txtNewPlugInName.TabIndex = 3;
			this.txtNewPlugInName.Text = "";
			// 
			// btDeletePlugIn
			// 
			this.btDeletePlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btDeletePlugIn.Location = new System.Drawing.Point(8, 304);
			this.btDeletePlugIn.Name = "btDeletePlugIn";
			this.btDeletePlugIn.Size = new System.Drawing.Size(136, 24);
			this.btDeletePlugIn.TabIndex = 2;
			this.btDeletePlugIn.Text = "Delete Plug-In";
			this.btDeletePlugIn.Click += new System.EventHandler(this.btDeletePlugIn_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Available Plug-Ins";
			// 
			// lbAvailablePlugIns
			// 
			this.lbAvailablePlugIns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.lbAvailablePlugIns.Location = new System.Drawing.Point(8, 32);
			this.lbAvailablePlugIns.Name = "lbAvailablePlugIns";
			this.lbAvailablePlugIns.Size = new System.Drawing.Size(136, 225);
			this.lbAvailablePlugIns.TabIndex = 0;
			this.lbAvailablePlugIns.SelectedIndexChanged += new System.EventHandler(this.lbAvailablePlugIns_SelectedIndexChanged);
			// 
			// btCreateNewPlugIn
			// 
			this.btCreateNewPlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btCreateNewPlugIn.Location = new System.Drawing.Point(88, 275);
			this.btCreateNewPlugIn.Name = "btCreateNewPlugIn";
			this.btCreateNewPlugIn.Size = new System.Drawing.Size(56, 20);
			this.btCreateNewPlugIn.TabIndex = 2;
			this.btCreateNewPlugIn.Text = "Create";
			this.btCreateNewPlugIn.Click += new System.EventHandler(this.btCreateNewPlugIn_Click);
			// 
			// lbPlugInFileSaved
			// 
			this.lbPlugInFileSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbPlugInFileSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbPlugInFileSaved.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.lbPlugInFileSaved.Location = new System.Drawing.Point(576, 6);
			this.lbPlugInFileSaved.Name = "lbPlugInFileSaved";
			this.lbPlugInFileSaved.Size = new System.Drawing.Size(136, 24);
			this.lbPlugInFileSaved.TabIndex = 28;
			this.lbPlugInFileSaved.Text = "Plug-In file saved";
			this.lbPlugInFileSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbPlugInFileSaved.Visible = false;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Location = new System.Drawing.Point(16, 376);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Debug Messages";
			// 
			// txtDebugMessages
			// 
			this.txtDebugMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDebugMessages.Location = new System.Drawing.Point(16, 392);
			this.txtDebugMessages.Multiline = true;
			this.txtDebugMessages.Name = "txtDebugMessages";
			this.txtDebugMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDebugMessages.Size = new System.Drawing.Size(816, 104);
			this.txtDebugMessages.TabIndex = 6;
			this.txtDebugMessages.Text = "";
			// 
			// txtPlugInArguments
			// 
			this.txtPlugInArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPlugInArguments.Location = new System.Drawing.Point(8, 80);
			this.txtPlugInArguments.Multiline = true;
			this.txtPlugInArguments.Name = "txtPlugInArguments";
			this.txtPlugInArguments.Size = new System.Drawing.Size(168, 88);
			this.txtPlugInArguments.TabIndex = 1;
			this.txtPlugInArguments.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Plug-in Arguments";
			// 
			// btPlugInCompile
			// 
			this.btPlugInCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btPlugInCompile.Location = new System.Drawing.Point(664, 304);
			this.btPlugInCompile.Name = "btPlugInCompile";
			this.btPlugInCompile.Size = new System.Drawing.Size(144, 24);
			this.btPlugInCompile.TabIndex = 29;
			this.btPlugInCompile.Text = "Save and Compile";
			this.btPlugInCompile.Click += new System.EventHandler(this.btPlugInCompile_Click);
			// 
			// ascxPlugIns
			// 
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtDebugMessages);
			this.Controls.Add(this.label3);
			this.Name = "ascxPlugIns";
			this.Size = new System.Drawing.Size(840, 504);
			this.Load += new System.EventHandler(this.ascxPlugIns_Load);
			this.tabControl1.ResumeLayout(false);
			this.tpPlugIn.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Plugin)).EndInit();
			this.gbPlugInActions.ResumeLayout(false);
			this.tpEditPlugIn.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void btCreateNewPlugIn_Click(object sender, System.EventArgs e)
		{
			if(txtNewPlugInName.Text == "")
			{
				MessageBox.Show("You must type a name for the new Plug-In");
				return;
			}
			string strFilename =  Path.Combine(GlobalVariables.strPathToPlugIns,txtNewPlugInName.Text+".xml");
			if (false == File.Exists(strFilename))
			{
				FileStream fsNewPlugInFile = File.Create(strFilename);
				fsNewPlugInFile.Close();
				LoadPlugInsIntoListAndComboBoxes();
			}
			else
				MessageBox.Show("Plug-In File Already exist");
		}

		private void LoadPlugInsIntoListAndComboBoxes()
		{
			if (false == Directory.Exists(GlobalVariables.strPathToPlugIns))
			{
				Directory.CreateDirectory(GlobalVariables.strPathToPlugIns);
				return;
			}
			strPlugInFileToLoad = "";
			utils.windowsForms.loadDirectoriesIntoListBox(lbAvailablePlugIns,GlobalVariables.strPathToPlugIns,"*");
			utils.windowsForms.loadDirectoriesIntoComboBox(cbCurrentPlugIns,GlobalVariables.strPathToPlugIns,"*");
		}


		private void LoadPlugInXmlFiles()
		{			
			strPathToCurrentPluginFiles = Path.Combine(GlobalVariables.strPathToPlugIns,cbCurrentPlugIns.Text);			
			strPathToLoadedPlugInXmlFolder = Path.Combine(strPathToCurrentPluginFiles,strPathToXmlFiles);
			utils.windowsForms.loadFilesIntoListBox(lbPlugInXmlFiles,strPathToLoadedPlugInXmlFolder ,"*.xml");
			
			if (lbPlugInXmlFiles.Items.Count>0)
				lbPlugInXmlFiles.SelectedIndex =0;		
		}

		private void lbAvailablePlugIns_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			strPlugInFileToLoad =  Path.Combine(GlobalVariables.strPathToPlugIns,lbAvailablePlugIns.Text+"\\"+lbAvailablePlugIns.Text+".xml"); // we expect to find the project file as an xml file with the same name as the selected directory
		}

		private void btSavePlugIn_Click(object sender, System.EventArgs e)
		{
			tecPlugIns.SaveFile(strPlugInFileToLoad);
			lbPlugInFileSaved.Visible = true;
			lbUnsavedData.Visible = false;
		}


		private void tecPlugIns_Enter(object sender, System.EventArgs e)
		{
			lbPlugInFileSaved.Visible=false;			
		}

		// this is not working must find which one is the correct one to detect when a change has occured
		//		private void tecPlugIns_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		//		{
		//			MessageBox.Show("Keyup");
		//				lbUnsavedData.Visible = true;
		//		}

		private void Document_DocumentChanged(object sender, ICSharpCode.TextEditor.Document.DocumentEventArgs e)
		{
			lbUnsavedData.Visible = true;
		}

		private void btDeletePlugIn_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.Yes ==  MessageBox.Show("Are you sure you want to delete the Plug-In '"+lbAvailablePlugIns.Text+"' ?","",MessageBoxButtons.YesNo))
			{
				File.Delete(strPlugInFileToLoad);
				LoadPlugInsIntoListAndComboBoxes();
			}
		}

		private void cbCurrentPlugIns_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			loadXmlFileAndPopulateVars();
			LoadPlugInXmlFiles();
		}

		private void loadXmlFileAndPopulateVars()
		{	
			try
			{
				utils.windowsForms.addMessageToTextBox_top(txtDebugMessages,"Loading Xml file and populating internal vars (from"+cbCurrentPlugIns.Text+")");
				string strFullPathToPlugInXmlFileToLoad = Path.Combine(GlobalVariables.strPathToPlugIns,cbCurrentPlugIns.Text+"\\"+cbCurrentPlugIns.Text+".xml");
				XmlDocument xdPlugInXmlFile = new XmlDocument();
				xdPlugInXmlFile .Load(strFullPathToPlugInXmlFileToLoad);
				XmlNodeList xnlPlugIns = xdPlugInXmlFile.GetElementsByTagName("PlugIn");
				if (xnlPlugIns.Count > 1)
					MessageBox.Show("Note: there are more than one Plug-In in this Plug-ins File. Only the first one will be processed");
				if (xnlPlugIns.Count == 0)
				{
					MessageBox.Show("There are NO (i.e. zero) Plug-In in this Plug-ins File");
					return;
				}			
				XmlNode xnPlugIn = xnlPlugIns[0];			
				strPathToXmlFiles = xnPlugIn.Attributes.GetNamedItem("pathToXmlFiles").InnerText;			
				strPathToSpsFile = xnPlugIn.Attributes.GetNamedItem("pathToSpsFile").InnerText;			
				strPathToXsdFile = xnPlugIn.Attributes.GetNamedItem("pathToXsdFile").InnerText;			
				strTemplateXmlFile = xnPlugIn.Attributes.GetNamedItem("templateXmlFile").InnerText;								
				XmlNode xnReferenceAssemblies = xnPlugIn.Attributes.GetNamedItem("referenceAssemblies");
				if (null != xnReferenceAssemblies)
					strReferenceAssemblies = xnReferenceAssemblies.InnerText.Split(',');
				if (xnPlugIn.ChildNodes.Count>0)
					strActionSourceCode = xnPlugIn.ChildNodes[0].InnerText;
				else
					MessageBox.Show("There are no actions in this XML file");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in loadXmlFileAndPopulateVars:"+ ex.Message);
			}
		}

		private void getSourceCodeFromXmlFile(string strXmlFileToProcess, ref string strSourceCode, ref string[] strReferenceAssemblies)
		{
			try
			{
				XmlDocument xdPlugInXmlFile = new XmlDocument();
				xdPlugInXmlFile .Load(strXmlFileToProcess);
				XmlNodeList xnlPlugIns = xdPlugInXmlFile.GetElementsByTagName("PlugIn");
				if (xnlPlugIns.Count > 1)
					MessageBox.Show("Note: there are more than one Plug-In in this Plug-ins File. Only the first one will be processed");
				if (xnlPlugIns.Count == 0)			
				{
					MessageBox.Show("There are NO (i.e. zero) Plug-In in this Plug-ins File");
					return;
				}	
				XmlNode xnPlugIn = xnlPlugIns[0];	
				XmlNode xnReferenceAssemblies = xnPlugIn.Attributes.GetNamedItem("referenceAssemblies");
				if (null != xnReferenceAssemblies)
					strReferenceAssemblies = xnReferenceAssemblies.InnerText.Split(',');
			
				// ADD BIT OF GETTING REFERENCE ASSEMBLIES FROM XML FILE			
				if (xnPlugIn.ChildNodes.Count>0)
					strSourceCode = xnPlugIn.ChildNodes[0].InnerText;
				else			
					MessageBox.Show("There are no actions in this XML file");							
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in getSourceCodeFromXmlFile:"+ ex.Message);
			}
		}

		private void lbPlugInXmlFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			utils.windowsForms.addMessageToTextBox_top(txtDebugMessages,"Loading Plug-in: " + lbPlugInXmlFiles.Text);
			string strFullPathToXmlFile = Path.Combine(strPathToLoadedPlugInXmlFolder,lbPlugInXmlFiles.Text);
			string strFullPathToSPSFile = Path.Combine(strPathToCurrentPluginFiles,strPathToSpsFile);
			string strFullPathToXsdFile = Path.Combine(strPathToCurrentPluginFiles,strPathToXsdFile);
			utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_Plugin,strFullPathToXmlFile,strFullPathToXsdFile,strFullPathToSPSFile);
			txtPlugInArguments.Text = strFullPathToXmlFile;
		}

		private void btExecuteAction_Click(object sender, System.EventArgs e)
		{
			utils.scriptHost.compileAndExecuteSourceCode(strActionSourceCode,txtPlugInArguments.Text, strReferenceAssemblies);
		}

		private void ascxPlugIns_Load(object sender, System.EventArgs e)
		{
			if (!this.DesignMode)
			{
				LoadPlugInsIntoListAndComboBoxes();

				// add this here to avoid being automatically deleted 
				this.tecPlugIns.Document.DocumentChanged += new ICSharpCode.TextEditor.Document.DocumentEventHandler(Document_DocumentChanged);
			}
		}

		private void tecPlugIns_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btReloadPluginData_Click(object sender, System.EventArgs e)
		{
			loadXmlFileAndPopulateVars();
		}

		private void btPlugInCompile_Click(object sender, System.EventArgs e)
		{
			utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "------------------------------");
			utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Saving file: " + strPlugInFileToLoad);
			btSavePlugIn_Click(null,null);
			utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Starting Compilation");
			
			string[] strReferenceAssembliesToAdd = new string[0];
			string strPlugInSourceCode = "";
			getSourceCodeFromXmlFile(strPlugInFileToLoad, ref strPlugInSourceCode, ref strReferenceAssembliesToAdd);
			utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, utils.scriptHost.compileSourceCode(strPlugInSourceCode ,strReferenceAssembliesToAdd));
		}
		

	}

	public class PlugIn
	{
        /// TODO: Need to figure out what this was supposed to do.
	}	
}
