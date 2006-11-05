using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace Owasp.SiteGenerator
{
    class SiteGenerator_HelperClasses
    {
        public static void loadXmlDatabase(XmlDocument xdTargetXmlFile , string strFullPathToXmlDatabase)
        {            
            if (File.Exists(strFullPathToXmlDatabase))
                xdTargetXmlFile.Load(strFullPathToXmlDatabase);
        }
    }
}
