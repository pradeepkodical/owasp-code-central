namespace TigerClient.CustomControls
{
    partial class PropertiesControl
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.windowHeaderControl1 = new TigerClient.CustomControls.WindowHeaderControl();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 17);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(281, 315);
            this.propertyGrid1.TabIndex = 1;
            // 
            // windowHeaderControl1
            // 
            this.windowHeaderControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowHeaderControl1.IsActive = false;
            this.windowHeaderControl1.Location = new System.Drawing.Point(0, 0);
            this.windowHeaderControl1.Name = "windowHeaderControl1";
            this.windowHeaderControl1.Size = new System.Drawing.Size(281, 17);
            this.windowHeaderControl1.TabIndex = 0;
            this.windowHeaderControl1.Text = "Properties";
            this.windowHeaderControl1.CloseButtonClick += new System.EventHandler(this.windowHeaderControl1_CloseButtonClick);
            this.windowHeaderControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.windowHeaderControl1_MouseDown);
            // 
            // PropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.windowHeaderControl1);
            this.Name = "PropertiesControl";
            this.Size = new System.Drawing.Size(281, 332);
            this.Enter += new System.EventHandler(this.PropertiesControl_Enter);
            this.Leave += new System.EventHandler(this.PropertiesControl_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowHeaderControl windowHeaderControl1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;


    }
}
