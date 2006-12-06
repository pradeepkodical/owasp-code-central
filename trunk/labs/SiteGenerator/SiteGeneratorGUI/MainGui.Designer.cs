namespace Owasp.SiteGenerator
{
    partial class MainGui
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGui));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbDynamicWebsites = new System.Windows.Forms.TabPage();
            this.ascxDynamicWebSites1 = new Owasp.SiteGenerator.ascx.ascxDynamicWebSites();
            this.tcSiteGenerator_FileTransformations = new System.Windows.Forms.TabPage();
            this.ascxFileTransformation1 = new Owasp.SiteGenerator.ascx.ascxFileTransformation();
            this.tpWebBrowser = new System.Windows.Forms.TabPage();
            this.ascxWebBrowser1 = new Owasp.SiteGenerator.ascx.ascxWebBrowser();
            this.tpWebsiteCreator = new System.Windows.Forms.TabPage();
            this.websiteCreator1 = new Owasp.SiteGenerator.ascx.WebsiteCreator();
            this.admin1 = new Owasp.SiteGenerator.ascx.ascxAdmin();
            this.tabControl1.SuspendLayout();
            this.tbDynamicWebsites.SuspendLayout();
            this.tcSiteGenerator_FileTransformations.SuspendLayout();
            this.tpWebBrowser.SuspendLayout();
            this.tpWebsiteCreator.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbDynamicWebsites);
            this.tabControl1.Controls.Add(this.tcSiteGenerator_FileTransformations);
            this.tabControl1.Controls.Add(this.tpWebBrowser);
            this.tabControl1.Controls.Add(this.tpWebsiteCreator);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 440);
            this.tabControl1.TabIndex = 3;
            // 
            // tbDynamicWebsites
            // 
            this.tbDynamicWebsites.Controls.Add(this.ascxDynamicWebSites1);
            this.tbDynamicWebsites.Location = new System.Drawing.Point(4, 22);
            this.tbDynamicWebsites.Name = "tbDynamicWebsites";
            this.tbDynamicWebsites.Padding = new System.Windows.Forms.Padding(3);
            this.tbDynamicWebsites.Size = new System.Drawing.Size(917, 414);
            this.tbDynamicWebsites.TabIndex = 7;
            this.tbDynamicWebsites.Text = "Edit / Create Dynamic Websites";
            this.tbDynamicWebsites.UseVisualStyleBackColor = true;
            // 
            // ascxDynamicWebSites1
            // 
            this.ascxDynamicWebSites1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxDynamicWebSites1.AutoScroll = true;
            this.ascxDynamicWebSites1.Location = new System.Drawing.Point(6, 3);
            this.ascxDynamicWebSites1.Name = "ascxDynamicWebSites1";
            this.ascxDynamicWebSites1.Size = new System.Drawing.Size(904, 405);
            this.ascxDynamicWebSites1.TabIndex = 0;
            // 
            // tcSiteGenerator_FileTransformations
            // 
            this.tcSiteGenerator_FileTransformations.Controls.Add(this.ascxFileTransformation1);
            this.tcSiteGenerator_FileTransformations.Location = new System.Drawing.Point(4, 22);
            this.tcSiteGenerator_FileTransformations.Name = "tcSiteGenerator_FileTransformations";
            this.tcSiteGenerator_FileTransformations.Padding = new System.Windows.Forms.Padding(3);
            this.tcSiteGenerator_FileTransformations.Size = new System.Drawing.Size(917, 414);
            this.tcSiteGenerator_FileTransformations.TabIndex = 5;
            this.tcSiteGenerator_FileTransformations.Text = "File Transformations Log";
            this.tcSiteGenerator_FileTransformations.UseVisualStyleBackColor = true;
            // 
            // ascxFileTransformation1
            // 
            this.ascxFileTransformation1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxFileTransformation1.AutoScroll = true;
            this.ascxFileTransformation1.Location = new System.Drawing.Point(3, 3);
            this.ascxFileTransformation1.Name = "ascxFileTransformation1";
            this.ascxFileTransformation1.Size = new System.Drawing.Size(909, 405);
            this.ascxFileTransformation1.TabIndex = 0;
            // 
            // tpWebBrowser
            // 
            this.tpWebBrowser.Controls.Add(this.ascxWebBrowser1);
            this.tpWebBrowser.Location = new System.Drawing.Point(4, 22);
            this.tpWebBrowser.Name = "tpWebBrowser";
            this.tpWebBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tpWebBrowser.Size = new System.Drawing.Size(917, 414);
            this.tpWebBrowser.TabIndex = 8;
            this.tpWebBrowser.Text = "WebBrowser (SiteGenerator Sites)";
            this.tpWebBrowser.UseVisualStyleBackColor = true;
            // 
            // ascxWebBrowser1
            // 
            this.ascxWebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxWebBrowser1.Location = new System.Drawing.Point(6, 3);
            this.ascxWebBrowser1.Name = "ascxWebBrowser1";
            this.ascxWebBrowser1.Size = new System.Drawing.Size(905, 405);
            this.ascxWebBrowser1.TabIndex = 0;
            // 
            // tpWebsiteCreator
            // 
            this.tpWebsiteCreator.Controls.Add(this.websiteCreator1);
            this.tpWebsiteCreator.Location = new System.Drawing.Point(4, 22);
            this.tpWebsiteCreator.Name = "tpWebsiteCreator";
            this.tpWebsiteCreator.Padding = new System.Windows.Forms.Padding(3);
            this.tpWebsiteCreator.Size = new System.Drawing.Size(917, 414);
            this.tpWebsiteCreator.TabIndex = 9;
            this.tpWebsiteCreator.Text = "Website Creator";
            this.tpWebsiteCreator.UseVisualStyleBackColor = true;
            // 
            // websiteCreator1
            // 
            this.websiteCreator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.websiteCreator1.AutoScroll = true;
            this.websiteCreator1.Location = new System.Drawing.Point(6, 6);
            this.websiteCreator1.Name = "websiteCreator1";
            this.websiteCreator1.Size = new System.Drawing.Size(908, 402);
            this.websiteCreator1.TabIndex = 0;
            // 
            // admin1
            // 
            this.admin1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.admin1.Location = new System.Drawing.Point(0, 442);
            this.admin1.Name = "admin1";
            this.admin1.Size = new System.Drawing.Size(925, 140);
            this.admin1.TabIndex = 0;
            // 
            // MainGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 576);
            this.Controls.Add(this.admin1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGui";
            this.Text = "SiteGenerator GUI";
            this.Load += new System.EventHandler(this.MainGui_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbDynamicWebsites.ResumeLayout(false);
            this.tcSiteGenerator_FileTransformations.ResumeLayout(false);
            this.tpWebBrowser.ResumeLayout(false);
            this.tpWebsiteCreator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private Owasp.SiteGenerator.ascx.ascxAdmin admin1;
        private System.Windows.Forms.TabPage tcSiteGenerator_FileTransformations;
        private Owasp.SiteGenerator.ascx.ascxFileTransformation ascxFileTransformation1;
        private System.Windows.Forms.TabPage tbDynamicWebsites;
        private Owasp.SiteGenerator.ascx.ascxDynamicWebSites ascxDynamicWebSites1;
        private System.Windows.Forms.TabPage tpWebBrowser;
        private Owasp.SiteGenerator.ascx.ascxWebBrowser ascxWebBrowser1;
        private System.Windows.Forms.TabPage tpWebsiteCreator;
        private Owasp.SiteGenerator.ascx.WebsiteCreator websiteCreator1;

    }
}

