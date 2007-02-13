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
    public partial class AutomatedTestControl : UserControl
    {
        protected Document.AutomatedTest automatedTest;
        protected string finalStatusMessage;
        protected string statusImageFileName;

        public event EventHandler<TestCompletedEventArgs> TestCompleted;

        public string FinalStatusMessage
        {
            get { return finalStatusMessage; }
        }

        public string StatusImageFileName
        {
            get { return statusImageFileName; }
        }

        public AutomatedTestControl()
        {
            InitializeComponent();
        }

        public Document.AutomatedTest AutomatedTest
        {
            get { return automatedTest; }
            set
            {
                automatedTest = value;
                if (value == null)
                {
                    if (DesignMode)
                        lblTestDisplayName.Text = "[No test specified]";
                    else
                        lblTestDisplayName.Text = "";
                }
                else
                    lblTestDisplayName.Text = automatedTest.DisplayName;
            }
        }

        public void Run()
        {
            finalStatusMessage = "";

            picStatus.Image = Properties.Resources.busy;

            try
            {
                backgroundWorker1.RunWorkerAsync(automatedTest);
            }
            catch (Exception ex)
            {
                picStatus.Image = Properties.Resources.test_failed;
                statusImageFileName = "test_failed.gif";

                lblTestDisplayName.Text = automatedTest.DisplayName + " (" + ex.Message + ")";
            }

            Refresh();
        }

        public void Cancel()
        {
            automatedTest.Stop();
            backgroundWorker1.CancelAsync();

            Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                automatedTest.Status = TigerClient.Document.TestStatusType.Executing;
                automatedTest.Run();
            }
            else
            {
                automatedTest.Status = TigerClient.Document.TestStatusType.Cancelled;
                automatedTest.StatusMessage = "User cancelled.";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message = automatedTest.DisplayName + " (" + automatedTest.StatusMessage + ")";

            switch (automatedTest.Status)
            {
                case TigerClient.Document.TestStatusType.Failed:
                    picStatus.Image = Properties.Resources.test_failed;
                    statusImageFileName = "test_failed.gif";
                    break;
                case TigerClient.Document.TestStatusType.Cancelled:
                    picStatus.Image = Properties.Resources.StopHS;
                    statusImageFileName = "StopHS.png";
                    break;
                default:
                    picStatus.Image = Properties.Resources.test_succeeded;
                    statusImageFileName = "test_succeeded.gif";
                    break;
            }

            if (automatedTest.Status == TigerClient.Document.TestStatusType.Succeeded)
            {
                foreach (Document.Alert alert in automatedTest.Alerts)
                {
                    Document.Condition.ICondition condition = alert.Condition as Document.Condition.ICondition;

                    if (condition.Result)
                    {
                        switch (alert.Type)
                        {
                            case TigerClient.Document.AlertType.Red:
                                picStatus.Image = Properties.Resources.red_flag;
                                statusImageFileName = "red_flag.gif";
                                break;
                            case TigerClient.Document.AlertType.Orange:
                                picStatus.Image = Properties.Resources.orange_flag;
                                statusImageFileName = "orange_flag.gif";
                                break;
                            case TigerClient.Document.AlertType.Yellow:
                                picStatus.Image = Properties.Resources.yellow_flag;
                                statusImageFileName = "yellow_flag.gif";
                                break;
                        }

                        if (string.IsNullOrEmpty(alert.Message))
                        {
                            finalStatusMessage = "[no alert message available]";
                            message = automatedTest.DisplayName + ": " + alert.Type.ToString() + " alert " + finalStatusMessage; // - no detailed message available";
                        }
                        else
                        {
                            finalStatusMessage = alert.Message;
                            message = automatedTest.DisplayName + ": " + alert.Type.ToString() + " alert - " + finalStatusMessage;
                        }

                        break;
                    }
                }
            }

            if (finalStatusMessage == "") finalStatusMessage = automatedTest.StatusMessage;

            lblTestDisplayName.Text = message;

            if (TestCompleted != null) TestCompleted(this, new TestCompletedEventArgs(automatedTest));
        }
    }
}
