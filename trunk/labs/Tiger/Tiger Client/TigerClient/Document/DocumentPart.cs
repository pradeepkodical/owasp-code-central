using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TigerClient.Document
{
    public abstract class DocumentPart
    {
        protected int id;
        protected DocumentPart parent;

        protected DocumentPart()
        {
            id = Utilities.IdGenerator.GetID();
        }

        [Browsable(false)]
        public int ID
        {
            get { return id; }
        }

        [Browsable(false)]
        [System.Xml.Serialization.XmlIgnore()]
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

        [Browsable(false)]
        public abstract string ErrorMessage { get; }

        [Browsable(false)]
        public abstract string DisplayName { get; }

        [Browsable(false)]
        public virtual bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(ErrorMessage); 
            }
        }

        protected virtual void OnModified(DocumentPartModifiedEventArgs e)
        {
            if (parent != null) parent.OnModified(e);
        }
    }
}
