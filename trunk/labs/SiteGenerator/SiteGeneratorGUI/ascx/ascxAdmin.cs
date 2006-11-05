using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace Owasp.SiteGenerator.ascx
{
    public partial class ascxAdmin : UserControl
    {
        private Listener ConnectionForCommunicatingWithWeb = new Listener();
        private ListView lvFileTransformations = null;

        public ascxAdmin()
        {
            InitializeComponent();
            ConnectionForCommunicatingWithWeb.ControlForCallingBackTo = this;
            ConnectionForCommunicatingWithWeb.TextBoxForCommunication = txtDebugAllReceivedMessages;
        }

        public ListView ListViewFileTransformations
        {
            set
            {
                lvFileTransformations = value;
                ConnectionForCommunicatingWithWeb.ListViewForFileTransformations = lvFileTransformations;
            }
        }
      
        private void btClearAllControls_Click(object sender, EventArgs e)
        {
            txtDebugAllReceivedMessages.Clear();
            if (lvFileTransformations != null)
            {
                lvFileTransformations.Items.Clear();
            }
        }

        /// <summary>
        /// Method to start accepting connections from websites.  
        /// </summary>
        public void StartAcceptingConnections() 
        {
            ConnectionForCommunicatingWithWeb.AcceptConnections();
        }

    }
}
