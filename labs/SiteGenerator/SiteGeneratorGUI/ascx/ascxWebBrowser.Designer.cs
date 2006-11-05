namespace Owasp.SiteGenerator.ascx
{
    partial class ascxWebBrowser
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
            this.btLoadPage = new System.Windows.Forms.Button();
            this.wbWebBrowser = new System.Windows.Forms.WebBrowser();
            this.cbUrlToOpen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btLoadPage
            // 
            this.btLoadPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoadPage.Location = new System.Drawing.Point(514, 2);
            this.btLoadPage.Name = "btLoadPage";
            this.btLoadPage.Size = new System.Drawing.Size(148, 20);
            this.btLoadPage.TabIndex = 5;
            this.btLoadPage.Text = "Load Page in Web Browser";
            this.btLoadPage.UseVisualStyleBackColor = true;
            this.btLoadPage.Click += new System.EventHandler(this.btLoadPage_Click);
            // 
            // wbWebBrowser
            // 
            this.wbWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbWebBrowser.Location = new System.Drawing.Point(3, 26);
            this.wbWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbWebBrowser.Name = "wbWebBrowser";
            this.wbWebBrowser.Size = new System.Drawing.Size(659, 280);
            this.wbWebBrowser.TabIndex = 3;
            this.wbWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wbWebBrowser_Navigating);
            // 
            // cbUrlToOpen
            // 
            this.cbUrlToOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUrlToOpen.FormattingEnabled = true;
            this.cbUrlToOpen.Items.AddRange(new object[] {
            "http://SiteGenerator",
            "http://127.0.0.1"});
            this.cbUrlToOpen.Location = new System.Drawing.Point(2, 2);
            this.cbUrlToOpen.Name = "cbUrlToOpen";
            this.cbUrlToOpen.Size = new System.Drawing.Size(510, 21);
            this.cbUrlToOpen.TabIndex = 6;
            this.cbUrlToOpen.Text = "http://SiteGenerator/Default.htm";
            this.cbUrlToOpen.SelectedIndexChanged += new System.EventHandler(this.cbUrlToOpen_SelectedIndexChanged);
            this.cbUrlToOpen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbUrlToOpen_KeyPress);
            // 
            // ascxWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbUrlToOpen);
            this.Controls.Add(this.btLoadPage);
            this.Controls.Add(this.wbWebBrowser);
            this.Name = "ascxWebBrowser";
            this.Size = new System.Drawing.Size(665, 309);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btLoadPage;
        private System.Windows.Forms.WebBrowser wbWebBrowser;
        private System.Windows.Forms.ComboBox cbUrlToOpen;
    }
}
