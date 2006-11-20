using System;
using System.Data;
using beretta.Objects;
using System.IO;

namespace beretta.objects
{
	/// <summary>
	/// Summary description for beretta.
	/// </summary>
	public class beretta
	{
		private int mSessionId;
		private string strGuid;
		private session objSession=new session();
		private sessionDataAccess objSessionDataAccess=new sessionDataAccess();
		private payloadDataAccess objPayloadDataAccess=new payloadDataAccess();
		private signaturesDataAccess objSignatureDataAccess=new signaturesDataAccess();
		private formSubmitter objFormSubmitter=new formSubmitter();
		private urlsDataAccess objUrlsDataAccess=new urlsDataAccess();
		
		private DataSet objPayloadDataSet=new DataSet();
		private DataSet objSignaturesDataSet=new DataSet();
		private DataSet objUrlsDataSet=new DataSet();
		protected response objRespone=new response();
		private System.Text.StringBuilder objStringBuilder=new System.Text.StringBuilder();
		private string strUrls="";

		public beretta()
		{
			//
			// TODO: Add constructor logic here
			//
		}



		public string initiate(int intSessionId)
		{
			
			string strTotalDoc="";
			string strHeader="";
			string strUserAgent="";
			System.Text.StringBuilder objFormSubmissionStr=new System.Text.StringBuilder();

			strGuid="" + System.Guid.NewGuid().ToString();

			mSessionId=intSessionId;
			objSession.id=mSessionId;
			objSession.populate();

			
			devCafe.framework.frameworkListItems objFrameWorkListItem=new devCafe.framework.frameworkListItems();
			objFrameWorkListItem.id=objSession.userAgent;
			objFrameWorkListItem.populate();

			strUserAgent=objFrameWorkListItem.listItemName;




			#region Construct Report Header

			strHeader += "<header>";
			strHeader += "<application>beretta</application>";
			strHeader += "<version>1.0</version>";
			strHeader += "<sessionId>" + objSession.id.ToString() + "</sessionId>";
			strHeader += "<date>" + System.DateTime.Now + "</date>";


			if (objSession.authenticationType==0) strHeader += "<authenticationType>None</authenticationType>";
			else if (objSession.authenticationType==1) strHeader += "<authenticationType>Forms</authenticationType>";
			else if (objSession.authenticationType==2) strHeader += "<authenticationType>Raw</authenticationType>";
			strHeader += "<sessionName>" + objSession.sessionName + "</sessionName>";
			strHeader += "<sessionDescription>" + objSession.sessionDescription + "</sessionDescription>";
			strHeader += "</header>";

			#endregion

			
			objUrlsDataSet=urlsDataAccess.getAllForSession(objSession.id);


			//For each URL in session
			foreach(DataRow objUrlRow in objUrlsDataSet.Tables[0].Rows)
			{
				//Manual Scan
				urlWorker objUrlWorker=new urlWorker();

				objUrlWorker.sessionId=objSession.id;
				objUrlWorker.authenticationType=objSession.authenticationType;
				objUrlWorker.urlId=System.Convert.ToInt32(objUrlRow["id"]);
				objUrlWorker.userAgent=strUserAgent;
				objUrlWorker.scanManual();

				strUrls=strUrls + "<url>" + objUrlWorker.url + "</url>";

				if (objUrlWorker.objBerettaResultHashTable != null && objUrlWorker.objBerettaResultHashTable.Count>0)
				{
					objStringBuilder.Append(buildResults(objUrlWorker.objBerettaResultHashTable));
				}


				objFormSubmissionStr.Append(buildSubmission(objUrlWorker.objBerettaSubmissionHashTable));

				objUrlWorker=null;

				//Auto Scan
				if (objSession.useAutoScan==1)
				{
					urlWorker objUrlWorkerAuto=new urlWorker();
					objUrlWorkerAuto.sessionId=objSession.id;
					objUrlWorkerAuto.authenticationType=objSession.authenticationType;
					objUrlWorkerAuto.urlId=System.Convert.ToInt32(objUrlRow["id"]);
					objUrlWorkerAuto.userAgent=strUserAgent;
					objUrlWorkerAuto.scanAuto();
				
				
					if (objUrlWorkerAuto.objBerettaResultHashTable != null && objUrlWorkerAuto.objBerettaResultHashTable.Count>0)
					{
						objStringBuilder.Append(buildResults(objUrlWorkerAuto.objBerettaResultHashTable));
					}

					objFormSubmissionStr.Append(buildSubmission(objUrlWorkerAuto.objBerettaSubmissionHashTable));

					objUrlWorkerAuto=null;
				}

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
			
			string strPath="" + System.Configuration.ConfigurationSettings.AppSettings.Get("outputDir") + strGuid + ".XML";

			StreamWriter objStreamWriter; 
					
			//Add XSL file ref
			string strXslFile="" + devCafe.framework.keyDataAccess.get("defaultScanXSL");
			strTotalDoc="<?xml-stylesheet href='../xsl/" + strXslFile + "' type='text/xsl'?>" + strTotalDoc;
				 
			objStreamWriter = System.IO.File.CreateText(strPath);
			objStreamWriter.WriteLine(strTotalDoc);
			objStreamWriter.Close();
			
			#endregion

				
			return "./" + strGuid + ".XML";

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



	}
}
