using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TigerClient.Document.Condition;

namespace TigerClient.CustomControls
{
    public partial class ResponseStatusEqualToControl : ConditionControlWithTextBoxBase
    {
        protected bool negateCondition = false;

        public ResponseStatusEqualToControl()
        {
            InitializeComponent();

            Text = "Response Status Code";
            parameterCaption = "Is Equal to:";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ResponseStatusCodeEqualToCondition c = new ResponseStatusCodeEqualToCondition();
                try
                {
                    c.ResponseStatusCode = int.Parse(txtConditionParameter.Text);
                }
                catch
                {
                    throw new ApplicationException("Response status code must be provided and must be an integer.");
                }

                return c;
            }
            set
            {
                if (value.GetType() == typeof(ResponseStatusCodeEqualToCondition))
                {
                    ResponseStatusCodeEqualToCondition c = value as ResponseStatusCodeEqualToCondition;
                    txtConditionParameter.Text = c.ResponseStatusCode.ToString();
                    negateCondition = false;
                }
                else
                    throw new ArgumentException("Invalid argument type", "Condition");

                Invalidate();
            }
        }

        public override bool IsValid
        {
            get { return false; }
        }
    }
}
