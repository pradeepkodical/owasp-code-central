namespace TigerClient.CustomControls
{
    partial class ProjectExplorerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectExplorerControl));
            this.tree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.windowHeaderControl1 = new TigerClient.CustomControls.WindowHeaderControl();
            this.treeViewAdapter = new TigerClient.ControlAdapters.TreeViewAdapter(this.components);
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.imageList1;
            this.tree.Location = new System.Drawing.Point(0, 17);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowNodeToolTips = true;
            this.tree.Size = new System.Drawing.Size(263, 260);
            this.tree.TabIndex = 1;
            this.tree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterCollapse);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            this.tree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterExpand);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "project");
            this.imageList1.Images.SetKeyName(1, "project_invalid");
            this.imageList1.Images.SetKeyName(2, "folder_open");
            this.imageList1.Images.SetKeyName(3, "folder_closed");
            this.imageList1.Images.SetKeyName(4, "target");
            this.imageList1.Images.SetKeyName(5, "target_invalid");
            this.imageList1.Images.SetKeyName(6, "test");
            this.imageList1.Images.SetKeyName(7, "test_invalid");
            this.imageList1.Images.SetKeyName(8, "parameter");
            this.imageList1.Images.SetKeyName(9, "parameter_invalid");
            this.imageList1.Images.SetKeyName(10, "alert_invalid");
            this.imageList1.Images.SetKeyName(11, "alert");
            // 
            // windowHeaderControl1
            // 
            this.windowHeaderControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowHeaderControl1.IsActive = false;
            this.windowHeaderControl1.Location = new System.Drawing.Point(0, 0);
            this.windowHeaderControl1.Name = "windowHeaderControl1";
            this.windowHeaderControl1.Size = new System.Drawing.Size(263, 17);
            this.windowHeaderControl1.TabIndex = 0;
            this.windowHeaderControl1.Text = "Project Explorer";
            this.windowHeaderControl1.CloseButtonClick += new System.EventHandler(this.windowHeaderControl1_CloseButtonClick);
            this.windowHeaderControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.windowHeaderControl1_MouseDown);
            // 
            // treeViewAdapter
            // 
            this.treeViewAdapter.TreeView = null;
            // 
            // ProjectExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree);
            this.Controls.Add(this.windowHeaderControl1);
            this.Name = "ProjectExplorerControl";
            this.Size = new System.Drawing.Size(263, 277);
            this.Enter += new System.EventHandler(this.ProjectExplorerControl_Enter);
            this.Leave += new System.EventHandler(this.ProjectExplorerControl_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowHeaderControl windowHeaderControl1;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ImageList imageList1;
        private TigerClient.ControlAdapters.TreeViewAdapter treeViewAdapter;
    }
}
