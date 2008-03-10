namespace Owasp.Osg.Controller.Controls
{
    partial class SiteTreeControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteTreeControl));
            this.treeControl = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeControl
            // 
            this.treeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeControl.ImageIndex = 0;
            this.treeControl.ImageList = this.imageList1;
            this.treeControl.Location = new System.Drawing.Point(0, 0);
            this.treeControl.Name = "treeControl";
            this.treeControl.SelectedImageIndex = 0;
            this.treeControl.Size = new System.Drawing.Size(372, 400);
            this.treeControl.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "project");
            this.imageList1.Images.SetKeyName(1, "project_invalid");
            this.imageList1.Images.SetKeyName(2, "folder_open");
            this.imageList1.Images.SetKeyName(3, "folder_closed");
            this.imageList1.Images.SetKeyName(4, "site");
            this.imageList1.Images.SetKeyName(5, "site_invalid");
            this.imageList1.Images.SetKeyName(6, "test");
            this.imageList1.Images.SetKeyName(7, "test_invalid");
            this.imageList1.Images.SetKeyName(8, "parameter");
            this.imageList1.Images.SetKeyName(9, "parameter_invalid");
            this.imageList1.Images.SetKeyName(10, "alert_invalid");
            this.imageList1.Images.SetKeyName(11, "alert");
            // 
            // SiteTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeControl);
            this.Name = "SiteTreeControl";
            this.Size = new System.Drawing.Size(372, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeControl;
        private System.Windows.Forms.ImageList imageList1;
    }
}
