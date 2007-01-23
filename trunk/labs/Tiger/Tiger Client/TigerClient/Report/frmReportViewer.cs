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