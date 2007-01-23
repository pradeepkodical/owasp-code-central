using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.CustomControls
{
    public class TestCompletedEventArgs: EventArgs
    {
        protected Document.AutomatedTest test;

        public TestCompletedEventArgs(Document.AutomatedTest test)
        {
            this.test = test;
        }

        public Document.AutomatedTest Test
        {
            get { return test; }
        }
    }
}
