namespace TigerClient.CustomControls
{
    partial class ConditionPlaceholderControl
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuResponseCodeIsEqualTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResponseCodeIsNOTEqualTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResponseBodyContains = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResponseBodyDoesNOTContain = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResponseBodyContainsRegex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResponseBodyDoesNOTContainRegex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAND = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOR = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(286, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(286, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(286, 6);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuResponseCodeIsEqualTo,
            this.mnuResponseCodeIsNOTEqualTo,
            toolStripSeparator1,
            this.mnuResponseBodyContains,
            this.mnuResponseBodyDoesNOTContain,
            toolStripSeparator2,
            this.mnuResponseBodyContainsRegex,
            this.mnuResponseBodyDoesNOTContainRegex,
            toolStripSeparator3,
            this.mnuAND,
            this.mnuOR});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(290, 220);
            // 
            // mnuResponseCodeIsEqualTo
            // 
            this.mnuResponseCodeIsEqualTo.Name = "mnuResponseCodeIsEqualTo";
            this.mnuResponseCodeIsEqualTo.Size = new System.Drawing.Size(289, 22);
            this.mnuResponseCodeIsEqualTo.Text = "Response Code is Equal to";
            this.mnuResponseCodeIsEqualTo.Click += new System.EventHandler(this.mnuResponseCodeIsEqualTo_Click);
            // 
            // mnuResponseCodeIsNOTEqualTo
            // 
            this.mnuResponseCodeIsNOTEqualTo.Name = "mnuResponseCodeIsNOTEqualTo";
            this.mnuResponseCodeIsNOTEqualTo.Size = new System.Drawing.Size(289, 22);
            this.mnuResponseCodeIsNOTEqualTo.Text = "Response Code is NOT Equal to";
            this.mnuResponseCodeIsNOTEqualTo.Click += new System.EventHandler(this.mnuResponseCodeIsNOTEqualTo_Click);
            // 
            // mnuResponseBodyContains
            // 
            this.mnuResponseBodyContains.Name = "mnuResponseBodyContains";
            this.mnuResponseBodyContains.Size = new System.Drawing.Size(289, 22);
            this.mnuResponseBodyContains.Text = "Response Body Contains";
            this.mnuResponseBodyContains.Click += new System.EventHandler(this.mnuResponseBodyContains_Click);
            // 
            // mnuResponseBodyDoesNOTContain
            // 
            this.mnuResponseBodyDoesNOTContain.Name = "mnuResponseBodyDoesNOTContain";
            this.mnuResponseBodyDoesNOTContain.Size = new System.Drawing.Size(289, 22);
            this.mnuResponseBodyDoesNOTContain.Text = "Response Body Does NOT Contain";
            this.mnuResponseBodyDoesNOTContain.Click += new System.EventHandler(this.mnuResponseBodyDoesNOTContain_Click);
            // 
            // mnuResponseBodyContainsRegex
            // 
            this.mnuResponseBodyContainsRegex.Name = "mnuResponseBodyContainsRegex";
            this.mnuResponseBodyContainsRegex.Size = new System.Drawing.Size(289, 22);
            this.mnuResponseBodyContainsRegex.Text = "Response Body Contains (regex)";
            this.mnuResponseBodyContainsRegex.Click += new System.EventHandler(this.mnuResponseBodyContainsRegex_Click);
            // 
            // mnuResponseBodyDoesNOTContainRegex
            // 
            this.mnuResponseBodyDoesNOTContainRegex.Name = "mnuResponseBodyDoesNOTContainRegex";
            this.mnuResponseBodyDoesNOTContainRegex.Size = new System.Drawing.Size(289, 22);
            this.mnuResponseBodyDoesNOTContainRegex.Text = "Response Body Does NOT Contain (regex)";
            this.mnuResponseBodyDoesNOTContainRegex.Click += new System.EventHandler(this.mnuResponseBodyDoesNOTContainRegex_Click);
            // 
            // mnuAND
            // 
            this.mnuAND.Name = "mnuAND";
            this.mnuAND.Size = new System.Drawing.Size(289, 22);
            this.mnuAND.Text = "AND";
            this.mnuAND.Click += new System.EventHandler(this.mnuAND_Click);
            // 
            // mnuOR
            // 
            this.mnuOR.Name = "mnuOR";
            this.mnuOR.Size = new System.Drawing.Size(289, 22);
            this.mnuOR.Text = "OR";
            this.mnuOR.Click += new System.EventHandler(this.mnuOR_Click);
            // 
            // ConditionPlaceholderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Center = new System.Drawing.Point(117, 50);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "ConditionPlaceholderControl";
            this.Size = new System.Drawing.Size(204, 71);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuResponseCodeIsEqualTo;
        private System.Windows.Forms.ToolStripMenuItem mnuResponseCodeIsNOTEqualTo;
        private System.Windows.Forms.ToolStripMenuItem mnuResponseBodyContains;
        private System.Windows.Forms.ToolStripMenuItem mnuResponseBodyDoesNOTContain;
        private System.Windows.Forms.ToolStripMenuItem mnuResponseBodyContainsRegex;
        private System.Windows.Forms.ToolStripMenuItem mnuResponseBodyDoesNOTContainRegex;
        private System.Windows.Forms.ToolStripMenuItem mnuAND;
        private System.Windows.Forms.ToolStripMenuItem mnuOR;
    }
}
