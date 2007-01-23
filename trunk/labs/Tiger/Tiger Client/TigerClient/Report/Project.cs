using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Report
{
    public class Project
    {
        protected string name;
        protected string description;
        protected string testersName;
        protected string testersComments;
        protected DateTime timeStarted;
        protected DateTime timeFinished;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string TestersName
        {
            get { return testersName; }
            set { testersName = value; }
        }

        public string TestersComments
        {
            get { return testersComments; }
            set { testersComments = value; }
        }

        public DateTime TimeStarted
        {
            get { return timeStarted; }
            set { timeStarted = value; }
        }

        public DateTime TimeFinished
        {
            get { return timeFinished; }
            set { timeFinished = value; }
        }
    }
}
