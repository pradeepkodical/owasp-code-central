using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for ascxExport.
	/// </summary>
	public class ascxExport : System.Windows.Forms.UserControl
	{
		private string strXmlWithAllData;
		private string strDataTransformationXmlFile;
        private UserProfile upCurrentUser = UserProfile.GetUserProfile();
		bool bSuccess;

		private System.Windows.Forms.Button btPreviewXmlFileWithAllData;
		private System.Windows.Forms.Label lbXmlFileCreated;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btGenerateXmlWithAllData;
		private System.Windows.Forms.Label label8;
		private AxSHDocVw.AxWebBrowser axWebBrowser_ShowHtmlReport;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btProcessTransformation;
		private System.Windows.Forms.Label lbXmlFileCreate_DataTransformation;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btPreviewDataTransformationFile;
		private System.Windows.Forms.ComboBox cbDataFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbXSDtoUseOnExport;
		private System.Windows.Forms.Button btVerifyXmlFile;
		private System.Windows.Forms.Label lbXmlValidationResult;
		private System.Windows.Forms.TextBox txtXmlValidationResult;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPathToSaveXmlFile;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtExportedXmlFileName;
		private System.Windows.Forms.Button btExportedXmlFileCopy;
		private System.Windows.Forms.Label label11;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxExport()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ascxExport));
			this.btPreviewXmlFileWithAllData = new System.Windows.Forms.Button();
			this.lbXmlFileCreated = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btGenerateXmlWithAllData = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.axWebBrowser_ShowHtmlReport = new AxSHDocVw.AxWebBrowser();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btProcessTransformation = new System.Windows.Forms.Button();
			this.lbXmlFileCreate_DataTransformation = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.btPreviewDataTransformationFile = new System.Windows.Forms.Button();
			this.cbDataFilter = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbXSDtoUseOnExport = new System.Windows.Forms.ComboBox();
			this.btVerifyXmlFile = new System.Windows.Forms.Button();
			this.lbXmlValidationResult = new System.Windows.Forms.Label();
			this.txtXmlValidationResult = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPathToSaveXmlFile = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtExportedXmlFileName = new System.Windows.Forms.TextBox();
			this.btExportedXmlFileCopy = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_ShowHtmlReport)).BeginInit();
			this.SuspendLayout();
			// 
			// btPreviewXmlFileWithAllData
			// 
			this.btPreviewXmlFileWithAllData.Enabled = false;
			this.btPreviewXmlFileWithAllData.Location = new System.Drawing.Point(664, 40);
			this.btPreviewXmlFileWithAllData.Name = "btPreviewXmlFileWithAllData";
			this.btPreviewXmlFileWithAllData.Size = new System.Drawing.Size(96, 20);
			this.btPreviewXmlFileWithAllData.TabIndex = 34;
			this.btPreviewXmlFileWithAllData.Text = "Preview File";
			this.btPreviewXmlFileWithAllData.Click += new System.EventHandler(this.btPreviewXmlFileWithAllData_Click);
			// 
			// lbXmlFileCreated
			// 
			this.lbXmlFileCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbXmlFileCreated.Location = new System.Drawing.Point(576, 48);
			this.lbXmlFileCreated.Name = "lbXmlFileCreated";
			this.lbXmlFileCreated.Size = new System.Drawing.Size(88, 16);
			this.lbXmlFileCreated.TabIndex = 36;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(480, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 35;
			this.label6.Text = "Xml File Created ->";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// btGenerateXmlWithAllData
			// 
			this.btGenerateXmlWithAllData.Location = new System.Drawing.Point(312, 40);
			this.btGenerateXmlWithAllData.Name = "btGenerateXmlWithAllData";
			this.btGenerateXmlWithAllData.Size = new System.Drawing.Size(152, 20);
			this.btGenerateXmlWithAllData.TabIndex = 33;
			this.btGenerateXmlWithAllData.Text = "Generate Xml With All Data";
			this.btGenerateXmlWithAllData.Click += new System.EventHandler(this.btGenerateXmlWithAllData_Click);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(8, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(280, 16);
			this.label8.TabIndex = 37;
			this.label8.Text = "Step 1) Generate Xml File with All Data";
			// 
			// axWebBrowser_ShowHtmlReport
			// 
			this.axWebBrowser_ShowHtmlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.axWebBrowser_ShowHtmlReport.Enabled = true;
			this.axWebBrowser_ShowHtmlReport.Location = new System.Drawing.Point(8, 392);
			this.axWebBrowser_ShowHtmlReport.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser_ShowHtmlReport.OcxState")));
			this.axWebBrowser_ShowHtmlReport.Size = new System.Drawing.Size(904, 96);
			this.axWebBrowser_ShowHtmlReport.TabIndex = 38;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(8, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(280, 16);
			this.label9.TabIndex = 39;
			this.label9.Text = "Step 2)  Apply Data Filter";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(40, 91);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 16);
			this.label7.TabIndex = 43;
			this.label7.Text = "Data Filter ->";
			// 
			// btProcessTransformation
			// 
			this.btProcessTransformation.Enabled = false;
			this.btProcessTransformation.Location = new System.Drawing.Point(312, 88);
			this.btProcessTransformation.Name = "btProcessTransformation";
			this.btProcessTransformation.Size = new System.Drawing.Size(152, 20);
			this.btProcessTransformation.TabIndex = 40;
			this.btProcessTransformation.Text = "ProcessTransformation";
			this.btProcessTransformation.Click += new System.EventHandler(this.btProcessTransformation_Click);
			// 
			// lbXmlFileCreate_DataTransformation
			// 
			this.lbXmlFileCreate_DataTransformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbXmlFileCreate_DataTransformation.Location = new System.Drawing.Point(568, 91);
			this.lbXmlFileCreate_DataTransformation.Name = "lbXmlFileCreate_DataTransformation";
			this.lbXmlFileCreate_DataTransformation.Size = new System.Drawing.Size(88, 16);
			this.lbXmlFileCreate_DataTransformation.TabIndex = 44;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(480, 91);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(112, 16);
			this.label13.TabIndex = 42;
			this.label13.Text = "Xml File Created ->";
			// 
			// btPreviewDataTransformationFile
			// 
			this.btPreviewDataTransformationFile.Enabled = false;
			this.btPreviewDataTransformationFile.Location = new System.Drawing.Point(664, 89);
			this.btPreviewDataTransformationFile.Name = "btPreviewDataTransformationFile";
			this.btPreviewDataTransformationFile.Size = new System.Drawing.Size(96, 20);
			this.btPreviewDataTransformationFile.TabIndex = 41;
			this.btPreviewDataTransformationFile.Text = "Preview File";
			this.btPreviewDataTransformationFile.Click += new System.EventHandler(this.btPreviewDataTransformationFile_Click);
			// 
			// cbDataFilter
			// 
			this.cbDataFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDataFilter.Enabled = false;
			this.cbDataFilter.Items.AddRange(new object[] {
															  "misc\\Export.xslt",
															  "misc\\MapToDataFeedXsd_v0_5.xslt"});
			this.cbDataFilter.Location = new System.Drawing.Point(120, 88);
			this.cbDataFilter.Name = "cbDataFilter";
			this.cbDataFilter.Size = new System.Drawing.Size(184, 21);
			this.cbDataFilter.Sorted = true;
			this.cbDataFilter.TabIndex = 45;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 16);
			this.label1.TabIndex = 39;
			this.label1.Text = "Step 3) Verify created XML file with current XSD";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 155);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 43;
			this.label2.Text = "XSD to use ->";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 248);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 16);
			this.label3.TabIndex = 39;
			this.label3.Text = "Step 4) Publish XML File";
			// 
			// cbXSDtoUseOnExport
			// 
			this.cbXSDtoUseOnExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbXSDtoUseOnExport.Enabled = false;
			this.cbXSDtoUseOnExport.Items.AddRange(new object[] {
																	   "DataFeedXsd_v0.5.xsd"});
			this.cbXSDtoUseOnExport.Location = new System.Drawing.Point(120, 152);
			this.cbXSDtoUseOnExport.Name = "cbXSDtoUseOnExport";
			this.cbXSDtoUseOnExport.Size = new System.Drawing.Size(184, 21);
			this.cbXSDtoUseOnExport.Sorted = true;
			this.cbXSDtoUseOnExport.TabIndex = 45;
			// 
			// btVerifyXmlFile
			// 
			this.btVerifyXmlFile.Enabled = false;
			this.btVerifyXmlFile.Location = new System.Drawing.Point(312, 152);
			this.btVerifyXmlFile.Name = "btVerifyXmlFile";
			this.btVerifyXmlFile.Size = new System.Drawing.Size(208, 20);
			this.btVerifyXmlFile.TabIndex = 40;
			this.btVerifyXmlFile.Text = "Verify Xml File using selected XSD";
			this.btVerifyXmlFile.Click += new System.EventHandler(this.btVerifyXmlFile_Click);
			// 
			// lbXmlValidationResult
			// 
			this.lbXmlValidationResult.Location = new System.Drawing.Point(648, 152);
			this.lbXmlValidationResult.Name = "lbXmlValidationResult";
			this.lbXmlValidationResult.Size = new System.Drawing.Size(112, 16);
			this.lbXmlValidationResult.TabIndex = 43;
			this.lbXmlValidationResult.Text = "...";
			// 
			// txtXmlValidationResult
			// 
			this.txtXmlValidationResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtXmlValidationResult.Location = new System.Drawing.Point(552, 168);
			this.txtXmlValidationResult.Multiline = true;
			this.txtXmlValidationResult.Name = "txtXmlValidationResult";
			this.txtXmlValidationResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtXmlValidationResult.Size = new System.Drawing.Size(352, 56);
			this.txtXmlValidationResult.TabIndex = 46;
			this.txtXmlValidationResult.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(552, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 16);
			this.label5.TabIndex = 43;
			this.label5.Text = "Xml Validation Result:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 280);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 16);
			this.label4.TabIndex = 35;
			this.label4.Text = "Path To Save Exported Xml File";
			// 
			// txtPathToSaveXmlFile
			// 
			this.txtPathToSaveXmlFile.Location = new System.Drawing.Point(208, 276);
			this.txtPathToSaveXmlFile.Name = "txtPathToSaveXmlFile";
			this.txtPathToSaveXmlFile.Size = new System.Drawing.Size(112, 20);
			this.txtPathToSaveXmlFile.TabIndex = 47;
			this.txtPathToSaveXmlFile.Text = "c:\\__Exports";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(328, 280);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 35;
			this.label10.Text = "FileName:";
			// 
			// txtExportedXmlFileName
			// 
			this.txtExportedXmlFileName.Location = new System.Drawing.Point(384, 276);
			this.txtExportedXmlFileName.Name = "txtExportedXmlFileName";
			this.txtExportedXmlFileName.Size = new System.Drawing.Size(160, 20);
			this.txtExportedXmlFileName.TabIndex = 47;
			this.txtExportedXmlFileName.Text = "data_Jul_2006.xml";
			this.txtExportedXmlFileName.TextChanged += new System.EventHandler(this.txtExportedXmlFileName_TextChanged);
			// 
			// btExportedXmlFileCopy
			// 
			this.btExportedXmlFileCopy.Enabled = false;
			this.btExportedXmlFileCopy.Location = new System.Drawing.Point(552, 278);
			this.btExportedXmlFileCopy.Name = "btExportedXmlFileCopy";
			this.btExportedXmlFileCopy.Size = new System.Drawing.Size(136, 20);
			this.btExportedXmlFileCopy.TabIndex = 34;
			this.btExportedXmlFileCopy.Text = "Copy File ";
			this.btExportedXmlFileCopy.Click += new System.EventHandler(this.btExportedXmlFileCopy_Click);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(552, 302);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(152, 16);
			this.label11.TabIndex = 35;
			this.label11.Text = "(i.e. put file in Exported Directory)";
			// 
			// ascxExport
			// 
			this.Controls.Add(this.txtPathToSaveXmlFile);
			this.Controls.Add(this.txtXmlValidationResult);
			this.Controls.Add(this.cbDataFilter);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btProcessTransformation);
			this.Controls.Add(this.lbXmlFileCreate_DataTransformation);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.btPreviewDataTransformationFile);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.axWebBrowser_ShowHtmlReport);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btPreviewXmlFileWithAllData);
			this.Controls.Add(this.lbXmlFileCreated);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btGenerateXmlWithAllData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbXSDtoUseOnExport);
			this.Controls.Add(this.btVerifyXmlFile);
			this.Controls.Add(this.lbXmlValidationResult);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtExportedXmlFileName);
			this.Controls.Add(this.btExportedXmlFileCopy);
			this.Controls.Add(this.label11);
			this.Name = "ascxExport";
			this.Size = new System.Drawing.Size(920, 496);
			this.Load += new System.EventHandler(this.ascxExport_Load);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_ShowHtmlReport)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btGenerateXmlWithAllData_Click(object sender, System.EventArgs e)
		{
			if (Directory.Exists(upCurrentUser.TempDirectoryPath) == false)
				Directory.CreateDirectory(upCurrentUser.TempDirectoryPath);
			this.strXmlWithAllData = Path.GetFullPath(Path.Combine(upCurrentUser.TempDirectoryPath, utils.files.returnUniqueFileName(".xml")));			
			createXmlFileWithAllData(this.strXmlWithAllData);			
			lbXmlFileCreated.Text = Path.GetFileName(this.strXmlWithAllData);
			btPreviewXmlFileWithAllData.Enabled = true;
			btProcessTransformation.Enabled = true;
			cbDataFilter.SelectedIndex=0;
		}

		private void createXmlFileWithAllData(string strTargetXmlFile)
		{			
			StringBuilder sbProjects = new StringBuilder();
			foreach (string strXmlFileWithData in Directory.GetFiles(upCurrentUser.ConsolidatedReportsPath))
			{
				XmlDocument xdProject = new XmlDocument();
				xdProject.Load(strXmlFileWithData);
				sbProjects.Append(xdProject.DocumentElement.OuterXml);				
			}
			XmlDocument xdReport = createXmlFileToStoreXmlFindings(strTargetXmlFile);				
			XmlNode xdConsolidatedProjects = xdReport.GetElementsByTagName("ConsolidatedProjects").Item(0);
			xdConsolidatedProjects.InnerXml += sbProjects;
			utils.files.SaveFileWithStringContents(strTargetXmlFile,xdReport.OuterXml);
		}

		private XmlDocument createXmlFileToStoreXmlFindings(string strTargetXmlFile)
		{
			XmlDocument xdXmlDocument = new XmlDocument();			
			xdXmlDocument.Load(GlobalVariables.strPathToTemplateFile_EmptyConsolidatedProjectXmlFile);									
			return xdXmlDocument;
		}

		private void btPreviewXmlFileWithAllData_Click(object sender, System.EventArgs e)
		{
			utils.webBrowser.openFileInWebBrowser(axWebBrowser_ShowHtmlReport, this.strXmlWithAllData);
		}

		private void btProcessTransformation_Click(object sender, System.EventArgs e)
		{

			string strXmlFileToUse = this.strXmlWithAllData;

			this.strDataTransformationXmlFile = Path.GetFullPath(Path.Combine(upCurrentUser.TempDirectoryPath, utils.files.returnUniqueFileName(".xml")));			
			string strXsltDataTransformationFile = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToXslt_Reports,cbDataFilter.Text));
			string strXsltTransformationErrorMessage = utils.xml.returnXmlXslTransformation(strXmlFileToUse,strXsltDataTransformationFile ,this.strDataTransformationXmlFile );
			if ("" != strXsltTransformationErrorMessage)
			{
				MessageBox.Show("Xsl Transformation Error: " + strXsltTransformationErrorMessage);
				btPreviewDataTransformationFile.Enabled = false;
				btVerifyXmlFile.Enabled = false;
			}
			else
			{
				lbXmlFileCreate_DataTransformation.Text = Path.GetFileName(strDataTransformationXmlFile);
				btPreviewDataTransformationFile.Enabled = true;
				btVerifyXmlFile.Enabled = true;
				cbXSDtoUseOnExport.SelectedIndex=0;
			}
		}

		private void btPreviewDataTransformationFile_Click(object sender, System.EventArgs e)
		{
			utils.webBrowser.openFileInWebBrowser(axWebBrowser_ShowHtmlReport, this.strDataTransformationXmlFile);
		}

		private void btVerifyXmlFile_Click(object sender, System.EventArgs e)
		{
			copyXSDToDirectory(upCurrentUser.TempDirectoryPath);
			btVerifyXmlFile.Enabled = false;
			txtXmlValidationResult.Text = "";

			XmlTextReader xtrFileToValidate = new XmlTextReader(this.strDataTransformationXmlFile);
            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(xvrValidator_ValidationEventHandler);

            XmlReader xrValidator = XmlReader.Create(this.strDataTransformationXmlFile, xrs);
			bSuccess = true;
            while (xrValidator.Read()) { }
            xrValidator.Close();			
			if (bSuccess)			
				lbXmlValidationResult.Text = "OK";			
			else
				lbXmlValidationResult.Text = "Failed (see errors below)";
			btVerifyXmlFile.Enabled = true;
			btExportedXmlFileCopy.Enabled = true;			
		}

		private void xvrValidator_ValidationEventHandler(Object sender, ValidationEventArgs args)
		{			
			bSuccess = false;
			txtXmlValidationResult.Text += args.Message + Environment.NewLine ;			
		}

		private void label6_Click(object sender, System.EventArgs e)
		{
		
		}

		private void txtExportedXmlFileName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btExportedXmlFileCopy_Click(object sender, System.EventArgs e)
		{
			if (false == Directory.Exists(txtPathToSaveXmlFile.Text))
				Directory.CreateDirectory(txtPathToSaveXmlFile.Text);
			copyXSDToDirectory(txtPathToSaveXmlFile.Text);
			string strFullPathToExportFile = Path.Combine(txtPathToSaveXmlFile.Text, txtExportedXmlFileName.Text);
			if (strFullPathToExportFile != "")
				File.Copy(strDataTransformationXmlFile,strFullPathToExportFile,true);
		}

		private void copyXSDToDirectory(string strTargetDirectory)
		{
			string strPathToXsdFile = Path.Combine(GlobalVariables.strPathToXsdFiles,cbXSDtoUseOnExport.Text);
			string strPathToDestinationXsdFile = Path.Combine(strTargetDirectory,Path.GetFileName(strPathToXsdFile));
			File.Copy(strPathToXsdFile,strPathToDestinationXsdFile,true);
		}

		private void ascxExport_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
