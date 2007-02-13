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

namespace TigerClient.Report
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        public void ShowHtml(string html)
        {
            webBrowser1.DocumentText = html;
            Show();
        }

        public void ShowFile(string filePath)
        {
            webBrowser1.Navigate(filePath);
            Show();
        }

        private void tbtnPrint_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
        }

        private void tbtnSave_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowSaveAsDialog();
        }
    }
}