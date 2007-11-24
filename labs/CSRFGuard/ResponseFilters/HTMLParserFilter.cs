using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using org.owasp.csrfguard.ResponseFilters;

namespace org.owasp.csrfguard
{
	/// <summary>
	/// Summary description for CSRFHtmlFilter.
	/// 
	/// Code adapted from a similar model at http://aspnetresources.com/articles/HttpFilters.aspx
	/// </summary>
	internal class HTMLParserFilter : ResponseFilterBase
	{
		
		public HTMLParserFilter(Stream inputStream, String tokenName, String token) : base(inputStream, tokenName, token)
		{
			// nothing extra
		}

		#region Do the rewriting
		// This is the opportunity to rewrite the HTML before sending back to the browser
		public override void Write(byte[] buffer, int offset, int count)
		{
			string strBuffer = UTF8Encoding.UTF8.GetString (buffer, offset, count);

			// ---------------------------------
			// Wait for the closing </html> tag
			// ---------------------------------
			Regex eof = new Regex ("</html>", RegexOptions.IgnoreCase);

			if (!eof.IsMatch (strBuffer))
			{
				_responseHtml.Append (strBuffer);
			}
			else
			{
				_responseHtml.Append (strBuffer); // append the last piece of the html
				String finalHtml = _responseHtml.ToString();

				// TODO:  Implement HTML parsing tag injection
				
				byte[] data = UTF8Encoding.UTF8.GetBytes (finalHtml);
        
				_responseStream.Write (data, 0, data.Length);
			}
		}
		#endregion
		
		#region Helper methods

		#endregion
	}
}
