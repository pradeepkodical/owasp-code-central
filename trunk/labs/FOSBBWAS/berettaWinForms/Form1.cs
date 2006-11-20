using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using beretta.Objects;
using System.IO;

namespace berettaWinForms
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstUrls;
		private System.Windows.Forms.Label lblBaseUrl;
		private System.Windows.Forms.TextBox txtBaseUrl;
		private System.Windows.Forms.Button cmdSpider;
		private System.Windows.Forms.Button cmdScan;
		private Spider.Spider m_spider;
		private System.Windows.Forms.Label label1;

		private DataSet objPayloadDataSet=new DataSet();
		private DataSet objSignaturesDataSet=new DataSet();
		private DataSet objUrlsDataSet=new DataSet();
		private formSubmitter objFormSubmitter=new formSubmitter();
		protected response objRespone=new response();
		private System.Text.StringBuilder objStringBuilder=new System.Text.StringBuilder();
		private string strUrls="";
		private System.Windows.Forms.Button cmdAdd;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstUrls = new System.Windows.Forms.ListBox();
			this.lblBaseUrl = new System.Windows.Forms.Label();
			this.txtBaseUrl = new System.Windows.Forms.TextBox();
			this.cmdSpider = new System.Windows.Forms.Button();
			this.cmdScan = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lstUrls
			// 
			this.lstUrls.Location = new System.Drawing.Point(16, 144);
			this.lstUrls.Name = "lstUrls";
			this.lstUrls.Size = new System.Drawing.Size(456, 238);
			this.lstUrls.TabIndex = 0;
			// 
			// lblBaseUrl
			// 
			this.lblBaseUrl.Location = new System.Drawing.Point(16, 24);
			this.lblBaseUrl.Name = "lblBaseUrl";
			this.lblBaseUrl.Size = new System.Drawing.Size(64, 23);
			this.lblBaseUrl.TabIndex = 1;
			this.lblBaseUrl.Text = "Base URL:";
			// 
			// txtBaseUrl
			// 
			this.txtBaseUrl.Location = new System.Drawing.Point(88, 24);
			this.txtBaseUrl.Name = "txtBaseUrl";
			this.txtBaseUrl.Size = new System.Drawing.Size(296, 20);
			this.txtBaseUrl.TabIndex = 2;
			this.txtBaseUrl.Text = "http://localhost/hacmebank/";
			// 
			// cmdSpider
			// 
			this.cmdSpider.Location = new System.Drawing.Point(16, 64);
			this.cmdSpider.Name = "cmdSpider";
			this.cmdSpider.TabIndex = 3;
			this.cmdSpider.Text = "Spider";
			this.cmdSpider.Click += new System.EventHandler(this.cmdSpider_Click);
			// 
			// cmdScan
			// 
			this.cmdScan.Location = new System.Drawing.Point(16, 416);
			this.cmdScan.Name = "cmdScan";
			this.cmdScan.TabIndex = 4;
			this.cmdScan.Text = "Scan";
			this.cmdScan.Click += new System.EventHandler(this.cmdScan_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Urls:";
			// 
			// cmdAdd
			// 
			this.cmdAdd.Location = new System.Drawing.Point(400, 24);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 6;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 470);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmdScan);
			this.Controls.Add(this.cmdSpider);
			this.Controls.Add(this.txtBaseUrl);
			this.Controls.Add(this.lblBaseUrl);
			this.Controls.Add(this.lstUrls);
			this.Name = "Form1";
			this.Text = "Beretta Windows Application";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());

			
		}

		private void cmdSpider_Click(object sender, System.EventArgs e)
		{
			lstUrls.Items.Clear();

			string strNewGuid="" + System.Guid.NewGuid();
			string strNewPath="" + Application.StartupPath + "/temp/" + strNewGuid + "/";

			System.IO.Directory.CreateDirectory(strNewPath);

			m_spider = new Spider.Spider();
			m_spider.OutputPath = Application.StartupPath + "/temp/" + strNewGuid + "/";
			m_spider.rootPath=strNewPath;
			m_spider.sessionId=0;
			m_spider.Start(new Uri(this.txtBaseUrl.Text), 1);
		
			System.Threading.Thread.Sleep(6000);

			string strUrl="";
			string[] strTmpUrl;

			try
			{

				System.IO.StreamReader oRead;
				oRead = System.IO.File.OpenText(strNewPath + "tmpUrl.txt");
				strUrl=oRead.ReadToEnd();
				oRead.Close();
				oRead=null;

				System.IO.Directory.Delete(strNewPath, true);

				strTmpUrl=strUrl.Split(';');

				foreach(string strTmp in strTmpUrl)
				{
					lstUrls.Items.Add(strTmp);
				}

			}
			catch
			{
				MessageBox.Show("No urls found, is the base url correct?");
			}

		}


		public void SpiderThread()
		{
			m_spider = new Spider.Spider();
			m_spider.OutputPath = "";
			
			int threads = 1;

			if(threads<1) threads = 1;
				
			try
			{
				m_spider.Start(new Uri(this.txtBaseUrl.Text),threads);
			}
			catch
			{
				
				return;
			}
		}

		private void cmdScan_Click(object sender, System.EventArgs e)
		{
			string strPath="" + Application.StartupPath;
			string strTotalDoc="";
			string strHeader="";
			string strUserAgent="";
			DataSet objPayloads;
			DataSet objSignatures;

			berettaWinForms.classes.loadXml objLoadXml=new berettaWinForms.classes.loadXml();
			objSignatures=objLoadXml.loadSignatures(strPath + "/data/signatures.xml");
			objPayloads=objLoadXml.loadPayloads(strPath + "/data/payloads.xml");


			MessageBox.Show("Starting Scan");
		

			System.Text.StringBuilder objFormSubmissionStr=new System.Text.StringBuilder();

			string strGuid="" + System.Guid.NewGuid().ToString();

		
			
			#region Construct Report Header

			strHeader += "<header>";
			strHeader += "<application>beretta</application>";
			strHeader += "<version>1.0</version>";
			strHeader += "<sessionId>0</sessionId>";
			strHeader += "<date>" + System.DateTime.Now + "</date>";


			strHeader += "<authenticationType>None</authenticationType>";
			strHeader += "<sessionName>New Session</sessionName>";
			strHeader += "<sessionDescription>Description</sessionDescription>";
			strHeader += "</header>";

			#endregion

			
			
			foreach(string strUrl in lstUrls.Items)
			{
				//Auto Scan
				
					urlWorker objUrlWorkerAuto=new urlWorker();
					objUrlWorkerAuto.sessionId=0;
					objUrlWorkerAuto.authenticationType=0;
					objUrlWorkerAuto.url="" + strUrl;
					objUrlWorkerAuto.userAgent=strUserAgent;
					objUrlWorkerAuto.payloadDataSet=objPayloads;
					objUrlWorkerAuto.signaturesDataSet=objSignatures;
					objUrlWorkerAuto.scanAuto();
				
				
					if (objUrlWorkerAuto.objBerettaResultHashTable != null && objUrlWorkerAuto.objBerettaResultHashTable.Count>0)
					{
						objStringBuilder.Append(buildResults(objUrlWorkerAuto.objBerettaResultHashTable));
					}

					objFormSubmissionStr.Append(buildSubmission(objUrlWorkerAuto.objBerettaSubmissionHashTable));

					objUrlWorkerAuto=null;
				
					strUrls=strUrls + "<url>" + strUrl + "</url>";
				
			}


			

			#region Construct XML report

			strTotalDoc+="<report>";
			strTotalDoc+="" + strHeader;
			strTotalDoc+="" + "<body>";
			strTotalDoc+="" + "<urlsScanned>" + strUrls + "</urlsScanned>";
			strTotalDoc+="<scanItems>"  + objStringBuilder.ToString() + "</scanItems>";
			strTotalDoc+="<formSubmissions>"  + objFormSubmissionStr.ToString() + "</formSubmissions>";
			strTotalDoc+="" + "</body>";
			strTotalDoc+="</report>";

			#endregion

			#region Write XML report
			
			
			

			string strOutputPath="" + Application.StartupPath + "/output/" + strGuid + ".XML";
			string strXSLPath="" + Application.StartupPath + "/xsl/beretta.xsl";

			StreamWriter objStreamWriter; 
					
			//Add XSL file ref
			
			strTotalDoc="<?xml-stylesheet href='" + strXSLPath + "' type='text/xsl'?>" + strTotalDoc;
				 
			objStreamWriter = System.IO.File.CreateText(strOutputPath);
			objStreamWriter.WriteLine(strTotalDoc);
			objStreamWriter.Close();
			
			MessageBox.Show("Finished Scan. Report at: " + strOutputPath);


			#endregion

		}


		public string buildResults(System.Collections.Hashtable objUrlResults)
		{
			string strTmp="";
			string strSignatureMessageType="";

			int intX=0;
			

			
			foreach (System.Collections.DictionaryEntry objEntry in objUrlResults)
			{
		
				berettaResult objBerettaResult;
			
				objBerettaResult=(berettaResult) objEntry.Value;

				strTmp += "<item>";
				strTmp += "<url>" + objBerettaResult.url + "</url>";
				strTmp += "<payload>" + objBerettaResult.payloadName + "</payload>";
				strTmp += "<signature>" + objBerettaResult.signatureName+ "</signature>";
				strTmp += "<signatureMessage>" + objBerettaResult.signatureMessage + "</signatureMessage>";


				if (objBerettaResult.signatureMessageType=="0")
				{
					strSignatureMessageType="Info";
				}	
				else if (objBerettaResult.signatureMessageType=="1")
				{
					strSignatureMessageType="Warning";
				}	
				else if (objBerettaResult.signatureMessageType=="2")
				{
					strSignatureMessageType="Critical";
				}

				strTmp += "<signatureMessageType>" + strSignatureMessageType + "</signatureMessageType>";
				strTmp += "<signatureType>" + objBerettaResult.signatureType + "</signatureType>";
				strTmp += "<result>" + objBerettaResult.isMatch.ToString() + "</result>";			
				strTmp += "<fieldName>" + objBerettaResult.fieldName.ToString() + "</fieldName>";
				strTmp += "<logFormSubmission>" + objBerettaResult.formSubmission.ToString() + "</logFormSubmission>";
				strTmp += "</item>";

				
				objBerettaResult=null;
				intX++;

			}

			return strTmp;

			
		}



		public string buildSubmission(System.Collections.Hashtable objSubmission)
		{
			string strTmp="";
			int intX=0;

			
			foreach (System.Collections.DictionaryEntry objEntry in objSubmission)
			{
		
				berettaSubmission objSubmissionLine;
			
				objSubmissionLine=(berettaSubmission) objEntry.Value;

				strTmp += "<item>";
				strTmp += "<submissionUrl>" + objSubmissionLine.url.ToString() + "</submissionUrl>";
				strTmp += "<submissionData><![CDATA[" + objSubmissionLine.formSubmission.ToString() + "]]></submissionData>";
				strTmp += "</item>";

				objSubmission=null;
				intX++;

			}

			return strTmp;

			
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			lstUrls.Items.Add(txtBaseUrl.Text);
		}
	}
}
