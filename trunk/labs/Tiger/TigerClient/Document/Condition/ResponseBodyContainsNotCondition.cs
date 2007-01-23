using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    [System.Xml.Serialization.XmlType("ResponseBodyDoesNotContain")]
    public class ResponseBodyContainsNotCondition : ResponseBodyContainsConditionBase
    {
        public override bool Result
        {
            get
            {
                if (actualResponseBody == null)
                    return true;

                if (caseSensitive)
                    return (actualResponseBody.IndexOf(matchString, StringComparison.Ordinal) == -1);
                else
                    return (actualResponseBody.IndexOf(matchString, StringComparison.OrdinalIgnoreCase) == -1);
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(matchString))
                return "Invalid condition";
            else
                return "Response body does not contain text \"" + matchString + "\"";
        }
    }
}
