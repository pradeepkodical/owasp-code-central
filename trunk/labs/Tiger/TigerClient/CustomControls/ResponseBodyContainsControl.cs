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
    public partial class ResponseBodyContainsControl : ConditionControlWithTextBoxBase
    {
        public ResponseBodyContainsControl()
        {
            InitializeComponent();

            Text = "Response Body";
            parameterCaption = "Contains text:";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ResponseBodyContainsCondition c = new ResponseBodyContainsCondition();
                c.MatchString = txtConditionParameter.Text;

                return c;
            }
            set
            {
                if (value.GetType() == typeof(ResponseBodyContainsCondition))
                {
                    ResponseBodyContainsCondition c = value as ResponseBodyContainsCondition;
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
