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
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace TigerClient.CustomControls
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
