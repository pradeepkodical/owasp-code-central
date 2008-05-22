using System;
using System.Text;

namespace org.owasp.csrfguard
{
    /// <summary>
    /// The token class encapsulates session token data for accessing later in a thread-safe manner
    /// </summary>
    class Token
    {

        string _csrfTokenName;
        string _csrfTokenValue;

        private Token() { }

        public Token(string tokenName, string tokenValue)
        {
            _csrfTokenName = tokenName;
            _csrfTokenValue = tokenValue;
        }

        public string Name { get { return _csrfTokenName; } }

        public string Value { get { return _csrfTokenValue; } }
    }
}
