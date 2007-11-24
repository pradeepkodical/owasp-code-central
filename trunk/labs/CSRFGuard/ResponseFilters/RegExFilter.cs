using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using org.owasp.csrfguard.ResponseFilters;

namespace org.owasp.csrfguard.ResponseFilters
{
	/// <summary>
	/// Summary description for CSRFHtmlFilter.
	/// 
	/// Code adapted from a similar model at http://aspnetresources.com/articles/HttpFilters.aspx
	/// </summary>
	internal class RegExFilter : ResponseFilterBase
	{
		
		public RegExFilter(Stream inputStream, String tokenName, String token) : base(inputStream, tokenName, token)
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

				// Do the transformations
				// put the hidden form fields in place
				finalHtml = injectHiddenFormFields(finalHtml);
				
				// now, inject parameters into any URLs within the page
				finalHtml = injectURLParameters(finalHtml);
                _responseHtml = new StringBuilder(finalHtml);

				byte[] data = UTF8Encoding.UTF8.GetBytes(finalHtml);
        
				_responseStream.Write (data, 0, data.Length);
			}
		}
		#endregion
		
		#region Helper methods
		private String injectHiddenFormFields(String htmlText)
		{
			Regex formFieldRegex = new Regex("</form>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
			// Replace by default replaces all occurrences
			htmlText = formFieldRegex.Replace(htmlText, "<input type=\"hidden\" name=\"" + _CSRFTokenName + "\" value=\"" + _CSRFSesssionToken + "\">\n</form>");
			return htmlText;
		}
		
		private String injectURLParameters(String htmlText)
		{
            /*
            State machine parser
            1. look for a tag start <[a-z]
            2. scan ahead until you find a " h" or " s" for href/src, or end of tag >
            3. if you find h, look for href; s, look for src
            4. scan ahead and capture the URI
            5. check the URI to ensure it is either a relative URI or the hostname matches (same origin).  Ignore javascript URIs.
            6. if valid URI, then check for a ? and append the token, or add the ? and token
             */
			return htmlText;
		}
		#endregion
	}
}
