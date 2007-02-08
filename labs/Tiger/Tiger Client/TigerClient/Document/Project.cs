using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace TigerClient.Document
{
    public class Project: DocumentPart, IDocument
    {
        private string name;
        private string description;
        private string filePath;
        private bool isModified;
        private TestStatusType status;
        private string statusMessage;

        public event EventHandler<DocumentPartModifiedEventArgs> Modified;

        [XmlArrayItem(Type = typeof(Target))]
        private DocumentPartCollection<Target> targets = new DocumentPartCollection<Target>();
        //private TargetCollection targets = new TargetCollection();

        public Project()
        {
            targets.Modified += new EventHandler<DocumentPartModifiedEventArgs>(targetsCollectionModifed);
        }

        [XmlIgnore(), Category("Status")]
        public TestStatusType Status
        {
            get { return status; }
            private set
            {
                status = value;
                // this is a transient property, so I commented out the following line
                //OnModified(new DocumentPartModifiedEventArgs(this, "Status", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [XmlIgnore(), Category("Status")]
        public string StatusMessage
        {
            get { return statusMessage; }
            private set
            {
                statusMessage = value;
                // this is a transient property, so I commented out the following line
                //OnModified(new DocumentPartModifiedEventArgs(this, "StatusMessage", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Description("User-friendly name of this project"), Category("General")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Name", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Description("Description of this project"), Category("General")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Description", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Description("This project's targets"), Category("Configuration")]
        public DocumentPartCollection<Target> Targets
        {
            get { return targets; }
            set
            {
                targets = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Targets", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        private void targetsCollectionModifed(object sender, DocumentPartModifiedEventArgs e)
        {
            if (e.AffectedDocumentPart != null)
                if (e.AffectedDocumentPart.Parent == null)
                    e.AffectedDocumentPart.Parent = this;

            DocumentPartModifiedEventArgs eventArgs;

            if (e.ModificationType == DocumentPartModificationType.ChildDocumentPartsCleared)
                eventArgs = new DocumentPartModifiedEventArgs(this, "Targets", DocumentPartModificationType.ChildDocumentPartsCleared);
            else
                eventArgs = e;

            OnModified(eventArgs);
        }

        public static Project LoadFromFile(string filePath)
        {
            FileStream input = null;

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(Project));
                input = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Project p = (Project)s.Deserialize(input);
                p.filePath = filePath;
                p.isModified = false;
                return p;
            }
            finally
            {
                if (input != null) input.Close();
            }
        }

        public static Project New()
        {
            Project p = new Project();
            p.name = "<Untitled Project>";
            p.isModified = false;
            return p;
        }

        public static Project NewFromTemplate(string templateFilePath)
        {
            FileStream input = null;

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(Project));
                input = new FileStream(templateFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Project p = (Project)s.Deserialize(input);
                p.name = "<Untitled Project>";
                p.isModified = false;
                return p;
            }
            finally
            {
                if (input != null) input.Close();
            }
        }

        #region IDocument Members

        [Browsable(false)]
        public bool IsModified
        {
            get { return isModified; }
        }

        [DisplayName("File Path"), Description("Full path of this project file"), Category("General")]
        public string FilePath
        {
            get { return filePath; }
        }

        [Browsable(false)]
        public string Title
        {
            get
            {
                string title = null;

                if (!string.IsNullOrEmpty(filePath))
                    title = Path.GetFileName(filePath);
                else
                    title = "<Untitled Project>";

                if (isModified) title += "*";

                return title;
            }
        }

        public void SaveAs(string filePath)
        {
            StreamWriter writer = null;

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(Project));
                writer = new StreamWriter(filePath);
                s.Serialize(writer, this);
                writer.Close();
                this.filePath = filePath;
                isModified = false;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(filePath))
                throw new InvalidOperationException("The \"Save\" method must not be called on documents that have never been saved before.");

            SaveAs(this.filePath);
        }

        #endregion

        public override string DisplayName
        {
            get { return Name; }
        }

        public override string ErrorMessage
        {
            get
            {
                foreach (Document.Target t in Targets)
                    if (!t.IsValid) return "Some targets for this project are not valid.";

                int totalTests = 0;
                foreach (Document.Target t in Targets)
                    totalTests += t.AutomatedTests.Count;

                if (totalTests == 0) return "There are no tests in this project.";

                return null;
            }
        }

        protected override void OnModified(DocumentPartModifiedEventArgs e)
        {
            isModified = true;
            if (Modified != null) Modified(this, e);
            base.OnModified(e);
        }
    }
}
