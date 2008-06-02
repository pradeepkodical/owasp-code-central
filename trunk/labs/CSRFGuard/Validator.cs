using System;
using System.Text.RegularExpressions;

namespace Org.Owasp.CsrfGuard
{
    internal class Validator
    {
        protected static readonly string HEX_PATTERN = "^[a-fA-F0-9]*$";

        /// <summary>
        /// Validates the CSRF Token Value passed to us against what it should look like according to the app configuration
        /// </summary>
        /// <param name="token"></param>
        internal static bool IsTokenValid(string token)
        {
            if (token == null)
            {
                return false;
            }

            Regex tokenValueRegex = new Regex(HEX_PATTERN, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if ((token.Length != App.Configuration.CSRFTokenLengthInBytes*2) ||
                !tokenValueRegex.IsMatch(token))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates the CSRF Token Name passed to us based on how it should look according to the app configuration.
        /// </summary>
        internal static bool IsTokenNameValid(string name)
        {
            bool result = false;

            if (name == null)
            {
                return false;
            }

            if (!App.Configuration.useRandomCSRFTokenName)
            {
                if (name == App.Configuration.staticCSRFTokenName)
                {
                    result = true;
                }
            }
            else
            {
                Regex tokenNameRegex = new Regex(HEX_PATTERN, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if ((name.Length == App.Configuration.CSRFRandomTokenNameLengthInBytes*2) &&
                    tokenNameRegex.IsMatch(name))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}