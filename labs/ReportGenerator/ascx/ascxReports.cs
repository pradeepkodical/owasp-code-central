using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxReports.
	/// </summary>
	public class ascxReports : System.Windows.Forms.UserControl
	{
		private string strXmlWithAllData,strTargetHtmFile, strDataTransformationXmlFile;
		private bool bCancelPdfReportGeneration = false;
		private string strPathToTempPdfFile ="";
		private Hashtable htDataFilter_XsltEngineComboBox = new Hashtable();
        private UserProfile upCurrentUser = UserProfile.GetUserProfile();
        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

		private System.Windows.Forms.ListBox lbCurrentIssueTrackingFiles;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rbUseSpecificProject;
		private System.Windows.Forms.GroupBox gbUsingASpecific;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox gbUseProjectsTarget;
		private System.Windows.Forms.Button btRenderReport;
		private System.Windows.Forms.Button btGenerateXmlWithAllData;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbXmlFileCreated;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbDataFilter;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btProcessTransformation;
		private System.Windows.Forms.Label lbXmlFileCreate_DataTransformation;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lbTempReportFileCreated;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btPreviewDataTransformationFile;
		private System.Windows.Forms.Button btPreviewXmlFileWithAllData;
		private System.Windows.Forms.RadioButton rbCreateXmlWithConsolidatedData;
		private System.Windows.Forms.RadioButton rbIndividualConsolidatedXmlReports;
		private System.Windows.Forms.ComboBox cbIndividualConsolidatedXmlReports;
		private System.Windows.Forms.ComboBox cbReportTemplateToUse_Html;
		private System.Windows.Forms.ComboBox cbReportTemplateToUse_Pdf;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btReloadComboBoxes;
		private System.Windows.Forms.Button btGenerateHtmlReport;
		private System.Windows.Forms.Button btGeneratePdfReport;
		private System.Windows.Forms.CheckBox cbShowFopResults;
		private System.Windows.Forms.Button btCancelPdfGeneration;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbProposedPdfFileName;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btSaveGeneratedPdf;
		private AxSHDocVw.AxWebBrowser axWebBrowser_ShowHtmlReport;
		private System.Windows.Forms.ComboBox cbDataFilter_XsltEngine;
		private System.Windows.Forms.Label label15;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxReports()
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
				axWebBrowser_ShowHtmlReport.Dispose();
				axWebBrowser_ShowHtmlReport.ContainingControl = null;
				if(null != axWebBrowser_ShowHtmlReport && null != components )
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ascxReports));
			this.cbReportTemplateToUse_Html = new System.Windows.Forms.ComboBox();
			this.lbCurrentIssueTrackingFiles = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rbUseSpecificProject = new System.Windows.Forms.RadioButton();
			this.gbUsingASpecific = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.gbUseProjectsTarget = new System.Windows.Forms.GroupBox();
			this.btGenerateXmlWithAllData = new System.Windows.Forms.Button();
			this.btRenderReport = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btCancelPdfGeneration = new System.Windows.Forms.Button();
			this.cbShowFopResults = new System.Windows.Forms.CheckBox();
			this.rbCreateXmlWithConsolidatedData = new System.Windows.Forms.RadioButton();
			this.btPreviewXmlFileWithAllData = new System.Windows.Forms.Button();
			this.btGenerateHtmlReport = new System.Windows.Forms.Button();
			this.cbDataFilter = new System.Windows.Forms.ComboBox();
			this.lbXmlFileCreated = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btProcessTransformation = new System.Windows.Forms.Button();
			this.lbXmlFileCreate_DataTransformation = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lbTempReportFileCreated = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.btPreviewDataTransformationFile = new System.Windows.Forms.Button();
			this.rbIndividualConsolidatedXmlReports = new System.Windows.Forms.RadioButton();
			this.cbIndividualConsolidatedXmlReports = new System.Windows.Forms.ComboBox();
			this.cbReportTemplateToUse_Pdf = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btGeneratePdfReport = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lbProposedPdfFileName = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.btSaveGeneratedPdf = new System.Windows.Forms.Button();
			this.btReloadComboBoxes = new System.Windows.Forms.Button();
			this.axWebBrowser_ShowHtmlReport = new AxSHDocVw.AxWebBrowser();
			this.cbDataFilter_XsltEngine = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.gbUsingASpecific.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_ShowHtmlReport)).BeginInit();
			this.SuspendLayout();
			// 
			// cbReportTemplateToUse_Html
			// 
			this.cbReportTemplateToUse_Html.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbReportTemplateToUse_Html.Enabled = false;
			this.cbReportTemplateToUse_Html.Items.AddRange(new object[] {
																			"Just Items and Status",
																			"With Resolution Info"});
			this.cbReportTemplateToUse_Html.Location = new System.Drawing.Point(168, 200);
			this.cbReportTemplateToUse_Html.Name = "cbReportTemplateToUse_Html";
			this.cbReportTemplateToUse_Html.Size = new System.Drawing.Size(216, 21);
			this.cbReportTemplateToUse_Html.Sorted = true;
			this.cbReportTemplateToUse_Html.TabIndex = 28;
			// 
			// lbCurrentIssueTrackingFiles
			// 
			this.lbCurrentIssueTrackingFiles.Location = new System.Drawing.Point(8, 40);
			this.lbCurrentIssueTrackingFiles.Name = "lbCurrentIssueTrackingFiles";
			this.lbCurrentIssueTrackingFiles.Size = new System.Drawing.Size(192, 56);
			this.lbCurrentIssueTrackingFiles.TabIndex = 25;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(0, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(208, 24);
			this.label2.TabIndex = 27;
			this.label2.Text = "Choose the report\'s scope";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Visible = false;
			// 
			// rbUseSpecificProject
			// 
			this.rbUseSpecificProject.Location = new System.Drawing.Point(640, 24);
			this.rbUseSpecificProject.Name = "rbUseSpecificProject";
			this.rbUseSpecificProject.Size = new System.Drawing.Size(168, 16);
			this.rbUseSpecificProject.TabIndex = 29;
			this.rbUseSpecificProject.Text = "Use Specific Project";
			this.rbUseSpecificProject.CheckedChanged += new System.EventHandler(this.rbUseSpecificProject_CheckedChanged);
			// 
			// gbUsingASpecific
			// 
			this.gbUsingASpecific.Controls.Add(this.lbCurrentIssueTrackingFiles);
			this.gbUsingASpecific.Controls.Add(this.label3);
			this.gbUsingASpecific.Controls.Add(this.label4);
			this.gbUsingASpecific.Controls.Add(this.comboBox1);
			this.gbUsingASpecific.Location = new System.Drawing.Point(464, 64);
			this.gbUsingASpecific.Name = "gbUsingASpecific";
			this.gbUsingASpecific.Size = new System.Drawing.Size(176, 160);
			this.gbUsingASpecific.TabIndex = 30;
			this.gbUsingASpecific.TabStop = false;
			this.gbUsingASpecific.Text = "Using a Specific  Project";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 24);
			this.label3.TabIndex = 27;
			this.label3.Text = "Report Template To Use";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(8, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 24);
			this.label4.TabIndex = 27;
			this.label4.Text = "Report Template To Use";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Visible = false;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "Just Items and Status",
														   "With Resolution Info"});
			this.comboBox1.Location = new System.Drawing.Point(8, 120);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(144, 21);
			this.comboBox1.TabIndex = 28;
			// 
			// gbUseProjectsTarget
			// 
			this.gbUseProjectsTarget.Location = new System.Drawing.Point(672, 56);
			this.gbUseProjectsTarget.Name = "gbUseProjectsTarget";
			this.gbUseProjectsTarget.Size = new System.Drawing.Size(120, 160);
			this.gbUseProjectsTarget.TabIndex = 30;
			this.gbUseProjectsTarget.TabStop = false;
			this.gbUseProjectsTarget.Text = "Use Project\'s Target ";
			// 
			// btGenerateXmlWithAllData
			// 
			this.btGenerateXmlWithAllData.Location = new System.Drawing.Point(328, 56);
			this.btGenerateXmlWithAllData.Name = "btGenerateXmlWithAllData";
			this.btGenerateXmlWithAllData.Size = new System.Drawing.Size(152, 20);
			this.btGenerateXmlWithAllData.TabIndex = 31;
			this.btGenerateXmlWithAllData.Text = "Generate Xml With All Data";
			this.btGenerateXmlWithAllData.Click += new System.EventHandler(this.btGenerateXmlWithAllData_Click);
			// 
			// btRenderReport
			// 
			this.btRenderReport.Location = new System.Drawing.Point(704, 256);
			this.btRenderReport.Name = "btRenderReport";
			this.btRenderReport.Size = new System.Drawing.Size(88, 24);
			this.btRenderReport.TabIndex = 31;
			this.btRenderReport.Text = "Render Report";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btCancelPdfGeneration);
			this.groupBox1.Controls.Add(this.cbShowFopResults);
			this.groupBox1.Controls.Add(this.rbCreateXmlWithConsolidatedData);
			this.groupBox1.Controls.Add(this.cbReportTemplateToUse_Html);
			this.groupBox1.Controls.Add(this.btPreviewXmlFileWithAllData);
			this.groupBox1.Controls.Add(this.btGenerateHtmlReport);
			this.groupBox1.Controls.Add(this.cbDataFilter);
			this.groupBox1.Controls.Add(this.lbXmlFileCreated);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btGenerateXmlWithAllData);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.btProcessTransformation);
			this.groupBox1.Controls.Add(this.lbXmlFileCreate_DataTransformation);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.lbTempReportFileCreated);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.btPreviewDataTransformationFile);
			this.groupBox1.Controls.Add(this.rbIndividualConsolidatedXmlReports);
			this.groupBox1.Controls.Add(this.cbIndividualConsolidatedXmlReports);
			this.groupBox1.Controls.Add(this.cbReportTemplateToUse_Pdf);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.btGeneratePdfReport);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lbProposedPdfFileName);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.btSaveGeneratedPdf);
			this.groupBox1.Controls.Add(this.cbDataFilter_XsltEngine);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Location = new System.Drawing.Point(8, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(800, 360);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			// 
			// btCancelPdfGeneration
			// 
			this.btCancelPdfGeneration.Enabled = false;
			this.btCancelPdfGeneration.Location = new System.Drawing.Point(656, 280);
			this.btCancelPdfGeneration.Name = "btCancelPdfGeneration";
			this.btCancelPdfGeneration.Size = new System.Drawing.Size(104, 20);
			this.btCancelPdfGeneration.TabIndex = 35;
			this.btCancelPdfGeneration.Text = "Cancel Pdf";
			this.btCancelPdfGeneration.Click += new System.EventHandler(this.btCancelPdfGeneration_Click);
			// 
			// cbShowFopResults
			// 
			this.cbShowFopResults.Location = new System.Drawing.Point(536, 280);
			this.cbShowFopResults.Name = "cbShowFopResults";
			this.cbShowFopResults.Size = new System.Drawing.Size(120, 16);
			this.cbShowFopResults.TabIndex = 34;
			this.cbShowFopResults.Text = "Show FOP Results";
			// 
			// rbCreateXmlWithConsolidatedData
			// 
			this.rbCreateXmlWithConsolidatedData.Checked = true;
			this.rbCreateXmlWithConsolidatedData.Location = new System.Drawing.Point(328, 32);
			this.rbCreateXmlWithConsolidatedData.Name = "rbCreateXmlWithConsolidatedData";
			this.rbCreateXmlWithConsolidatedData.Size = new System.Drawing.Size(272, 24);
			this.rbCreateXmlWithConsolidatedData.TabIndex = 33;
			this.rbCreateXmlWithConsolidatedData.TabStop = true;
			this.rbCreateXmlWithConsolidatedData.Text = "Create Xml file with consolidated data";
			this.rbCreateXmlWithConsolidatedData.CheckedChanged += new System.EventHandler(this.rbCreateXmlWithConsolidatedData_CheckedChanged);
			// 
			// btPreviewXmlFileWithAllData
			// 
			this.btPreviewXmlFileWithAllData.Enabled = false;
			this.btPreviewXmlFileWithAllData.Location = new System.Drawing.Point(664, 62);
			this.btPreviewXmlFileWithAllData.Name = "btPreviewXmlFileWithAllData";
			this.btPreviewXmlFileWithAllData.Size = new System.Drawing.Size(112, 20);
			this.btPreviewXmlFileWithAllData.TabIndex = 31;
			this.btPreviewXmlFileWithAllData.Text = "Preview File";
			this.btPreviewXmlFileWithAllData.Click += new System.EventHandler(this.btPreviewXmlFileWithAllData_Click);
			// 
			// btGenerateHtmlReport
			// 
			this.btGenerateHtmlReport.Enabled = false;
			this.btGenerateHtmlReport.Location = new System.Drawing.Point(160, 248);
			this.btGenerateHtmlReport.Name = "btGenerateHtmlReport";
			this.btGenerateHtmlReport.Size = new System.Drawing.Size(216, 24);
			this.btGenerateHtmlReport.TabIndex = 31;
			this.btGenerateHtmlReport.Text = "Generate Html Report";
			this.btGenerateHtmlReport.Click += new System.EventHandler(this.btGenerateHtmlReport_Click);
			// 
			// cbDataFilter
			// 
			this.cbDataFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDataFilter.Enabled = false;
			this.cbDataFilter.Items.AddRange(new object[] {
															  "---- Select Filter -----"});
			this.cbDataFilter.Location = new System.Drawing.Point(96, 112);
			this.cbDataFilter.Name = "cbDataFilter";
			this.cbDataFilter.Size = new System.Drawing.Size(216, 21);
			this.cbDataFilter.Sorted = true;
			this.cbDataFilter.TabIndex = 28;
			this.cbDataFilter.SelectedIndexChanged += new System.EventHandler(this.cbDataFilter_SelectedIndexChanged);
			// 
			// lbXmlFileCreated
			// 
			this.lbXmlFileCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbXmlFileCreated.Location = new System.Drawing.Point(584, 64);
			this.lbXmlFileCreated.Name = "lbXmlFileCreated";
			this.lbXmlFileCreated.Size = new System.Drawing.Size(88, 16);
			this.lbXmlFileCreated.TabIndex = 32;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(488, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 32;
			this.label6.Text = "Xml File Created ->";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(24, 118);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 16);
			this.label7.TabIndex = 32;
			this.label7.Text = "Data Filter ->";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(8, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(280, 16);
			this.label8.TabIndex = 32;
			this.label8.Text = "Step 1) Choose Data Source";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(8, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(280, 16);
			this.label9.TabIndex = 32;
			this.label9.Text = "Step 2)  Chose a Data Filter";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 200);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(128, 16);
			this.label10.TabIndex = 32;
			this.label10.Text = "Html Report Template ->";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(8, 176);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(280, 16);
			this.label11.TabIndex = 32;
			this.label11.Text = "Step 3)  Choose a Report Template";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 248);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(176, 16);
			this.label5.TabIndex = 32;
			this.label5.Text = "Step 4)  Generate report";
			// 
			// btProcessTransformation
			// 
			this.btProcessTransformation.Location = new System.Drawing.Point(344, 112);
			this.btProcessTransformation.Name = "btProcessTransformation";
			this.btProcessTransformation.Size = new System.Drawing.Size(136, 20);
			this.btProcessTransformation.TabIndex = 31;
			this.btProcessTransformation.Text = "ProcessTransformation";
			this.btProcessTransformation.Click += new System.EventHandler(this.btProcessTransformation_Click);
			// 
			// lbXmlFileCreate_DataTransformation
			// 
			this.lbXmlFileCreate_DataTransformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbXmlFileCreate_DataTransformation.Location = new System.Drawing.Point(584, 116);
			this.lbXmlFileCreate_DataTransformation.Name = "lbXmlFileCreate_DataTransformation";
			this.lbXmlFileCreate_DataTransformation.Size = new System.Drawing.Size(88, 16);
			this.lbXmlFileCreate_DataTransformation.TabIndex = 32;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(488, 116);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(112, 16);
			this.label13.TabIndex = 32;
			this.label13.Text = "Xml File Created ->";
			// 
			// lbTempReportFileCreated
			// 
			this.lbTempReportFileCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTempReportFileCreated.Location = new System.Drawing.Point(144, 288);
			this.lbTempReportFileCreated.Name = "lbTempReportFileCreated";
			this.lbTempReportFileCreated.Size = new System.Drawing.Size(88, 16);
			this.lbTempReportFileCreated.TabIndex = 32;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(24, 288);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(112, 16);
			this.label14.TabIndex = 32;
			this.label14.Text = "Temp File Created ->";
			// 
			// btPreviewDataTransformationFile
			// 
			this.btPreviewDataTransformationFile.Enabled = false;
			this.btPreviewDataTransformationFile.Location = new System.Drawing.Point(664, 114);
			this.btPreviewDataTransformationFile.Name = "btPreviewDataTransformationFile";
			this.btPreviewDataTransformationFile.Size = new System.Drawing.Size(112, 20);
			this.btPreviewDataTransformationFile.TabIndex = 31;
			this.btPreviewDataTransformationFile.Text = "Preview File";
			this.btPreviewDataTransformationFile.Click += new System.EventHandler(this.btPreviewDataTransformationFile_Click);
			// 
			// rbIndividualConsolidatedXmlReports
			// 
			this.rbIndividualConsolidatedXmlReports.Location = new System.Drawing.Point(24, 32);
			this.rbIndividualConsolidatedXmlReports.Name = "rbIndividualConsolidatedXmlReports";
			this.rbIndividualConsolidatedXmlReports.Size = new System.Drawing.Size(272, 24);
			this.rbIndividualConsolidatedXmlReports.TabIndex = 33;
			this.rbIndividualConsolidatedXmlReports.Text = "Individual Consolidated XML Report";
			this.rbIndividualConsolidatedXmlReports.CheckedChanged += new System.EventHandler(this.rbIndividualConsolidatedXmlReports_CheckedChanged);
			// 
			// cbIndividualConsolidatedXmlReports
			// 
			this.cbIndividualConsolidatedXmlReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbIndividualConsolidatedXmlReports.Enabled = false;
			this.cbIndividualConsolidatedXmlReports.Items.AddRange(new object[] {
																					"---- Select Filter -----"});
			this.cbIndividualConsolidatedXmlReports.Location = new System.Drawing.Point(24, 56);
			this.cbIndividualConsolidatedXmlReports.Name = "cbIndividualConsolidatedXmlReports";
			this.cbIndividualConsolidatedXmlReports.Size = new System.Drawing.Size(224, 21);
			this.cbIndividualConsolidatedXmlReports.Sorted = true;
			this.cbIndividualConsolidatedXmlReports.TabIndex = 28;
			this.cbIndividualConsolidatedXmlReports.SelectedIndexChanged += new System.EventHandler(this.cbIndividualConsolidatedXmlReports_SelectedIndexChanged);
			// 
			// cbReportTemplateToUse_Pdf
			// 
			this.cbReportTemplateToUse_Pdf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbReportTemplateToUse_Pdf.Enabled = false;
			this.cbReportTemplateToUse_Pdf.Items.AddRange(new object[] {
																		   "Just Items and Status",
																		   "With Resolution Info"});
			this.cbReportTemplateToUse_Pdf.Location = new System.Drawing.Point(536, 200);
			this.cbReportTemplateToUse_Pdf.Name = "cbReportTemplateToUse_Pdf";
			this.cbReportTemplateToUse_Pdf.Size = new System.Drawing.Size(224, 21);
			this.cbReportTemplateToUse_Pdf.Sorted = true;
			this.cbReportTemplateToUse_Pdf.TabIndex = 28;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(400, 200);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(128, 16);
			this.label12.TabIndex = 32;
			this.label12.Text = "Pdf Report Template ->";
			// 
			// btGeneratePdfReport
			// 
			this.btGeneratePdfReport.Enabled = false;
			this.btGeneratePdfReport.Location = new System.Drawing.Point(536, 248);
			this.btGeneratePdfReport.Name = "btGeneratePdfReport";
			this.btGeneratePdfReport.Size = new System.Drawing.Size(224, 24);
			this.btGeneratePdfReport.TabIndex = 31;
			this.btGeneratePdfReport.Text = "Generate Pdf Report";
			this.btGeneratePdfReport.Click += new System.EventHandler(this.btGeneratePdfReport_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 320);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 16);
			this.label1.TabIndex = 32;
			this.label1.Text = "Step 5) Save Report";
			// 
			// lbProposedPdfFileName
			// 
			this.lbProposedPdfFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbProposedPdfFileName.Location = new System.Drawing.Point(536, 320);
			this.lbProposedPdfFileName.Name = "lbProposedPdfFileName";
			this.lbProposedPdfFileName.Size = new System.Drawing.Size(208, 32);
			this.lbProposedPdfFileName.TabIndex = 32;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(536, 304);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(128, 16);
			this.label16.TabIndex = 32;
			this.label16.Text = "Proposed File Name:";
			// 
			// btSaveGeneratedPdf
			// 
			this.btSaveGeneratedPdf.Enabled = false;
			this.btSaveGeneratedPdf.Location = new System.Drawing.Point(744, 312);
			this.btSaveGeneratedPdf.Name = "btSaveGeneratedPdf";
			this.btSaveGeneratedPdf.Size = new System.Drawing.Size(48, 20);
			this.btSaveGeneratedPdf.TabIndex = 35;
			this.btSaveGeneratedPdf.Text = "Save";
			this.btSaveGeneratedPdf.Click += new System.EventHandler(this.btSaveGeneratedPdf_Click);
			// 
			// btReloadComboBoxes
			// 
			this.btReloadComboBoxes.Location = new System.Drawing.Point(688, 4);
			this.btReloadComboBoxes.Name = "btReloadComboBoxes";
			this.btReloadComboBoxes.Size = new System.Drawing.Size(120, 20);
			this.btReloadComboBoxes.TabIndex = 35;
			this.btReloadComboBoxes.Text = "reload Combo Boxes";
			this.btReloadComboBoxes.Click += new System.EventHandler(this.btReloadComboBoxes_Click);
			// 
			// axWebBrowser_ShowHtmlReport
			// 
			this.axWebBrowser_ShowHtmlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.axWebBrowser_ShowHtmlReport.Enabled = true;
			this.axWebBrowser_ShowHtmlReport.Location = new System.Drawing.Point(8, 392);
			this.axWebBrowser_ShowHtmlReport.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser_ShowHtmlReport.OcxState")));
			this.axWebBrowser_ShowHtmlReport.Size = new System.Drawing.Size(800, 96);
			this.axWebBrowser_ShowHtmlReport.TabIndex = 36;
			// 
			// cbDataFilter_XsltEngine
			// 
			this.cbDataFilter_XsltEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDataFilter_XsltEngine.Enabled = false;
			this.cbDataFilter_XsltEngine.Items.AddRange(new object[] {
																		 "---- Select Filter -----"});
			this.cbDataFilter_XsltEngine.Location = new System.Drawing.Point(96, 144);
			this.cbDataFilter_XsltEngine.Name = "cbDataFilter_XsltEngine";
			this.cbDataFilter_XsltEngine.Size = new System.Drawing.Size(216, 21);
			this.cbDataFilter_XsltEngine.Sorted = true;
			this.cbDataFilter_XsltEngine.TabIndex = 28;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(24, 148);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(112, 16);
			this.label15.TabIndex = 32;
			this.label15.Text = "Xslt Engine ->";
			// 
			// ascxReports
			// 
			this.Controls.Add(this.axWebBrowser_ShowHtmlReport);
			this.Controls.Add(this.btReloadComboBoxes);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rbUseSpecificProject);
			this.Controls.Add(this.gbUsingASpecific);
			this.Controls.Add(this.gbUseProjectsTarget);
			this.Controls.Add(this.btRenderReport);
			this.Name = "ascxReports";
			this.Size = new System.Drawing.Size(816, 496);
			this.Load += new System.EventHandler(this.ascxReports_Load);
			this.gbUsingASpecific.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_ShowHtmlReport)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion		

		private void rbUseSpecificProject_CheckedChanged(object sender, System.EventArgs e)
		{			
			gbUsingASpecific.Enabled = true;
		}

		private void rbUseProjectsTarget_CheckedChanged(object sender, System.EventArgs e)
		{			
			gbUseProjectsTarget.Enabled= true;
		}

		private void ascxReports_Load(object sender, System.EventArgs e)
		{
			if (!this.DesignMode)
			{
				if (false == populateComboBoxes())
				{
					MessageBox.Show("The last error was fatal, and the application will terminate now");
					VulnReportHelpers.deleteTempFilesAndTerminateProcess();
				}
				if (cbDataFilter.Items.Count>0)
					cbDataFilter.SelectedIndex = 0;						
			}
		}

		private void renderReport(string strXsltFileToUse, string strXmlFileWithData)
		{
			this.strTargetHtmFile = Path.GetFullPath(Path.Combine(upCurrentUser.TempDirectoryPath, utils.files.returnUniqueFileName(".htm")));
			string strXsltTransformationErrorMessage = utils.xml.returnXmlXslTransformation(strXmlFileWithData,strXsltFileToUse,this.strTargetHtmFile);
			if ("" != strXsltTransformationErrorMessage)
			{
				MessageBox.Show("Xsl Transformation Error: " + strXsltTransformationErrorMessage);
				utils.webBrowser.openFileInWebBrowser(axWebBrowser_ShowHtmlReport,"about:blank");
			}
			else
			{
				lbTempReportFileCreated.Text = Path.GetFileName(strTargetHtmFile);
				utils.webBrowser.openFileInWebBrowser(axWebBrowser_ShowHtmlReport, this.strTargetHtmFile);
			}
			
		}

		private void createXmlFileWithAllData(string strTargetXmlFile)
		{			
			try 
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
			catch (Exception ex)
			{
				MessageBox.Show("Error in createXmlFileWithAllData:" + ex.Message);
			}
		}


		private XmlDocument createXmlFileToStoreXmlFindings(string strTargetXmlFile)
		{
			XmlDocument xdXmlDocument = new XmlDocument();
            if (File.Exists(obpPaths.EmptyConsolidatedProjectPath))
            {
                xdXmlDocument.Load(obpPaths.EmptyConsolidatedProjectPath);
            }
			return xdXmlDocument;
		}

		private void btGenerateXmlWithAllData_Click(object sender, System.EventArgs e)
		{
			if (Directory.Exists(upCurrentUser.TempDirectoryPath) == false)
				Directory.CreateDirectory(upCurrentUser.TempDirectoryPath);
			this.strXmlWithAllData = Path.GetFullPath(Path.Combine(upCurrentUser.TempDirectoryPath, utils.files.returnUniqueFileName(".xml")));			
			createXmlFileWithAllData(this.strXmlWithAllData);			
			lbXmlFileCreated.Text = Path.GetFileName(this.strXmlWithAllData);
			cbDataFilter.Enabled =  true;
			cbDataFilter_XsltEngine.Enabled = true;
			btPreviewXmlFileWithAllData.Enabled = true;
		}

		private bool populateComboBoxes()
		{
			populateDataFilterXsltEngine();
			// if one of these fails we abort the application start
            if (utils.windowsForms.loadFilesIntoComboBox(cbIndividualConsolidatedXmlReports, upCurrentUser.ConsolidatedReportsPath, "*.xml") &&
                utils.windowsForms.loadFilesIntoComboBox(cbDataFilter, obpPaths.XsltReportDataFiltersPath, "*.xslt") &&
                utils.windowsForms.loadFilesIntoComboBox(cbReportTemplateToUse_Html, obpPaths.XsltReportHtmlPath, "*.xslt") &&
                utils.windowsForms.loadFilesIntoComboBox(cbReportTemplateToUse_Pdf, obpPaths.XsltIssueTrackingReportsPath, "*.xslt"))
            {
                return true;
            }
			return false;			
		}

		private void populateDataFilterXsltEngine()
		{
			htDataFilter_XsltEngineComboBox.Clear();
			cbDataFilter_XsltEngine.Items.Clear();
			// create default entries
			htDataFilter_XsltEngineComboBox.Add("Altova XSLT Engine","Altova");
			htDataFilter_XsltEngineComboBox.Add(".NET XSLT Engine",".NET");			
			
			// populate combobox
			foreach (string strKey in htDataFilter_XsltEngineComboBox.Keys)
				cbDataFilter_XsltEngine.Items.Add(strKey);
			cbDataFilter_XsltEngine.SelectedIndex = 0;
		}

		private void cbDataFilter_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbDataFilter.SelectedIndex>0)
			{
				cbReportTemplateToUse_Html.Enabled = true;
				cbReportTemplateToUse_Pdf.Enabled= true;
			}
		}

		private void btProcessTransformation_Click(object sender, System.EventArgs e)
		{
			string strXmlFileToUse = "";
			if (rbIndividualConsolidatedXmlReports.Checked)
				strXmlFileToUse =  Path.GetFullPath(Path.Combine(upCurrentUser.ConsolidatedReportsPath,cbIndividualConsolidatedXmlReports.Text));
			else if (rbCreateXmlWithConsolidatedData.Checked)
				strXmlFileToUse = this.strXmlWithAllData;
			else
			{
				MessageBox.Show("No Radio Box selected");
				return;
			}
			this.strDataTransformationXmlFile = Path.GetFullPath(Path.Combine(upCurrentUser.TempDirectoryPath, utils.files.returnUniqueFileName(".xml")));			
			string strXsltDataTransformationFile = Path.GetFullPath(Path.Combine(obpPaths.XsltReportDataFiltersPath, cbDataFilter.Text));
			string strXsltTransformationErrorMessage ="";
			switch ((string)htDataFilter_XsltEngineComboBox[cbDataFilter_XsltEngine.Text])
			{
				case ".NET":
					strXsltTransformationErrorMessage = utils.xml.returnXmlXslTransformation(strXmlFileToUse,strXsltDataTransformationFile ,this.strDataTransformationXmlFile );
					break;
				case "Altova":
					bool bShowCmdWindow = true;
					strXsltTransformationErrorMessage = utils.altovaXml.processFiles(strDataTransformationXmlFile,strXmlFileToUse,strXsltDataTransformationFile,bShowCmdWindow,ref bCancelPdfReportGeneration, true);
					break;
			}						

			if ("" != strXsltTransformationErrorMessage)
			{
				MessageBox.Show("Xsl Transformation Error: " + strXsltTransformationErrorMessage);
				btPreviewDataTransformationFile.Enabled = false;
				cbReportTemplateToUse_Html.Enabled = false;
				cbReportTemplateToUse_Pdf.Enabled = false;
				btGenerateHtmlReport.Enabled= false;
				btGeneratePdfReport.Enabled= false;
				btCancelPdfGeneration.Enabled = false;
			}
			else
			{
				lbXmlFileCreate_DataTransformation.Text = Path.GetFileName(strDataTransformationXmlFile);
				btPreviewDataTransformationFile.Enabled = true;
				cbReportTemplateToUse_Html.Enabled = true;
				cbReportTemplateToUse_Pdf.Enabled = true;
				btGenerateHtmlReport.Enabled= true;
				btGeneratePdfReport.Enabled= true;
				btCancelPdfGeneration.Enabled = true;
			}
		}

		private void btPreviewDataTransformationFile_Click(object sender, System.EventArgs e)
		{
			utils.webBrowser.openFileInWebBrowser(axWebBrowser_ShowHtmlReport, this.strDataTransformationXmlFile);
		}


		private void btPreviewXmlFileWithAllData_Click(object sender, System.EventArgs e)
		{
			utils.webBrowser.openFileInWebBrowser(axWebBrowser_ShowHtmlReport, this.strXmlWithAllData);
		}

		private void rbCreateXmlWithConsolidatedData_CheckedChanged(object sender, System.EventArgs e)
		{
			btGenerateXmlWithAllData.Enabled = true;
			btPreviewXmlFileWithAllData.Enabled= true;
			cbIndividualConsolidatedXmlReports.Enabled = false;
			cbDataFilter.Enabled = false;
			cbDataFilter_XsltEngine.Enabled = false;
		}

		private void rbIndividualConsolidatedXmlReports_CheckedChanged(object sender, System.EventArgs e)
		{
			btGenerateXmlWithAllData.Enabled = false;
			btPreviewXmlFileWithAllData.Enabled= false;
			cbIndividualConsolidatedXmlReports.Enabled = true;		
			cbDataFilter.Enabled = true;
			cbDataFilter_XsltEngine.Enabled = true;

		}

		private void btReloadComboBoxes_Click(object sender, System.EventArgs e)
		{
			populateComboBoxes();
		}

		private void btGenerateHtmlReport_Click(object sender, System.EventArgs e)
		{
			//string strXsltFileToUse=GlobalVariables.strPathToXslt_Reports;
			string strXsltFileToUse= Path.GetFullPath(Path.Combine(obpPaths.XsltReportHtmlPath, cbReportTemplateToUse_Html.Text));
			string strXmlFileWithData = this.strDataTransformationXmlFile;
			renderReport(strXsltFileToUse,strXmlFileWithData);
		}

		private void cbIndividualConsolidatedXmlReports_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btGeneratePdfReport_Click(object sender, System.EventArgs e)
		{			
			btGeneratePdfReport.Enabled = false;
			cbShowFopResults.Enabled = false;
			btCancelPdfGeneration.Enabled = false;
			btSaveGeneratedPdf.Enabled = false;
			strPathToTempPdfFile = utils.files.returnFullPathToUniqueFileName(upCurrentUser.TempDirectoryPath,".pdf");;
			string strPathToPDFEngine = Path.Combine(Environment.CurrentDirectory, obpPaths.FopEnginePath);
			string strPathToXMLfile =  this.strDataTransformationXmlFile;
			string strPathToXSL_FO_file = Path.GetFullPath(Path.Combine(obpPaths.XsltIssueTrackingReportsPath, cbReportTemplateToUse_Pdf.Text));
			bool boolShowFOPResults = cbShowFopResults.Checked;
			if (utils.FOP.genereteAndCreatePDF( strPathToTempPdfFile,strPathToPDFEngine,strPathToXMLfile,strPathToXSL_FO_file,boolShowFOPResults, ref bCancelPdfReportGeneration))		
			{
				lbProposedPdfFileName.Text = calculateProposedPdfFileNameFromXmlFileOrTempPdfFileName(strPathToXMLfile,strPathToTempPdfFile);
				utils.webBrowser.openFileInWebBrowser(axWebBrowser_ShowHtmlReport,strPathToTempPdfFile);
			}
			btGeneratePdfReport.Enabled = true;
			cbShowFopResults.Enabled = true;
			btCancelPdfGeneration.Enabled = true;
			btSaveGeneratedPdf.Enabled = true;
		}

		private void btCancelPdfGeneration_Click(object sender, System.EventArgs e)
		{
			bCancelPdfReportGeneration = true;
		}

		private string calculateProposedPdfFileNameFromXmlFileOrTempPdfFileName(string strPathToXMLfile,string strPathToTempPdfFile)
		{
            string strProposedPdfFileName = Path.GetFileName(strPathToTempPdfFile);
			XmlDocument xdXmlDocument = new XmlDocument();
            if (File.Exists(strPathToXMLfile))
            {
                xdXmlDocument.Load(strPathToXMLfile);
                XmlNodeList xnlReportTitle = xdXmlDocument.GetElementsByTagName("ReportTitle");
                XmlNodeList xnlReportMonth = xdXmlDocument.GetElementsByTagName("ReportMonth");
                XmlNodeList xnlReportVersion = xdXmlDocument.GetElementsByTagName("ReportVersion");
                if (xnlReportTitle.Count > 0 || xnlReportMonth.Count > 0 || xnlReportVersion.Count > 0)
                {
                    if (xnlReportTitle.Count > 0)
                        strProposedPdfFileName += xnlReportTitle.Item(0).InnerText + " -";
                    if (xnlReportMonth.Count > 0)
                        strProposedPdfFileName += " " + xnlReportMonth.Item(0).InnerText + " -";
                    if (xnlReportVersion.Count > 0)
                        strProposedPdfFileName += " v" + xnlReportVersion.Item(0).InnerText;
                    if (strProposedPdfFileName[strProposedPdfFileName.Length - 1] == '-')			// remove end _
                        strProposedPdfFileName = strProposedPdfFileName.Substring(0, strProposedPdfFileName.Length - 1);
                    strProposedPdfFileName += ".pdf";
                }
            }
			return strProposedPdfFileName;
		}

		private void btSaveGeneratedPdf_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog fdPathToSavePdf = new SaveFileDialog();
			fdPathToSavePdf.FileName = lbProposedPdfFileName.Text;
			fdPathToSavePdf.Filter = "Pdf Files (*.pdf)|*.pdf";
			DialogResult drSavePdfFile = fdPathToSavePdf.ShowDialog();
			if (drSavePdfFile == DialogResult.OK)
				File.Copy(this.strPathToTempPdfFile,fdPathToSavePdf.FileName.ToString());
		}
	}
}
