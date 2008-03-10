using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace Owasp.Osg.Controller.Controls
{
    enum CloseButtonState
    {
        Normal,
        Hover,
        Pressed
    }

    class CloseButtonControl: Control
    {
        private bool isActive = false;
        private CloseButtonState state = CloseButtonState.Normal;

        public CloseButtonControl()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardClick, true);
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (isActive)
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, ClientRectangle);
            else
                e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, ClientRectangle);

            if (VisualStyleRenderer.IsSupported)
            {
                VisualStyleRenderer vr = null;

                if (state == CloseButtonState.Pressed)
                    vr = new VisualStyleRenderer(VisualStyleElement.Window.SmallCloseButton.Pressed);
                else if (state == CloseButtonState.Hover)
                    vr = new VisualStyleRenderer(VisualStyleElement.Window.SmallCloseButton.Hot);
                else
                    vr = new VisualStyleRenderer(VisualStyleElement.Window.SmallCloseButton.Normal);

                vr.DrawBackground(e.Graphics, ClientRectangle);
            }
            else
            {
                if (state == CloseButtonState.Pressed)
                    ControlPaint.DrawCaptionButton(e.Graphics, ClientRectangle, CaptionButton.Close, ButtonState.Pushed);
                else
                    ControlPaint.DrawCaptionButton(e.Graphics, ClientRectangle, CaptionButton.Close, ButtonState.Normal);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            state = CloseButtonState.Hover;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = CloseButtonState.Normal;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            state = CloseButtonState.Pressed;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!ClientRectangle.Contains(e.Location))
            {
                state = CloseButtonState.Normal;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
    }
}
