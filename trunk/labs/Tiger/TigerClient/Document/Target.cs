using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TigerClient.Document
{
    public class Target: DocumentPart
    {
        private string path;
        private string name;
        private string description;

        //private TestCollection automatedTests = new TestCollection();
        private DocumentPartCollection<AutomatedTest> automatedTests = new DocumentPartCollection<AutomatedTest>();

        public Target()
        {
            automatedTests.Modified += new EventHandler<DocumentPartModifiedEventArgs>(automatedTestsCollectionModifed);
        }

        //public Target(string path)
        //{
        //    this.Path = path;
        //}

        //public Target(string path, string name)
        //{
        //    this.Path = path;
        //    this.Name = name;
        //}

        [Description("User-friendly name of this target"), Category("General")]
        public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Name", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Description("Description of this target"), Category("General")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Description", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Description("Base path for all test files for this target"), Category("Configuration")]
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Path", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [DisplayName("Tests"), Description("This target's tests"), Category("Configuration")]
        [XmlArrayItem(Type = typeof(AutomatedTest), ElementName = "Test")]
        public DocumentPartCollection<AutomatedTest> AutomatedTests
        {
            get { return automatedTests; }
            set
            {
                automatedTests = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "AutomatedTests", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        protected bool ValidatePath(string path)
        {
            try
            {
                Uri uri = new Uri(path);
                if (uri.Scheme.ToUpper() != "HTTP" && uri.Scheme.ToUpper() != "HTTPS")
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(name))
                return Name;
            else
                return Path;
        }

        public override string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(Name)) return Name;
                if (!string.IsNullOrEmpty(Path)) return Path;
                return "<Untitled Target>";
            }
        }

        public override string ErrorMessage
        {
            get
            {
                if (!ValidatePath(path))
                    return "Target path is not valid.";
                else
                {
                    foreach (AutomatedTest t in AutomatedTests)
                        if (!t.IsValid) return "Some tests for this target are not valid.";
                }

                return null;
            }
        }

        private void automatedTestsCollectionModifed(object sender, DocumentPartModifiedEventArgs e)
        {
            if (e.AffectedDocumentPart != null)
                if (e.AffectedDocumentPart.Parent == null)
                    e.AffectedDocumentPart.Parent = this;

            DocumentPartModifiedEventArgs eventArgs;

            if (e.ModificationType == DocumentPartModificationType.ChildDocumentPartsCleared)
                eventArgs = new DocumentPartModifiedEventArgs(this, "AutomatedTests", DocumentPartModificationType.ChildDocumentPartsCleared);
            else
                eventArgs = e;

            OnModified(eventArgs);
        }
    }
}
