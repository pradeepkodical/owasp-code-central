using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    [System.Xml.Serialization.XmlType("Or")]
    public class OrCondition : BinaryCondition
    {
        public override bool Result
        {
            get { return ((condition1 as ICondition).Result || (condition2 as ICondition).Result); }
        }

        public override string ToString()
        {
            return "(" + Condition1.ToString() + ") OR (" + Condition2.ToString() + ")";
        }
    }
}
