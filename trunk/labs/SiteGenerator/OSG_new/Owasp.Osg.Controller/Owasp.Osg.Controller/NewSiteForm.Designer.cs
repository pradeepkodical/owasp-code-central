namespace Owasp.Osg.Controller
{
    partial class NewSiteForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSiteForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lstTemplates = new System.Windows.Forms.ListView();
            this.btnManageTemplates = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blank_site");
            this.imageList1.Images.SetKeyName(1, "template");
            // 
            // lstTemplates
            // 
            this.lstTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTemplates.LargeImageList = this.imageList1;
            this.lstTemplates.Location = new System.Drawing.Point(12, 12);
            this.lstTemplates.MultiSelect = false;
            this.lstTemplates.Name = "lstTemplates";
            this.lstTemplates.ShowItemToolTips = true;
            this.lstTemplates.Size = new System.Drawing.Size(515, 314);
            this.lstTemplates.TabIndex = 1;
            this.lstTemplates.UseCompatibleStateImageBehavior = false;
            this.lstTemplates.SelectedIndexChanged += new System.EventHandler(this.lstTemplates_SelectedIndexChanged);
            this.lstTemplates.DoubleClick += new System.EventHandler(this.lstTemplates_DoubleClick);
            // 
            // btnManageTemplates
            // 
            this.btnManageTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnManageTemplates.Location = new System.Drawing.Point(12, 332);
            this.btnManageTemplates.Name = "btnManageTemplates";
            this.btnManageTemplates.Size = new System.Drawing.Size(125, 23);
            this.btnManageTemplates.TabIndex = 7;
            this.btnManageTemplates.Text = "&Manage Templates...";
            this.btnManageTemplates.UseVisualStyleBackColor = true;
            this.btnManageTemplates.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(452, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(371, 332);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // NewSiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 367);
            this.Controls.Add(this.btnManageTemplates);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstTemplates);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewSiteForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Create New Site";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lstTemplates;
        private System.Windows.Forms.Button btnManageTemplates;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}