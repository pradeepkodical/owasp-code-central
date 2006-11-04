using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.TextEditor.Document;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxXsltEditor.
	/// </summary>
	public class ascxXsltEditor : System.Windows.Forms.UserControl
	{
		int iLastFoundPosition;
		private string strDirectoryWithXsltFiles = "";
		string strFileToLoad = "";

		private System.Windows.Forms.ListBox lbReportType;
		private System.Windows.Forms.ListBox lbXsltFiles;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private ICSharpCode.TextEditor.TextEditorControl textEditorControl;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNewXsltFileName;
		private System.Windows.Forms.Button btCreateNewXsltFile;
		private System.Windows.Forms.Button btSaveXsltFile;
		private System.Windows.Forms.Label lbFileSaved;
		private System.Windows.Forms.Label lbFind;
		private System.Windows.Forms.TextBox txtTextToFind;
		private System.Windows.Forms.Button btFindText;
		private System.Windows.Forms.Button btFindNext;
		private System.Windows.Forms.Label lbPhraseNotFound;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxXsltEditor()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ascxXsltEditor));
			this.lbReportType = new System.Windows.Forms.ListBox();
			this.lbXsltFiles = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btCreateNewXsltFile = new System.Windows.Forms.Button();
			this.txtNewXsltFileName = new System.Windows.Forms.TextBox();
			this.btSaveXsltFile = new System.Windows.Forms.Button();
			this.lbFileSaved = new System.Windows.Forms.Label();
			this.lbFind = new System.Windows.Forms.Label();
			this.txtTextToFind = new System.Windows.Forms.TextBox();
			this.btFindText = new System.Windows.Forms.Button();
			this.btFindNext = new System.Windows.Forms.Button();
			this.lbPhraseNotFound = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbReportType
			// 
			this.lbReportType.Location = new System.Drawing.Point(8, 32);
			this.lbReportType.Name = "lbReportType";
			this.lbReportType.Size = new System.Drawing.Size(168, 134);
			this.lbReportType.Sorted = true;
			this.lbReportType.TabIndex = 0;
			this.lbReportType.SelectedIndexChanged += new System.EventHandler(this.lbReportType_SelectedIndexChanged);
			// 
			// lbXsltFiles
			// 
			this.lbXsltFiles.Location = new System.Drawing.Point(8, 208);
			this.lbXsltFiles.Name = "lbXsltFiles";
			this.lbXsltFiles.Size = new System.Drawing.Size(168, 134);
			this.lbXsltFiles.Sorted = true;
			this.lbXsltFiles.TabIndex = 0;
			this.lbXsltFiles.SelectedIndexChanged += new System.EventHandler(this.lbXsltFiles_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(208, 24);
			this.label2.TabIndex = 28;
			this.label2.Text = "Report Type";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Visible = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(8, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 24);
			this.label1.TabIndex = 28;
			this.label1.Text = "XSLT Files";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Visible = false;
			// 
			// textEditorControl
			// 
			this.textEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textEditorControl.Encoding = ((System.Text.Encoding)(resources.GetObject("textEditorControl.Encoding")));
			this.textEditorControl.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.FullRow;
			this.textEditorControl.Location = new System.Drawing.Point(192, 32);
			this.textEditorControl.Name = "textEditorControl";
			this.textEditorControl.ShowEOLMarkers = true;
			this.textEditorControl.ShowSpaces = true;
			this.textEditorControl.ShowTabs = true;
			this.textEditorControl.ShowVRuler = true;
			this.textEditorControl.Size = new System.Drawing.Size(584, 432);
			this.textEditorControl.TabIndex = 29;
			this.textEditorControl.Enter += new System.EventHandler(this.textEditorControl_Enter);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btCreateNewXsltFile);
			this.groupBox1.Controls.Add(this.txtNewXsltFileName);
			this.groupBox1.Location = new System.Drawing.Point(8, 360);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 48);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "New Xslt File";
			// 
			// btCreateNewXsltFile
			// 
			this.btCreateNewXsltFile.Location = new System.Drawing.Point(112, 24);
			this.btCreateNewXsltFile.Name = "btCreateNewXsltFile";
			this.btCreateNewXsltFile.Size = new System.Drawing.Size(48, 20);
			this.btCreateNewXsltFile.TabIndex = 1;
			this.btCreateNewXsltFile.Text = "Create";
			this.btCreateNewXsltFile.Click += new System.EventHandler(this.btCreateNewXsltFile_Click);
			// 
			// txtNewXsltFileName
			// 
			this.txtNewXsltFileName.Location = new System.Drawing.Point(8, 24);
			this.txtNewXsltFileName.Name = "txtNewXsltFileName";
			this.txtNewXsltFileName.Size = new System.Drawing.Size(96, 20);
			this.txtNewXsltFileName.TabIndex = 0;
			this.txtNewXsltFileName.Text = "";
			// 
			// btSaveXsltFile
			// 
			this.btSaveXsltFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSaveXsltFile.Location = new System.Drawing.Point(664, 5);
			this.btSaveXsltFile.Name = "btSaveXsltFile";
			this.btSaveXsltFile.Size = new System.Drawing.Size(112, 20);
			this.btSaveXsltFile.TabIndex = 31;
			this.btSaveXsltFile.Text = "Save Xslt File";
			this.btSaveXsltFile.Click += new System.EventHandler(this.btSaveXsltFile_Click);
			// 
			// lbFileSaved
			// 
			this.lbFileSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbFileSaved.ForeColor = System.Drawing.Color.Red;
			this.lbFileSaved.Location = new System.Drawing.Point(568, 7);
			this.lbFileSaved.Name = "lbFileSaved";
			this.lbFileSaved.Size = new System.Drawing.Size(80, 16);
			this.lbFileSaved.TabIndex = 32;
			this.lbFileSaved.Text = "File Saved";
			this.lbFileSaved.Visible = false;
			// 
			// lbFind
			// 
			this.lbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbFind.Location = new System.Drawing.Point(192, 473);
			this.lbFind.Name = "lbFind";
			this.lbFind.Size = new System.Drawing.Size(40, 16);
			this.lbFind.TabIndex = 33;
			this.lbFind.Text = "Find:";
			// 
			// txtTextToFind
			// 
			this.txtTextToFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTextToFind.Location = new System.Drawing.Point(232, 472);
			this.txtTextToFind.Name = "txtTextToFind";
			this.txtTextToFind.Size = new System.Drawing.Size(96, 20);
			this.txtTextToFind.TabIndex = 0;
			this.txtTextToFind.Text = "xml";
			// 
			// btFindText
			// 
			this.btFindText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btFindText.Location = new System.Drawing.Point(344, 472);
			this.btFindText.Name = "btFindText";
			this.btFindText.Size = new System.Drawing.Size(48, 20);
			this.btFindText.TabIndex = 1;
			this.btFindText.Text = "Find";
			this.btFindText.Click += new System.EventHandler(this.btFindText_Click);
			// 
			// btFindNext
			// 
			this.btFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btFindNext.Location = new System.Drawing.Point(400, 472);
			this.btFindNext.Name = "btFindNext";
			this.btFindNext.Size = new System.Drawing.Size(72, 20);
			this.btFindNext.TabIndex = 1;
			this.btFindNext.Text = "Find Next";
			this.btFindNext.Click += new System.EventHandler(this.btFindNext_Click);
			// 
			// lbPhraseNotFound
			// 
			this.lbPhraseNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbPhraseNotFound.ForeColor = System.Drawing.Color.Red;
			this.lbPhraseNotFound.Location = new System.Drawing.Point(488, 472);
			this.lbPhraseNotFound.Name = "lbPhraseNotFound";
			this.lbPhraseNotFound.Size = new System.Drawing.Size(104, 16);
			this.lbPhraseNotFound.TabIndex = 34;
			this.lbPhraseNotFound.Text = "Phrase not Found";
			this.lbPhraseNotFound.Visible = false;
			// 
			// ascxXsltEditor
			// 
			this.Controls.Add(this.lbPhraseNotFound);
			this.Controls.Add(this.lbFind);
			this.Controls.Add(this.lbFileSaved);
			this.Controls.Add(this.btSaveXsltFile);
			this.Controls.Add(this.textEditorControl);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbReportType);
			this.Controls.Add(this.lbXsltFiles);
			this.Controls.Add(this.txtTextToFind);
			this.Controls.Add(this.btFindText);
			this.Controls.Add(this.btFindNext);
			this.Name = "ascxXsltEditor";
			this.Size = new System.Drawing.Size(784, 496);
			this.Load += new System.EventHandler(this.ascxXsltEditor_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ascxXsltEditor_Load(object sender, System.EventArgs e)
		{
			if (!this.DesignMode)
			{
				string appPath = Path.GetDirectoryName(Application.ExecutablePath);
				HighlightingManager.Manager.AddSyntaxModeFileProvider(new FileSyntaxModeProvider(appPath));   
				textEditorControl.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("VulnReport");
				textEditorControl.ShowVRuler = false; 
				populateReportTypeListBox();
			}
		}

		public void populateReportTypeListBox()
		{
			utils.windowsForms.loadDirectoriesIntoListBox(lbReportType,GlobalVariables.strPathToXslt_Reports,"*");
		}

		private void populateXsltFilesListBox()
		{
			this.strDirectoryWithXsltFiles = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToXslt_Reports,lbReportType.Text));
			utils.windowsForms.loadFilesIntoListBox(lbXsltFiles,strDirectoryWithXsltFiles,"*.xslt");
		}

		private void loadFileInTextEditor(string strFileToLoad)
		{			
			textEditorControl.LoadFile(strFileToLoad);
		}

		private void lbReportType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			populateXsltFilesListBox();
		}

		private void lbXsltFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.strFileToLoad = Path.GetFullPath(Path.Combine(this.strDirectoryWithXsltFiles,lbXsltFiles.Text));
			loadFileInTextEditor(this.strFileToLoad);
		}

		private void btCreateNewXsltFile_Click(object sender, System.EventArgs e)
		{			
			string strFileToCreate = Path.GetFullPath(Path.Combine(this.strDirectoryWithXsltFiles,txtNewXsltFileName.Text));
			if (strFileToCreate.IndexOf(".xslt")==-1) 
				strFileToCreate += ".xslt";
			if (strFileToCreate == "")
				MessageBox.Show("Filename cannot be empty");	
			else if (File.Exists(strFileToCreate))
				MessageBox.Show("File Already Exists, please chose another name");
			else
			{
				FileStream fsNewFile =  File.Create(strFileToCreate);
				fsNewFile.Close();
				populateXsltFilesListBox();
			}
		}

		private void btSaveXsltFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				textEditorControl.SaveFile(this.strFileToLoad);
				lbFileSaved.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in btSaveXsltFile_Click:" + ex.Message);
			}
		}

		private void textEditorControl_Enter(object sender, System.EventArgs e)
		{
			lbFileSaved.Visible = false;
		}

		private void btFindText_Click(object sender, System.EventArgs e)
		{
			int iFoundPos = textEditorControl.Text.IndexOf(txtTextToFind.Text);
			if (iFoundPos >-1)
			{
				lbPhraseNotFound.Visible = false;
				textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
				textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(new DefaultSelection(textEditorControl.Document,
					textEditorControl.Document.OffsetToPosition(iFoundPos),
					textEditorControl.Document.OffsetToPosition(iFoundPos + txtTextToFind.Text.Length)));
				//textEditorControl.ActiveTextAreaControl.ScrollTo(textEditorControl.ActiveTextAreaControl.SelectionManager.SelectionCollection[0].
				textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.FireSelectionChanged();
				//textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.SelectionCollection[0].StartPosition.

				iLastFoundPosition = iFoundPos + txtTextToFind.Text.Length;
			}
			else
			{
				lbPhraseNotFound.Visible = true;
			}
		}

		private void btFindNext_Click(object sender, System.EventArgs e)
		{																											 
			int iFoundPos = textEditorControl.Text.IndexOf(txtTextToFind.Text,	iLastFoundPosition);			
			if (iFoundPos >-1)
			{
				lbPhraseNotFound.Visible = false;
				textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
				textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(new DefaultSelection(textEditorControl.Document,
					textEditorControl.Document.OffsetToPosition(iFoundPos),
					textEditorControl.Document.OffsetToPosition(iFoundPos + txtTextToFind.Text.Length)));
				iLastFoundPosition = iFoundPos + txtTextToFind.Text.Length;
			}
			else
			{
				lbPhraseNotFound.Visible = true;
			}			
		}
	}
}
