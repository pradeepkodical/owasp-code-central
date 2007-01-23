using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace TigerClient
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            this.Text = "About OWASP Tiger";
            this.labelProductName.Text = "OWASP Tiger";
            this.labelVersion.Text = "Version 0.9";
            this.labelCopyright.Text = "Copyright ©";
            this.labelCompanyName.Text = "OWASP";
            this.textBoxDescription.Text = "OWASP Tiger";
        }
    }
}
