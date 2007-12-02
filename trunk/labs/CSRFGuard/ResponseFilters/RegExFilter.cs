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
            StringBuilder newHtmlText = new StringBuilder();

            for (int i=0; i < htmlText.Length; i++) {
                Console.WriteLine(htmlText[i]);

                switch (htmlText[i]) {
                    case '<':
                        // got a tag start.  Let's grab the whole tag
                        String htmlTag = captureFromStartToStopChar(htmlText, i, '<', '>');
                        // okay, now we need to tokenize the internals to grab src=blah or href=blah so we can replace them.  Best to create an objec
                        // that exposes these values that we can rewrite.
                        i += htmlTag.Length;    // advance the loop value ahead past this tag.
                        break;
                    case '>':
                        // should never get here since the end tag gets gobbled up by the captureFromStartToStopChar() method
                        break;
                    default:
                        newHtmlText.Append(htmlText[i]);
                        break;
                }
            }

			return newHtmlText.ToString();
		}

        private String captureFromStartToStopChar(String str, int start, char startchar, char endchar)
        {
            bool capturingText = false;
            bool gotStart = false;
            bool gotEnd = false;

            StringBuilder sb = new StringBuilder();
            
            for (int i = start; i < str.Length; i++)
            {

                // it's stupid that c# switch statements require CONSTANTS.  Blame MS for how ugly this is.
                if (str[i] == startchar) {
                    if (capturingText && !gotEnd)
                    {
                        // this is an error.  We got a duplicate startchar before an endchar
                        // TODO:  probably need to throw a parsing exception
                    }
                    else
                    {
                        gotStart = true;
                        capturingText = true;
                        sb.Append(str[i]);
                    }
                }
                else if (str[i] == endchar)
                {
                    sb.Append(str[i]);
                    capturingText = false;
                    gotEnd = true;
                    break;  // break out of loop
                }
                else
                {
                    if (capturingText)
                    {
                        // not a start or end character so add it
                        sb.Append(str[i]);
                    }
                }
            }
            // if we ever get here, we did not find an end delimiter so just return what we have
            return sb.ToString();
        }

        private String injectURLToken(String url, String tokenName, String tokenValue)
        {
            if (url.IndexOf('?') > 0)
            {
                // this url has parameters.  We need to append one more
                url = String.Format("{0}&{1}={2}", url, tokenName, tokenValue);
            }
            else
            {
                // this url has no parameters.  Add one
                url = String.Format("{0}?{1}={2}", url, tokenName, tokenValue);
            }

            return url;
        }
		#endregion
	}
}
