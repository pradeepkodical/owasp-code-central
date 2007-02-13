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
using TigerClient.Document.Condition;

namespace TigerClient.CustomControls
{
    public partial class ConditionEditorForm : Form
    {
        public ConditionEditorForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ICondition c = Condition;

                if (c == null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    if (c.IsValid)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        MessageBox.Show(c.ErrorMessage, "Condition is not valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Condition is not valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public ICondition Condition
        {
            get { return conditionEditorSurface1.Condition; }
            set { conditionEditorSurface1.Condition = value; }
        }
    }
}