using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;

namespace Owasp.SiteGenerator
{
    class SiteGenerator_Transformers
    {
        private const string SGIdentifier = "_SiteGenerator_";
        public static TextBox tbDebugMessages = null;

        public static string CreateFileW(string strOriginalFileName)
        {
            SiteMapping smCurrent = SiteMapping.GetSiteMapping();

            string strFullPathToRootDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, Path.Combine(ConfigurationManager.AppSettings["StaticPagePath"], "SiteA")));
            string strProcessedFileName = strOriginalFileName;       // defaults to the original one
            if (strOriginalFileName.ToUpper().IndexOf(SGIdentifier) > -1)
            {
                string[] strSplitedRequest = strOriginalFileName.ToUpper().Split(new string[] { SGIdentifier }, StringSplitOptions.RemoveEmptyEntries);
                if (strSplitedRequest.Length == 1)  // we are in the root of the [SG] files so let's point it to strFullPathToRootDir
                    return strFullPathToRootDir;
                if (strSplitedRequest.Length == 2)
                {
                    string strVirtualPathToProcess = strSplitedRequest[1];
                    strVirtualPathToProcess = strVirtualPathToProcess.Replace('-', '\\');
                    string strDirectoryPath = Path.GetDirectoryName(strVirtualPathToProcess);
                    string strFileName = Path.GetFileName(strVirtualPathToProcess);
                    Console.Write("dir: " + strDirectoryPath);
                    Console.WriteLine("file: " + strFileName);
                    if (null == strDirectoryPath)
                    {
                        return strFullPathToRootDir;
                    }
                    XmlNode xnXmlDataToUse = smCurrent.Mapping.DocumentElement.GetElementsByTagName("site")[0];

                    bool bMatch = false;
                    if (null != xnXmlDataToUse)
                    {
                        // map directory                        
                        foreach (string strDirToProcess in strDirectoryPath.Split('\\'))
                        {
                            if (bMatch && strDirToProcess == "")
                                break;                                                          // for the case where strDirToProcess =
                            bMatch = false;
                            foreach (XmlNode xnDirectories in xnXmlDataToUse.ChildNodes)
                            {
                                if (xnDirectories.Attributes.GetNamedItem("name").Value.ToUpper() == strDirToProcess.ToUpper())  // .ToUpper() will make it case insensitive
                                {
                                    xnXmlDataToUse = xnDirectories;
                                    bMatch = true;
                                    break;
                                }
                            }
                        }
                        if (bMatch)
                        {
                            // map File
                            foreach (XmlNode xnFiles in xnXmlDataToUse.ChildNodes)
                            {
                                bMatch = false;
                                if (xnFiles.Attributes.GetNamedItem("name").Value.ToUpper() == strFileName.ToUpper())
                                {
                                    bMatch = true;
                                    string strMappedFileName = xnFiles.Attributes.GetNamedItem("mappedTo").Value;
                                    if (strMappedFileName.IndexOf("~\\") > -1)                                                                           //  "~\\" means use the website base directory                                            
                                        return Path.GetFullPath(Path.Combine(strSplitedRequest[0], strMappedFileName));              // strSplitedRequest[0] contains the what was to the left of GlobalVariables.strSiteGenerator_SGIdentifierString
                                    else
                                        return Path.GetFullPath(Path.Combine(strFullPathToRootDir, strMappedFileName));   //  strFullPathToRootDir contains the full path to this Site's Root Dir (i.e. not the original wwwroot folder)                                                                    
                                }
                            }
                        }
                    }

                }
                else if(SiteGenerator_Transformers.tbDebugMessages != null) 
                {
                    GUI.updateTextBox("CreateFileW Transformer error: more that 1 instance of *", 
                                      SiteGenerator_Transformers.tbDebugMessages);
                }
            }
            return strProcessedFileName;
        }

        public static bool isPathAFolder(string strVirtualPathToProcess,ref XmlNode xnSelectedDirectory)
        {
            SiteMapping smCurrent = SiteMapping.GetSiteMapping();
            char[] charSeperators = new char[] {'/'};

            XmlNode xnXmlDataToUse = smCurrent.Mapping.DocumentElement.GetElementsByTagName("site")[0];             // I wanted to place this here but this becomes null after a while
            bool bMatch = false;
            if (null != xnXmlDataToUse)
            {
                // Handle the root folder case...
                if (strVirtualPathToProcess == "/")
                {
                    xnSelectedDirectory = smCurrent.Mapping.DocumentElement.GetElementsByTagName("rootFolder")[0];
                    bMatch = true;
                }
                else
                {
                    // map directory                        
                    foreach (string strDirToProcess in strVirtualPathToProcess.Split(charSeperators,
                                                                                     StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (bMatch && strDirToProcess == "")
                            break;                                                          // for the case where strDirToProcess =
                        bMatch = false;
                        foreach (XmlNode xnDirectories in xnXmlDataToUse.ChildNodes)
                        {
                            if ((xnDirectories.Name == "folder") || (xnDirectories.Name == "rootFolder"))
                            {

                                // Do a case-insensitive compare
                                XmlNode xnName = xnDirectories.Attributes.GetNamedItem("name");
                                if ((xnName != null) && (xnName.Value.ToUpper() == strDirToProcess.ToUpper()))
                                {
                                    xnXmlDataToUse = xnDirectories;
                                    xnSelectedDirectory = xnDirectories;
                                    bMatch = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (!bMatch)
                xnSelectedDirectory = null;
            return bMatch;
        }



        public static string generateNavigation_flash(string strPathToAnalyze, XmlNode xnSelectedDirectory)
        {
            string strDynamicFlashMenuDir  =  "flash_xml_menu";
            string strDynamicFlashHtmlFile   =   "cromas_xml.htm";
            string strDynamicFlashXmlFile    =   "cromas_menu.xml";            
            string strFullPathToTempNavigationFilesDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,
                                                                          Path.Combine(ConfigurationManager.AppSettings["StaticPagePath"],
                                                                          Path.Combine("SiteA",strDynamicFlashMenuDir))));
            string strFullPathToHtmlWithDirectoryStructure = Path.Combine(strFullPathToTempNavigationFilesDir, strDynamicFlashHtmlFile);
            string strFullPathToTempXmlFileWithDirectoryStructure = Path.Combine(strFullPathToTempNavigationFilesDir, strDynamicFlashXmlFile);
            SiteGenerator_Transformers.generateDirectoryNavigation_flash(xnSelectedDirectory, strFullPathToTempXmlFileWithDirectoryStructure, strPathToAnalyze);
            return  strFullPathToHtmlWithDirectoryStructure ;
        }

        public static void generateDirectoryNavigation_flash(XmlNode xnSelectedDirectory, string strTargetFileName, string strBaseDir)
        {
            StringBuilder strXmlFileContents =new StringBuilder( "<?xml version=\"1.0\" encoding= \"UTF-8\" ?> <menu>");
            foreach (XmlNode xnfile in xnSelectedDirectory.SelectNodes("folder"))
            {
                strXmlFileContents.Append("<button text=\""+xnfile.Attributes.GetNamedItem("name").Value+"\" url=\""+Path.Combine(strBaseDir, xnfile.Attributes.GetNamedItem("name").Value)+"\" target=\"ContentFrame\"></button>");
            }
            strXmlFileContents.Append("<options button_color=\"2E3192\" text_color=\"00FFFF\" cursor_color=\"00FFFF\" custom_cursor=\"false\"></options></menu>");
            utils.files.WriteFileContent(strTargetFileName, strXmlFileContents.ToString());     

        }

        public static string generateNavigation_html(string strPathToAnalyze, XmlNode xnSelectedDirectory, bool showFiles, bool verticalMenu)
        {
            string strFullPathToTempNavigationFilesDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,
                                                                                       Path.Combine(ConfigurationManager.AppSettings["StaticPagePath"],
                                                                                                    Path.Combine("SiteA", ConfigurationManager.AppSettings["tempNavigationFiles"]))));
            string strTempFileName = strPathToAnalyze.Replace("/", "_") + ".htm";
            string strFullPathToTempFileWithDirectoryStructure = Path.Combine(strFullPathToTempNavigationFilesDir, strTempFileName);
            SiteGenerator_Transformers.generateDirectoryNavigation_html(xnSelectedDirectory, strPathToAnalyze, strFullPathToTempFileWithDirectoryStructure, showFiles, verticalMenu);
            return  strFullPathToTempFileWithDirectoryStructure;
        }

        public static void generateDirectoryNavigation_html(XmlNode xnSelectedDirectory, string strBaseDir, string strTargetFileName, bool showFiles, bool verticalMenu)
        {
            StringBuilder strFileHtmlContents = new StringBuilder("<html><body>");
            if ((strBaseDir.Length > 1) && (strBaseDir[strBaseDir.Length - 1] == '/'))
                strBaseDir = strBaseDir.Substring(0,strBaseDir.Length - 1);
            if ((strBaseDir.Length > 1))
            {
                string strUpDirectory = strBaseDir.Substring(0,strBaseDir.LastIndexOf("/")+1);
                strFileHtmlContents.Append("<a href='" + strUpDirectory + "' target='ContentFrame'>");
                strFileHtmlContents.Append("<b>..</b></a>");
                if (verticalMenu)
                    strFileHtmlContents.Append("<br>");
                else
                    strFileHtmlContents.Append(" - ");
            }
            if (strBaseDir[strBaseDir.Length - 1] != '/')
                strBaseDir += "/";
            foreach (XmlNode xnfile in xnSelectedDirectory.SelectNodes("folder"))
            {
                strFileHtmlContents.Append("<a href='" + strBaseDir  + xnfile.Attributes.GetNamedItem("name").Value + "' target='ContentFrame'>");
                strFileHtmlContents.Append("<b>" + xnfile.Attributes.GetNamedItem("name").Value + "</b></a>");
                if (verticalMenu)
                    strFileHtmlContents.Append("<br>");
                else
                    strFileHtmlContents.Append(" - ");
            }
            if (showFiles)
            {
                foreach (XmlNode xnfile in xnSelectedDirectory.SelectNodes("file"))
                {
                    strFileHtmlContents.Append("<a href='" + strBaseDir + xnfile.Attributes.GetNamedItem("name").Value + "' target='ContentFrame'>");
                    strFileHtmlContents.Append("" + xnfile.Attributes.GetNamedItem("name").Value + "</a>");
                    if (verticalMenu)
                        strFileHtmlContents.Append("<br>");
                    else
                        strFileHtmlContents.Append(" - ");
                }
            }
            strFileHtmlContents.Append("</html></body>");

            utils.files.WriteFileContent(strTargetFileName, strFileHtmlContents.ToString());            
        }

        /// <summary>
        /// History:
        /// 
        /// 12/9/2006 - Mike : Had to add a check for the attribute count when checking directories because
        ///                    of the new altova hack.
        /// </summary>
        /// <param name="strVirtualPathToProcess"></param>
        /// <param name="bMatch"></param>
        /// <returns></returns>
        public static string resolveNameAndFolder(string strVirtualPathToProcess, ref bool bMatch)
        {
            try
            {
                string strDirectoryPath = Path.GetDirectoryName(strVirtualPathToProcess);
                string strFileName = Path.GetFileName(strVirtualPathToProcess);
                SiteMapping smCurrent = SiteMapping.GetSiteMapping();
                
                if (null == strDirectoryPath)
                {
                    return strVirtualPathToProcess;
                }
                XmlNode xnXmlDataToUse = smCurrent.Mapping.DocumentElement.GetElementsByTagName("rootFolder")[0];             // I wanted to place this here but this becomes null after a while

                if (null != xnXmlDataToUse)
                {
                    // map directory                        
                    foreach (string strDirToProcess in strDirectoryPath.Split('\\'))
                    {
                        if (bMatch && strDirToProcess == "")
                            break;                                                          // for the case where strDirToProcess =
                        bMatch = false;
                        foreach (XmlNode xnDirectories in xnXmlDataToUse.ChildNodes)
                        {
                            if ((xnDirectories.Attributes.Count > 0) && 
                                (xnDirectories.Attributes.GetNamedItem("name").Value.ToUpper() == strDirToProcess.ToUpper()))  
                            {
                                xnXmlDataToUse = xnDirectories;
                                bMatch = true;
                                break;
                            }
                        }
                    }
                    if (bMatch || strDirectoryPath == "\\")                     // case when we find a match on a sub dir and case when we are on the root
                    {
                        // map File
                        foreach (XmlNode xnFiles in xnXmlDataToUse.ChildNodes)
                        {
                            bMatch = false;
                            if (xnFiles.Attributes.GetNamedItem("name").Value.ToUpper() == strFileName.ToUpper())
                            {
                                bMatch = true;
                                string strMappedFileName = xnFiles.Attributes.GetNamedItem("mappedTo").Value;
                                return strMappedFileName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in resolveNameAndFolder:  " + ex.Message);                
            }
            bMatch = false;
            return strVirtualPathToProcess;
        }        
   }
}
