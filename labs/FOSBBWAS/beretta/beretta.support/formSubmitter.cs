using System;
using System.Web;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using beretta.Support;

namespace beretta.Objects
{
	/// <summary>
	/// Summary description for formSubmitter.
	/// </summary>
	public class formSubmitter
	{
	
	
		private string mRawResponse;
		private string mServer;
		private string mProtocolVersion;
		private System.Net.WebHeaderCollection mObjWebHeaderCollection;
		private CookieContainer sessionCookieContainer = new CookieContainer();
		private string strRawPage="";

		public formSubmitter()
		{
			
		}

		public string rawResponse
		{
			get
			{
				return mRawResponse;
			}
			set
			{
				mRawResponse=value;
				

			}
		}

		public string server
		{
			get
			{
				return mServer;
			}
			set
			{
				mServer=value;
				

			}
		}

		public string protocolVersion
		{
			get
			{
				return mProtocolVersion;
			}
			set
			{
				mProtocolVersion=value;
				

			}
		}

		public  System.Net.WebHeaderCollection objWebHeaderCollection
		{
			get
			{
				return mObjWebHeaderCollection;
			}
			set
			{
				mObjWebHeaderCollection=value;
				

			}
		}


		/// <summary>
		/// Gets a page without submitting any form data. Used for url querystring payloads
		/// </summary>
		/// <param name="strUrl">URL to get</param>
		/// <param name="bolAllowAutoRedirect">All auto transfer of pages</param>
		/// <returns>Page HTML</returns>
		public string getPage(string strUrl, bool bolAllowAutoRedirect, string strUserAgent)
		{
			string strTmp="";

			try
			{
				HttpWebRequest objRequest;
				HttpWebResponse objResponse;
			
				objRequest = (HttpWebRequest) WebRequest.Create(strUrl);
				objRequest.CookieContainer=sessionCookieContainer;  
				objRequest.AllowAutoRedirect=bolAllowAutoRedirect;
				objRequest.UserAgent=strUserAgent;

			
				//Get form response
				objResponse = (System.Net.HttpWebResponse) objRequest.GetResponse();
				Stream receiveStream=objResponse.GetResponseStream();
				StreamReader readStream = new StreamReader(receiveStream, Encoding.ASCII);
			
				strTmp= readStream.ReadToEnd();	
			
				mServer="" + objResponse.Server;
				mProtocolVersion="" + objResponse.ProtocolVersion.Major + "." + objResponse.ProtocolVersion.Minor;

			
				objWebHeaderCollection=objResponse.Headers;

				

				return strTmp;
			}
			catch(System.Net.WebException ex)
			{
				
				//Get full error page
				HttpWebResponse objResponse2;
				StreamReader srResponse2;

				objResponse2 = (System.Net.HttpWebResponse) ex.Response;

				srResponse2 = new StreamReader( objResponse2.GetResponseStream(), Encoding.ASCII );
			
			
				strTmp= srResponse2.ReadToEnd();	
				srResponse2.Close();

				return strTmp;
			}
		}

	

		/// <summary>
		/// Sends an HTML form submission to a URL
		/// </summary>
		/// <param name="strMessage"></param>
		/// <returns></returns>
		public string submitData(string strMessage, string strUrl, bool bolAllowAutoRedirect, string strMode, string strUserAgent)
		{
			string strViewState="";
			string strTmp="";

			try
			{
				
				System.Net.WebClient objWebClient=new System.Net.WebClient();
				Byte[] byteResult = objWebClient.DownloadData(strUrl);

				strRawPage= System.Text.Encoding.ASCII.GetString(byteResult);

		
				strViewState=getViewStateForPage(strUrl);
				strUrl=getUrlForPage(strUrl);

				HttpWebRequest objRequest;

				Byte[] arrRequest;
				UTF8Encoding objUTF8Encoding = new UTF8Encoding();
				Stream strmRequest;
				HttpWebResponse objResponse;
				StreamReader srResponse;

				

				//If GET post append to url
				if(strMode=="GET")
				{
					if(strUrl.IndexOf("?") != -1)
					{
						strUrl=strUrl + "?" + strMessage;
					}

				}
			
				objRequest = (HttpWebRequest) WebRequest.Create(strUrl);
				objRequest.CookieContainer=sessionCookieContainer;  
			

				objRequest.UserAgent=strUserAgent;
			
				objRequest.ContentType = "application/x-www-form-urlencoded";
				objRequest.AllowAutoRedirect=bolAllowAutoRedirect;
		
				objUTF8Encoding = new UTF8Encoding();
				
				if (strMessage.IndexOf("__VIEWSTATE")==-1 && strViewState != "")
				{
					strMessage= strViewState + "&" + strMessage;
				}
			

				if(strMode=="POST")
				{

					objRequest.Method = "POST";

					arrRequest = objUTF8Encoding.GetBytes(strMessage);    
								  
					objRequest.ContentLength = arrRequest.Length;
					strmRequest = objRequest.GetRequestStream();
					
					//Write form submission
					strmRequest.Write( arrRequest, 0, arrRequest.Length );
					strmRequest.Close();
				}
				else if(strMode=="GET")
				{
					objRequest.Method = "GET";
				}
			  
				//Get form response
				objResponse = (System.Net.HttpWebResponse) objRequest.GetResponse();
			
				srResponse = new StreamReader( objResponse.GetResponseStream(), Encoding.ASCII );
			
			
				strTmp= srResponse.ReadToEnd();	
				srResponse.Close();

				return strTmp;

			}
			catch(System.Net.WebException ex)
			{

				//Get full error page
				HttpWebResponse objResponse2;
				StreamReader srResponse2;

				objResponse2 = (System.Net.HttpWebResponse) ex.Response;

				srResponse2 = new StreamReader( objResponse2.GetResponseStream(), Encoding.ASCII );
			
			
				strTmp= srResponse2.ReadToEnd();	
				srResponse2.Close();

				return strTmp;
			}

		}

		

		public void login(string strMessage, string strUrl)
		{

			string strViewState="";
			string strTmp="";

			//Get view state if not set already
			if (strMessage.IndexOf("__VIEWSTATE")==-1)
			{
				strViewState=getViewStateForPage(strUrl);
				strMessage=strMessage.Replace("%%VIEWSTATE", strViewState);
			}

			CookieContainer CookieContainer = new CookieContainer();

			HttpWebRequest objRequest;
		
			Byte[] arrRequest;
			UTF8Encoding objUTF8Encoding = new UTF8Encoding();
			Stream strmRequest;
			HttpWebResponse objResponse;
			StreamReader srResponse;

			  
			objRequest = (HttpWebRequest) WebRequest.Create(strUrl);
			objRequest.Method = "POST";
			objRequest.ContentType = "application/x-www-form-urlencoded";
			objRequest.AllowAutoRedirect=true;
			objRequest.CookieContainer = CookieContainer;
			
			objUTF8Encoding = new UTF8Encoding();
			
			arrRequest = objUTF8Encoding.GetBytes(strMessage);    

			  
			objRequest.ContentLength = arrRequest.Length;
			strmRequest = objRequest.GetRequestStream();

			//Write form submission
			strmRequest.Write( arrRequest, 0, arrRequest.Length );
			strmRequest.Close();

			  
			//Get form response
			objResponse = (System.Net.HttpWebResponse) objRequest.GetResponse();
			
			foreach(Cookie retCookie in objResponse.Cookies)
			{
				sessionCookieContainer.Add(retCookie);
			}
		
			srResponse = new StreamReader( objResponse.GetResponseStream(), Encoding.ASCII );	
			
			
			strTmp= srResponse.ReadToEnd();	
			srResponse.Close();

		

		}



		private string getUrlForPage(string strUrl)
		{
			try
			{
				string strTmpUrl="";
				string strRegularExpression=devCafe.framework.keyDataAccess.get("formUrlRegexKey");
				string strActionRegularExpression=devCafe.framework.keyDataAccess.get("formActionRegexKey");

				
				RegexOptions options=RegexOptions.IgnoreCase; 		
				Regex regex = new Regex(strRegularExpression, options);
				MatchCollection  matches = regex.Matches(strRawPage);  

				
			
				    
				if (matches.Count > 0)
				{                  
					System.Collections.IEnumerator inum;                                                                        
					inum = matches.GetEnumerator();                                                                                                                                                             
				
					while (inum.MoveNext())
					{    
						strTmpUrl=inum.Current.ToString();

						RegexOptions options2=RegexOptions.IgnoreCase; 		
						Regex regex2 = new Regex(strActionRegularExpression, options2);
						MatchCollection  matches2 = regex2.Matches(strTmpUrl);  
				

						if (matches2.Count > 0)
						{                  
							System.Collections.IEnumerator inum2;                                                                        
							inum2 = matches2.GetEnumerator();                                                                                                                                                             
				
							while (inum2.MoveNext())
							{    
								strTmpUrl=inum2.Current.ToString();

								strTmpUrl=strTmpUrl.Replace("'", "");
								strTmpUrl=strTmpUrl.Replace("\"", "");
								strTmpUrl=strTmpUrl.Replace("action=", "");
								strTmpUrl=strTmpUrl.Replace("Action=", "");

								//Is this a relative link?

								if (strTmpUrl.IndexOf("http://")>0)
								{
									return strTmpUrl;
								}
								else
								{
									int intLast=0;
									string strTmp="";
									
									strTmp=strUrl.Substring(0, strUrl.LastIndexOf("/"));
									
									strTmpUrl=strTmp + "/" + strTmpUrl;

									return strTmpUrl;
									
								}

							}
								

							
						}
						
					}
						
					
				}

				}
			
			catch
			{

			}
			

				return strUrl;
		}


		/// <summary>
		/// Retrieves View State Field
		/// </summary>

		private string getViewStateForPage(string strUrl)
		{
			try
			{
				string strViewState="";
				string strRawPage="";
				string strRegularExpression=devCafe.framework.keyDataAccess.get("viewStateRegexKey");

				RegexOptions options=RegexOptions.IgnoreCase; 		
				Regex regex = new Regex(strRegularExpression, options);
				MatchCollection  matches = regex.Matches(strRawPage);  
				
				    
				if (matches.Count > 0)
				{                  
					System.Collections.IEnumerator inum;                                                                        
					inum = matches.GetEnumerator();                                                                                                                                                             
				
					while (inum.MoveNext())
					{    
						strViewState=inum.Current.ToString();
   
						strViewState=strViewState.Replace("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"", "");

						strViewState=strViewState.Replace("+", "%2b");
						strViewState=strViewState.Replace("=", "%3d");
						strViewState=strViewState.Replace("/", "%2f");
						strViewState="__VIEWSTATE=" + strViewState;
					}

				}

				
			

				return strViewState;
			}
			catch
			{
				//Probably no View State
				return "";
			}


			
		}


	}
}




