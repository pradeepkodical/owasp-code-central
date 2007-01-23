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
    public partial class ResponseBodyContainsRegexControl : ConditionControlWithTextBoxBase
    {
        public ResponseBodyContainsRegexControl()
        {
            InitializeComponent();

            Text = "Response Body";
            parameterCaption = "Contains match for regex:";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ResponseBodyRegexMatchCondition c = new ResponseBodyRegexMatchCondition();
                c.Regex = txtConditionParameter.Text;

                return c;
            }
            set
            {
                if (value.GetType() == typeof(ResponseBodyRegexMatchCondition))
                {
                    ResponseBodyRegexMatchCondition c = value as ResponseBodyRegexMatchCondition;
                    txtConditionParameter.Text = c.Regex;
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
