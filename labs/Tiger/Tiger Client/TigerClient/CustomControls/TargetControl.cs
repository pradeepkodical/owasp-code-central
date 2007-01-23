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
