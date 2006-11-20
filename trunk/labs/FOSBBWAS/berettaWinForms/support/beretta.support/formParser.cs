using System;
using System.Text.RegularExpressions;

namespace beretta.support
{
	/// <summary>
	/// Summary description for formParser.
	/// </summary>
	public class formParser
	{

		
		private static string strInputRegex="<input[a-zA-Z0-9=\"':;\\+_?\\-/\\s]+>";
		private static string strNameRegex="name=[a-zA-Z0-9\"'_:=]+";
		private static string strTypeRegex="type=[a-zA-Z0-9\"'_:=]+";
		private static string strValueRegex="value=[a-zA-Z0-9%/=\\+\"'_:=]+";
		private static string strDropDownRegex="<select[a-zA-Z0-9=\"':;\\+_?\\-/\\s]+>";
		

		

		public formParser()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static System.Collections.Hashtable getInputElements(string strInput)
		{	
			string strTmpFormElement="";
			
			string strTmpName="";
			string strTmpValue="";
			string strTmpType="";
			
			System.Collections.Hashtable objHashTable=new System.Collections.Hashtable();

			Regex objRegex = new Regex(strInputRegex, RegexOptions.IgnoreCase);
			MatchCollection matches = objRegex.Matches(strInput);

			if (matches.Count > 0)
			{
				System.Collections.IEnumerator inum;                                                                        
				inum = matches.GetEnumerator();                                                                                                                                                             
				
				while (inum.MoveNext())
				{    
					strTmpFormElement=inum.Current.ToString();

					strTmpName="" + getItem(strTmpFormElement, strNameRegex);
					strTmpValue="" + getItem(strTmpFormElement, strValueRegex);
					strTmpType="" + getItem(strTmpFormElement, strTypeRegex);

					formElement objFormElement=new formElement();
				
					if (strTmpName.IndexOf("=")>0)
					{
						strTmpName=strTmpName.Substring(strTmpName.IndexOf("=")+1);
					}

					if (strTmpValue.IndexOf("=")>0 && strTmpName !="__VIEWSTATE")
					{
						strTmpValue=strTmpValue.Substring(strTmpValue.IndexOf("=")+1);
					}
					
					if (strTmpType.IndexOf("=")>0)
					{
						strTmpType=strTmpType.Substring(strTmpType.IndexOf("=")+1);
					}
				

					objFormElement.name=strTmpName;
					objFormElement.value=strTmpValue;
					objFormElement.type=strTmpType;

				
					objHashTable.Add(System.Guid.NewGuid(), objFormElement);	
		
					objFormElement=null;
				}				

				
			}


			//Get drop down lists
			Regex objRegex2 = new Regex(strDropDownRegex, RegexOptions.IgnoreCase);
			MatchCollection matches2 = objRegex2.Matches(strInput);
		
			if (matches2.Count > 0)
			{
				System.Collections.IEnumerator inum;                                                                        
				inum = matches2.GetEnumerator();                                                                                                                                                             
				
				while (inum.MoveNext())
				{    
					strTmpFormElement=inum.Current.ToString();

					strTmpName="" + getItem(strTmpFormElement, strNameRegex);
					strTmpValue="" + getItem(strTmpFormElement, strValueRegex);
					strTmpType="" + getItem(strTmpFormElement, strTypeRegex);

					formElement objFormElement=new formElement();
				
					if (strTmpName.IndexOf("=")>0)
					{
						strTmpName=strTmpName.Substring(strTmpName.IndexOf("=")+1);
					}

					if (strTmpValue.IndexOf("=")>0)
					{
						strTmpValue=strTmpValue.Substring(strTmpValue.IndexOf("=")+1);
					}
					
					if (strTmpType.IndexOf("=")>0)
					{
						strTmpType=strTmpType.Substring(strTmpType.IndexOf("=")+1);
					}
				
					objFormElement.name=strTmpName;
					objFormElement.value=strTmpValue;
					objFormElement.type="select";

				
					objHashTable.Add(System.Guid.NewGuid(), objFormElement);	
		
					objFormElement=null;
				}				

				
			}
			
			return objHashTable;

		}


		public static string getItem(string strInput, string strRegex)
		{
			string strTmp="";
		
			Regex objRegex = new Regex(strRegex, RegexOptions.IgnoreCase);
			MatchCollection matches = objRegex.Matches(strInput);

			if (matches.Count > 0)
			{
				System.Collections.IEnumerator inum;                                                                        
				inum = matches.GetEnumerator();                                                                                                                                                             
				
				while (inum.MoveNext())
				{    
					strTmp=inum.Current.ToString();
				}

				strTmp=strTmp.Replace("\"", "");
				strTmp=strTmp.Replace("'","");
				strTmp=strTmp.Replace("name=", "");
				strTmp=strTmp.Replace("value=", "");
				strTmp=strTmp.Replace("type=", "");
				strTmp=strTmp.Replace("name= ", "");
				strTmp=strTmp.Replace("value= ", "");
				strTmp=strTmp.Replace("type= ", "");

			}
			else
			{
				strTmp="";
			}

			return strTmp;

		}


		
	}
}
