using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;

namespace Owasp.SiteGenerator.utils
{
    class xml
    {
        public static bool CreateDynamicWebsite (string strWebsiteName)
        {
            string ContentPagesPath = ConfigurationManager.AppSettings["ContentPagesRoot"];
            string strNewDynamicWebsiteName = Path.GetFullPath(Path.Combine(ContentPagesPath, strWebsiteName));
            string templateSitePath = Path.GetFullPath(Path.Combine(ContentPagesPath, @"_templates\_templateSite.xml"));
            if (strNewDynamicWebsiteName.IndexOf(".xml") == -1)
                strNewDynamicWebsiteName += ".xml";
            File.Copy(templateSitePath, strNewDynamicWebsiteName, true);
            return true;
        }

        public static XmlElement addElementToNode(XmlDocument xdWorkingXmlDocument, XmlNode xnNodeToAdd, string strNewElementName)
        {
            XmlElement xeElementToAdd = xdWorkingXmlDocument.CreateElement(strNewElementName);
            xnNodeToAdd.AppendChild(xeElementToAdd);
            return xeElementToAdd;
        }

        public static void addFileToFolder(XmlDocument xdWorkingXmlDocument, XmlNode xnNodeToAdd, string strName, string strMappedTo)
        {
            XmlElement xeNewFile = xdWorkingXmlDocument.CreateElement("file");            
            XmlAttribute xaName = xdWorkingXmlDocument.CreateAttribute("name");
            xaName.Value = strName;
            xeNewFile.Attributes.Append(xaName);
            XmlAttribute xaMappedTo = xdWorkingXmlDocument.CreateAttribute("mappedTo");
            xaMappedTo.Value = strMappedTo;
            xeNewFile.Attributes.Append(xaMappedTo);
            xnNodeToAdd.AppendChild(xeNewFile);

        }

        public static XmlElement addFolderToFolder(XmlDocument xdWorkingXmlDocument, XmlNode xnNodeToAdd, string strName)
        {
            XmlElement xeNewFolder = xdWorkingXmlDocument.CreateElement("folder");
            XmlAttribute xaName = xdWorkingXmlDocument.CreateAttribute("name");
            xaName.Value = strName;
            xeNewFolder.Attributes.Append(xaName);
            xnNodeToAdd.AppendChild(xeNewFolder);
            return xeNewFolder;
        }
        
    }
}
