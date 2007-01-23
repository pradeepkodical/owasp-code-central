using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TigerClient
{
    public partial class frmNewProject : Form
    {
        private string template;

        public frmNewProject()
        {
            InitializeComponent();

            ListViewItem lvi = lstTemplates.Items.Add("Blank Project");
            lvi.Tag = "";
            lvi.ImageKey = "blank_project";
            lvi.Selected = true;

            AddInstalledTemplates();
        }

        private void AddInstalledTemplates()
        {
            string[] templates = Utilities.TemplateManager.GetTemplateFileNames();

            if (templates != null)
            {
                ListViewItem lvi;

                foreach (string templateFileName in templates)
                {
                    lvi = lstTemplates.Items.Add(System.IO.Path.GetFileNameWithoutExtension(templateFileName));
                    lvi.Tag = templateFileName;
                    lvi.ImageKey = "template";
                }
            }
        }

        public string Template
        {
            get { return template; }
            set { template = value; }
        }

        private void lstTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (lstTemplates.SelectedItems.Count != 0) ;
        }

        private void lstTemplates_DoubleClick(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedItems.Count != 0)
            {
                DialogResult = DialogResult.OK;
                template = lstTemplates.SelectedItems[0].Tag.ToString();
                Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstTemplates.SelectedItems.Count != 0)
            {
                DialogResult = DialogResult.OK;
                template = lstTemplates.SelectedItems[0].Tag.ToString();
                Close();
            }
        }
    }
}