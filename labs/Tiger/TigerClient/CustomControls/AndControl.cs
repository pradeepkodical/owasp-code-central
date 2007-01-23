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
    public partial class AndControl : BinaryConditionControl
    {
        public AndControl()
        {
            InitializeComponent();

            operatorString = "AND";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ConditionControlBase rightControl = SubconditionControls[0];
                ConditionControlBase leftControl = SubconditionControls[1];

                AndCondition c = new AndCondition();
                c.Condition1 = leftControl.Condition;
                c.Condition2 = rightControl.Condition;

                return c;
            }
            set
            {
                if (value.GetType() != typeof(AndCondition))
                    throw new ArgumentException("Invalid argument type", "Condition");

                Invalidate();
            }
        }

        public override bool IsValid
        {
            get
            {
                ConditionControlBase rightControl = SubconditionControls[0];
                ConditionControlBase leftControl = SubconditionControls[1];

                return leftControl.IsValid && rightControl.IsValid;
            }
        }
    }
}
