using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Org.Owasp.CsrfGuard.ResponseFilters;

namespace Org.Owasp.CsrfGuard.ResponseFilters
{
    /// <summary>
    /// Summary description for CSRFHtmlFilter.
    /// 
    /// Code adapted from a similar model at http://aspnetresources.com/articles/HttpFilters.aspx
    /// </summary>
    internal class JavascriptFilter : ResponseFilterBase
    {
        protected static string TOKEN_NAME_PAT = "<%NAME%>";
        protected static string TOKEN_VALUE_PAT = "<%VALUE%>";

        public JavascriptFilter(Stream inputStream, String tokenName, String token)
            : base(inputStream, tokenName, token)
        {
            // nothing extra
        }

        //--------
        // Do the rewriting
        //--------

        // This is the opportunity to rewrite the HTML before sending back to the browser
        public override void Write(byte[] buffer, int offset, int count)
        {
            string strBuffer = UTF8Encoding.UTF8.GetString(buffer, offset, count);

            // ---------------------------------
            // Wait for the closing </html> tag
            // ---------------------------------
            Regex eof = new Regex("</html>", RegexOptions.IgnoreCase);

            if (!eof.IsMatch(strBuffer))
            {
                _responseHtml.Append(strBuffer);
            }
            else
            {
                _responseHtml.Append(strBuffer); // append the last piece of the html
                String finalHtml = _responseHtml.ToString();

                // Do the transformations
                finalHtml = InjectJavascriptReference(finalHtml);

                byte[] data = UTF8Encoding.UTF8.GetBytes(finalHtml);

                _responseStream.Write(data, 0, data.Length);
            }
        }

        //--------
        // Helper methods
        //--------

        // TODO:  javascript has to honor the same origin policy.
        private String InjectJavascriptReference(String htmlText)
        {
            Regex bodyFieldRegex = new Regex("</body>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            // Replace by default replaces all occurrences
            htmlText = bodyFieldRegex.Replace(htmlText, GetCSRFJavascriptContent() + "\n\t</body>");
            return htmlText;
        }

        private String GetCSRFJavascriptContent()
        {
            string jsFileContent = String.Empty;
            const string resourceName = "csrf.js";

            try
            {
                Assembly thisAssem = Assembly.GetExecutingAssembly();
                Stream stream = thisAssem.GetManifestResourceStream("Org.Owasp.CsrfGuard" + "." + resourceName);

                if (stream == null)
                {
                    throw new Exception("Could not locate embedded resource '" + resourceName + "' in assembly '" +
                                        thisAssem.GetName() + "'");
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    jsFileContent = reader.ReadToEnd();
                }

                // now, inject the token name and value into the placeholders
                jsFileContent = jsFileContent.Replace(TOKEN_NAME_PAT, _CSRFTokenName);
                jsFileContent = jsFileContent.Replace(TOKEN_VALUE_PAT, _CSRFSesssionToken);
            }
            catch (Exception e)
            {
                _log.Error(String.Format(CultureInfo.InvariantCulture, "Error reading javascript resource {0}: {1}; {2}",
                                  e.Message, e.StackTrace));
            }
            return jsFileContent;
        }
    }
}