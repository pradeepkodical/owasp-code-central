namespace TigerClient.CustomControls
{
    partial class TargetControl
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
            this.picCollapse = new System.Windows.Forms.PictureBox();
            this.lblTargetDisplayName = new System.Windows.Forms.Label();
            this.automatedTestsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCollapse)).BeginInit();
            this.SuspendLayout();
            // 
            // picCollapse
            // 
            this.picCollapse.Image = global::TigerClient.Properties.Resources.Expanded;
            this.picCollapse.Location = new System.Drawing.Point(3, 3);
            this.picCollapse.Name = "picCollapse";
            this.picCollapse.Size = new System.Drawing.Size(11, 11);
            this.picCollapse.TabIndex = 0;
            this.picCollapse.TabStop = false;
            this.picCollapse.Click += new System.EventHandler(this.picCollapse_Click);
            // 
            // lblTargetDisplayName
            // 
            this.lblTargetDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetDisplayName.AutoEllipsis = true;
            this.lblTargetDisplayName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTargetDisplayName.Location = new System.Drawing.Point(20, 3);
            this.lblTargetDisplayName.Name = "lblTargetDisplayName";
            this.lblTargetDisplayName.Size = new System.Drawing.Size(569, 13);
            this.lblTargetDisplayName.TabIndex = 1;
            this.lblTargetDisplayName.Text = "Target label";
            // 
            // automatedTestsPanel
            // 
            this.automatedTestsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.automatedTestsPanel.AutoSize = true;
            this.automatedTestsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.automatedTestsPanel.Location = new System.Drawing.Point(23, 19);
            this.automatedTestsPanel.Name = "automatedTestsPanel";
            this.automatedTestsPanel.Size = new System.Drawing.Size(567, 10);
            this.automatedTestsPanel.TabIndex = 2;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Response body:";
            // 
            // TargetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.automatedTestsPanel);
            this.Controls.Add(this.lblTargetDisplayName);
            this.Controls.Add(this.picCollapse);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TargetControl";
            this.Size = new System.Drawing.Size(592, 32);
            ((System.ComponentModel.ISupportInitialize)(this.picCollapse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCollapse;
        private System.Windows.Forms.Label lblTargetDisplayName;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.FlowLayoutPanel automatedTestsPanel;
    }
}
