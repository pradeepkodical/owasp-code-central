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