using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    public abstract class ResponseBodyContainsConditionBase : ResponseBodyConditionBase
    {
        protected string matchString;
        protected bool caseSensitive;

        [System.Xml.Serialization.XmlElement("Value")]
        public virtual string MatchString
        {
            get { return matchString; }
            set { matchString = value; }
        }

        [System.Xml.Serialization.XmlIgnore()]
        public virtual bool CaseSensitive
        {
            get { return caseSensitive; }
            set { caseSensitive = value; }
        }

        public override string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(matchString))
                    return "Match string must be set.";
                else
                    return null;
            }
        }
    }
}
