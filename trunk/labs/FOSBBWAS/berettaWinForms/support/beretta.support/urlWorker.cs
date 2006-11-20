using System;
using System.Data;
using beretta.Objects;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace beretta.Objects
{
	/// <summary>
	/// Summary description for urlWorker.
	/// </summary>
	public class urlWorker
	{
		private string mUrl="";
		private int mUrlId=0;

		private int mAuthenticationType=0;
		private int mSessionId=0;
		
		private formSubmitter objFormSubmitter=new formSubmitter();
	
		private string mUserAgent="";

		private Hashtable mObjBerettaResultHashTable=new Hashtable();
		private Hashtable mObjBerettaSubmissionHashTable=new Hashtable();

		private DataSet mObjPayloadDataSet;
		private DataSet mObjSignaturesDataSet;


		public DataSet payloadDataSet
		{
			get{return mObjPayloadDataSet;}
			set{mObjPayloadDataSet=value;}
		}

		public DataSet signaturesDataSet
		{
			get{return mObjSignaturesDataSet;}
			set{mObjSignaturesDataSet=value;}
		}
			
		public string url
		{
			get{return mUrl;}
			set{mUrl=value;}
		}

		

		
		public int authenticationType
		{
			get{return mAuthenticationType;}
			set{mAuthenticationType=value;}
		}

		public int sessionId
		{
			get{return mSessionId;}
			set{mSessionId=value;}
		}

		public Hashtable objBerettaResultHashTable
		{
			get{return mObjBerettaResultHashTable;}
			set{mObjBerettaResultHashTable=value;}
		}


		public Hashtable objBerettaSubmissionHashTable
		{
			get{return mObjBerettaSubmissionHashTable;}
			set{mObjBerettaSubmissionHashTable=value;}
		}


		

		public string userAgent
		{
			get{return mUserAgent;}
			set{mUserAgent=value;}
		}


		public urlWorker()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void authenticate()
		{

			#region Authenticate To Application
			//Log on to application if required
			

			#endregion

		}

		public void scanManual()
		{
			string strReturn="";
			int intX=0;

			//Get Payloads and Signatures for URL

			//Dont get form element payloads
			
			foreach(DataRow objDataRow in mObjPayloadDataSet.Tables[0].Rows)
			{	
				berettaSubmission objSubmission=new berettaSubmission();
				objSubmission.url="" + mUrl;
				objSubmission.formSubmission="" + objDataRow["payloadData"].ToString();

				mObjBerettaSubmissionHashTable.Add(System.Guid.NewGuid().ToString(), objSubmission);

				objSubmission=null;

				strReturn=objFormSubmitter.submitData(objDataRow["payloadData"].ToString(), mUrl, false, "POST", mUserAgent);
				
				//Check if result matches any signatures
				foreach(DataRow objSignatureRow in mObjSignaturesDataSet.Tables[0].Rows)
				{
					berettaResult objResult=new berettaResult();
				
					//Check if matches signature
					objResult=isMatch(strReturn, objSignatureRow, System.Convert.ToInt32(objDataRow["id"]), objDataRow["payloadName"].ToString(), "MANUAL", objDataRow["payloadData"].ToString());

					if (objResult.isMatch==true)
					{
						mObjBerettaResultHashTable.Add(intX, objResult);
						intX++;
					}
				
					objResult=null;
				}
						
			}

		}

		public void scanAuto()
		{
			string strReturn="";
			string strPayloadData="";
			string strFieldName="";
			string strCurrentUrlFormValues="";
			string strHtml="";
			int intX=0;
			int intReplacerPos=0;
			int intFieldPos=0;
			string strTmpUrl="";
			int intQueryStringPos=0;

			beretta.Objects.response objResponse= new beretta.Objects.response();

			
			//Get form elements for page
			strHtml=objFormSubmitter.getPage(mUrl, true, mUserAgent);
			
			if(strHtml=="") return;

			objResponse.input=strHtml;
			objResponse.analyze();
			
			
			//For each Payload
			foreach(DataRow objDataRow in mObjPayloadDataSet.Tables[0].Rows)
			{	
				intReplacerPos=0;
				strPayloadData="" + objDataRow["payloadData"].ToString();
			
				//For Each submit button
				foreach(string strUrlFormValues in objResponse.formSubmission)
				{
	
					//Have we reached end of submit buttons?
					if (strUrlFormValues==null || strUrlFormValues=="")
					{
						break;
					}


					//Form submission payload or url?
					if (objDataRow["type"].ToString()=="1" || objDataRow["type"].ToString()=="0")
					{
						strPayloadData="" + beretta.support.encoding.encodeFormElements(strPayloadData);

																		
						//Find placeholder and replace with payload
						intReplacerPos=strUrlFormValues.IndexOf("%%r%%", intReplacerPos);
			
						//Insert payload in each form field
						while(intReplacerPos != -1)
						{
							strCurrentUrlFormValues=strUrlFormValues;

							//Get name of field we are working on
							strFieldName=strUrlFormValues.Substring(0, intReplacerPos);
						
							intFieldPos=strFieldName.LastIndexOf("&");

							if(intFieldPos!=-1)
							{
								strFieldName=strFieldName.Substring(intFieldPos); 
							}
							else
							{
							
							}
						
							strFieldName=strFieldName.Replace("&", "");
							strFieldName=strFieldName.Replace("=", "");
						
					

							strCurrentUrlFormValues=strUrlFormValues.Remove(intReplacerPos, 5);
							strCurrentUrlFormValues=strCurrentUrlFormValues.Insert(intReplacerPos, strPayloadData);
							strCurrentUrlFormValues=strCurrentUrlFormValues.Replace("%%r%%", "");
			
							strCurrentUrlFormValues=beretta.support.encoding.encodeForm(strCurrentUrlFormValues);


							berettaSubmission objSubmission=new berettaSubmission();
							objSubmission.url="" + mUrl;
							objSubmission.formSubmission="" + strCurrentUrlFormValues;

							mObjBerettaSubmissionHashTable.Add(System.Guid.NewGuid().ToString(), objSubmission);

							objSubmission=null;


							strReturn=objFormSubmitter.submitData(strCurrentUrlFormValues, mUrl, true, "POST", mUserAgent);
				
							//Check if result matches any signatures
							foreach(DataRow objSignatureRow in mObjSignaturesDataSet.Tables[0].Rows)
							{
								berettaResult objResult=new berettaResult();
				
							
								//Check if matches signature
								objResult=isMatch(strReturn, objSignatureRow, System.Convert.ToInt32(objDataRow["id"]), objDataRow["payloadName"].ToString(), strFieldName, strCurrentUrlFormValues);

								if (objResult.isMatch==true)
								{
									mObjBerettaResultHashTable.Add(intX, objResult);
									intX++;
								}
				
								objResult=null;
							}

							intReplacerPos=strUrlFormValues.IndexOf("%%r%%", intReplacerPos + 1);
			
						}
					
					}
					else
					{

						//Query String Replace		

						strTmpUrl=mUrl;

						//4= query string replace auto
						if (objDataRow["type"].ToString()=="4")
						{
							intQueryStringPos= strTmpUrl.IndexOf("?");

							if (intQueryStringPos>0)
							{
								strTmpUrl=strTmpUrl.Substring(0, intQueryStringPos);
								strTmpUrl=strTmpUrl + "?" + strPayloadData;
							}
							else
							{
								strTmpUrl=strTmpUrl + "?" + strPayloadData;
							}

						}

						//5= query string append auto
						if (objDataRow["type"].ToString()=="5")
						{
							intQueryStringPos= strTmpUrl.IndexOf("?");

							if (intQueryStringPos>0)
							{
								strTmpUrl=strTmpUrl + "&" + strPayloadData;
							}
							else
							{
								strTmpUrl=strTmpUrl + "?" + strPayloadData;
							}

						}

						berettaSubmission objSubmission=new berettaSubmission();
						objSubmission.url="" + strTmpUrl;
						objSubmission.formSubmission="" + strCurrentUrlFormValues;

						mObjBerettaSubmissionHashTable.Add(System.Guid.NewGuid().ToString(), objSubmission);

						objSubmission=null;

						strReturn=objFormSubmitter.submitData(strCurrentUrlFormValues, strTmpUrl, true, "POST", mUserAgent);
				
						//Check if result matches any signatures
						foreach(DataRow objSignatureRow in mObjSignaturesDataSet.Tables[0].Rows)
						{
							berettaResult objResult=new berettaResult();
				
							
							//Check if matches signature
							objResult=isMatch(strReturn, objSignatureRow, System.Convert.ToInt32(objDataRow["id"]), objDataRow["payloadName"].ToString(), strTmpUrl, strCurrentUrlFormValues);

							if (objResult.isMatch==true)
							{
								mObjBerettaResultHashTable.Add(intX, objResult);
								intX++;
							}
				
							objResult=null;
						}
						
					}


				}
						
			}

		}

		private berettaResult isMatch(string strInput, DataRow objSignatureRow, int intPayloadId, string strPayloadName, string strFieldName, string strFormSubmission)
		{
			
			berettaResult objResult=new berettaResult();


					
					//Signature type 0 check for occurence of string
					if (objSignatureRow["signatureType"].ToString()=="0")
					{
						//Equal to
						if (objSignatureRow["signatureOperator"].ToString()=="=")
						{
							string strTest=objSignatureRow["signatureValue"].ToString();
						
							int intTmp=strInput.IndexOf(objSignatureRow["signatureValue"].ToString());


							if (strInput.IndexOf(objSignatureRow["signatureValue"].ToString())==-1 && strInput != objSignatureRow["signatureValue"].ToString())
							{
								objResult.isMatch=false;
								return objResult;
							}
							else
							{
								objResult.isMatch=true;
								objResult.payloadId=intPayloadId;
								objResult.payloadName=strPayloadName;
								objResult.payloadPriortiy="";
								objResult.signatureId=System.Convert.ToInt32(objSignatureRow["id"]);
								objResult.signatureName=objSignatureRow["signatureName"].ToString();
								objResult.signatureType=objSignatureRow["signatureType"].ToString();
								objResult.signatureMessage=objSignatureRow["signatureMessage"].ToString();
								objResult.signatureMessageType=objSignatureRow["signatureMessageType"].ToString();
								objResult.fieldName="<![CDATA[" + strFieldName + "]]>";
								objResult.formSubmission="<![CDATA[" + strFormSubmission + "]]>";
							
								objResult.url=mUrl;

								return objResult;
							}
						}

						//Not equal to
						if (objSignatureRow["signatureOperator"].ToString()=="!=")
						{
							if (strInput.IndexOf(objSignatureRow["signatureValue"].ToString())==-1 && strInput != objSignatureRow["signatureValue"].ToString())
							{
								objResult.isMatch=true;
								objResult.payloadId=intPayloadId;
								objResult.payloadName=strPayloadName;
								objResult.payloadPriortiy="";
								objResult.signatureId=System.Convert.ToInt32(objSignatureRow["id"]);
								objResult.signatureName=objSignatureRow["signatureName"].ToString();
								objResult.signatureType=objSignatureRow["signatureType"].ToString();
								objResult.signatureMessage=objSignatureRow["signatureMessage"].ToString();
								objResult.signatureMessageType=objSignatureRow["signatureMessageType"].ToString();
								objResult.fieldName="<![CDATA[" + strFieldName + "]]>";
								objResult.formSubmission="<![CDATA[" + strFormSubmission + "]]>";
								objResult.url=mUrl;

								return objResult;
							}
							else
							{
								objResult.isMatch=false;
								return objResult;

								
							}
						}

						
			
					}

					//Signature type 1 user regular expression
					else if (objSignatureRow["signatureType"].ToString()=="1")
					{

						Regex objRegex = new Regex(objSignatureRow["signatureValue"].ToString(), RegexOptions.IgnoreCase);
						MatchCollection matches = objRegex.Matches(strInput);

						//Equal to
						if (objSignatureRow["signatureOperator"].ToString()=="=")
						{
							if (matches.Count > 0)
							{
								objResult.isMatch=true;
								objResult.payloadId=intPayloadId;
								objResult.payloadName=strPayloadName;
								objResult.payloadPriortiy="";
								objResult.signatureId=System.Convert.ToInt32(objSignatureRow["id"]);
								objResult.signatureName=objSignatureRow["signatureName"].ToString();
								objResult.signatureType=objSignatureRow["signatureType"].ToString();
								objResult.signatureMessage=objSignatureRow["signatureMessage"].ToString();
								objResult.signatureMessageType=objSignatureRow["signatureMessageType"].ToString();
								objResult.formSubmission="<![CDATA[" + strFormSubmission + "]]>";
								objResult.url=mUrl;

								return objResult;
							}
							else
							{
								objResult.isMatch=false;
								return objResult;
							}
						}
						
						//Not Equal to
						if (objSignatureRow["signatureOperator"].ToString()=="!=")
						{
							if (matches.Count > 0)
							{
								objResult.isMatch=false;
								return objResult;
							}
							else
							{
								objResult.isMatch=true;
								objResult.payloadId=intPayloadId;
								objResult.payloadName=strPayloadName;
								objResult.payloadPriortiy="";
								objResult.signatureId=System.Convert.ToInt32(objSignatureRow["id"]);
								objResult.signatureName=objSignatureRow["signatureName"].ToString();
								objResult.signatureType=objSignatureRow["signatureType"].ToString();
								objResult.signatureMessage=objSignatureRow["signatureMessage"].ToString();
								objResult.signatureMessageType=objSignatureRow["signatureMessageType"].ToString();
								objResult.formSubmission="<![CDATA[" + strFormSubmission + "]]>";
								objResult.url=mUrl;

								return objResult;
							}
						}
						
					}

					
				

			objResult.isMatch=false;
			return objResult;
			
		}

		
	}
}
