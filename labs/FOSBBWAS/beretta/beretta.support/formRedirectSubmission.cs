using System;
using System.Text;

namespace beretta.Objects
{
	/// <summary>
	/// Summary description for formRedirectSubmission.
	/// </summary>
	public class formRedirectSubmission
	{
		string strHtml="";
		int intStart=0;
		int intEnd=0;
		System.Net.WebClient objWebClient=new System.Net.WebClient();


		public formRedirectSubmission()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string getUrlAndRedirect(string strUrl, string strRedirectUrl, string strLinkRedirectUrl, string strApplicationBaseUrl)
		{

			
			try
			{
				byte[] myDataBuffer = objWebClient.DownloadData(strUrl);
				strHtml = Encoding.ASCII.GetString(myDataBuffer);

				strHtml=rewriteForm(strHtml, strRedirectUrl, strLinkRedirectUrl, strApplicationBaseUrl);
			
			}
			catch(System.Exception ex)
			{
				
				strHtml=ex.Message.ToString();
			}

			return strHtml;

		}

		public string rewriteForm(string strHtml, string strRedirectUrl, string strLinkRedirectUrl, string strApplicationBaseUrl)
		{

			string strTmp="";

			//We now need to rewrite the form submission paramater
			intStart=strHtml.IndexOf("<form", 0);

			if(intStart==-1)
			{
				intStart=strHtml.IndexOf("<Form", 0);

			}

			intEnd=strHtml.IndexOf(">", intStart) + 1;

			strHtml=(strHtml.Remove(intStart, intEnd - intStart));
			
			//Attempt to rewrite all URLS
			
			strTmp=rewriteUrls(strHtml, "a href=", strLinkRedirectUrl, strApplicationBaseUrl);

			if (strTmp.IndexOf("%%error") ==-1)
			{
				strHtml=strTmp;
			}

			strTmp=rewriteImagePaths(strHtml, "src=", strLinkRedirectUrl, strApplicationBaseUrl);

			if (strTmp.IndexOf("%%error") ==-1)
			{
				strHtml=strTmp;
			}
			  
			//remove all other form tags
			strHtml=strHtml.Replace("<Form", "<OldFrom");
			strHtml=strHtml.Replace("<form", "<OldForm");
			strHtml=strHtml.Replace("</form>", "");
			strHtml=strHtml.Replace("</Form>", "");

			strHtml= "<form name='Form2' method='post' id='form2' action='" + strRedirectUrl + "'>"+ strHtml;

			return strHtml;
		}


		public string rewriteImagePaths(string strHtml, string strHrefSearchTag, string strReplaceUrl, string strApplicationBaseUrl)
		{

			
			
			string strTmp="" + strHtml;
			string strTmp2="";
			string strOldUrl="";
		

			
			string strReplacement="";

			int intCurrentPos=0;
			int intStart=0;
			int intEnd=0;
			int intStart2=0;
			int intLength=0;
			int intStrLength=0;

			try
			{

				while(strTmp.IndexOf(strHrefSearchTag, intCurrentPos) != -1)
				{
					intStrLength=strTmp.Length;

					intStart=strTmp.IndexOf("src=", intCurrentPos);
					intEnd=strTmp.IndexOf("\"", intStart);

					//Gets 'href="a.html'
					intLength=intEnd - intStart + strHrefSearchTag.Length + 2;
					strTmp2=strTmp.Substring(intStart, intLength);

					intStart2=strTmp2.IndexOf("\"", 0);
					intStart2=intStart2 + 1;

					//Get URL
					strOldUrl=strTmp2.Substring(intStart2, strTmp2.Length - intStart2);
	 
				
					//Remove Old Url
					strTmp=strTmp.Remove(intStart, intLength);

					//Replace with new url
					
					//If the old URL is not a full url replace with application root
					if (strOldUrl.IndexOf("http://")==-1)
					{
						strOldUrl=strApplicationBaseUrl + strOldUrl;
			
					}

					strReplacement= "src=\"" + strOldUrl;
					strTmp=strTmp.Insert(intStart, strReplacement);
				
				
					intCurrentPos=intStart + strReplacement.Length + 1;

								
				   
				}

				return strTmp;

			}
			catch (System.Exception ex)
			{
				return "%%error " + ex.Message;
			}


		}

		public string rewriteUrls(string strHtml, string strHrefSearchTag, string strReplaceUrl, string strApplicationBaseUrl)
		{

			
			
			string strTmp="" + strHtml;
			string strTmp2="";
			string strOldUrl="";
		

			
			string strReplacement="";

			int intCurrentPos=0;
			int intStart=0;
			int intEnd=0;
			int intStart2=0;
			int intLength=0;
			int intStrLength=0;

			try
			{

				while(strTmp.IndexOf(strHrefSearchTag, intCurrentPos) != -1)
				{
					intStrLength=strTmp.Length;

					intStart=strTmp.IndexOf("a href=", intCurrentPos);
					intEnd=strTmp.IndexOf("\"", intStart);

					//Gets 'href="a.html'
					intLength=intEnd - intStart + strHrefSearchTag.Length + 2;
					strTmp2=strTmp.Substring(intStart, intLength);

					intStart2=strTmp2.IndexOf("\"", 0);
					intStart2=intStart2 + 1;

					//Get URL
					strOldUrl=strTmp2.Substring(intStart2, strTmp2.Length - intStart2);
	 
				
					//Remove Old Url
					strTmp=strTmp.Remove(intStart, intLength);

					//Replace with new url
					
					//If the old URL is not a full url replace with application root
					if (strOldUrl.IndexOf("http://")==-1)
					{
						strOldUrl=strApplicationBaseUrl + strOldUrl;
			
					}

					strReplacement= "a href=\"" + strReplaceUrl + System.Web.HttpUtility.UrlEncode(strOldUrl);
					strTmp=strTmp.Insert(intStart, strReplacement);
				
				
					intCurrentPos=intStart + strReplacement.Length + 1;

								
				   
				}

				return strTmp;

			}
			catch (System.Exception ex)
			{
				return "%%error " + ex.Message;
			}


		}


	}
}
