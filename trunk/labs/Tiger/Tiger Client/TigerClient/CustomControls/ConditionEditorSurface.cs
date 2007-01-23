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
    public partial class ConditionEditorSurface : UserControl
    {
        protected ConditionControlBase rootConditionControl;
        protected const int horizontalMargin = 20;
        protected const int verticalMargin = 15;

        public ConditionEditorSurface()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        [Browsable(false)]
        public ICondition Condition
        {
            get
            {
                return rootConditionControl.Condition;
            }
            set
            {
                Controls.Clear();
                ConditionControlBase control = GetControlForCondition(value, null);
                rootConditionControl = control;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawLinksToSubconditionControls(e.Graphics, rootConditionControl);
        }

        protected void DrawLinksToSubconditionControls(Graphics g, ConditionControlBase c)
        {
            foreach (ConditionControlBase child in c.SubconditionControls)
            {
                //g.DrawLine(SystemPens.ControlDark, c.Center, child.Center);
                //DrawLinksToSubconditionControls(g, child);

                Point[] points = new Point[4];
                points[0] = c.Center;
                points[1] = new Point(c.Center.X, c.Bounds.Bottom + verticalMargin);
                points[2] = new Point(child.Center.X, child.Top - verticalMargin);
                points[3] = child.Center;
                g.DrawLines(SystemPens.ControlDark, points);
                DrawLinksToSubconditionControls(g, child);
            }
        }

        //internal void InsertCondition(object sender, InsertConditionEventArgs e)
        //{
        //    SuspendLayout();

        //    ICondition condition = Activator.CreateInstance(e.ConditiionType) as ICondition;

        //    ConditionControlBase placeholderControl = sender as ConditionControlBase;
        //    ConditionControlBase parentConditionControl = placeholderControl.ParentConditionControl;
        //    ConditionControlBase newControl;

        //    if (e.ConditiionType == typeof(AndCondition) || e.ConditiionType == typeof(OrCondition))
        //    {
        //        AndOrConditionControl binaryConditionControl = new AndOrConditionControl();
        //        binaryConditionControl.Condition = condition;

        //        ConditionPlaceholderControl cpc1 = new ConditionPlaceholderControl();
        //        cpc1.InsertCondition += new EventHandler<InsertConditionEventArgs>(InsertCondition);
        //        cpc1.ParentConditionControl = binaryConditionControl;
        //        binaryConditionControl.SubconditionControls.Add(cpc1);
        //        Controls.Add(cpc1);

        //        ConditionPlaceholderControl cpc2 = new ConditionPlaceholderControl();
        //        cpc2.InsertCondition += new EventHandler<InsertConditionEventArgs>(InsertCondition);
        //        cpc2.ParentConditionControl = binaryConditionControl;
        //        binaryConditionControl.SubconditionControls.Add(cpc2);
        //        Controls.Add(cpc2);

        //        newControl = binaryConditionControl;
        //    }
        //    else
        //    {
        //        ConditionControlWithTextBoxBase textControl = new ConditionControlWithTextBoxBase();
        //        textControl.Condition = condition;
        //        textControl.DeleteCondition += new EventHandler<DeleteConditionEventArgs>(DeleteCondition);

        //        newControl = textControl;
        //    }

        //    if (rootConditionControl == placeholderControl) rootConditionControl = newControl;

        //    if (parentConditionControl != null)
        //    {
        //        int index = parentConditionControl.SubconditionControls.IndexOf(placeholderControl);
        //        parentConditionControl.SubconditionControls.Remove(placeholderControl);
        //        parentConditionControl.SubconditionControls.Insert(index, newControl);

        //        newControl.ParentConditionControl = parentConditionControl;
        //    }

        //    Controls.Remove(placeholderControl);
        //    Controls.Add(newControl);

        //    newControl.Focus();

        //    ResumeLayout();
        //    Invalidate();
        //}

        internal void InsertCondition(object sender, InsertConditionEventArgs e)
        {
            SuspendLayout();

            ICondition condition = e.Condition;

            ConditionControlBase placeholderControl = sender as ConditionControlBase;
            ConditionControlBase parentConditionControl = placeholderControl.ParentConditionControl;
            ConditionControlBase newControl = GetControlForCondition(e.Condition, parentConditionControl);

            if (rootConditionControl == placeholderControl) rootConditionControl = newControl;

            if (parentConditionControl != null)
            {
                int index = parentConditionControl.SubconditionControls.IndexOf(placeholderControl);
                parentConditionControl.SubconditionControls.Remove(placeholderControl);
                parentConditionControl.SubconditionControls.Insert(index, newControl);

                newControl.ParentConditionControl = parentConditionControl;
            }

            Controls.Remove(placeholderControl);

            newControl.Focus();

            ResumeLayout();
            Invalidate();
        }

        internal void DeleteCondition(object sender, DeleteConditionEventArgs e)
        {
            SuspendLayout();
            ConditionControlBase controlToDelete = sender as ConditionControlBase;
            ConditionControlBase parentControl = controlToDelete.ParentConditionControl;

            Point center = controlToDelete.Center;

            DeleteControlSubtree(controlToDelete);
            ConditionControlBase newControl = GetControlForCondition(null, parentControl);

            if (parentControl != null)
            {
                int index = parentControl.SubconditionControls.IndexOf(controlToDelete);
                parentControl.SubconditionControls.Remove(controlToDelete);
                parentControl.SubconditionControls.Insert(index, newControl);
            }

            if (rootConditionControl == controlToDelete) rootConditionControl = newControl;

            newControl.Center = center;
            newControl.Focus();
            ResumeLayout();
            Invalidate();
        }

        protected void LayoutControls()
        {
            if (rootConditionControl != null)
            {
                int subtreeWidth = rootConditionControl.GetSubtreeWidth(horizontalMargin, 0);
                int centerX = subtreeWidth / 2 + AutoScrollPosition.X;
                int verticalOffset = rootConditionControl.Height / 2 + verticalMargin + AutoScrollPosition.Y;
                rootConditionControl.Center = new Point(centerX, verticalOffset);

                rootConditionControl.LayoutChildControls(horizontalMargin, verticalMargin);
            }
        }

        private void CriteriaEditorSurface_Layout(object sender, LayoutEventArgs e)
        {
            LayoutControls();
        }

        private ConditionControlBase GetControlForCondition(ICondition c, ConditionControlBase parent)
        {
            ConditionControlBase control = null;

            if (c == null)
            {
                ConditionPlaceholderControl cpc = new ConditionPlaceholderControl();
                cpc.ParentConditionControl = parent;
                cpc.InsertCondition += new EventHandler<InsertConditionEventArgs>(InsertCondition);
                Controls.Add(cpc);
                control = cpc;
            }
            else if (c.GetType() == typeof(ResponseStatusCodeEqualToCondition))
            {
                ResponseStatusEqualToControl ctl = new ResponseStatusEqualToControl();
                ctl.Condition = c;
                Controls.Add(ctl);
                control = ctl;
            }
            else if (c.GetType() == typeof(ResponseStatusCodeEqualToNotCondition))
            {
                ResponseStatusNotEqualToControl ctl = new ResponseStatusNotEqualToControl();
                ctl.Condition = c;
                Controls.Add(ctl);
                control = ctl;
            }
            else if (c.GetType() == typeof(ResponseBodyContainsCondition))
            {
                ResponseBodyContainsControl ctl = new ResponseBodyContainsControl();
                ctl.Condition = c;
                Controls.Add(ctl);
                control = ctl;
            }
            else if (c.GetType() == typeof(ResponseBodyContainsNotCondition))
            {
                ResponseBodyContainsNotControl ctl = new ResponseBodyContainsNotControl();
                ctl.Condition = c;
                Controls.Add(ctl);
                control = ctl;
            }
            else if (c.GetType() == typeof(ResponseBodyRegexMatchCondition))
            {
                ResponseBodyContainsRegexControl ctl = new ResponseBodyContainsRegexControl();
                ctl.Condition = c;
                Controls.Add(ctl);
                control = ctl;
            }
            else if (c.GetType() == typeof(ResponseBodyRegexMatchNotCondition))
            {
                ResponseBodyContainsRegexNotControl ctl = new ResponseBodyContainsRegexNotControl();
                ctl.Condition = c;
                Controls.Add(ctl);
                control = ctl;
            }
            else if (c.GetType() == typeof(AndCondition) || c.GetType() == typeof(OrCondition))
            {
                BinaryCondition bc = c as BinaryCondition;
                BinaryConditionControl ctl = (c.GetType() == typeof(AndCondition) ? (BinaryConditionControl)new AndControl() : (BinaryConditionControl)new OrControl());
                ctl.Condition = c;
                Controls.Add(ctl);
                control = ctl;

                ctl.SubconditionControls.Add(GetControlForCondition(bc.Condition2 as ICondition, ctl));

                ctl.SubconditionControls.Add(GetControlForCondition(bc.Condition1 as ICondition, ctl));
            }

            control.ParentConditionControl = parent;

            //if (parent != null)
            //    parent.SubconditionControls.Add(control);

            control.DeleteCondition += new EventHandler<DeleteConditionEventArgs>(DeleteCondition);

            return control;
        }

        private void DeleteControlSubtree(ConditionControlBase control)
        {
            foreach (ConditionControlBase subcontrol in control.SubconditionControls)
                DeleteControlSubtree(subcontrol);

            Controls.Remove(control);
        }
    }
}
