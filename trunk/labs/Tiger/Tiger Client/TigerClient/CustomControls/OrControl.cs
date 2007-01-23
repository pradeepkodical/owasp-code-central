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
    public partial class OrControl : BinaryConditionControl
    {
        public OrControl()
        {
            InitializeComponent();
            
            operatorString = "OR";
        }

        public override TigerClient.Document.Condition.ICondition Condition
        {
            get
            {
                ConditionControlBase rightControl = SubconditionControls[0];
                ConditionControlBase leftControl = SubconditionControls[1];

                OrCondition c = new OrCondition();
                c.Condition1 = leftControl.Condition;
                c.Condition2 = rightControl.Condition;

                return c;
            }
            set
            {
                if (value.GetType() != typeof(OrCondition))
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

                return leftControl.IsValid || rightControl.IsValid;
            }
        }
    }
}
