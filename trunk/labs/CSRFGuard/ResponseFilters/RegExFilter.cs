using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using org.owasp.csrfguard.ResponseFilters;

namespace org.owasp.csrfguard.ResponseFilters
{
	/// <summary>
	/// Summary description for RegexFilter.
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

				// now, inject parameters into any URLs within the page
				finalHtml = injectURLParameters(finalHtml);

                // put the hidden form fields in place (do this after url parameters to avoid injecting twice)
                finalHtml = injectHiddenFormFields(finalHtml);
                _responseHtml = new StringBuilder(finalHtml);

				byte[] responseHtmlBytes = UTF8Encoding.UTF8.GetBytes(finalHtml);
        
				_responseStream.Write (responseHtmlBytes, 0, responseHtmlBytes.Length);
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
_log.Debug(App.Configuration.extensionWhitelistPattern);
            Regex extensionWhitelistRegex = new Regex(App.Configuration.extensionWhitelistPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex skipJavascriptRegex = new Regex("^javascript:", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            for (int i=0; i < htmlText.Length; i++) {

                switch (htmlText[i]) {
                    case '<':
                        // got a tag start.  Let's grab the whole tag
                        String tagStr = Util.captureFromStartToStopChar(htmlText, i, '<', '>'); 
                        i += (tagStr.Length - 1);    // advance the loop value ahead past this tag.
                        HtmlTag tagObj = new HtmlTag(tagStr);
                        String value;
                        if ((value = tagObj.getAttributeValue("src")) != null)
                        {
                            // SECURITY NOTE:  enforce the same-origin policy for rewrites.  Only links for this site get rewritten!
                            if (Util.urlIsSameOriginAsServer(Util.StripQuotes(value)) 
                                && !extensionWhitelistRegex.IsMatch(Util.StripQuotes(value)))
                            {
                                _log.Debug("Injecting token for src url '" + value + "'");
                                tagObj.setAttributeValue("src", injectURLToken(value, _CSRFTokenName, _CSRFSesssionToken));
                            }
                        }
                        else if ((value = tagObj.getAttributeValue("href")) != null)
                        {
                            // SECURITY NOTE:  enforce the same-origin policy for rewrites.  Only links for this site get rewritten!
                            if (Util.urlIsSameOriginAsServer(Util.StripQuotes(value))
                                && !extensionWhitelistRegex.IsMatch(Util.StripQuotes(value))
                                && !skipJavascriptRegex.IsMatch(Util.StripQuotes(value)))  // don't break javascript hrefs
                            {
_log.Debug("Injecting token for href url " + value);
                                tagObj.setAttributeValue("href", injectURLToken(value, _CSRFTokenName, _CSRFSesssionToken));
                            }
                        }

                        newHtmlText.Append(tagObj.TagString);
                        break;
                    case '>':
                        // should never get here since the end tag gets gobbled up by the captureFromStartToStopChar() method
                        _log.Warn("Supposedly unreachable parse error encountered in RegExFilter at char #" + i);
                        break;
                    default:
                        // anything else passes through without modification
                        newHtmlText.Append(htmlText[i]);
                        break;
                }
            }

			return newHtmlText.ToString();
		}

        private String injectURLToken(String url, String tokenName, String tokenValue)
        {
            if (url.IndexOf('?') > 0)
            {
                // this url has parameters.  We need to append one more
                // check for trailing quote
                if (url[url.Length-1] == '"')
                {
                    url = url.Substring(0, url.Length - 1) + "&" + tokenName + "=" + tokenValue + "\"";
                }
                else
                {
                    url = String.Format("{0}&{1}={2}", url, tokenName, tokenValue);
                }
            }
            else
            {
                // check for trailing quote
                if (url[url.Length-1] == '"')
                {
                    url = url.Substring(0, url.Length - 1) + "?" + tokenName + "=" + tokenValue + "\"";
                }
                else
                {
                    // this url has no parameters.  Add one
                    url = String.Format("{0}?{1}={2}", url, tokenName, tokenValue);
                }
            }

            return url;
        }
		#endregion
	}
}
