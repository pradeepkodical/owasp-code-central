using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Owasp.SiteGenerator.ascx
{
    public partial class ascxWebBrowser : UserControl
    {
        public ascxWebBrowser()
        {
            InitializeComponent();
        }

        private void btLoadPage_Click(object sender, EventArgs e)
        {
            wbWebBrowser.Navigate(cbUrlToOpen.Text);
        }
        private void wbWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            cbUrlToOpen.Text = e.Url.ToString();
        }

        private void cbUrlToOpen_SelectedIndexChanged(object sender, EventArgs e)
        {
            wbWebBrowser.Navigate(cbUrlToOpen.Text);
        }

        private void cbUrlToOpen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0d)       // 0x0d (13) enter
                btLoadPage_Click(null, null);
        }
    }
}
