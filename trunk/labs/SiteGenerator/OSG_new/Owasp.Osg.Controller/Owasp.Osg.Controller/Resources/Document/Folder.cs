using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Owasp.Osg.Controller.Document
{
    public class Folder : DocumentPart
    {
        protected List<DocumentPart> contents;

        public Folder()
        {
            contents = new List<DocumentPart>();
        }

        public Folder(string name)
            : base(name)
        {
            contents = new List<DocumentPart>();
        }

        [XmlElement(Type = typeof(Document.File), ElementName = "file")]
        [XmlElement(Type = typeof(Document.Folder), ElementName = "folder")]
        public List<DocumentPart> Contents
        {
            get { return contents; }
        }

        public override string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return "Name must be provided.";
                else
                    return "";
            }
        }
    }
}
