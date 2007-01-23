using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    [System.Xml.Serialization.XmlType("ResponseStatusCodeNotEqualTo")]
    public class ResponseStatusCodeEqualToNotCondition : ResponseStatusCodeConditionBase
    {
        public override bool Result
        {
            get { return (responseStatusCode != actualResponseStatusCode); }
        }

        public override string ToString()
        {
            return "Response status code is not " + responseStatusCode.ToString();
        }
    }
}
