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
    public partial class ConditionControlWithTextBoxBase : ConditionControlBase
    {
        protected string parameterCaption;

        //internal event EventHandler<DeleteConditionEventArgs> DeleteCondition;

        public ConditionControlWithTextBoxBase()
        {
            InitializeComponent();

            txtConditionParameter.GotFocus += new EventHandler(txtConditionParameter_FocusChanged);
            txtConditionParameter.LostFocus += new EventHandler(txtConditionParameter_FocusChanged);
        }

        public override string ParameterCaption
        {
            get { return parameterCaption; }
        }

        public override bool IsValid
        {
            get { return false; }
        }

        public override ICondition Condition
        {
            get { return base.Condition; }
            set
            {
                //Type conditionType = value.GetType();

                //if (conditionType == typeof(ResponseStatusCodeEqualToCondition))
                //{
                //    //parameterCaption = "Is Equal to:";
                //    //Text = "Response Status Code";
                //    //ResponseStatusCodeEqualToCondition c = value as ResponseStatusCodeEqualToCondition;
                //    //txtConditionParameter.Text = c.ResponseStatusCode.ToString();
                //}
                //else if (conditionType == typeof(ResponseStatusCodeEqualToNotCondition))
                //{
                //    parameterCaption = "Is NOT Equal to:";
                //    Text = "Response Status Code";
                //}
                //else if (conditionType == typeof(ResponseBodyContainsCondition))
                //{
                //    parameterCaption = "Contains Text:";
                //    Text = "Response Body";
                //}
                //else if (conditionType == typeof(ResponseBodyContainsNotCondition))
                //{
                //    parameterCaption = "Does NOT Contain Text:";
                //    Text = "Response Body";
                //}
                //else if (conditionType == typeof(ResponseBodyRegexMatchCondition))
                //{
                //    parameterCaption = "Contains Match for Regex:";
                //    Text = "Response Body";
                //}
                //else if (conditionType == typeof(ResponseBodyRegexMatchNotCondition))
                //{
                //    parameterCaption = "Does NOT Contain Match for Regex:";
                //    Text = "Response Body";
                //}
                //else
                //    throw new ArgumentException("This type of condition is not supported by this control.");


                base.Condition = value;
            }
        }

        private void txtConditionParameter_FocusChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        //private void mnuDelete_Click(object sender, EventArgs e)
        //{
        //    //if (DeleteCondition != null)
        //    //    DeleteCondition(this, new DeleteConditionEventArgs(condition));
        //    OnDeleteCondition(new DeleteConditionEventArgs(condition));
        //}
    }
}
