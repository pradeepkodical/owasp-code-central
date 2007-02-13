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