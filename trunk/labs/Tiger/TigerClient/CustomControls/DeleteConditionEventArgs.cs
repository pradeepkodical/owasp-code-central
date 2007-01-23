using System;
using System.Collections.Generic;
using System.Text;
using TigerClient.Document.Condition;

namespace TigerClient.CustomControls
{
    public class DeleteConditionEventArgs: EventArgs
    {
        protected ICondition condition;

        public DeleteConditionEventArgs(ICondition condition)
        {
            this.condition = condition;
        }

        public ICondition Condition
        {
            get { return condition; }
        }
    }
}
