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
using System.Text;
using System.Drawing.Design;
using TigerClient.Document.Condition;
using TigerClient.CustomControls;

namespace TigerClient.CustomControls
{
    class ConditionTypeEditor: UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //ConditionEditorForm f = new ConditionEditorForm();
            ////f.Natpis = oldNatpis;

            //ICondition newCondition = oldCondition;

            //if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    //newNatpis = f.Natpis;
            //    System.Windows.Forms.MessageBox.Show("OK");
            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show("Cancel");
            //    //newNatpis = oldNatpis;
            //}

            ////System.Windows.Forms.MessageBox.Show(newNatpis);

            //return newCondition;

            ConditionEditorForm f = new ConditionEditorForm();
            ICondition oldCondition = value as ICondition;
            f.Condition = oldCondition;

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return f.Condition;
            else
                return oldCondition;
        }
    }
}
