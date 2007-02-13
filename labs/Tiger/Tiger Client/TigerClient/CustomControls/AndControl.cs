// Tiger Client 1.0
// Copyright (C) 2007 Boris Maletic
//
// This program is free software; you can redistribute it and/or modify it under 
// the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with this program;
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

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
