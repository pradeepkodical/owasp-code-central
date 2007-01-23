using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.CustomControls
{
    public partial class WindowHeaderControl : Control
    {
        private bool isActive = false;
        private CloseButtonControl closeButton;
        private int padding = 1;

        public event EventHandler CloseButtonClick;

        public WindowHeaderControl()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.ContainerControl, true);

            closeButton = new CloseButtonControl();
            closeButton.Click += new EventHandler(closeButton_Click);
            Controls.Add(closeButton);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (CloseButtonClick != null)
                CloseButtonClick(this, e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle textRectangle = new Rectangle();
            textRectangle.X = ClientRectangle.X;
            textRectangle.Y = ClientRectangle.Y;
            textRectangle.Height = ClientRectangle.Height;
            textRectangle.Width = ClientRectangle.Width - closeButton.Width - padding * 2;

            TextFormatFlags tff = TextFormatFlags.EndEllipsis | TextFormatFlags.Left | TextFormatFlags.LeftAndRightPadding |
                TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;

            if (isActive)
            {
                pe.Graphics.FillRectangle(SystemBrushes.ActiveCaption, this.ClientRectangle);
                TextRenderer.DrawText(pe.Graphics, Text, Font, textRectangle, SystemColors.ActiveCaptionText, tff);
            }
            else
            {
                using (SolidBrush br = new SolidBrush(ControlPaint.Light(SystemColors.ControlDark)))
                    pe.Graphics.FillRectangle(br, this.ClientRectangle);
                //pe.Graphics.FillRectangle(SystemBrushes.ControlDark, this.ClientRectangle);
                TextRenderer.DrawText(pe.Graphics, Text, Font, textRectangle, SystemColors.ControlText, tff);
            }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; closeButton.IsActive = value; Invalidate(); }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            IsActive = true;
            base.OnMouseDown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            int dimension = ClientRectangle.Height - 2 * padding;
            closeButton.Location = new Point(ClientRectangle.Right - dimension - padding, ClientRectangle.Y + padding);
            //closeButton.Location = new Point(100, 1);
            closeButton.Size = new Size(dimension, dimension);

            base.OnSizeChanged(e);
        }
    }
}
