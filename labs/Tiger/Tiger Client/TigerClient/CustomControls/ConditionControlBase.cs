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
using System.Drawing.Drawing2D;

namespace TigerClient.CustomControls
{
    public partial class ConditionControlBase : UserControl
    {
        public ConditionControlBase()
        {
            InitializeComponent();
        }

        protected ICondition condition;
        protected List<ConditionControlBase> subconditionControls = new List<ConditionControlBase>();
        protected ConditionControlBase parentConditionControl;

        internal event EventHandler<DeleteConditionEventArgs> DeleteCondition;

        protected virtual void OnDeleteCondition(DeleteConditionEventArgs e)
        {
            if (DeleteCondition != null)
                DeleteCondition(this, e);
        }

        public virtual ICondition Condition
        {
            get { return condition; }
            set
            {
                condition = value;
                Invalidate();
            }
        }

        public List<ConditionControlBase> SubconditionControls
        {
            get { return subconditionControls; }
            set
            {
                if (value == null)
                    subconditionControls = new List<ConditionControlBase>();
                else
                    subconditionControls = value;
            }
        }

        public ConditionControlBase ParentConditionControl
        {
            get { return parentConditionControl; }
            set { parentConditionControl = value; }
        }

        public virtual string ParameterCaption
        {
            get { return ""; }
        }

        public virtual bool IsValid
        {
            get
            {
                return false;
            }
        }

        public virtual int GetSubtreeWidth(int horizontalMargin, int minWidth)
        {
            int thisControlsWidth = Width + 2 * horizontalMargin;

            int maxChildSubtreeWidth = 0;
            foreach (ConditionControlBase child in subconditionControls)
            {
                int childSutbreeWidth = child.GetSubtreeWidth(horizontalMargin, minWidth);
                if (childSutbreeWidth > maxChildSubtreeWidth) maxChildSubtreeWidth = childSutbreeWidth;
            }

            int childSubtreesTotalWidth = maxChildSubtreeWidth * subconditionControls.Count;
            int subtreeWidth = (thisControlsWidth > childSubtreesTotalWidth ? thisControlsWidth : childSubtreesTotalWidth);
            return (subtreeWidth > minWidth ? subtreeWidth : minWidth);
        }

        public virtual void LayoutChildControls(int horizontalMargin, int verticalMargin)
        {
            foreach (ConditionControlBase child in subconditionControls)
                child.LayoutChildControls(horizontalMargin, verticalMargin);
        }

        public Point Center
        {
            get
            {
                int x = Location.X + (Width / 2);
                int y = Location.Y + (Height / 2);
                return new Point(x, y);
            }
            set
            {
                if (!DesignMode)
                {
                    int x = value.X - (Width / 2);
                    int y = value.Y - (Height / 2);
                    Location = new Point(x, y);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color normalFillColor = SystemColors.Window; // Color.White;
            Color selectedFillColor = SystemColors.Window; // Color.White;

            Color normalStrokeColor = SystemColors.ControlDark; // Color.DarkGray;
            Color selectedStrokeColor = SystemColors.ActiveCaption; // Color.SteelBlue;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath fullPath = GetOutlinePath(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1, 8);
            GraphicsPath topPath = GetTopOutlinePath(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1, 8);

            if (ContainsFocus)
            {
                using (Brush b = new SolidBrush(selectedFillColor))
                    e.Graphics.FillPath(b, fullPath);

                using (Brush b = new SolidBrush(selectedStrokeColor))
                    e.Graphics.FillPath(b, topPath);

                using (Pen p = new Pen(selectedStrokeColor, 1F))
                    e.Graphics.DrawPath(p, fullPath);

            }
            else
            {
                using (Brush b = new SolidBrush(normalFillColor))
                    e.Graphics.FillPath(b, fullPath);

                using (Brush b = new SolidBrush(normalStrokeColor))
                    e.Graphics.FillPath(b, topPath);

                using (Pen p = new Pen(normalStrokeColor, 1F))
                    e.Graphics.DrawPath(p, fullPath);
            }

            topPath.Dispose();
            fullPath.Dispose();

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;// SmoothingMode.None;

            using (Brush b = new SolidBrush(SystemColors.ActiveCaptionText))
                e.Graphics.DrawString(Text, this.Font, b, 5, 2);

            using (Brush b = new SolidBrush(SystemColors.WindowText))
                e.Graphics.DrawString(ParameterCaption, this.Font, b, 10, 23);

            base.OnPaint(e);
        }

        protected GraphicsPath GetOutlinePath(float X, float Y, float width, float height, float cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(X + width - (cornerRadius * 2), Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddArc(X + width - (cornerRadius * 2), Y + height - (cornerRadius * 2), cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddArc(X, Y + height - (cornerRadius * 2), cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.AddArc(X, Y, cornerRadius * 2, cornerRadius * 2, 180, 90);

            path.CloseFigure();

            return path;
        }

        protected GraphicsPath GetTopOutlinePath(float X, float Y, float width, float height, float cornerRadius)
        {
            int flatPartHeight = 8;

            GraphicsPath path = new GraphicsPath();

            path.AddLine(0, cornerRadius + flatPartHeight, 0, cornerRadius);
            path.AddArc(X, Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddArc(X + width - (cornerRadius * 2), Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddLine(X + width, cornerRadius, X + width, cornerRadius + flatPartHeight);

            path.CloseFigure();

            return path;
        }

        protected override void OnEnter(EventArgs e)
        {
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            Invalidate();
            base.OnLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            OnDeleteCondition(new DeleteConditionEventArgs(condition));
        }
    }
}
