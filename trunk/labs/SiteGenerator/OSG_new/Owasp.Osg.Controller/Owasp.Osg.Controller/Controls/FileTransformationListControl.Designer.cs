namespace Owasp.Osg.Controller.Controls
{
    partial class FileTransformationListControl
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.colFileTransformationFilter = new System.Windows.Forms.ColumnHeader();
            this.colOriginalFileName = new System.Windows.Forms.ColumnHeader();
            this.colTransformedFileName = new System.Windows.Forms.ColumnHeader();
            this.windowHeaderControl1 = new Owasp.Osg.Controller.Controls.WindowHeaderControl();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileTransformationFilter,
            this.colOriginalFileName,
            this.colTransformedFileName});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 17);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(689, 248);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colFileTransformationFilter
            // 
            this.colFileTransformationFilter.Text = "File Transformation Filter";
            this.colFileTransformationFilter.Width = 10;
            // 
            // colOriginalFileName
            // 
            this.colOriginalFileName.Text = "Original File Name";
            this.colOriginalFileName.Width = 260;
            // 
            // colTransformedFileName
            // 
            this.colTransformedFileName.Text = "Transformed File Name";
            this.colTransformedFileName.Width = 415;
            // 
            // windowHeaderControl1
            // 
            this.windowHeaderControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowHeaderControl1.IsActive = false;
            this.windowHeaderControl1.Location = new System.Drawing.Point(0, 0);
            this.windowHeaderControl1.Name = "windowHeaderControl1";
            this.windowHeaderControl1.Size = new System.Drawing.Size(689, 17);
            this.windowHeaderControl1.TabIndex = 0;
            this.windowHeaderControl1.Text = "File Transformation List";
            this.windowHeaderControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.windowHeaderControl1_MouseDown);
            this.windowHeaderControl1.CloseButtonClick += new System.EventHandler(this.windowHeaderControl1_CloseButtonClick);
            // 
            // FileTransformationListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.windowHeaderControl1);
            this.Name = "FileTransformationListControl";
            this.Size = new System.Drawing.Size(689, 265);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowHeaderControl windowHeaderControl1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colFileTransformationFilter;
        private System.Windows.Forms.ColumnHeader colOriginalFileName;
        private System.Windows.Forms.ColumnHeader colTransformedFileName;

    }
}
