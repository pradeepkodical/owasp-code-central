#region Licence Information

// The General Tools For Asp.Net Applications
// Version 0.6
// Copyright (C) 2004 - 2005 Izzet Kerem Kusmezer
// Email: keremkusmezer@yazilimguvenligi.com
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

#endregion

#region Imported Libraries

using System.Collections;
using System.Collections.Specialized;
using System.IO;
	using System.Text;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using log4net;
	using Owasp.DefApp.Utility;
#endregion

namespace Owasp.DefApp.Convertors
{
	/// <summary>
	/// General Purpose Convertors
	/// </summary>
	public sealed class OutputConvertors
	{
		#region Private Methods

		private OutputConvertors()
		{
		}

		private static readonly ILog logger = LogManager.GetLogger(typeof (OutputConvertors));

		/// <summary>
		/// Renders The Given Control Into The String Output
		/// </summary>
		/// <param name="control">The WebControl To Be Converted</param>
		/// <returns>The Rendered Result Of The Given Control</returns>
		/// 
		private static string GetControl(WebControl control)
		{
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter);
			control.RenderControl(textWriter);
			textWriter.Flush();
			return textWriter.ToString();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Converts The Given ASP.Net Control Into Excel Response
		/// </summary>
		/// <param name="resp"></param>
		/// <param name="control"></param>
		public static void ConvertToExcel(HttpResponse resp, WebControl control)
		{
			resp.Clear();
			resp.Buffer = true;
			resp.ContentEncoding = Encoding.Default;
			resp.ContentType = "application/vnd.ms-excel";
			resp.Write(GetControl(control));
		}

		/// <summary>
		/// Creates A New Copy Of The Given Cookie
		/// </summary>
		/// <param name="cookieToDuplicate">The Cookie To Be Duplicated</param>
		/// <returns>Duplicated Cookie</returns>
		public static HttpCookie DuplicateCookie(HttpCookie cookieToDuplicate)
		{
			HttpCookie tempCookie = null;
			if (!cookieToDuplicate.HasKeys)
			{
				tempCookie = 
			      new HttpCookie(cookieToDuplicate.Name, cookieToDuplicate.Value);
			}
			else
			{
				tempCookie = new HttpCookie(cookieToDuplicate.Name);
				NameValueCollection nameValue = cookieToDuplicate.Values;
					tempCookie.Values.Add(cookieToDuplicate.Values);
			}
			tempCookie.Path = cookieToDuplicate.Path;
			tempCookie.Secure = cookieToDuplicate.Secure;
			tempCookie.Expires = cookieToDuplicate.Expires;
			tempCookie.Domain = cookieToDuplicate.Domain;
			return tempCookie;
		}

		#region HexDecimal Conversion Functions

		/// <summary>
		/// Converts The Given Hexadecimal Character To Integer
		/// </summary>
		/// <param name="h"></param>
		/// <returns></returns>
		public static int HexToInt(char h)
		{
			if ((h >= '0') && (h <= '9'))
			{
				return (h - '0');
			}
			if ((h < 'a') || (h > 'f'))
			{
				if ((h >= 'A') && (h <= 'F'))
				{
					return ((h - 'A') + '\n');
				}
				return -1;
			}
			return ((h - 'a') + '\n');
		}

		/// <summary>
		/// Converts The Given Integer To Hexadecimal Representation
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static char IntToHex(int n)
		{
			if (n <= 9)
			{
				return (char) ((ushort) (n + 0x30));
			}
			return (char) ((ushort) ((n - 10) + 0x61));
		}

		#endregion

		#region Validation Check Functions

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsSafe(string str)
		{
			char[] safeChars = str.ToCharArray();
			for (int i = 0; i < safeChars.Length; i++)
			{
				if (!IsSafe(safeChars[i]))
					return false;
			}
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ch"></param>
		/// <returns></returns>
		public static bool IsSafe(char ch)
		{
			if ((((ch < 'a') || (ch > 'z')) && ((ch < 'A') || (ch > 'Z'))) && ((ch < '0') || (ch > '9')))
			{
				char ch1 = ch;
				switch (ch1)
				{
					case '\'':
					case '(':
					case ')':
					case '*':
					case '-':
					case '.':
					case '!':
						{
							break;
						}
					case '+':
					case ',':
						{
							return false;
						}
					default:
						{
							if (ch1 != '_')
								return false;
							break;
						}
				}
			}
			return true;
		}

		#endregion

		#region The FULLHALFWIDTHINTEGERS To be Used

		#region FULLHALF Private Variables

		/// <summary>
		/// The Constant used to convert HALFFULLWIDTH Characters To Normal Characters
		/// Valid Only For The Latin Alphabet
		/// </summary>
		private const int HALFFULLWIDTHCLEAR = 65248;
		/// <summary>
		/// The Begin of the HALFFULLWIDTH Characters as Integer Value
		/// </summary>
		private const int HALFFULLWIDTHBEGIN = 65280;
		/// <summary>
		/// The End of the HALFFULLWIDTH Characters as Integer Value
		/// </summary>
		private const int HALFFULLWIDTHEND = 65374;

		#endregion

		/// <summary>
		/// Converts The Given String into none HALFFULLWIDTH String
		/// </summary>
		/// <param name="valueToClear">The Value To Be Cleared From The Input String</param>
		/// <param name="isItActive">Tells If The Module Should Be Activated</param>
		/// <returns>The Cleared String</returns>
		public static string ClearHalfFullWidth(string valueToClear, bool isItActive)
		{
			if (isItActive)
			{
				logger.Debug("Begin With CleanUp");
				if (GeneralUtilities.CheckString(valueToClear))
				{
					char[] Characters = valueToClear.ToCharArray();
					StringBuilder results = new StringBuilder(Characters.Length);
					for (int i = 0; i < Characters.Length; i++)
					{
						int integerPresentation =
							(int) Characters[i];
						if (integerPresentation >= HALFFULLWIDTHBEGIN && integerPresentation <= HALFFULLWIDTHEND)
						{
							Characters[i] = (char) (integerPresentation - HALFFULLWIDTHCLEAR);
						}
						results.Append(Characters[i]);
					}
					valueToClear = results.ToString();
				}
			}
			return valueToClear;
		}

		#endregion		

		#region Cookie Conversion Functions
		/// <summary>
		/// Converts The Cookies In The Given Cookie Collection in to HttpCookies
		/// </summary>
		/// <param name="cookies">The Cookie Collection To Be Converted</param>
		public static void ConvertCookiesToHttpOnly(HttpCookieCollection cookies)
		{
			for (int i=0;i<cookies.Count;i++)
			{
				ConvertCookieToHttpOnly(cookies.Get(i));
			}
		}

		/// <summary>
		/// Converts The Cookie To A HttpOnly Cookie
		/// </summary>
		/// <param name="cookie">The Cookie To Be Converted</param>		
		public static void ConvertCookieToHttpOnly(HttpCookie cookie)
		{
			cookie.Path += "; HttpOnly";
		}
		#endregion
		
		#endregion
	}
}