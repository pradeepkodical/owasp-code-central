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
	/// Summary description for ReportPdf.
	/// </summary>
	public class ascxReportPdf : System.Windows.Forms.UserControl
	{

		private string strPathToProjectFiles;
		private string strCurrentProject;
		private string strFullPathToCurrentProject;
		private string strFullPathToCurrentProjectXmlFile;		
		private Hashtable htReportEngineComboBox = new Hashtable();
        private UserProfile upCurrentUser = UserProfile.GetUserProfile();
        private OrgBasePaths obpCurrentPaths = OrgBasePaths.GetPaths();
		private string strFullPathToTempReportFolder;
		private string strFullPathToTempReportXmlFile;
		private bool bCancelPdfReportGeneration = false; // this is not used here so this value will always be null

		private System.Windows.Forms.CheckBox cbShowFopResults;
		private System.Windows.Forms.TextBox txtDebugMessages;
		private System.Windows.Forms.Button btGeneratePdf;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox cbDeleteTempPdfFiles;
		private System.Windows.Forms.Button btJustCreatePdf;
		private System.Windows.Forms.Button btCreateReportXmlFileAndPublishItToIssueTrackingSystem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbFopXsltToUse;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbReportFileEngine;
		private AxSHDocVw.AxWebBrowser axWebBrowser_WithXslResult;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbReportExtension;
        private Button btCreateAndShowConsolidatedXmlFile;
        private Label label3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ascxReportPdf()
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
				axWebBrowser_WithXslResult.Dispose();
				axWebBrowser_WithXslResult.ContainingControl = null;
				if(null != axWebBrowser_WithXslResult && null != components )
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );	
		}


		public void loadProjectData(string strProjectToLoad)
		{
			axWebBrowser_WithXslResult.Visible=false;
			this.strPathToProjectFiles  = upCurrentUser.ProjectFilesPath;
			this.strCurrentProject = strProjectToLoad;
			this.strFullPathToCurrentProject = Path.GetFullPath(Path.Combine(strPathToProjectFiles, strCurrentProject));																		
			this.strFullPathToCurrentProjectXmlFile = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject , strCurrentProject + ".xml"));			
			populateComboBoxWithReport();
			populateReportEngineComboBox();

		}
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxReportPdf));
            this.cbShowFopResults = new System.Windows.Forms.CheckBox();
            this.txtDebugMessages = new System.Windows.Forms.TextBox();
            this.btGeneratePdf = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem = new System.Windows.Forms.Button();
            this.cbDeleteTempPdfFiles = new System.Windows.Forms.CheckBox();
            this.btJustCreatePdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFopXsltToUse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.axWebBrowser_WithXslResult = new AxSHDocVw.AxWebBrowser();
            this.cbReportFileEngine = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbReportExtension = new System.Windows.Forms.ComboBox();
            this.btCreateAndShowConsolidatedXmlFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_WithXslResult)).BeginInit();
            this.SuspendLayout();
            // 
            // cbShowFopResults
            // 
            this.cbShowFopResults.Location = new System.Drawing.Point(384, 32);
            this.cbShowFopResults.Name = "cbShowFopResults";
            this.cbShowFopResults.Size = new System.Drawing.Size(240, 16);
            this.cbShowFopResults.TabIndex = 16;
            this.cbShowFopResults.Text = "Show Fop Results in CMD window";
            // 
            // txtDebugMessages
            // 
            this.txtDebugMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugMessages.Location = new System.Drawing.Point(8, 304);
            this.txtDebugMessages.Multiline = true;
            this.txtDebugMessages.Name = "txtDebugMessages";
            this.txtDebugMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugMessages.Size = new System.Drawing.Size(784, 64);
            this.txtDebugMessages.TabIndex = 14;
            // 
            // btGeneratePdf
            // 
            this.btGeneratePdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGeneratePdf.Location = new System.Drawing.Point(384, 3);
            this.btGeneratePdf.Name = "btGeneratePdf";
            this.btGeneratePdf.Size = new System.Drawing.Size(216, 24);
            this.btGeneratePdf.TabIndex = 13;
            this.btGeneratePdf.Text = "Create Report Files using ->";
            this.btGeneratePdf.Click += new System.EventHandler(this.btGeneratePdf_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Debug Messages";
            // 
            // btCreateReportXmlFileAndPublishItToIssueTrackingSystem
            // 
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem.Location = new System.Drawing.Point(593, 238);
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem.Name = "btCreateReportXmlFileAndPublishItToIssueTrackingSystem";
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem.Size = new System.Drawing.Size(198, 40);
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem.TabIndex = 17;
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem.Text = "Create Report Xml File and Publish it to Issue Tracking Database";
            this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem.Click += new System.EventHandler(this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem_Click);
            // 
            // cbDeleteTempPdfFiles
            // 
            this.cbDeleteTempPdfFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDeleteTempPdfFiles.Location = new System.Drawing.Point(120, 253);
            this.cbDeleteTempPdfFiles.Name = "cbDeleteTempPdfFiles";
            this.cbDeleteTempPdfFiles.Size = new System.Drawing.Size(136, 16);
            this.cbDeleteTempPdfFiles.TabIndex = 18;
            this.cbDeleteTempPdfFiles.Text = "Delete Temp Pdf Files";
            // 
            // btJustCreatePdf
            // 
            this.btJustCreatePdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btJustCreatePdf.Location = new System.Drawing.Point(8, 240);
            this.btJustCreatePdf.Name = "btJustCreatePdf";
            this.btJustCreatePdf.Size = new System.Drawing.Size(106, 40);
            this.btJustCreatePdf.TabIndex = 19;
            this.btJustCreatePdf.Text = "Just Create Pdf (requires temp files)";
            this.btJustCreatePdf.Click += new System.EventHandler(this.btJustCreatePdf_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Step 1) choose which Xslt Fop to use";
            // 
            // cbFopXsltToUse
            // 
            this.cbFopXsltToUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFopXsltToUse.Location = new System.Drawing.Point(8, 24);
            this.cbFopXsltToUse.Name = "cbFopXsltToUse";
            this.cbFopXsltToUse.Size = new System.Drawing.Size(309, 21);
            this.cbFopXsltToUse.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Step 2)";
            // 
            // axWebBrowser_WithXslResult
            // 
            this.axWebBrowser_WithXslResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axWebBrowser_WithXslResult.Enabled = true;
            this.axWebBrowser_WithXslResult.Location = new System.Drawing.Point(8, 56);
            this.axWebBrowser_WithXslResult.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser_WithXslResult.OcxState")));
            this.axWebBrowser_WithXslResult.Size = new System.Drawing.Size(784, 176);
            this.axWebBrowser_WithXslResult.TabIndex = 23;
            // 
            // cbReportFileEngine
            // 
            this.cbReportFileEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReportFileEngine.Location = new System.Drawing.Point(622, 5);
            this.cbReportFileEngine.Name = "cbReportFileEngine";
            this.cbReportFileEngine.Size = new System.Drawing.Size(152, 21);
            this.cbReportFileEngine.TabIndex = 24;
            this.cbReportFileEngine.SelectedIndexChanged += new System.EventHandler(this.cbReportFileEngine_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(622, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 24);
            this.label12.TabIndex = 25;
            this.label12.Text = "Report Extension:";
            // 
            // cbReportExtension
            // 
            this.cbReportExtension.Items.AddRange(new object[] {
            ".xls",
            ".html",
            ".doc",
            ".pdf",
            ".xml"});
            this.cbReportExtension.Location = new System.Drawing.Point(710, 28);
            this.cbReportExtension.Name = "cbReportExtension";
            this.cbReportExtension.Size = new System.Drawing.Size(64, 21);
            this.cbReportExtension.TabIndex = 26;
            // 
            // btCreateAndShowConsolidatedXmlFile
            // 
            this.btCreateAndShowConsolidatedXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateAndShowConsolidatedXmlFile.Location = new System.Drawing.Point(255, 244);
            this.btCreateAndShowConsolidatedXmlFile.Name = "btCreateAndShowConsolidatedXmlFile";
            this.btCreateAndShowConsolidatedXmlFile.Size = new System.Drawing.Size(123, 36);
            this.btCreateAndShowConsolidatedXmlFile.TabIndex = 27;
            this.btCreateAndShowConsolidatedXmlFile.Text = "Create and show consolidated XML file";
            this.btCreateAndShowConsolidatedXmlFile.UseVisualStyleBackColor = true;
            this.btCreateAndShowConsolidatedXmlFile.Click += new System.EventHandler(this.btCreateAndShowConsolidatedXmlFile_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "This is the file that is used by the selected XSLT engine";
            // 
            // ascxReportPdf
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btCreateAndShowConsolidatedXmlFile);
            this.Controls.Add(this.cbReportExtension);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbReportFileEngine);
            this.Controls.Add(this.axWebBrowser_WithXslResult);
            this.Controls.Add(this.cbFopXsltToUse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btJustCreatePdf);
            this.Controls.Add(this.cbDeleteTempPdfFiles);
            this.Controls.Add(this.btCreateReportXmlFileAndPublishItToIssueTrackingSystem);
            this.Controls.Add(this.cbShowFopResults);
            this.Controls.Add(this.txtDebugMessages);
            this.Controls.Add(this.btGeneratePdf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Name = "ascxReportPdf";
            this.Size = new System.Drawing.Size(800, 376);
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser_WithXslResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btGeneratePdf_Click(object sender, System.EventArgs e)
		{
			createReportXmlFile();			
			switch ((string)htReportEngineComboBox[cbReportFileEngine.Text])
			{
				case "FOP":					
					useFopToCreatePdf();
					break;
				case ".NET":
					useDotNetToCreateFile();
					break;
				case "Altova":
					useAltovaToCreateFile();
					break;
			}			
			if (cbDeleteTempPdfFiles.Checked)
			{
				if (Directory.Exists(strFullPathToTempReportFolder))
					Directory.Delete(this.strFullPathToTempReportFolder,true);
			}
		}

		private void createReportXmlFile()
		{
			try
			{
				this.strFullPathToTempReportFolder = Path.GetFullPath(Path.Combine(upCurrentUser.TempDirectoryPath,strCurrentProject+"_report"));
                string strFullPathToXmlReportTempUnZipFolder = Path.Combine(upCurrentUser.TempDirectoryPath, "_XmlFileForReport");	// [DC] I added the "_XmlFileForReport" because there was an race-condition that would occur if the user had open in the Findings Tab a Finding that was used in the report
				if (Directory.Exists(strFullPathToTempReportFolder))
					Directory.Delete(strFullPathToTempReportFolder,true);
				if (false == Directory.Exists(strFullPathToTempReportFolder))
					Directory.CreateDirectory(strFullPathToTempReportFolder);
				this.strFullPathToTempReportXmlFile = Path.GetFullPath(Path.Combine(strFullPathToTempReportFolder , strCurrentProject + ".xml"));			
				File.Copy(strFullPathToCurrentProjectXmlFile ,this.strFullPathToTempReportXmlFile);

				// main report Xml document
				XmlDocument xdReport = new XmlDocument();
				xdReport.Load(this.strFullPathToTempReportXmlFile);
				XmlNodeList xnlReportContentsInMainXmlDocument = xdReport.GetElementsByTagName("ExecutiveSummary"); 			
				if (xnlReportContentsInMainXmlDocument.Count==1)		// if there is content here we want to remove it (since the original content will be legacy)
				{
					xdReport.DocumentElement.RemoveChild(xnlReportContentsInMainXmlDocument[0]);				
				}
				// Load ReportContents file			
				string strReportContentsFile = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject, strCurrentProject + "_ReportContents.xml"));
                if (!File.Exists(strReportContentsFile))
                {
                    File.Copy(obpCurrentPaths.EmptyConsolidatedProjectPath, strReportContentsFile);
                }

                XmlDocument xdReportContents = new XmlDocument();
                xdReportContents.Load(strReportContentsFile);
                XmlNodeList xnlReportContents = xdReportContents.GetElementsByTagName("ExecutiveSummary");   // originally the ReportContents was called Executive Summary
                if (xnlReportContents.Count == 1)		// there is content in ReportContents
                {
                    xdReport.DocumentElement.InnerXml += xnlReportContents[0].OuterXml;
                }
                
				XmlNodeList xnlFinalTargets = xdReport.GetElementsByTagName("Targets");
				if (xnlFinalTargets.Count==1)
				{
					XmlNode xnFinalTargets = xnlFinalTargets[0];							
					foreach(DirectoryInfo diTargets in new DirectoryInfo(strFullPathToCurrentProject).GetDirectories())			
					{				 
						// Handeling Target info
						string StrPathToTargetXmlFileInTempFolder = Path.GetFullPath(Path.Combine(diTargets.FullName,Path.GetFileNameWithoutExtension(diTargets.FullName)+ ".xml"));
						if (File.Exists(StrPathToTargetXmlFileInTempFolder))
						{
							XmlDocument xdTargets = new XmlDocument();
							string strFileContents = utils.files.GetFileContents(StrPathToTargetXmlFileInTempFolder);
							if ("" != strFileContents)
							{
								xdTargets.LoadXml(strFileContents );
													
								XmlNodeList xnlFindings = xdTargets.GetElementsByTagName("Findings");
								XmlNode xnFindings;
								if (xnlFindings.Count == 0)			// There is not Findings Tag						
								{
									xnFindings = xdTargets.CreateElement("Findings");								
								}
								else						
									xnFindings = xnlFindings[0];
								foreach(FileInfo fiTarget in new DirectoryInfo(diTargets.FullName).GetFiles())
								{
									if (fiTarget.Extension == ".zip")
									{
										try
										{
											//Handling Findings Xml content
                                            utils.zip.unzipFile(fiTarget.FullName, strFullPathToXmlReportTempUnZipFolder);
											string strFindingName = Path.GetFileNameWithoutExtension(fiTarget.FullName);
											string strPathToUnzipFindingsInTempFolder = Path.GetFullPath(
                                                Path.Combine(strFullPathToXmlReportTempUnZipFolder, strFindingName));
                                            string StrPathToFindingstXmlFileInTempFolder = Path.GetFullPath(Path.Combine(strFullPathToXmlReportTempUnZipFolder, strFindingName + "\\" + strFindingName + ".xml"));
																					
											XmlDocument xdFindings = new XmlDocument();
											if (File.Exists(StrPathToFindingstXmlFileInTempFolder))
											{
                                               // string strFindingFileContents = utils.files.GetFileContents(StrPathToFindingstXmlFileInTempFolder);

                                                /* */

												xdFindings.Load(StrPathToFindingstXmlFileInTempFolder);
												foreach (XmlNode xnlFinding in xdFindings.GetElementsByTagName("Finding"))
													xnFindings.InnerXml += xnlFinding.OuterXml;							
												//Handling Images
                                                string strPathToFindingsImageDirectory = Path.GetFullPath(Path.Combine(strFullPathToXmlReportTempUnZipFolder, strFindingName + "//" + strFindingName));
												string strPathToImagesFolderInTempReportFolder = Path.GetFullPath(Path.Combine(strFullPathToTempReportFolder,strFindingName ));
												if (Directory.Exists(strPathToFindingsImageDirectory))
                                                {
                                                    if (false == Directory.Exists(strPathToImagesFolderInTempReportFolder))
                                                        Directory.CreateDirectory(strPathToImagesFolderInTempReportFolder);
                                                    foreach (string strFile in Directory.GetFiles(strPathToFindingsImageDirectory))
                                                    {
                                                        string strTargetFileName = Path.Combine(strPathToImagesFolderInTempReportFolder, Path.GetFileName(strFile));
                                                        if (false == File.Exists(strTargetFileName))                                                            
                                                            File.Copy(strFile, strTargetFileName);
                                                       // at the moment the following check is thowing a lot of false positives (since they occour if one copy and paste a finding). 
                                                       // the correct way to do this is to implement a image checksum check which makes sure that the images are the same
                                                       // else
                                                       //     addMessageToDebugWindow("Error: Image  '" + strTargetFileName.Replace(strFullPathToTempReportFolder, "") + "' already exists, skiping current file");                                                                                                                    
                                                    }   
                                                  
                                                }
                                               /* */
                                            }
											Directory.Delete(strPathToUnzipFindingsInTempFolder,true);
										}
										catch (Exception ex)
										{
											//MessageBox.Show
											addMessageToDebugWindow("Error in file '"+ Path.Combine( diTargets.Name, fiTarget.Name) + "':" + ex.Message);
										}
									}
								}	
								if (xdTargets.GetElementsByTagName("Target").Count>0)
								{
									if (xnlFindings.Count == 0)			// There is not Findings Tag																
										xdTargets.GetElementsByTagName("Target")[0].AppendChild(xnFindings);													
									xnFinalTargets.InnerXml+=((xdTargets.GetElementsByTagName("Target")[0].OuterXml).Replace("xmlns=\"\"",""));  // need to add the xslt namespace directly to the Findings Element
								}	
							}
						}
					}
				}						
				xdReport.Save(this.strFullPathToTempReportXmlFile);
                Directory.Delete(strFullPathToXmlReportTempUnZipFolder);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in createReportXmlFile: " + ex.Message);
			}

		}
		private void btJustCreatePdf_Click(object sender, System.EventArgs e)
		{
			cbReportExtension.Text= ".pdf";
			useFopToCreatePdf();			
		}


		private void useAltovaToCreateFile()
		{
			string stringPathToTempFile = utils.files.returnFullPathToUniqueFileName(upCurrentUser.TempDirectoryPath ,cbReportExtension.Text);;
			string stringPathToXMLfile =  this.strFullPathToTempReportXmlFile;
			string stringPathToXSLfile = Path.Combine(obpCurrentPaths.XsltLiveProjectsReportPath, cbFopXsltToUse.Text); 
		
			bool boolShowFOPResults = cbShowFopResults.Checked;
			utils.altovaXml.processFiles(stringPathToTempFile,stringPathToXMLfile,stringPathToXSLfile,boolShowFOPResults,ref bCancelPdfReportGeneration,true);		
		}

		private void useDotNetToCreateFile()
		{
			string stringPathToTempFile = utils.files.returnFullPathToUniqueFileName(upCurrentUser.TempDirectoryPath ,cbReportExtension.Text);;
			string stringPathToXMLfile =  this.strFullPathToTempReportXmlFile;
			string stringPathToXSLfile = Path.Combine(obpCurrentPaths.XsltLiveProjectsReportPath, cbFopXsltToUse.Text); 
			string strErrorMessage = utils.xml.returnXmlXslTransformation(stringPathToXMLfile,stringPathToXSLfile,stringPathToTempFile);
			if (strErrorMessage != "")
				MessageBox.Show(strErrorMessage);
			utils.webBrowser.openFileInWebBrowser(axWebBrowser_WithXslResult,stringPathToTempFile);						
		}

		private void useFopToCreatePdf()
		{
			string stringPathToTempPdfFile = utils.files.returnFullPathToUniqueFileName(upCurrentUser.TempDirectoryPath ,cbReportExtension.Text);;
			string stringPathToPDFEngine = Path.Combine(Environment.CurrentDirectory, obpCurrentPaths.FopEnginePath);
			string stringPathToXMLfile =  this.strFullPathToTempReportXmlFile; 
			string stringPathToXSL_FO_file = Path.Combine(obpCurrentPaths.XsltLiveProjectsReportPath, cbFopXsltToUse.Text); 
			bool boolShowFOPResults = cbShowFopResults.Checked;
			if (utils.FOP.genereteAndCreatePDF( stringPathToTempPdfFile,stringPathToPDFEngine,stringPathToXMLfile,stringPathToXSL_FO_file,boolShowFOPResults, ref bCancelPdfReportGeneration))					
				utils.webBrowser.openFileInWebBrowser(axWebBrowser_WithXslResult,stringPathToTempPdfFile);						
		}

		private void addMessageToDebugWindow(string strMessageToAdd)
		{
			txtDebugMessages.Text = strMessageToAdd + Environment.NewLine + txtDebugMessages.Text ;
		}

		private void btCreateReportXmlFileAndPublishItToIssueTrackingSystem_Click(object sender, System.EventArgs e)
		{			
			createReportXmlFile();
			string strFullPathToNewIssueTrackingFile = Path.GetFullPath(Path.Combine(upCurrentUser.ConsolidatedReportsPath,Path.GetFileName(strFullPathToTempReportXmlFile)));
            if (File.Exists(strFullPathToNewIssueTrackingFile))
                MessageBox.Show("Issue Tracking File '" + Path.GetFileName(strFullPathToTempReportXmlFile) + "' already exists! Delete it first");
            else
            {
                if (!Directory.Exists(upCurrentUser.ConsolidatedReportsPath))
                {
                    Directory.CreateDirectory(upCurrentUser.ConsolidatedReportsPath);
                }
                File.Copy(this.strFullPathToTempReportXmlFile, strFullPathToNewIssueTrackingFile);
            }
		}


		public void populateComboBoxWithReport()
		{			
			utils.windowsForms.loadFilesIntoComboBox(cbFopXsltToUse, obpCurrentPaths.XsltLiveProjectsReportPath,"*.xslt");			
		}

		private void cbReportFileEngine_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch ((string)htReportEngineComboBox[cbReportFileEngine.Text])
			{
				case "FOP":
					cbReportExtension.Text = ".pdf";
					cbReportExtension.Enabled=false;
					break;
				case ".NET":
				case "Altova":
					cbReportExtension.Text = ".xml";
					cbReportExtension.Enabled=true;
					break;
			}
		}

		private void populateReportEngineComboBox()
		{
			htReportEngineComboBox.Clear();
			cbReportFileEngine.Items.Clear();
			// create default entries
			htReportEngineComboBox.Add("Altova XSLT Engine","Altova");
			htReportEngineComboBox.Add(".NET XSLT Engine",".NET");
			htReportEngineComboBox.Add("FOP (Output PDF)","FOP");
			
			// populate combobox
			foreach (string strKey in htReportEngineComboBox.Keys)
				cbReportFileEngine.Items.Add(strKey);
			cbReportFileEngine.SelectedIndex = 0;
		}

        private void btCreateAndShowConsolidatedXmlFile_Click(object sender, EventArgs e)
        {
            createReportXmlFile();
            axWebBrowser_WithXslResult.Navigate(strFullPathToTempReportXmlFile);
            axWebBrowser_WithXslResult.Visible = true;
        }

	}
}
