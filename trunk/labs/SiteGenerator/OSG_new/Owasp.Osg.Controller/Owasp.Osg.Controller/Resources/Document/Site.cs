using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Owasp.Osg.Controller.Document
{
    public class Site: DocumentPart
    {
        protected List<DocumentPart> contents;

        public Site()
        {
            contents = new List<DocumentPart>();
        }

        [XmlElement(Type=typeof(Document.File), ElementName="file")]
        [XmlElement(Type=typeof(Document.Folder), ElementName="folder")]
        public List<DocumentPart> Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        public override string ErrorMessage
        {
            get { throw new NotImplementedException(); }
        }
    }
}
