using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Configuration;

namespace Owasp.SiteGenerator.ascx
{
    public partial class ascxDynamicWebSites : UserControl
    {
        private string ContentPagesPath = ConfigurationManager.AppSettings["ContentPagesRoot"];

        public ascxDynamicWebSites()
        {
            InitializeComponent();   
        }

        public void populateDynamicWebsitesListBox()
        {
            utils.WindowsForms.loadFilesIntoListBox(lbDynamicWebsites, ContentPagesPath,"*.xml");
        }

        private void ascxDynamicWebSites_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                populateDynamicWebsitesListBox();
            }
        }

        private void lbDynamicWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dynamicWebsiteSPSPath = Path.GetFullPath(Path.Combine(ContentPagesPath, "DynamicWebsites.sps"));
            string strXmlFileToLoad = Path.GetFullPath(Path.Combine(ContentPagesPath, lbDynamicWebsites.Text));
            string dynamicWebsiteXSDPath = Path.GetFullPath(Path.Combine(ContentPagesPath, "DynamicWebsites.xsd"));
            utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_DynamicWebsites, strXmlFileToLoad, dynamicWebsiteXSDPath, dynamicWebsiteSPSPath);
            txtDynamicWebsitesTextXmlView.Text = utils.files.GetFileContent(strXmlFileToLoad);
            btLoadXmlFileIntoSiteGenerator_Click(null, null);
        }

        private void btLoadXmlFileIntoSiteGenerator_Click(object sender, EventArgs e)
        {
            string strXmlFileToLoad = Path.GetFullPath(Path.Combine(ContentPagesPath, lbDynamicWebsites.Text));
            SiteMapping sm = SiteMapping.GetSiteMapping();

            sm.LoadNewMapping(strXmlFileToLoad);

            lbCurrentXmlFileLoaded.Text = lbDynamicWebsites.Text;
        }

        private void btSaveAndReloadXmlFile_Click(object sender, EventArgs e)
        {
            string strXmlFileToSave = Path.GetFullPath(Path.Combine(ContentPagesPath, lbDynamicWebsites.Text));
            if (tbDynamicWebsiteViews.SelectedIndex==0)
                axAuthentic_DynamicWebsites.Save();
            if (tbDynamicWebsiteViews.SelectedIndex == 1)
                utils.files.WriteFileContent(strXmlFileToSave, txtDynamicWebsitesTextXmlView.Text);
            lbDynamicWebsites_SelectedIndexChanged(null, null);
            lbFileSaved.Visible = true;
        }

        private void btCreateDynamicWebsite_Click(object sender, EventArgs e)
        {
            utils.xml.CreateDynamicWebsite(txtNewDynamicWebsiteName.Text);
            populateDynamicWebsitesListBox();
        }

        private void axAuthentic_DynamicWebsites_SelectionChanged(object sender, EventArgs e)
        {
            lbFileSaved.Visible = false;
        }

        private void txtDynamicWebsitesTextXmlView_TextChanged(object sender, EventArgs e)
        {
            lbFileSaved.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            populateDynamicWebsitesListBox();
        }

        private void btnDelCurrentSite_Click(object sender, EventArgs e)
        {
            RemoveSelectedWebsite();
        }

        /// <summary>
        /// This method removes a selected website.  
        /// </summary>
        private void RemoveSelectedWebsite()
        {
            // make sure someone has a list selected
            if (lbDynamicWebsites.SelectedIndex >= 0)
            {
                string projectName = lbDynamicWebsites.Items[lbDynamicWebsites.SelectedIndex].ToString();
                projectName = projectName.Replace(".xml", "");
                string projectPath = Path.GetFullPath(Path.Combine(ConfigurationManager.AppSettings["ContentPagesRoot"],
                                                                   projectName));
                string configLocation = Path.GetFullPath(Path.Combine(ConfigurationManager.AppSettings["ContentPagesRoot"], 
                                                                      lbDynamicWebsites.Items[lbDynamicWebsites.SelectedIndex].ToString()));  

                if (Directory.Exists(projectPath))
                {
                    Directory.Delete(projectPath, true);
                }

                if (File.Exists(configLocation))
                {
                    File.Delete(configLocation);
                }

                lbDynamicWebsites.Items.RemoveAt(lbDynamicWebsites.SelectedIndex);
            }
        }
    }
}
