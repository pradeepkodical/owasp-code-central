using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.Utilities
{
    public partial class frmSingleTestRunner : Form
    {
        public frmSingleTestRunner()
        {
            InitializeComponent();
        }

        private void frmSingleTestRunner_Load(object sender, EventArgs e)
        {
            if (automatedTestControl1.AutomatedTest != null)
                automatedTestControl1.Run();
        }

        public Document.AutomatedTest Test
        {
            get { return automatedTestControl1.AutomatedTest; }
            set { automatedTestControl1.AutomatedTest = value; }
        }

        public void Run(Document.AutomatedTest test)
        {
            Test = test;
            ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Test.Status == TigerClient.Document.TestStatusType.Executing)
                automatedTestControl1.Cancel();

            Close();
        }

        private void automatedTestControl1_TestCompleted(object sender, CustomControls.TestCompletedEventArgs e)
        {
            btnCancel.Text = "&Close";
            btnCancel.Focus();
        }
    }
}