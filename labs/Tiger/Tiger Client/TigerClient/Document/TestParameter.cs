using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TigerClient.Document
{
    public class TestParameter: DocumentPart
    {
        private string name;
        private string value;

        [Category("Configuration")]
        public string Name
        {
            get { return name; }
            set
            { 
                name = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Name", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Category("Configuration")]
        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Value", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return "<Parameter>";
                else
                    return name;
            }
        }

        public override string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return "Parameter name must be provided.";
                else
                    return null;
            }
        }
    }
}
