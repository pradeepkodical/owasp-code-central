namespace Owasp.SiteGenerator.ascx
{
    partial class WebsiteCreator
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumberOfLevels = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumberOfPagesPerDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPagesInThisSite = new System.Windows.Forms.Label();
            this.btCreateDinamicWebsite = new System.Windows.Forms.Button();
            this.txtDebugWindow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberOfDirectoriesPerLevel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDirectoriesInThisSite = new System.Windows.Forms.Label();
            this.lbCurrentListOfVulnerabilities = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btRemoveItemFromList = new System.Windows.Forms.Button();
            this.btReloadList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site Name:";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(68, 13);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(134, 20);
            this.txtSiteName.TabIndex = 1;
            this.txtSiteName.Text = "TestSite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number of Levels:";
            // 
            // txtNumberOfLevels
            // 
            this.txtNumberOfLevels.Location = new System.Drawing.Point(163, 39);
            this.txtNumberOfLevels.Name = "txtNumberOfLevels";
            this.txtNumberOfLevels.Size = new System.Drawing.Size(39, 20);
            this.txtNumberOfLevels.TabIndex = 1;
            this.txtNumberOfLevels.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Number of Pages per Directory";
            // 
            // txtNumberOfPagesPerDirectory
            // 
            this.txtNumberOfPagesPerDirectory.Location = new System.Drawing.Point(163, 99);
            this.txtNumberOfPagesPerDirectory.Name = "txtNumberOfPagesPerDirectory";
            this.txtNumberOfPagesPerDirectory.Size = new System.Drawing.Size(39, 20);
            this.txtNumberOfPagesPerDirectory.TabIndex = 1;
            this.txtNumberOfPagesPerDirectory.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pages in this site:";
            // 
            // lbPagesInThisSite
            // 
            this.lbPagesInThisSite.AutoSize = true;
            this.lbPagesInThisSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPagesInThisSite.Location = new System.Drawing.Point(160, 173);
            this.lbPagesInThisSite.Name = "lbPagesInThisSite";
            this.lbPagesInThisSite.Size = new System.Drawing.Size(14, 13);
            this.lbPagesInThisSite.TabIndex = 0;
            this.lbPagesInThisSite.Text = "0";
            // 
            // btCreateDinamicWebsite
            // 
            this.btCreateDinamicWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreateDinamicWebsite.Location = new System.Drawing.Point(599, 30);
            this.btCreateDinamicWebsite.Name = "btCreateDinamicWebsite";
            this.btCreateDinamicWebsite.Size = new System.Drawing.Size(200, 160);
            this.btCreateDinamicWebsite.TabIndex = 2;
            this.btCreateDinamicWebsite.Text = "Create Dynamic Website";
            this.btCreateDinamicWebsite.UseVisualStyleBackColor = true;
            this.btCreateDinamicWebsite.Click += new System.EventHandler(this.btCreateDinamicWebsite_Click);
            // 
            // txtDebugWindow
            // 
            this.txtDebugWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugWindow.Location = new System.Drawing.Point(6, 225);
            this.txtDebugWindow.Multiline = true;
            this.txtDebugWindow.Name = "txtDebugWindow";
            this.txtDebugWindow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugWindow.Size = new System.Drawing.Size(560, 104);
            this.txtDebugWindow.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "debugMessages";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Number of Directories per Level";
            // 
            // txtNumberOfDirectoriesPerLevel
            // 
            this.txtNumberOfDirectoriesPerLevel.Location = new System.Drawing.Point(163, 69);
            this.txtNumberOfDirectoriesPerLevel.Name = "txtNumberOfDirectoriesPerLevel";
            this.txtNumberOfDirectoriesPerLevel.Size = new System.Drawing.Size(39, 20);
            this.txtNumberOfDirectoriesPerLevel.TabIndex = 1;
            this.txtNumberOfDirectoriesPerLevel.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Directories in this site:";
            // 
            // lbDirectoriesInThisSite
            // 
            this.lbDirectoriesInThisSite.AutoSize = true;
            this.lbDirectoriesInThisSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDirectoriesInThisSite.Location = new System.Drawing.Point(160, 152);
            this.lbDirectoriesInThisSite.Name = "lbDirectoriesInThisSite";
            this.lbDirectoriesInThisSite.Size = new System.Drawing.Size(14, 13);
            this.lbDirectoriesInThisSite.TabIndex = 0;
            this.lbDirectoriesInThisSite.Text = "0";
            // 
            // lbCurrentListOfVulnerabilities
            // 
            this.lbCurrentListOfVulnerabilities.FormattingEnabled = true;
            this.lbCurrentListOfVulnerabilities.Location = new System.Drawing.Point(230, 30);
            this.lbCurrentListOfVulnerabilities.Name = "lbCurrentListOfVulnerabilities";
            this.lbCurrentListOfVulnerabilities.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCurrentListOfVulnerabilities.Size = new System.Drawing.Size(336, 160);
            this.lbCurrentListOfVulnerabilities.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Vulnerabilities To Include";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btRemoveItemFromList
            // 
            this.btRemoveItemFromList.Location = new System.Drawing.Point(432, 6);
            this.btRemoveItemFromList.Name = "btRemoveItemFromList";
            this.btRemoveItemFromList.Size = new System.Drawing.Size(131, 20);
            this.btRemoveItemFromList.TabIndex = 2;
            this.btRemoveItemFromList.Text = "Remove Item From List";
            this.btRemoveItemFromList.UseVisualStyleBackColor = true;
            this.btRemoveItemFromList.Click += new System.EventHandler(this.btRemoveItemFromList_Click);
            // 
            // btReloadList
            // 
            this.btReloadList.Location = new System.Drawing.Point(358, 6);
            this.btReloadList.Name = "btReloadList";
            this.btReloadList.Size = new System.Drawing.Size(68, 20);
            this.btReloadList.TabIndex = 2;
            this.btReloadList.Text = "Reload list";
            this.btReloadList.UseVisualStyleBackColor = true;
            this.btReloadList.Click += new System.EventHandler(this.btReloadList_Click);
            // 
            // WebsiteCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lbCurrentListOfVulnerabilities);
            this.Controls.Add(this.btReloadList);
            this.Controls.Add(this.btRemoveItemFromList);
            this.Controls.Add(this.btCreateDinamicWebsite);
            this.Controls.Add(this.txtNumberOfDirectoriesPerLevel);
            this.Controls.Add(this.txtNumberOfPagesPerDirectory);
            this.Controls.Add(this.txtNumberOfLevels);
            this.Controls.Add(this.txtDebugWindow);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.lbDirectoriesInThisSite);
            this.Controls.Add(this.lbPagesInThisSite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WebsiteCreator";
            this.Size = new System.Drawing.Size(802, 332);
            this.Load += new System.EventHandler(this.WebsiteCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumberOfLevels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumberOfPagesPerDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPagesInThisSite;
        private System.Windows.Forms.Button btCreateDinamicWebsite;
        private System.Windows.Forms.TextBox txtDebugWindow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumberOfDirectoriesPerLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbDirectoriesInThisSite;
        private System.Windows.Forms.ListBox lbCurrentListOfVulnerabilities;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btRemoveItemFromList;
        private System.Windows.Forms.Button btReloadList;
    }
}
