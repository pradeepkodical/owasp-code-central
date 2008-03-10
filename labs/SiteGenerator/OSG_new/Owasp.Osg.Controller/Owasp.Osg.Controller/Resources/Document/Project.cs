using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Owasp.Osg.Controller.Document
{
    [XmlRoot("SiteGenerator")]
    public class Project
    {
        protected Site site;
        protected string name;
        protected bool isModified;
        protected string filePath;

        public Project()
        {
            site = new Site();
        }

        //public override string ErrorMessage
        //{
        //    get { return ""; }
        //}

        public static Project New()
        {
            Project p = new Project();
            p.Name = "<Untitled>";
            p.isModified = false;
            return p;
        }

        public static Project NewFromTemplate(string templateFilePath)
        {
            //FileStream input = null;

            //try
            //{
            //    XmlSerializer s = new XmlSerializer(typeof(Project));
            //    input = new FileStream(templateFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //    Project p = (Project)s.Deserialize(input);
            //    p.name = "<Untitled Project>";
            //    p.isModified = false;
            //    return p;
            //}
            //finally
            //{
            //    if (input != null) input.Close();
            //}

            return null;
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

        public bool IsModified
        {
            get { return isModified; }
        }

        public string FilePath
        {
            get { return filePath; }
        }

        public string Title
        {
            get
            {
                string title = null;

                if (!string.IsNullOrEmpty(filePath))
                    title = Path.GetFileName(filePath);
                else
                    title = "<Untitled>";

                if (isModified) title += "*";

                return title;
            }
        }

        [XmlAttribute(AttributeName = "name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlElement("site")]
        public Site Site
        {
            get { return site; }
            set
            {
                site = value;
            }
        }

        [XmlAttribute(AttributeName="formatVersion")]
        public string FormatVersion
        {
            get { return "1.0"; }
            set { }
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(filePath))
                throw new InvalidOperationException("The \"Save\" method must not be called on documents that have never been saved before.");

            SaveAs(this.filePath);
        }

        public void SaveAs(string filePath)
        {
            StreamWriter writer = null;

            try
            {
                // string defaultNamespace = "http://www.owasp.org/sitegenerator/sitemap";
                //XmlSerializer s = new XmlSerializer(typeof(Project), defaultNamespace);
                
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
    }
}
