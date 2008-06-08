using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using log4net;

namespace Org.Owasp.CsrfGuard
{
    /// <summary>
    /// Summary description for Util.
    /// </summary>
    public class Util
    {
        private static readonly ILog _log = LogManager.GetLogger("CSRFGuard");

        // checks the request URL path (without parameters!!!) for whether it matches a whitelist of file extensions to ignore
        public static bool URLPathHasWhitelistedFileExtension(String filePath)
        {
            Regex whitelistRegex =
                new Regex(App.Configuration.ExtensionWhitelistPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (whitelistRegex.IsMatch(filePath))
            {
                return true;
            }
            return false;
        }

        // checks the request URL path (without parameters!!!) for whether it matches a whitelist of file URL paths to ignore
        public static bool URLPathIsOnWhitelist(String filePath)
        {
            if (App.Configuration.SkipDetectForTheseURLs.Contains(filePath))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adapted from http://www.west-wind.com/presentations/configurationclass/configurationclass.asp
        /// 
        /// Sets the value of a field or property via Reflection. This method alws 
        /// for using '.' syntax to specify objects multiple levels down.
        /// 
        /// Util.SetPropertyEx(this,"Invoice.LineItemsCount",10)
        /// 
        /// which would be equivalent of:
        /// 
        /// this.Invoice.LineItemsCount = 10;
        /// </summary>
        /// <param name="Object parent">
        /// Object to set the property on.
        /// </param>
        /// <param name="String property">
        /// property to set. Can be an object hierarchy with . syntax.
        /// </param>
        /// <param name="Object value">
        /// value to set the property to
        /// </param>
        public static object SetPropertyEx(object parent, string property, object value)
        {
            Type Type = parent.GetType();
            MemberInfo Member = null;

            // *** no more .s - we got our final object
            int lnAt = property.IndexOf(".");
            if (lnAt < 0)
            {
                Member = Type.GetMember(property, BindingFlags.Public | BindingFlags.NonPublic |
                                                  BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase)
                    [0];
                if (Member.MemberType == MemberTypes.Property)
                {
                    ((PropertyInfo) Member).SetValue(parent, value, null);
                    return null;
                }
                else
                {
                    ((FieldInfo) Member).SetValue(parent, value);
                    return null;
                }
            }

            // *** Walk the . syntax
            string Main = property.Substring(0, lnAt);
            string Subs = property.Substring(lnAt + 1);
            Member = Type.GetMember(Main, BindingFlags.Public | BindingFlags.NonPublic |
                                          BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase)[0];

            object Sub;
            if (Member.MemberType == MemberTypes.Property)
                Sub = ((PropertyInfo) Member).GetValue(parent, null);
            else
                Sub = ((FieldInfo) Member).GetValue(parent);

            // *** Recurse until we get the lowest ref
            SetPropertyEx(Sub, Subs, value);
            return null;
        }

        /// <summary>
        /// Extract a substring from the parameter <code>str</code> that starts with the character <code>startchar</code> and ends with the character <code>endchar</code>.
        /// Returns all captured text until end of string or the <code>endchar</code> is found.
        /// </summary>
        /// <param name="str">string to search for the substring</param>
        /// <param name="start">where to start reading from in the string</param>
        /// <param name="startchar">character beginning the substring to capture</param>
        /// <param name="endchar">character terminating the substring to capture</param>
        public static String CaptureFromStartToStopChar(String str, int start, char startchar, char endchar)
        {
            bool capturingText = false;
            bool gotEnd = false;

            StringBuilder sb = new StringBuilder();

            for (int i = start; i < str.Length; i++)
            {
                // it's stupid that c# switch statements require CONSTANTS.  Blame MS for how ugly this is.
                if (str[i] == startchar)
                {
                    if (capturingText && !gotEnd)
                    {
                        // this is an error.  We got a duplicate startchar before an endchar
                        // TODO:  probably need to throw a parsing exception
                    }
                    else
                    {
                        capturingText = true;
                        sb.Append(str[i]);
                    }
                }
                else if (str[i] == endchar)
                {
                    sb.Append(str[i]);
                    capturingText = false;
                    gotEnd = true;
                    break; // break out of loop
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
        
        /// <summary>
        /// if the URL is a relative URL, or the server name matches this one serving the request, then return true
        /// Note: it also returns false if the URL is a javascript URL.
        /// </summary>
        /// <param name="url">url to evaluate</param>
        public static bool IsUrlSameOriginAsServer(String url)
        {
            bool isSameOrigin = false;
            string machineName;
            if (HttpContext.Current == null)
            {
                machineName = Dns.GetHostName();
            }
            else
            {
                machineName = HttpContext.Current.Server.MachineName;
            }

            Regex urlRegex = new Regex("^(\"?)[a-zA-Z]+://([^/:]+)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex isJavascriptUrlRegex = new Regex("^javascript:", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // "/some/dir/index.html" 
            // starts with /
            if (StripQuotes(url).IndexOf('/') >= 0)
            {
                _log.Debug(String.Format(CultureInfo.InvariantCulture, "IsSameOrigin due to slash within first 2 characters of string {0}", url));
                isSameOrigin = true;
            }
            else if (urlRegex.IsMatch(url))
            {
                // check for a full URL reference
                Match m = urlRegex.Match(url);
                String urlServer = m.Groups[2].Value.ToLower(CultureInfo.InvariantCulture);
                IPHostEntry serverHostEntry = Dns.Resolve(machineName);

                if (urlServer == "localhost" ||
                    urlServer == "127.0.0.1" ||
                    urlServer == machineName ||
                    machineName.StartsWith(urlServer) ||
                    urlServer == serverHostEntry.AddressList[0].ToString())
                {
                    _log.Debug(
                        String.Format(CultureInfo.InvariantCulture, "IsSameOrigin due to machineName match {0}, {1}, {2}", machineName, urlServer, url));
                    isSameOrigin = true;
                }
            }
            else if (isJavascriptUrlRegex.IsMatch(StripQuotes(url)))
            {
                _log.Debug("IsNOTSameOrigin due to javascript match");
                isSameOrigin = false; // don't touch javascript URLs!  You will probably break them
            }
            else
            {
                // relative reference not starting with slash
                _log.Debug(String.Format(CultureInfo.InvariantCulture, "IsSameOrigin due to relative reference without starting slash {0}", url));
                isSameOrigin = true;
            }
            return isSameOrigin;
        }

        /// <summary>
        /// Remove double quotes from the first and last position of a string
        /// </summary>
        /// <param name="str">string to remove quotes from</param>
        public static string StripQuotes(string str)
        {
            if (str[0] == '"')
            {
                str = str.Substring(1);
            }
            if (str[str.Length - 1] == '"')
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }
    }
}