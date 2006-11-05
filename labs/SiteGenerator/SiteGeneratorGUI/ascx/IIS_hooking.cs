using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Owasp.SiteGenerator.ascx
{
    public partial class IIS_hooking : UserControl
    {
        public IIS_hooking()
        {
            InitializeComponent();
        }

        private void btRefreshProcess_Click(object sender, EventArgs e)
        {
            //Process[] pCurrentProcesses = Process.GetProcesses();            
            lvCurrentProcesses.Items.Clear();
            foreach (Process pProcess in Process.GetProcesses())
            {
                lvCurrentProcesses.Items.Add(new ListViewItem(new string[] { pProcess.ProcessName, pProcess.Id.ToString() }));
            }
            if (0 == (Process.GetProcessesByName("w3wp").Length))
            {
                lbW3wpAlert.Visible = true;
                btAttemptToCreateW3WP.Visible = true;
                gbW3wpHooking.Visible = false;
            }
            else
            {
                lbW3wpAlert.Visible = false;
                btAttemptToCreateW3WP.Visible = false;
                gbW3wpHooking.Visible = true;
                processExistentW3wpInstances();
            }
        }

        private void btAttemptToCreateW3WP_Click(object sender, EventArgs e)
        {
            cbUrlToLoad.Text = "http://127.0.0.1/ThisPageDoesNotExit.aspx";
            btLoadUrlInWebBrowser_Click(null, null);
            Thread.Sleep(1000);   // wait 1sec to give time for the w3wp to staty
            btRefreshProcess_Click(null, null);
        }

        private void btKillSelectedProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string strNameOfProcessToDelete = lvCurrentProcesses.SelectedItems[0].SubItems[0].Text;
                string strIdOfProcessToDelete = lvCurrentProcesses.SelectedItems[0].SubItems[1].Text;
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete process " + strNameOfProcessToDelete + " (" + strIdOfProcessToDelete + ") ?", "Confirm Delete", MessageBoxButtons.YesNo))
                {
                    Process.GetProcessById(Int32.Parse(strIdOfProcessToDelete)).Kill();
                    Thread.Sleep(1000);                                                                                // wait 1sec to give time for the w3wp to go
                    btRefreshProcess_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void processExistentW3wpInstances()
        {
            lvW3wpInstances.Items.Clear();
            foreach (Process pProcess in Process.GetProcessesByName("w3wp"))
            {
                lvW3wpInstances.Items.Add(new ListViewItem(new string[] { pProcess.ProcessName, pProcess.Id.ToString() }));
            }
            // Open the default IIS page in the local server
            cbUrlToLoad.Text = "http://127.0.0.1/";
            btLoadUrlInWebBrowser_Click(null, null);
        }

        private void btLoadUrlInWebBrowser_Click(object sender, EventArgs e)
        {
            wbW3wpHooking.Navigate(cbUrlToLoad.Text);//"http://127.0.0.1/ThisPageDoesNotExit.aspx");                 
        }

        private void btInjectDllIntoProcess_Click(object sender, EventArgs e)
        {
            string cDllToInject = Environment.CurrentDirectory + "\\" + GlobalVariables.strSharedMemoryDll;   // DetoursTest.dll";
            MessageBox.Show(cDllToInject);
            /*if (lvCurrentProcesses.SelectedItems.Count > 0)
            {
                string strInjectionResult = SharedMemoryForDotNet.smdt_detours_injdll(cDllToInject, Int32.Parse(lvCurrentProcesses.SelectedItems[0].SubItems[1].Text));
                if (strInjectionResult == "")
                    lvCurrentProcesses_SelectedIndexChanged(null, null);
                else
                    MessageBox.Show(strInjectionResult);
            }
            else
                MessageBox.Show("Please select Process to Inject");*/
        }

        private void lvCurrentProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCurrentProcesses.SelectedItems.Count == 0)
                lvSelectedProcessInfo.Items.Clear();
            else
            {
                try
                {
                    bool bDllInjectedInThisProcess = false;
                    int iSelectedProcessID = Int32.Parse(lvCurrentProcesses.SelectedItems[0].SubItems[1].Text);
                    Process pSelectedProcess = Process.GetProcessById(iSelectedProcessID);
                    foreach (ProcessModule pmToProcess in pSelectedProcess.Modules)
                    {
                        if (pmToProcess.ModuleName == GlobalVariables.strSharedMemoryDll)
                            bDllInjectedInThisProcess = true;
                        lvSelectedProcessInfo.Items.Add(new ListViewItem(new string[] { pmToProcess.ModuleName, pmToProcess.FileName }));
                    }
                    if (bDllInjectedInThisProcess)
                    {
                        lbDllInjectedIntoThisProcess.Visible = true;
                        btInjectDllIntoProcess.Enabled = false;
                    }
                    else
                    {
                        lbDllInjectedIntoThisProcess.Visible = false;
                        btInjectDllIntoProcess.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void lvSelectedProcessInfo_Resize(object sender, EventArgs e)
        {
            lvSelectedProcessInfo.Columns[1].Width = lvSelectedProcessInfo.Width - lvSelectedProcessInfo.Columns[0].Width;
        }

        private void btCreateNotepad_Click(object sender, EventArgs e)
        {
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = "notepad.exe";
            pProcess.Start();
            btRefreshProcess_Click(null, null);
        }

        private void btCreateCmd_Click(object sender, EventArgs e)
        {
            Process pProcess = new Process();
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.Start();
            btRefreshProcess_Click(null, null);
        }

    }
}
