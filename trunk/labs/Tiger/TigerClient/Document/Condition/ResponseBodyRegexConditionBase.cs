using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    public abstract class ResponseBodyRegexConditionBase : ResponseBodyConditionBase
    {
        protected string regex;
        protected bool caseSensitive;

        public virtual string Regex
        {
            get { return regex; }
            set { regex = value; }
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
                if (string.IsNullOrEmpty(regex))
                    return "Regular expression must be set.";
                else
                    return null;
            }
        }
    }
}
