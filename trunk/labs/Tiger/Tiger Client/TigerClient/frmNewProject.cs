// Tiger Client 1.0
// Copyright (C) 2007 Boris Maletic
//
// This program is free software; you can redistribute it and/or modify it under 
// the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with this program;
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

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