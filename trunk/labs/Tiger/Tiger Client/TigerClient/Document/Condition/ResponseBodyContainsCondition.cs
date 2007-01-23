using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    [System.Xml.Serialization.XmlType("ResponseBodyContains")]
    public class ResponseBodyContainsCondition : ResponseBodyContainsConditionBase
    {
        public override bool Result
        {
            get
            {
                if (actualResponseBody == null)
                    return false;


                if (caseSensitive)
                    return (actualResponseBody.IndexOf(matchString, StringComparison.Ordinal) != -1);
                else
                    return (actualResponseBody.IndexOf(matchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(matchString))
                return "Invalid condition";
            else
                return "Response body contains text \"" + matchString + "\"";
        }
    }
}
