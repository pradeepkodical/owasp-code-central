using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.CustomControls
{
    public partial class PropertiesControl : UserControl
    {
        public event EventHandler CloseButtonClick;

        public PropertiesControl()
        {
            InitializeComponent();
        }

        public object SelectedObject
        {
            get { return propertyGrid1.SelectedObject; }
            set { propertyGrid1.SelectedObject = value; }
        }

        public override void Refresh()
        {
            propertyGrid1.Refresh();
            base.Refresh();
        }

        private void PropertiesControl_Enter(object sender, EventArgs e)
        {
            windowHeaderControl1.IsActive = true;
        }

        private void PropertiesControl_Leave(object sender, EventArgs e)
        {
            windowHeaderControl1.IsActive = false;
        }

        private void windowHeaderControl1_MouseDown(object sender, MouseEventArgs e)
        {
            propertyGrid1.Focus();
        }

        private void windowHeaderControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if (CloseButtonClick != null)
                CloseButtonClick(this, e);
        }
    }
}
