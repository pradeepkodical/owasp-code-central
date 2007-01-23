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
    public partial class ResponseStatusNotEqualToControl : ConditionControlWithTextBoxBase
    {
        public ResponseStatusNotEqualToControl()
        {
            InitializeComponent();

            Text = "Response Status Code";
            parameterCaption = "Is NOT equal to:";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ResponseStatusCodeEqualToNotCondition c = new ResponseStatusCodeEqualToNotCondition();

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
                if (value.GetType() == typeof(ResponseStatusCodeEqualToNotCondition))
                {
                    ResponseStatusCodeEqualToNotCondition c = value as ResponseStatusCodeEqualToNotCondition;
                    txtConditionParameter.Text = c.ResponseStatusCode.ToString();
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
