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
