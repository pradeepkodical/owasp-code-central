using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document
{
    public class DocumentPartModifiedEventArgs: EventArgs
    {
        protected string propertyName;
        protected DocumentPart affectedDocumentPart;
        protected DocumentPartModificationType modificationType;

        public DocumentPartModifiedEventArgs(DocumentPart affectedDocumentPart, string propertyName, DocumentPartModificationType modificationType)
        {
            this.propertyName = propertyName;
            this.affectedDocumentPart = affectedDocumentPart;
            this.modificationType = modificationType;
        }

        public DocumentPartModificationType ModificationType
        {
            get { return modificationType; }
        }
        
        public string PropertyName
        {
            get { return propertyName; }
        }

        public DocumentPart AffectedDocumentPart
        {
            get { return affectedDocumentPart; }
        }
    }
}
