using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    [System.Xml.Serialization.XmlType("ResponseBodyMatchesRegex")]
    public class ResponseBodyRegexMatchCondition : ResponseBodyRegexConditionBase
    {
        public override bool Result
        {
            get
            {
                if (actualResponseBody == null)
                    return false;

                if (caseSensitive)
                    return System.Text.RegularExpressions.Regex.IsMatch(actualResponseBody, regex, System.Text.RegularExpressions.RegexOptions.None);
                else
                    return System.Text.RegularExpressions.Regex.IsMatch(actualResponseBody, regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(regex))
                return "Invalid condition";
            else
                return "Response body contains match for regex \"" + regex + "\"";
        }
    }
}
