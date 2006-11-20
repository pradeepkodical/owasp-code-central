using System;
using System.Text;

namespace beretta.support
{
	/// <summary>
	/// Summary description for encoding.
	/// </summary>
	public class encoding
	{
		public encoding()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Replaces spaces with +
		/// </summary>
		/// <param name="strInput"></param>
		/// <returns></returns>
		public static string encodeForm(string strInput)
		{
			strInput=strInput.Replace(" ", "+");


			return strInput;

		}

		/// <summary>
		/// Replaces +, = and / to form submission values
		/// </summary>
		/// <param name="strInput"></param>
		/// <returns></returns>
		public static string encodeFormElements(string strInput)
		{
			strInput=strInput.Replace("+", "%2b");
			strInput=strInput.Replace("=", "%3d");
			strInput=strInput.Replace("/", "%2f");



			return strInput;

		}

		public static string convertDecimalToAscii(string strInput)
		{

			string[] strTmp;
			string strTmpResult="";
			
			strInput=strInput.Replace("&#", ",");


			strTmp=strInput.Split(',');

			foreach(string strChar in strTmp)
			{
				if (strChar != "")
				{

					strTmpResult=strTmpResult + convertToChar(System.Convert.ToInt32(strChar));
				}


			}

			return strTmpResult;

		}


		public static string convertToDecimal(string strInput) 
		{ 
			string result = ""; 
			string strTmp="";

			for (int i=0; i<strInput.Length; i++) 
			{
				strTmp=asc(strInput.Substring(i)).ToString();
				result += "&#" + strTmp; 
			}

			return result; 
		} 

		public static int asc(string ch)
		{
			return (int)Encoding.ASCII.GetBytes(ch)[0];

		}
		public static string convertToChar (int i)
		{
			//Return the character of the given character value
			return Convert.ToChar(i).ToString();
		}

		public static string toBase64(string strInput)
		{
			
			UnicodeEncoding ue = new UnicodeEncoding();
			byte[] b = ue.GetBytes(strInput);

			return System.Convert.ToBase64String(b, 0, b.Length);

		}

		public static string toHex(string strInput)
		{
			char[] charArray = strInput.ToCharArray();
			int intAsciiChar;
			StringBuilder objStrBuilder = new StringBuilder();
			
			foreach(char charC in charArray)
			{
				intAsciiChar = Convert.ToInt32(charC);
				objStrBuilder.Append("%" +string.Format("{0:X}", intAsciiChar ));
							
			}
			
			return objStrBuilder.ToString();
		}

		public static string toHexHtml(string strInput)
		{
			char[] charArray = strInput.ToCharArray();
			int intAsciiChar;
			StringBuilder objStrBuilder = new StringBuilder();
			
			foreach(char charC in charArray)
			{
				intAsciiChar = Convert.ToInt32(charC);
				objStrBuilder.Append("&#x" +string.Format("{0:X}", intAsciiChar ));
							
			}
			
			return objStrBuilder.ToString();
		}




	}
}
