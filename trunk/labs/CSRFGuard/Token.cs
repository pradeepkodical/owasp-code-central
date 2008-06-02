
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Org.Owasp.CsrfGuard
{
    /// <summary>
    /// The token class represents a token name and value.  It will validate the values and will not allow it to be set with invalid values.
    /// </summary>
    public class Token
    {
        protected string _csrfTokenName = String.Empty;
        protected string _csrfTokenValue = String.Empty;

        public Token(string tokenName, string tokenValue)
        {
            if (Validator.IsTokenNameValid(tokenName))
            {
                _csrfTokenName = tokenName;
            }
            if (Validator.IsTokenValid(tokenValue))
            {
                _csrfTokenValue = tokenValue;
            }
        }

        public Token()
        {
            // do nothing.  This constructor is required for the override in the subclass
        }

        public string Name
        {
            get { return _csrfTokenName; }
            set { _csrfTokenName = value; }
        }

        public string Value
        {
            get { return _csrfTokenValue; }
            set { _csrfTokenValue = value; }
        }

        /// <summary>
        /// Securely generates a random value and returns the bytes encoded as hexadecimal
        /// </summary>
        /// <param name="numBytes">How many random bytes to generate</param>
        protected static String GenerateRandomHexBytes(int numBytes)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randBytes = new byte[numBytes];

            rng.GetBytes(randBytes);
            return BytesToHexString(randBytes);
        }

        /// <summary>
        /// Convert a byte array into a hexadecimal string representation
        /// </summary>
        /// <param name="binary">byte array to convert</param>
        protected static String BytesToHexString(byte[] binary)
        {
            StringBuilder hex = new StringBuilder((binary.Length / 8) * 2);

            for (int i = 0; i < binary.Length; i++)
            {
                hex.Append(String.Format(CultureInfo.InvariantCulture, "{0:X2}", binary[i]));
            }
            return hex.ToString();
        }

        /// <summary>
        /// Compares the equality of the string values of the two Token objects
        /// </summary>
        public static bool operator ==(Token obj1, Token obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Compares the equality of the numerical values of the Amount field.
        /// </summary>
        public static bool operator !=(Token obj1, Token obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            Token other = obj as Token;

            try
            {
                string name = ((object)other == null) ? null : other.Name;
                string value = ((object)other == null) ? null : other.Value;
                return (this.Name == name) && (this.Value == value);
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Value.GetHashCode();
        }
    }

    public class RandomToken : Token
    {
        public RandomToken()
        {
            _csrfTokenName = GenerateRandomHexBytes(App.Configuration.CSRFRandomTokenNameLengthInBytes);
            _csrfTokenValue = GenerateRandomHexBytes(App.Configuration.CSRFTokenLengthInBytes);
        }
    }
}
