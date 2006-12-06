namespace Owasp.SiteGenerator.ascx
{
    partial class ascxDynamicWebSites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxDynamicWebSites));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbDynamicWebsites = new System.Windows.Forms.ListBox();
            this.btCreateDynamicWebsite = new System.Windows.Forms.Button();
            this.txtNewDynamicWebsiteName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btLoadXmlFileIntoSiteGenerator = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCurrentXmlFileLoaded = new System.Windows.Forms.Label();
            this.btSaveAndReloadXmlFile = new System.Windows.Forms.Button();
            this.tbDynamicWebsiteViews = new System.Windows.Forms.TabControl();
            this.tbAuthenticView = new System.Windows.Forms.TabPage();
            this.tbTextXmlView = new System.Windows.Forms.TabPage();
            this.txtDynamicWebsitesTextXmlView = new System.Windows.Forms.TextBox();
            this.lbFileSaved = new System.Windows.Forms.Label();
            this.btnDelCurrentSite = new System.Windows.Forms.Button();
            this.axAuthentic_DynamicWebsites = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbDynamicWebsiteViews.SuspendLayout();
            this.tbAuthenticView.SuspendLayout();
            this.tbTextXmlView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_DynamicWebsites)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "In this section you can create and edit the SiteGenerator Dynamic websites";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbDynamicWebsites);
            this.groupBox1.Location = new System.Drawing.Point(16, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 291);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dynamic WebSites";
            // 
            // lbDynamicWebsites
            // 
            this.lbDynamicWebsites.FormattingEnabled = true;
            this.lbDynamicWebsites.Location = new System.Drawing.Point(6, 18);
            this.lbDynamicWebsites.Name = "lbDynamicWebsites";
            this.lbDynamicWebsites.Size = new System.Drawing.Size(188, 264);
            this.lbDynamicWebsites.TabIndex = 0;
            this.lbDynamicWebsites.SelectedIndexChanged += new System.EventHandler(this.lbDynamicWebsites_SelectedIndexChanged);
            // 
            // btCreateDynamicWebsite
            // 
            this.btCreateDynamicWebsite.Location = new System.Drawing.Point(126, 19);
            this.btCreateDynamicWebsite.Name = "btCreateDynamicWebsite";
            this.btCreateDynamicWebsite.Size = new System.Drawing.Size(68, 20);
            this.btCreateDynamicWebsite.TabIndex = 2;
            this.btCreateDynamicWebsite.Text = "Create";
            this.btCreateDynamicWebsite.UseVisualStyleBackColor = true;
            this.btCreateDynamicWebsite.Click += new System.EventHandler(this.btCreateDynamicWebsite_Click);
            // 
            // txtNewDynamicWebsiteName
            // 
            this.txtNewDynamicWebsiteName.Location = new System.Drawing.Point(6, 19);
            this.txtNewDynamicWebsiteName.Name = "txtNewDynamicWebsiteName";
            this.txtNewDynamicWebsiteName.Size = new System.Drawing.Size(114, 20);
            this.txtNewDynamicWebsiteName.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btCreateDynamicWebsite);
            this.groupBox2.Controls.Add(this.txtNewDynamicWebsiteName);
            this.groupBox2.Location = new System.Drawing.Point(16, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 43);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Dynamic Website";
            // 
            // btLoadXmlFileIntoSiteGenerator
            // 
            this.btLoadXmlFileIntoSiteGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoadXmlFileIntoSiteGenerator.Location = new System.Drawing.Point(528, 39);
            this.btLoadXmlFileIntoSiteGenerator.Name = "btLoadXmlFileIntoSiteGenerator";
            this.btLoadXmlFileIntoSiteGenerator.Size = new System.Drawing.Size(179, 23);
            this.btLoadXmlFileIntoSiteGenerator.TabIndex = 3;
            this.btLoadXmlFileIntoSiteGenerator.Text = "Load Xml file into SiteGenerator";
            this.btLoadXmlFileIntoSiteGenerator.UseVisualStyleBackColor = true;
            this.btLoadXmlFileIntoSiteGenerator.Click += new System.EventHandler(this.btLoadXmlFileIntoSiteGenerator_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Loaded Xml File ->";
            // 
            // lbCurrentXmlFileLoaded
            // 
            this.lbCurrentXmlFileLoaded.AutoSize = true;
            this.lbCurrentXmlFileLoaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentXmlFileLoaded.Location = new System.Drawing.Point(614, 7);
            this.lbCurrentXmlFileLoaded.Name = "lbCurrentXmlFileLoaded";
            this.lbCurrentXmlFileLoaded.Size = new System.Drawing.Size(109, 13);
            this.lbCurrentXmlFileLoaded.TabIndex = 4;
            this.lbCurrentXmlFileLoaded.Text = "NO FILE LOADED";
            // 
            // btSaveAndReloadXmlFile
            // 
            this.btSaveAndReloadXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveAndReloadXmlFile.Location = new System.Drawing.Point(739, 39);
            this.btSaveAndReloadXmlFile.Name = "btSaveAndReloadXmlFile";
            this.btSaveAndReloadXmlFile.Size = new System.Drawing.Size(146, 23);
            this.btSaveAndReloadXmlFile.TabIndex = 3;
            this.btSaveAndReloadXmlFile.Text = "Save and Reload Xml File";
            this.btSaveAndReloadXmlFile.UseVisualStyleBackColor = true;
            this.btSaveAndReloadXmlFile.Click += new System.EventHandler(this.btSaveAndReloadXmlFile_Click);
            // 
            // tbDynamicWebsiteViews
            // 
            this.tbDynamicWebsiteViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDynamicWebsiteViews.Controls.Add(this.tbAuthenticView);
            this.tbDynamicWebsiteViews.Controls.Add(this.tbTextXmlView);
            this.tbDynamicWebsiteViews.Location = new System.Drawing.Point(222, 68);
            this.tbDynamicWebsiteViews.Name = "tbDynamicWebsiteViews";
            this.tbDynamicWebsiteViews.SelectedIndex = 0;
            this.tbDynamicWebsiteViews.Size = new System.Drawing.Size(663, 309);
            this.tbDynamicWebsiteViews.TabIndex = 5;
            // 
            // tbAuthenticView
            // 
            this.tbAuthenticView.Controls.Add(this.axAuthentic_DynamicWebsites);
            this.tbAuthenticView.Location = new System.Drawing.Point(4, 22);
            this.tbAuthenticView.Name = "tbAuthenticView";
            this.tbAuthenticView.Padding = new System.Windows.Forms.Padding(3);
            this.tbAuthenticView.Size = new System.Drawing.Size(655, 283);
            this.tbAuthenticView.TabIndex = 0;
            this.tbAuthenticView.Text = "Authentic Xml View";
            this.tbAuthenticView.UseVisualStyleBackColor = true;
            // 
            // tbTextXmlView
            // 
            this.tbTextXmlView.Controls.Add(this.txtDynamicWebsitesTextXmlView);
            this.tbTextXmlView.Location = new System.Drawing.Point(4, 22);
            this.tbTextXmlView.Name = "tbTextXmlView";
            this.tbTextXmlView.Padding = new System.Windows.Forms.Padding(3);
            this.tbTextXmlView.Size = new System.Drawing.Size(655, 283);
            this.tbTextXmlView.TabIndex = 1;
            this.tbTextXmlView.Text = "Text Xml View";
            this.tbTextXmlView.UseVisualStyleBackColor = true;
            // 
            // txtDynamicWebsitesTextXmlView
            // 
            this.txtDynamicWebsitesTextXmlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDynamicWebsitesTextXmlView.Location = new System.Drawing.Point(3, 3);
            this.txtDynamicWebsitesTextXmlView.Multiline = true;
            this.txtDynamicWebsitesTextXmlView.Name = "txtDynamicWebsitesTextXmlView";
            this.txtDynamicWebsitesTextXmlView.Size = new System.Drawing.Size(668, 273);
            this.txtDynamicWebsitesTextXmlView.TabIndex = 0;
            this.txtDynamicWebsitesTextXmlView.TextChanged += new System.EventHandler(this.txtDynamicWebsitesTextXmlView_TextChanged);
            // 
            // lbFileSaved
            // 
            this.lbFileSaved.AutoSize = true;
            this.lbFileSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFileSaved.ForeColor = System.Drawing.Color.Red;
            this.lbFileSaved.Location = new System.Drawing.Point(776, 23);
            this.lbFileSaved.Name = "lbFileSaved";
            this.lbFileSaved.Size = new System.Drawing.Size(91, 13);
            this.lbFileSaved.TabIndex = 4;
            this.lbFileSaved.Text = "Xml File Saved";
            this.lbFileSaved.Visible = false;
            // 
            // btnDelCurrentSite
            // 
            this.btnDelCurrentSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelCurrentSite.Location = new System.Drawing.Point(16, 364);
            this.btnDelCurrentSite.Name = "btnDelCurrentSite";
            this.btnDelCurrentSite.Size = new System.Drawing.Size(139, 23);
            this.btnDelCurrentSite.TabIndex = 6;
            this.btnDelCurrentSite.Text = "&Delete Selected Website";
            this.btnDelCurrentSite.UseVisualStyleBackColor = true;
            this.btnDelCurrentSite.Click += new System.EventHandler(this.btnDelCurrentSite_Click);
            // 
            // axAuthentic_DynamicWebsites
            // 
            this.axAuthentic_DynamicWebsites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_DynamicWebsites.Enabled = true;
            this.axAuthentic_DynamicWebsites.Location = new System.Drawing.Point(0, 0);
            this.axAuthentic_DynamicWebsites.Name = "axAuthentic_DynamicWebsites";
            this.axAuthentic_DynamicWebsites.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_DynamicWebsites.OcxState")));
            this.axAuthentic_DynamicWebsites.Size = new System.Drawing.Size(652, 283);
            this.axAuthentic_DynamicWebsites.TabIndex = 0;
            // 
            // ascxDynamicWebSites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnDelCurrentSite);
            this.Controls.Add(this.tbDynamicWebsiteViews);
            this.Controls.Add(this.lbFileSaved);
            this.Controls.Add(this.lbCurrentXmlFileLoaded);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSaveAndReloadXmlFile);
            this.Controls.Add(this.btLoadXmlFileIntoSiteGenerator);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ascxDynamicWebSites";
            this.Size = new System.Drawing.Size(902, 391);
            this.Load += new System.EventHandler(this.ascxDynamicWebSites_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbDynamicWebsiteViews.ResumeLayout(false);
            this.tbAuthenticView.ResumeLayout(false);
            this.tbTextXmlView.ResumeLayout(false);
            this.tbTextXmlView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_DynamicWebsites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btCreateDynamicWebsite;
        private System.Windows.Forms.TextBox txtNewDynamicWebsiteName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbDynamicWebsites;
        private System.Windows.Forms.Button btLoadXmlFileIntoSiteGenerator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCurrentXmlFileLoaded;
        private System.Windows.Forms.Button btSaveAndReloadXmlFile;
        private System.Windows.Forms.TabControl tbDynamicWebsiteViews;
        private System.Windows.Forms.TabPage tbAuthenticView;
        private System.Windows.Forms.TabPage tbTextXmlView;
        private System.Windows.Forms.TextBox txtDynamicWebsitesTextXmlView;
        private System.Windows.Forms.Label lbFileSaved;
        private System.Windows.Forms.Button btnDelCurrentSite;
        private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_DynamicWebsites;
    }
}
