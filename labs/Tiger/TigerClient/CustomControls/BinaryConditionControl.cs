using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.CustomControls
{
    public partial class BinaryConditionControl : ConditionControlBase
    {
        protected string operatorString;

        public BinaryConditionControl()
        {
            InitializeComponent();
        }

        public override void LayoutChildControls(int horizontalMargin, int verticalMargin)
        {
            ConditionControlBase rightControl = SubconditionControls[0];
            ConditionControlBase leftControl = SubconditionControls[1];

            int rihgtSubtreeWidth = rightControl.GetSubtreeWidth(horizontalMargin, 0);
            int leftSubtreeWidth = leftControl.GetSubtreeWidth(horizontalMargin, 0);

            int x = Center.X + rihgtSubtreeWidth / 2;
            int y = Bounds.Bottom + 2 * verticalMargin + rightControl.Height / 2;
            //int y = Bounds.Y + Bounds.Height + 2 * verticalMargin + rightControl.Height / 2;
            rightControl.Center = new Point(x, y);


            x = Center.X - leftSubtreeWidth / 2;
            y = Bounds.Bottom + 2 * verticalMargin + leftControl.Height / 2;
            //y = Bounds.Y + Bounds.Height + 2 * verticalMargin + leftControl.Height / 2;
            leftControl.Center = new Point(x, y);

            base.LayoutChildControls(horizontalMargin, verticalMargin);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            RectangleF rect = new RectangleF(ClientRectangle.X, ClientRectangle.Y + 16, ClientRectangle.Width, ClientRectangle.Height - 17);
            //if (condition is TigerClient.Document.Condition.AndCondition)
            e.Graphics.DrawString(operatorString, Font, SystemBrushes.ControlDark, rect, sf);
            //else
            //    e.Graphics.DrawString("OR", Font, SystemBrushes.ControlDark, rect, sf);

            sf.Dispose();
        }
    }
}
