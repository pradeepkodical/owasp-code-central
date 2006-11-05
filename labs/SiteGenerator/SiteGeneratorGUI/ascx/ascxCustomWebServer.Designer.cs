namespace Owasp.SiteGenerator.ascx
{
    partial class ascxCustomWebServer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btStartCustomWebServer = new System.Windows.Forms.Button();
            this.btStartCustomWebServerWithInjectedDll = new System.Windows.Forms.Button();
            this.lbCustomWebServerIsStarted = new System.Windows.Forms.Label();
            this.btKillCustomWebServerProcess = new System.Windows.Forms.Button();
            this.txtPageToLoad = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btOpenInWebBrowser = new System.Windows.Forms.Button();
            this.lbHarcodedBaseAddress = new System.Windows.Forms.Label();
            this.wbCustomWebServer = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStartCustomWebServer
            // 
            this.btStartCustomWebServer.Location = new System.Drawing.Point(3, 94);
            this.btStartCustomWebServer.Name = "btStartCustomWebServer";
            this.btStartCustomWebServer.Size = new System.Drawing.Size(127, 35);
            this.btStartCustomWebServer.TabIndex = 0;
            this.btStartCustomWebServer.Text = "Start Custom Web Server";
            this.btStartCustomWebServer.UseVisualStyleBackColor = true;
            this.btStartCustomWebServer.Click += new System.EventHandler(this.btStartCustomWebServer_Click);
            // 
            // btStartCustomWebServerWithInjectedDll
            // 
            this.btStartCustomWebServerWithInjectedDll.Location = new System.Drawing.Point(3, 3);
            this.btStartCustomWebServerWithInjectedDll.Name = "btStartCustomWebServerWithInjectedDll";
            this.btStartCustomWebServerWithInjectedDll.Size = new System.Drawing.Size(127, 41);
            this.btStartCustomWebServerWithInjectedDll.TabIndex = 1;
            this.btStartCustomWebServerWithInjectedDll.Text = "Start Custom Web Server with Injected Dll";
            this.btStartCustomWebServerWithInjectedDll.UseVisualStyleBackColor = true;
            this.btStartCustomWebServerWithInjectedDll.Click += new System.EventHandler(this.btStartCustomWebServerWithInjectedDll_Click);
            // 
            // lbCustomWebServerIsStarted
            // 
            this.lbCustomWebServerIsStarted.AutoSize = true;
            this.lbCustomWebServerIsStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomWebServerIsStarted.ForeColor = System.Drawing.Color.Red;
            this.lbCustomWebServerIsStarted.Location = new System.Drawing.Point(136, 3);
            this.lbCustomWebServerIsStarted.Name = "lbCustomWebServerIsStarted";
            this.lbCustomWebServerIsStarted.Size = new System.Drawing.Size(177, 13);
            this.lbCustomWebServerIsStarted.TabIndex = 2;
            this.lbCustomWebServerIsStarted.Text = "Custom Web Server is Started";
            this.lbCustomWebServerIsStarted.Visible = false;
            // 
            // btKillCustomWebServerProcess
            // 
            this.btKillCustomWebServerProcess.Location = new System.Drawing.Point(3, 50);
            this.btKillCustomWebServerProcess.Name = "btKillCustomWebServerProcess";
            this.btKillCustomWebServerProcess.Size = new System.Drawing.Size(127, 38);
            this.btKillCustomWebServerProcess.TabIndex = 4;
            this.btKillCustomWebServerProcess.Text = "Kill Custom Web Server Process";
            this.btKillCustomWebServerProcess.UseVisualStyleBackColor = true;
            this.btKillCustomWebServerProcess.Click += new System.EventHandler(this.btKillCustomWebServerProcess_Click);
            // 
            // txtPageToLoad
            // 
            this.txtPageToLoad.Location = new System.Drawing.Point(116, 19);
            this.txtPageToLoad.Name = "txtPageToLoad";
            this.txtPageToLoad.Size = new System.Drawing.Size(429, 20);
            this.txtPageToLoad.TabIndex = 5;
            this.txtPageToLoad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageToLoad_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btOpenInWebBrowser);
            this.groupBox1.Controls.Add(this.lbHarcodedBaseAddress);
            this.groupBox1.Controls.Add(this.wbCustomWebServer);
            this.groupBox1.Controls.Add(this.txtPageToLoad);
            this.groupBox1.Location = new System.Drawing.Point(139, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 357);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Navigate Custom Web Server";
            // 
            // btOpenInWebBrowser
            // 
            this.btOpenInWebBrowser.Location = new System.Drawing.Point(551, 19);
            this.btOpenInWebBrowser.Name = "btOpenInWebBrowser";
            this.btOpenInWebBrowser.Size = new System.Drawing.Size(122, 20);
            this.btOpenInWebBrowser.TabIndex = 8;
            this.btOpenInWebBrowser.Text = "Open in Web Browser ";
            this.btOpenInWebBrowser.UseVisualStyleBackColor = true;
            this.btOpenInWebBrowser.Click += new System.EventHandler(this.btOpenInWebBrowser_Click);
            // 
            // lbHarcodedBaseAddress
            // 
            this.lbHarcodedBaseAddress.AutoSize = true;
            this.lbHarcodedBaseAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHarcodedBaseAddress.Location = new System.Drawing.Point(4, 23);
            this.lbHarcodedBaseAddress.Name = "lbHarcodedBaseAddress";
            this.lbHarcodedBaseAddress.Size = new System.Drawing.Size(112, 13);
            this.lbHarcodedBaseAddress.TabIndex = 7;
            this.lbHarcodedBaseAddress.Text = "http://localhost:8090/";
            // 
            // wbCustomWebServer
            // 
            this.wbCustomWebServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbCustomWebServer.Location = new System.Drawing.Point(6, 45);
            this.wbCustomWebServer.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbCustomWebServer.Name = "wbCustomWebServer";
            this.wbCustomWebServer.Size = new System.Drawing.Size(697, 306);
            this.wbCustomWebServer.TabIndex = 6;
            // 
            // ascxCustomWebServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btKillCustomWebServerProcess);
            this.Controls.Add(this.lbCustomWebServerIsStarted);
            this.Controls.Add(this.btStartCustomWebServerWithInjectedDll);
            this.Controls.Add(this.btStartCustomWebServer);
            this.Name = "ascxCustomWebServer";
            this.Size = new System.Drawing.Size(851, 379);
            this.Load += new System.EventHandler(this.ascxCustomWebServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartCustomWebServer;
        private System.Windows.Forms.Button btStartCustomWebServerWithInjectedDll;
        private System.Windows.Forms.Label lbCustomWebServerIsStarted;
        private System.Windows.Forms.Button btKillCustomWebServerProcess;
        private System.Windows.Forms.TextBox txtPageToLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser wbCustomWebServer;
        private System.Windows.Forms.Label lbHarcodedBaseAddress;
        private System.Windows.Forms.Button btOpenInWebBrowser;
    }
}
