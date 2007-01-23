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
    public partial class ResponseBodyContainsNotControl : ConditionControlWithTextBoxBase
    {
        public ResponseBodyContainsNotControl()
        {
            InitializeComponent();

            Text = "Response Body";
            parameterCaption = "Does NOT contain text:";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ResponseBodyContainsNotCondition c = new ResponseBodyContainsNotCondition();
                c.MatchString = txtConditionParameter.Text;

                return c;
            }
            set
            {
                if (value.GetType() == typeof(ResponseBodyContainsNotCondition))
                {
                    ResponseBodyContainsNotCondition c = value as ResponseBodyContainsNotCondition;
                    txtConditionParameter.Text = c.MatchString;
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
