using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Configuration;

namespace Owasp.SiteGenerator.ascx
{
    public partial class WebsiteCreator : UserControl
    {

        private string strTopHtmlCode = "<html><head></head><body>";
        private string strBottomHtmlCode = "</body></html>";
        private string strDefaultLinkHtmlTarget = "dynamic_contentPage";
        private string strHomePage = "Default.htm";
        private string strLinkToHomePage = "";
        private XmlNode xnCurrentXmlNode = null;
        private XmlDocument xdCurrentXmDocument = null;
        private int iCurrentIndexInVulnerabilityList = 0;
        private string strLocalSiteDirectory = "";
        int iNumberOfPages= 0;
        int iNumberOfDirectories= 0;
        int iUniqueID = 0;
        private string ContentPagesPath = ConfigurationManager.AppSettings["ContentPagesRoot"];

        public WebsiteCreator()
        {
            InitializeComponent();
        }

        private void btCreateDinamicWebsite_Click(object sender, EventArgs e)
        {
            iCurrentIndexInVulnerabilityList = 0;
            iNumberOfPages = 0;
            iNumberOfDirectories = 0;
            btCreateDinamicWebsite.Enabled = false;            
            int iNumberOfLevels, iNumberOfDirectoriesPerLevel, iNumberOfPagesPerDirectory;
            if (!Int32.TryParse(txtNumberOfLevels.Text, out iNumberOfLevels) || !Int32.TryParse(txtNumberOfDirectoriesPerLevel.Text, out iNumberOfDirectoriesPerLevel) || !Int32.TryParse(txtNumberOfPagesPerDirectory.Text, out iNumberOfPagesPerDirectory)) //  (Int32.TryParse(txtNumberOfLevels.Text,System.Globalization.NumberStyles.Integer,new System.Globalization.NumberFormatInfo(),out iNumberOfLevels))            
                MessageBox.Show("All number provided must be an Integers");            
            else
            {
                string strWebsiteName = txtSiteName.Text;;
                if (utils.xml.CreateDynamicWebsite(strWebsiteName))
                {
                    string strPathToDynamicWebsiteXmlFile = Path.GetFullPath(Path.Combine(ContentPagesPath, strWebsiteName + ".xml"));
                    XmlDocument xdDynamicWebsite = new XmlDocument();
                    xdDynamicWebsite.Load(strPathToDynamicWebsiteXmlFile);                    
                    XmlNode xnSiteElement = xdDynamicWebsite.GetElementsByTagName("site")[0];
                    XmlElement xeRootFolder = utils.xml.addElementToNode(xdDynamicWebsite, xnSiteElement, "rootFolder");
                    

                    string strCurrentDirectory = strWebsiteName;
                    strLinkToHomePage =  "/" + strHomePage;
                    deletePreviousProjectDirectory(strCurrentDirectory);
                    createDirectory(strCurrentDirectory);

                    // creating home page
                    createFile(strCurrentDirectory, strHomePage, returnHomePageHtmlCode());

                    utils.xml.addFileToFolder(xdDynamicWebsite, xeRootFolder, strHomePage, strCurrentDirectory + "/" + strHomePage);
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeRootFolder, "SiteGenerator_Banner.html", "SiteGenerator_Banner.html");
                    XmlElement xeImagesFolder = utils.xml.addFolderToFolder(xdDynamicWebsite, xeRootFolder, "images");
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeImagesFolder, "topBanner_slice.gif", "images/topBanner_slice.gif");    
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeImagesFolder, "leftBanner.png", "images/leftBanner.png");    
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeImagesFolder, "owasp_logo.png", "images/owasp_logo.png");    
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeImagesFolder, "leftBanner.png", "images/leftBanner.png");
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeImagesFolder, "Foundstone_logo.jpg", "images/Foundstone_logo.jpg");                                    

                    // creating Main navigation
                    string strFileName = "TopNavigation.htm";
                    xdCurrentXmDocument = xdDynamicWebsite;
                    xnCurrentXmlNode = xeRootFolder;
                    strLocalSiteDirectory = strCurrentDirectory;
                    createFile(strCurrentDirectory, strFileName, createNavigationPage(iNumberOfDirectoriesPerLevel, iNumberOfPagesPerDirectory, 0));
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeRootFolder, "TopNavigation.htm", strCurrentDirectory + "/TopNavigation.htm");
                    utils.xml.addFileToFolder(xdDynamicWebsite, xeRootFolder, "NormalPage.htm",  "htm/NormalPage.htm");
                    // creating rest of navigation and files
                    iNumberOfDirectories++;
                    
                    for (int iLevel = 0; iLevel < iNumberOfLevels + 1; iLevel++)
                    {
                        for (int iDirectory = 0; iDirectory < iNumberOfDirectoriesPerLevel; iDirectory++)
                        {
                            strFileName = "Navigation_Level_" + iLevel.ToString() + "_SubLevel_" + iDirectory.ToString() + ".html";
                            if (iLevel < iNumberOfLevels)     // in the last one we don't need the links to the sub Folders
                                createFile(strCurrentDirectory, strFileName, createNavigationPage(iNumberOfDirectoriesPerLevel, iNumberOfPagesPerDirectory, iLevel + 1));
                            else
                                createFile(strCurrentDirectory, strFileName, createNavigationPage(0, iNumberOfPagesPerDirectory, iLevel + 1));
                            iNumberOfDirectories++;
                            iNumberOfPages += iNumberOfPagesPerDirectory;
                        }
                    }
                    xdDynamicWebsite.Save(strPathToDynamicWebsiteXmlFile);
                    // PATCH to fix xmlns namespace conflic
                    string strFileContents = utils.files.GetFileContent(strPathToDynamicWebsiteXmlFile).Replace("xmlns=\"\"", "");
                    utils.files.WriteFileContent(strPathToDynamicWebsiteXmlFile, strFileContents);                              
                }
            }
            lbDirectoriesInThisSite.Text = iNumberOfDirectories.ToString();
            lbPagesInThisSite.Text = iNumberOfPages.ToString();
            
            btCreateDinamicWebsite.Enabled = true;
        }

        private string createNavigationPage(int iNumberOfFolder, int iNumberOfPages, int iCurrentLevel)
        {            
            string strPageContents = strTopHtmlCode;
            strPageContents += html_BR();
            strPageContents += html_BR();
            for (int i = 0; i < iNumberOfFolder; i++)
            {                
                string strLinkName = "Level_" + iCurrentLevel.ToString() + "_SubLevel_" + i.ToString();
                string strLinkUrl = "Navigation_" +strLinkName+".html";
                strPageContents += html_A(strLinkUrl, strLinkName, "_self");
                strPageContents += html_BR();
                utils.xml.addFileToFolder(xdCurrentXmDocument, xnCurrentXmlNode, strLinkUrl, strLocalSiteDirectory + "\\" + strLinkUrl);
            }
            strPageContents += html_HR();
            for (int i = 0; i < iNumberOfPages; i++)
            {
                string strLinkUrl = lbCurrentListOfVulnerabilities.Items[iCurrentIndexInVulnerabilityList].ToString();
                iUniqueID++;
                string strLink = iUniqueID.ToString() + "_" + lbCurrentListOfVulnerabilities.Items[iCurrentIndexInVulnerabilityList].ToString();
                string strLinkName = Path.GetFileNameWithoutExtension(strLinkUrl);
                strPageContents += html_A(strLink, strLinkName, strDefaultLinkHtmlTarget);
                strPageContents += html_BR();
                iCurrentIndexInVulnerabilityList++;
                if (iCurrentIndexInVulnerabilityList == lbCurrentListOfVulnerabilities.Items.Count)
                    iCurrentIndexInVulnerabilityList = 0;
                utils.xml.addFileToFolder(xdCurrentXmDocument, xnCurrentXmlNode, strLink, "Vulnerabilities\\" + strLinkUrl);
            }        
            strPageContents += html_HR();
            strPageContents += strBottomHtmlCode;
            return strPageContents;
        }

        private string html_A(string strUrl, string strName, string strTargetFrame)
        {
            return "<a href=\"" + strUrl + "\" target =\"" + strTargetFrame + "\">" + strName + "</a>" + Environment.NewLine;
        }

        private string html_BR()
        {
            return "<br/>" + Environment.NewLine;
        }

        private string html_HR()
        {
            return "<hr/>" + Environment.NewLine;
        }

        private void updateDebugWindow(string txtTextToWrite)
        {
            txtDebugWindow.Text = txtTextToWrite + Environment.NewLine + txtDebugWindow.Text;
        }
        private void createDirectory(string strDirectoryTocreate)
        {
            string strFullPathToDirectoryToCreate = Path.Combine(ContentPagesPath, strDirectoryTocreate);            
            updateDebugWindow("Creating Dir  : " + strDirectoryTocreate);
            Directory.CreateDirectory(strFullPathToDirectoryToCreate);            
        }

        private void createFile(string strTargetDirectory, string strFileToCreate, string strFileContents)
        {
            string strVirtualPathToFileToCreate = Path.Combine(strTargetDirectory, strFileToCreate);
            string strFullPathToFileToCreate = Path.Combine(ContentPagesPath, strVirtualPathToFileToCreate);
            updateDebugWindow("Creating File: " + strVirtualPathToFileToCreate);
            utils.files.WriteFileContent(strFullPathToFileToCreate, strFileContents);            
        }

        private void deletePreviousProjectDirectory(string strDirectoryToDelete)
        {
            string strFullPathToDirectoryToDelete = Path.Combine(ContentPagesPath, strDirectoryToDelete);
            if (Directory.Exists(strFullPathToDirectoryToDelete))
                Directory.Delete(strFullPathToDirectoryToDelete, true);
        }

        private void WebsiteCreator_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                populateListViewWithCurrentListOfVulnerabilities();
            }
        }

        private void populateListViewWithCurrentListOfVulnerabilities()
        {
            lbCurrentListOfVulnerabilities.Items.Clear();
            string strPathToVulnerabilties = Path.Combine(ContentPagesPath, "Vulnerabilities");
            foreach (string fiVulnerabilitiyFile in Directory.GetFiles(strPathToVulnerabilties,"*.aspx"))
                lbCurrentListOfVulnerabilities.Items.Add(Path.GetFileName(fiVulnerabilitiyFile));
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void btRemoveItemFromList_Click(object sender, EventArgs e)
        {
            int iNumberOfItemsToDelete = lbCurrentListOfVulnerabilities.SelectedItems.Count;
            for (int i = 0; i < iNumberOfItemsToDelete; i++ )
                lbCurrentListOfVulnerabilities.Items.Remove(lbCurrentListOfVulnerabilities.SelectedItem);                                    
        }

        private void btReloadList_Click(object sender, EventArgs e)
        {
            populateListViewWithCurrentListOfVulnerabilities();
        }

        private string returnHomePageHtmlCode()
        {
            string strHomePageHtmlCode = "";
            strHomePageHtmlCode += "<html>";
            strHomePageHtmlCode += "	<head>";
            strHomePageHtmlCode += "		<TITLE>SiteGenerator DynamicWebsite</TITLE>";
            strHomePageHtmlCode += "	</head>";
            strHomePageHtmlCode += "	<FRAMESET>";
            strHomePageHtmlCode += "		<FRAMESET rows=\"140, *\" border=\"1\">";
            strHomePageHtmlCode += "			<FRAME name=\"Top\" src=\"SiteGenerator_Banner.html\"/>";
            strHomePageHtmlCode += "			<FRAMESET cols=\"350, *\" border=\"1\">";
            strHomePageHtmlCode += "				<FRAME name=\"Navigation\" id=\"Main\" src=\"TopNavigation.htm\"/>";
            strHomePageHtmlCode += "				<FRAME name=\"dynamic_contentPage\" id=\"dynamic_contentPage\" src=\"NormalPage.htm\"/>";
            strHomePageHtmlCode += "			</FRAMESET>";
            strHomePageHtmlCode += "		</FRAMESET>";
            strHomePageHtmlCode += "	</FRAMESET>";
            strHomePageHtmlCode += "</html>";
            return strHomePageHtmlCode;
        }
    }
}

