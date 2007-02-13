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
    public partial class ConditionPlaceholderControl : ConditionControlBase
    {
        internal event EventHandler<InsertConditionEventArgs> InsertCondition;

        public ConditionPlaceholderControl()
        {
            InitializeComponent();

            Text = "<Untitled Condition>";
        }

        public override string ParameterCaption
        {
            get { return ""; }
        }

        public override bool IsValid
        {
            get { return false; }
        }

        public override ICondition Condition
        {
            get
            {
                return null;
            }
            set
            {
                //base.Condition = value;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            RectangleF rect = new RectangleF(ClientRectangle.X, ClientRectangle.Y + 16, ClientRectangle.Width, ClientRectangle.Height - 17);
            e.Graphics.DrawString("Right click to add condition", Font, SystemBrushes.ControlDark, rect, sf);

            sf.Dispose();
        }

        private void mnuResponseCodeIsEqualTo_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new ResponseStatusCodeEqualToCondition()));
        }

        private void mnuResponseCodeIsNOTEqualTo_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new ResponseStatusCodeEqualToNotCondition()));
        }

        private void mnuResponseBodyContains_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new ResponseBodyContainsCondition()));
        }

        private void mnuResponseBodyDoesNOTContain_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new ResponseBodyContainsNotCondition()));
        }

        private void mnuResponseBodyContainsRegex_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new ResponseBodyRegexMatchCondition()));
        }

        private void mnuResponseBodyDoesNOTContainRegex_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new ResponseBodyRegexMatchNotCondition()));
        }

        private void mnuAND_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new AndCondition()));
        }

        private void mnuOR_Click(object sender, EventArgs e)
        {
            if (InsertCondition != null)
                InsertCondition(this, new InsertConditionEventArgs(new OrCondition()));
        }
    }
}
