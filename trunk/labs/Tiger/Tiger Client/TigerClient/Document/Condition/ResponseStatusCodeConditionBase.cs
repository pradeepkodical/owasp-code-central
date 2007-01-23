using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TigerClient.Document.Condition
{
    public abstract class ResponseStatusCodeConditionBase : ICondition
    {
        protected int responseStatusCode;
        protected int actualResponseStatusCode;

        [System.Xml.Serialization.XmlElement("Value")]
        public virtual int ResponseStatusCode
        {
            get { return responseStatusCode; }
            set { responseStatusCode = value; }
        }

        [XmlIgnore()]
        public virtual int ActualResponseStatusCode
        {
            get { return actualResponseStatusCode; }
            set { actualResponseStatusCode = value; }
        }

        #region ICondition Members

        public abstract bool Result
        {
            get;
        }

        public virtual bool IsValid
        {
            get { return true; }
        }

        public virtual string ErrorMessage
        {
            get { return null; }
        }

        public virtual void SetResponseBody(string responseBody)
        {
            // No-op
        }

        public virtual void SetResponseStatusCode(int responseStatusCode)
        {
            actualResponseStatusCode = responseStatusCode;
        }

        #endregion
    }
}
