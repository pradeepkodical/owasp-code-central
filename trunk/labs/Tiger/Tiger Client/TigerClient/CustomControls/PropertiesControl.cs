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
