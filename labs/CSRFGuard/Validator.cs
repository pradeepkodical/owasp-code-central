using System.Text.RegularExpressions;

namespace Org.Owasp.CsrfGuard
{
    internal class Validator
    {
        protected static bool IsTokenValid(string token)
        {
            Regex tokenValueRegex = new Regex("", RegexOptions.Compiled);

            return tokenValueRegex.IsMatch(token);
        }

        protected static bool IsTokenNameValid(string token)
        {
            Regex tokenValueRegex = new Regex("", RegexOptions.Compiled);

            return tokenValueRegex.IsMatch(token);
        }
    }
}