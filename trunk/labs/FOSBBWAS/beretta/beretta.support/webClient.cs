using System;
using System.Net;
using System.IO;
using System.Text;

namespace beretta.Objects
{
	/// <summary>
	/// Simple Class for downloading web pages
	/// </summary>
	public class webClient
	{
		public webClient()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Gets a web page from a url
		/// </summary>
		/// <param name="strUrl">URL of page to retrieve</param>
		/// <returns>String Page HTML</returns>
		public static string getPage(string strUrl)
		{
			string strTmp="";
				
			try
			{
				System.Net.WebClient objWebClient=new System.Net.WebClient();
				System.IO.Stream MyStream = objWebClient.OpenRead(strUrl);
				System.IO.StreamReader srResponse= new System.IO.StreamReader(MyStream);
				strTmp="" + srResponse.ReadToEnd();	

				
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

	}
}
