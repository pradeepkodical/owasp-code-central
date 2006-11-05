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
    public partial class ascxCustomWebServer : UserControl
    {
        public ascxCustomWebServer()
        {
            InitializeComponent();
        }

        private void btStartCustomWebServer_Click(object sender, EventArgs e)
        {
            createCustomWebServer();
            Thread.Sleep(1000);                                           // wait 1 sec to give the process time to start 
            checkIfCustomWebServerExistsAsAProcess();
        }
        //strCustomWebServerProcessName
        private void btStartCustomWebServerWithInjectedDll_Click(object sender, EventArgs e)
        {
            createCustomWebServerWithInjectedDll();           
            checkIfCustomWebServerExistsAsAProcess();
        }

        private void createCustomWebServer()
        {
            utils.processes.createProcess(GlobalVariables.strCustomWebServerExeName,"");
        }

        private void createCustomWebServerWithInjectedDll()
        {
            string strArguments =  "  /d:" + " " + GlobalVariables.strCustomWebServerExeName;            
            
            Application.DoEvents();
            utils.processes.createProcess(GlobalVariables.strWithDllExeName, strArguments);                   // create process using withDLl
            Thread.Sleep(3000);                                                                                                                       // Sleep for two sec
        }

        private void checkIfCustomWebServerExistsAsAProcess()
        {
            if (Process.GetProcessesByName(GlobalVariables.strCustomWebServerProcessName).Length > 0 )
            {
                lbCustomWebServerIsStarted.Visible = true;
                btKillCustomWebServerProcess.Enabled = true;
                btStartCustomWebServer.Enabled = false;
                btStartCustomWebServerWithInjectedDll.Enabled = false;
                btOpenInWebBrowser.Enabled = true;
                txtPageToLoad.Enabled = true;                
            }
            else 
            {
                lbCustomWebServerIsStarted.Visible = false;
                btKillCustomWebServerProcess.Enabled = false;
                btStartCustomWebServer.Enabled = true;
                btStartCustomWebServerWithInjectedDll.Enabled = true;
                btOpenInWebBrowser.Enabled = false;
                txtPageToLoad.Enabled = false;
            }
        }

        private void btKillCustomWebServerProcess_Click(object sender, EventArgs e)
        {
            if ( Process.GetProcessesByName(GlobalVariables.strCustomWebServerProcessName).Length > 0)
            {
                Process.GetProcessesByName(GlobalVariables.strCustomWebServerProcessName)[0].Kill();
                Thread.Sleep(1000);                                           // wait 1 sec to give the process time to be killed                 
            }
            checkIfCustomWebServerExistsAsAProcess();
        }

        private void ascxCustomWebServer_Load(object sender, EventArgs e)
        {
            checkIfCustomWebServerExistsAsAProcess();
        }

        private void btInjectDllIntoCustomWebServer_Click(object sender, EventArgs e)
        {

        }

        private void txtPageToLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btOpenInWebBrowser_Click(null, null);
        }

        private void btOpenInWebBrowser_Click(object sender, EventArgs e)
        {
            string strPageToOpen = lbHarcodedBaseAddress.Text + txtPageToLoad.Text;
            wbCustomWebServer.Navigate(strPageToOpen );
        }
    }
}
