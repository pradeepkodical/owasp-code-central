using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Owasp.Osg.Controller.Document
{
    public abstract class DocumentPart
    {
        protected string name;
        protected DocumentPart parent;

        public DocumentPart()
        {
        }

        public DocumentPart(string name)
        {
            this.name = name;
        }

        [XmlAttribute(AttributeName = "name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnModified(new EventArgs());
            }
        }

        public DocumentPart Parent
        {
            get { return parent; }
            set
            {
                if (parent == null)
                    parent = value;
                else
                    throw new InvalidOperationException("Reassigning value to the \"Parent\" property is not allowed.");
            }
        }

        public abstract string ErrorMessage { get; }

        public virtual bool IsValid
        {
            get { return string.IsNullOrEmpty(ErrorMessage); }
        }

        protected virtual void OnModified(EventArgs e)
        {
            if (parent != null) parent.OnModified(e);
        }
    }
}
