using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Owasp.Osg.Controller.Document
{
    public class File : DocumentPart
    {
        protected string mappedTo;

        public File()
        {
        }

        public File(string name, string mappedTo)
            : base(name)
        {
            this.mappedTo = mappedTo;
        }

        [XmlAttribute(AttributeName="mappedTo")]
        public string MappedTo
        {
            get { return mappedTo; }
            set
            {
                mappedTo = value;
                OnModified(new EventArgs());
            }
        }

        public override string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return "Name must be provided.";
                else if (string.IsNullOrEmpty(mappedTo))
                    return "Must be mapped to a physical file.";
                else if (!System.IO.File.Exists(mappedTo))
                    return "File does not exist.";
                else
                    return "";
            }
        }
    }
}
