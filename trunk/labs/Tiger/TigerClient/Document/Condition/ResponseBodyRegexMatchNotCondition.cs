using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    [System.Xml.Serialization.XmlType("ResponseBodyDoesNotMatchRegex")]
    public class ResponseBodyRegexMatchNotCondition : ResponseBodyRegexConditionBase
    {
        public override bool Result
        {
            get
            {
                if (actualResponseBody == null)
                    return true;

                if (caseSensitive)
                    return !(System.Text.RegularExpressions.Regex.IsMatch(actualResponseBody, regex, System.Text.RegularExpressions.RegexOptions.None));
                else
                    return !(System.Text.RegularExpressions.Regex.IsMatch(actualResponseBody, regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase));
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(regex))
                return "Invalid condition";
            else
                return "Response body does not contain match for regex \"" + regex + "\"";
        }
    }
}
