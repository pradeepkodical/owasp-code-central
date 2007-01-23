using System;
using System.Collections.Generic;
using System.Text;
using TigerClient.Document.Condition;
using System.Xml.Serialization;
using System.ComponentModel;

namespace TigerClient.Document
{
    public class Alert: DocumentPart
    {
        private AlertType alertType = AlertType.Red;
        private object condition;
        private string name;
        private string description;
        private string message;

        [Description("Message to display if the condition is met."), Category("Configuration")]
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Message", DocumentPartModificationType.DocumentPartPropertyModified));            
            }
        }

        [Description("Type of alert."), Category("Configuration")]
        public AlertType Type
        {
            get { return alertType; }
            set
            {
                alertType = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Type", DocumentPartModificationType.DocumentPartPropertyModified));            
            }
        }

        [System.ComponentModel.EditorAttribute(typeof(CustomControls.ConditionTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Description("Condition that defines whether this alert is generated."), Category("Configuration")]
        [XmlElement(typeof(ResponseStatusCodeEqualToCondition))]
        [XmlElement(typeof(ResponseStatusCodeEqualToNotCondition))]
        [XmlElement(typeof(ResponseBodyContainsCondition))]
        [XmlElement(typeof(ResponseBodyContainsNotCondition))]
        [XmlElement(typeof(ResponseBodyRegexMatchCondition))]
        [XmlElement(typeof(ResponseBodyRegexMatchNotCondition))]
        [XmlElement(typeof(AndCondition))]
        [XmlElement(typeof(OrCondition))]
        public object Condition
        {
            get { return condition; }
            set
            {
                condition = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Condition", DocumentPartModificationType.DocumentPartPropertyModified));            
            }
        }

        public override string ErrorMessage
        {
            get
            {
                ICondition c = condition as ICondition;
                if (c == null) return "Alert condition must be set.";
                return null;
            }
        }

        public override string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(name)) return name;
                return "<Untitled Alert>";
            }
        }

        [Description("User-friendly name of this alert."), Category("General")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Name", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Description("Description of this alert."), Category("General")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Description", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }
    }
}
