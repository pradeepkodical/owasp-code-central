using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace org.owasp.csrfguard
{
    class HtmlTag
    {
        // collection holding all attributes
        private Hashtable _attrCollection = new Hashtable();
        private String _tagString;
        private String[] _tokenizedTagString;

        // constructor
        public HtmlTag(String tagString)
        {
            _tagString = tagString;
            if (tagHasAttributes())
            {
                normalizeHtml();
                populateAttributes();
            }
        }

        // tokenizes the Html tag string and populates the attributes Hash table
        protected void populateAttributes() {
            // 
            String[] tokens = Split(_tagString, " ", "\"", true);

            foreach (String token in tokens)
            {
                // TODO:  only split on = outside of quotes to avoid impacting values
                if (token.IndexOf('=') > 0)
                {
                    String[] attr = token.Split(new char[] { '=' });
                    _attrCollection.Add(attr[0].ToLower(), attr[1]);
                }
            }
        }

        // need getter/setter methods for the attributes
        #region getters and setters
        public int AttrCount
        {
            get
            {
                return _attrCollection.Count;
            }
        }

        public String TagString
        {
            get
            {
                return _tagString;
            }
        }

        // Oh why make properties not easily able to deal with data structures in a safe way.  No way am I returning the whole
        // hashtable to the caller to screw up.
        public String getAttributeValue(String attrName)
        {
            return _attrCollection[attrName].ToString();
        }

        public void setAttributeValue(String attrName, String value)
        {
            if (_attrCollection.ContainsKey(attrName))
            {
                _attrCollection[attrName] = value;
            }
            else
            {
                _attrCollection.Add(attrName, value);
            }
        }
        #endregion

        #region helper methods

        // determines whether a given html tag string set on the object contains html attributes (e.g. href="/some/where.html")
        protected bool tagHasAttributes()
        {
            bool isAttrFound = false;
            int eqIdx;
            int quoteIdx, quoteIdx2;
            // first, look for an equals sign as possible evidence of an html attribute
            if (((eqIdx = _tagString.IndexOf('=')) > 0)) {
                // now, rule out an equals inside some other quoted string so we know it's part of the attribute definition markup
                quoteIdx = _tagString.IndexOf('"');
                quoteIdx2 = _tagString.IndexOf('\'');
                // if we found a double quote and it is to the right of the equals, OK
                if ((quoteIdx > 0) && (eqIdx < quoteIdx)) {
                    isAttrFound = true;
                }
                // and if we found a single quote and it is to the right of the equals, OK
                if ((quoteIdx2 > 0) && (eqIdx < quoteIdx2)) {
                    isAttrFound = true;
                }
            }
            return isAttrFound;
        }

        // normalizes whitespace in the Html using regexes
        protected void normalizeHtml()
        {
            // <a    href = "/my/url/that has spaces.aspx" id = 1>
            // normalize any closing tag endings to be offset by a space
            Regex endTagRegex = new Regex("/>", RegexOptions.Compiled);
            Regex endTagRegex2 = new Regex("([^/])>", RegexOptions.Compiled);
            _tagString = endTagRegex.Replace(_tagString, " />");
            _tagString = endTagRegex2.Replace(_tagString, "$1 >");
            // match 2+ whitespace not occuring within double quotes.  Love the zero-width lookaheads
            /* Regex whiteSpaceRegex = new Regex("(?!\".*)[ ]{2,}(?!.*\")", RegexOptions.Compiled);
            // Replace with a single whitespace
            _tagString = whiteSpaceRegex.Replace(_tagString, "$1 "); */
            _tagString = CompressWhitespace(_tagString, "\"");
            // now, get rid of whitespace around equals signs
            Regex equalsRegex = new Regex(" += +| +=|= +", RegexOptions.Compiled);
            _tagString = equalsRegex.Replace(_tagString, "=");
        }

        // String split that supports text qualifiers so we can split text on a delimiter but ignore delimiters inside quotes
        // http://www.codeproject.com/useritems/TextQualifyingSplit.asp?df=100&forumid=336054&exp=0&select=1798414
        public string[] Split(string str, string delimiter, string qualifier, bool ignoreCase)
        {
            bool _QualifierState = false;
            int _StartIndex = 0;
            System.Collections.ArrayList _Values = new System.Collections.ArrayList();

            for (int _CharIndex = 0; _CharIndex < str.Length - 1; _CharIndex++)
            {
                if ((qualifier != null)
                 & (string.Compare(str.Substring(_CharIndex, qualifier.Length), qualifier, ignoreCase) == 0))
                {
                    _QualifierState = !(_QualifierState);
                }
                else if (!(_QualifierState) & (delimiter != null)
                      & (string.Compare(str.Substring(_CharIndex, delimiter.Length), delimiter, ignoreCase) == 0))
                {
                    _Values.Add(str.Substring(_StartIndex, _CharIndex - _StartIndex));
                    _StartIndex = _CharIndex + 1;
                }
            }

            if (_StartIndex < str.Length)
                _Values.Add(str.Substring(_StartIndex, str.Length - _StartIndex));

            string[] _returnValues = new string[_Values.Count];
            _Values.CopyTo(_returnValues);
            return _returnValues;
        }

        // replace two or more consecutive spaces with a single space, but only outside of quoted strings!
        public String CompressWhitespace(string str, string qualifier)
        {
            bool gotQuotedString = false;
            int wsCount = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == qualifier[0])
                {
                    gotQuotedString = !(gotQuotedString);
                    sb.Append(str[i]);
                }
                else if (str[i] == ' ' && !gotQuotedString)
                {
                    wsCount++;
                    if (wsCount < 2)
                    {
                        sb.Append(str[i]);
                    }
                }
                else
                {
                    if (wsCount > 0)
                    {
                        wsCount = 0;
                    }
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}