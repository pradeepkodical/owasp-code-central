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
