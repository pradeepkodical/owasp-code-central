namespace Owasp.SiteGenerator.ascx
{
    partial class ascxAdmin
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
            ConnectionForCommunicatingWithWeb.CloseConnections();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDebugAllReceivedMessages = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btClearAllControls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDebugAllReceivedMessages
            // 
            this.txtDebugAllReceivedMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugAllReceivedMessages.Location = new System.Drawing.Point(3, 24);
            this.txtDebugAllReceivedMessages.Multiline = true;
            this.txtDebugAllReceivedMessages.Name = "txtDebugAllReceivedMessages";
            this.txtDebugAllReceivedMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugAllReceivedMessages.Size = new System.Drawing.Size(779, 107);
            this.txtDebugAllReceivedMessages.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Raw data (All  Received Messages)";
            // 
            // btClearAllControls
            // 
            this.btClearAllControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearAllControls.Location = new System.Drawing.Point(622, 3);
            this.btClearAllControls.Name = "btClearAllControls";
            this.btClearAllControls.Size = new System.Drawing.Size(160, 20);
            this.btClearAllControls.TabIndex = 6;
            this.btClearAllControls.Text = "&Clear Received Data";
            this.btClearAllControls.UseVisualStyleBackColor = true;
            this.btClearAllControls.Click += new System.EventHandler(this.btClearAllControls_Click);
            // 
            // ascxAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btClearAllControls);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDebugAllReceivedMessages);
            this.Name = "ascxAdmin";
            this.Size = new System.Drawing.Size(785, 135);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtDebugAllReceivedMessages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btClearAllControls;
    }
}
