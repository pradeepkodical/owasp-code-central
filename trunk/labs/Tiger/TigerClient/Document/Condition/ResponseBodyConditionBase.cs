using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document.Condition
{
    public abstract class ResponseBodyConditionBase : ICondition
    {
        protected string actualResponseBody;

        // This property should not be serialized
        public virtual string ActualResponseBody
        {
            get { return actualResponseBody; }
            set { actualResponseBody = value; }
        }

        #region ICondition Members

        public abstract bool Result
        {
            get;
        }

        public virtual bool IsValid
        {
            get { return string.IsNullOrEmpty(ErrorMessage); }
        }

        public abstract string ErrorMessage
        {
            get;
        }

        public virtual void SetResponseBody(string responseBody)
        {
            actualResponseBody = responseBody;
        }

        public virtual void SetResponseStatusCode(int responseStatusCode)
        {
            // No-op
        }

        #endregion
    }
}
