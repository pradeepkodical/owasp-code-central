#region Licence Information

// The Defence Application For ASP.Net Applications
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

using System;
using System.Text;
using Owasp.DefApp.Exceptions;

#endregion

namespace Owasp.DefApp.Rules.Tools
{
	/// <summary>
	/// Normalization Tools which will be used for modsecurity support
	/// </summary>
	public sealed class NormalizationTools
	{
		#region Private Methods

		private NormalizationTools()
		{
		}

		private static char x2c(char c1, char c2)
		{
			int i1 = 0, i2 = 0;
			if ((c1 >= '0') && (c1 <= '9'))
			{
				i1 = c1 - '0';
			}
			else if ((c1 >= 'a') && (c1 <= 'f'))
			{
				i1 = 10 + (c1 - 'a');
			}
			else if ((c1 >= 'A') && (c1 <= 'F'))
			{
				i1 = 10 + (c1 - 'A');
			}
			else
			{
				throw new InvalidURLEncodingException();
			}

			if ((c2 >= '0') && (c2 <= '9'))
			{
				i2 = c2 - '0';
			}
			else if ((c2 >= 'a') && (c2 <= 'f'))
			{
				i2 = 10 + (c2 - 'a');
			}
			else if ((c2 >= 'A') && (c2 <= 'F'))
			{
				i2 = 10 + (c2 - 'A');
			}
			else
			{
				throw new InvalidURLEncodingException();
			}

			return (char) ((i1*16) + i2);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Compress Slashes in the given String
		/// </summary>
		/// <param name="values">The String To Compress</param>
		/// <returns></returns>
		public static string CompressSlashes(string values)
		{
			StringBuilder sb = new StringBuilder(values.Length);
			bool previousWasSlash = false;
			int i = 0, n = values.Length;
			while (i < n)
			{
				char c = values[i];
				if (c == '/')
				{
					if (previousWasSlash == false)
					{
						sb.Append('/');
						previousWasSlash = true;
					}
				}
				else
				{
					previousWasSlash = false;
					sb.Append(c);
				}
				i++;
			}
			return sb.ToString();
		}

		/// <summary>
		/// Converts Slashes To Back Slashes
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string ConvertBackSlashes(string values)
		{
			StringBuilder sb = new StringBuilder(values.Length);
			int i = 0, n = values.Length;
			while (i < n)
			{
				char c = values[i]; //value.charAt(i);
				if (c == '\\') c = '/';
				sb.Append(c);
				i++;
			}
			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string RemoveSelfReferences(string values)
		{
			StringBuilder sb = new StringBuilder(values.Length);
			//bool previousWasSlash = false;
			int i = 0, n = values.Length;
			while (i < n)
			{
				char c = values[i];
				if ((c == '/') && (i + 2 < n) && (values[(i + 1)] == '.') && (values[(i + 2)] == '/'))
				{
					i += 2;
				}
				sb.Append(c);
				i++;
			}
			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string ConvertToLowercase(string values)
		{
			return values.ToLower();
		}

		/// <summary>
		/// Compresses The Whitespaces To Single White Space
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string CompressWhitespace(string values)
		{
			StringBuilder sb = new StringBuilder(values.Length);
			bool previousWasWhite = false;
			int i = 0, n = values.Length;
			while (i < n)
			{
				char c = values[i];
				if (Char.IsWhiteSpace(c))
				{
					if (!previousWasWhite)
					{
						sb.Append(' ');
						previousWasWhite = true;
					}
				}
				else
				{
					previousWasWhite = false;
					sb.Append(c);
				}
				i++;
			}
			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string DecodeURLEncodedUnicode(string values)
		{
			StringBuilder sb = new StringBuilder(values.Length);
			int i = 0, n = values.Length;
			while (i < n)
			{
				char c = values[i];
				if (c == '+') c = ' ';
				else if (c == '%')
				{
					if ((i + 5 < n) && ((values[i + 1] == 'u') || (values[i + 1] == 'U')))
					{
						// unicode
						char c1 = x2c(values[i + 2], values[i + 3]);
						char c2 = x2c(values[i + 4], values[i + 5]);
						//char[] cs = (char)((int)c1) * 256 + (int)c2);
						//sb.Append(cs[0]);
					}
					else if (i + 2 < n)
					{
						// normal URL-encoded character
						sb.Append(x2c(values[++i], values[++i]));
					}
					else throw new InvalidURLEncodingException();
				}
				else sb.Append(c);
				i++;
			}
			return sb.ToString();
		}

		/// <summary>
		/// Converts URL Encoded Strings To UnUrlEncoded
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string DecodeURLEncoded(string values)
		{
			StringBuilder sb = new StringBuilder(values.Length);
			int i = 0, n = values.Length;
			while (i < n)
			{
				char c = values[i];
				if (c == '+') c = ' ';
				else if (c == '%')
				{
					if (i + 2 >= n) throw new Exception();
					c = x2c(values[++i], values[++i]);
				}
				sb.Append(c);
				i++;
			}
			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static string DecodeEscaped(string values)
		{
			// TODO should web support \xHH and similar?

			StringBuilder sb = new StringBuilder(values.Length);
			int i = 0, n = values.Length;
			while (i < n)
			{
				char c = values[i];
				if ((c == '\\') && (i + 1 < n))
				{
					i++;
					c = values[i];
					switch (c)
					{
						case '0':
							c = '\0';
							break;
						case 'b':
							c = '\b';
							break;
						case 'f':
							c = '\f';
							break;
						case 'n':
							c = '\n';
							break;
						case 'r':
							c = '\r';
							break;
						case 't':
							c = '\t';
							break;
					}
					sb.Append(c);
				}
				else
				{
					sb.Append(c);
				}
				i++;
			}
			return sb.ToString();
		}

		#endregion
	}
}