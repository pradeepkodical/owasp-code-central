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

namespace TigerClient.CustomControls
{
    public partial class TargetControl : UserControl
    {
        private Document.Target target;
        private int executingTestsCount;
        private object executingTestsCountLock = new object();

        public event EventHandler TargetCompleted;

        public TargetControl()
        {
            InitializeComponent();
        }

        public Document.Target Target
        {
            get { return target; }
            set
            {
                target = value;
                lblTargetDisplayName.Text = target.DisplayName;
                automatedTestsPanel.SuspendLayout();

                automatedTestsPanel.Controls.Clear();
                foreach (Document.AutomatedTest automatedTest in target.AutomatedTests)
                {
                    AutomatedTestControl atc = new AutomatedTestControl();
                    atc.AutomatedTest = automatedTest;
                    atc.TestCompleted += new EventHandler<TestCompletedEventArgs>(atc_TestCompleted);
                    automatedTestsPanel.Controls.Add(atc);
                }

                automatedTestsPanel.ResumeLayout();
            }
        }

        public void Run()
        {
            executingTestsCount = target.AutomatedTests.Count;

            foreach (AutomatedTestControl atc in automatedTestsPanel.Controls)
                atc.Run();
        }

        public void Stop()
        {
            foreach (AutomatedTestControl atc in automatedTestsPanel.Controls)
                atc.Cancel();
        }

        private void picCollapse_Click(object sender, EventArgs e)
        {
            automatedTestsPanel.Visible = !automatedTestsPanel.Visible;
            if (automatedTestsPanel.Visible)
                picCollapse.Image = Properties.Resources.Expanded;
            else
                picCollapse.Image = Properties.Resources.Collapsed;
        }

        private void atc_TestCompleted(object sender, TestCompletedEventArgs e)
        {
            bool isTargetCompleted = false;

            lock (executingTestsCountLock)
            {
                executingTestsCount--;
                if (executingTestsCount == 0) isTargetCompleted = true;
            }

            AutomatedTestControl atc = sender as AutomatedTestControl;
            toolTip1.SetToolTip(atc, e.Test.ResponseBody);
            foreach (Control c in atc.Controls)
                toolTip1.SetToolTip(c, e.Test.ResponseBody);

            if (isTargetCompleted && TargetCompleted != null)
                TargetCompleted(this, new EventArgs());
        }
    }
}
