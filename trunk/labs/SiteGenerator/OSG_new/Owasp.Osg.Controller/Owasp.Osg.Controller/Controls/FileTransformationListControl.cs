using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Owasp.Osg.Controller.Controls
{
    public partial class FileTransformationListControl : UserControl
    {
        public event EventHandler CloseButtonClick;

        public FileTransformationListControl()
        {
            InitializeComponent();
        }

        private void windowHeaderControl1_MouseDown(object sender, MouseEventArgs e)
        {
            listView1.Focus();
        }

        private void windowHeaderControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if (CloseButtonClick != null) CloseButtonClick(this, e);
        }
    }
}
