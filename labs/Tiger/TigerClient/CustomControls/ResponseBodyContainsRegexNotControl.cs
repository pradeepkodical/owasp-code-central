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
    public partial class ResponseBodyContainsRegexNotControl : ConditionControlWithTextBoxBase
    {
        public ResponseBodyContainsRegexNotControl()
        {
            InitializeComponent();

            Text = "Response Body";
            parameterCaption = "Does not contain match for regex:";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ResponseBodyRegexMatchNotCondition c = new ResponseBodyRegexMatchNotCondition();
                c.Regex = txtConditionParameter.Text;

                return c;
            }
            set
            {
                if (value.GetType() == typeof(ResponseBodyRegexMatchNotCondition))
                {
                    ResponseBodyRegexMatchNotCondition c = value as ResponseBodyRegexMatchNotCondition;
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
