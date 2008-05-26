namespace Org.Owasp.CsrfGuard
{
    /// <summary>
    /// The token class encapsulates session token data for accessing later in a thread-safe manner
    /// </summary>
    internal class Token
    {
        private string _csrfTokenName;
        private string _csrfTokenValue;

        public Token(string tokenName, string tokenValue)
        {
            _csrfTokenName = tokenName;
            _csrfTokenValue = tokenValue;
        }

        public string Name
        {
            get { return _csrfTokenName; }
        }

        public string Value
        {
            get { return _csrfTokenValue; }
        }
    }
}