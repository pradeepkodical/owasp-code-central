using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Owasp.SiteGenerator
{
    public partial class MainGui : Form
    {
        public MainGui()
        {
            InitializeComponent();            
        }

        private void MainGui_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                admin1.ListViewFileTransformations = ascxFileTransformation1.lvFileTransformations;
                admin1.StartAcceptingConnections();

                SiteGenerator_Transformers.tbDebugMessages = admin1.txtDebugAllReceivedMessages;
            }
        }

    }
}