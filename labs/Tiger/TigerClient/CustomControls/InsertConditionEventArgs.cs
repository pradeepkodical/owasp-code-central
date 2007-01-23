using System;
using System.Collections.Generic;
using System.Text;
using TigerClient.Document.Condition;

namespace TigerClient.CustomControls
{
    class InsertConditionEventArgs: EventArgs
    {
        protected ICondition condition;

        public InsertConditionEventArgs(ICondition condition)
        {
            if (condition == null) throw new ArgumentNullException("Condition must not be null.");
            this.condition = condition;
        }

        public ICondition Condition
        {
            get { return condition; }
        }

        public Type ConditionType
        {
            get { return condition.GetType(); }
        }
    }
}
