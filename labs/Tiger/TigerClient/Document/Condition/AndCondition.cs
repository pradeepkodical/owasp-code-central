using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    [System.Xml.Serialization.XmlType("And")]
    public class AndCondition : BinaryCondition
    {
        public override bool Result
        {
            get { return ((condition1 as ICondition).Result && (condition2 as ICondition).Result); }
        }

        public override string ToString()
        {
            return "(" + Condition1.ToString() + ") AND (" + Condition2.ToString() + ")";
        }
    }
}
