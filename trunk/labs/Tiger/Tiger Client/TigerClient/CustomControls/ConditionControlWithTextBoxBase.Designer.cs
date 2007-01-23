namespace TigerClient.CustomControls
{
    partial class ConditionControlWithTextBoxBase
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
            this.txtConditionParameter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtConditionParameter
            // 
            this.txtConditionParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConditionParameter.Location = new System.Drawing.Point(12, 38);
            this.txtConditionParameter.Name = "txtConditionParameter";
            this.txtConditionParameter.Size = new System.Drawing.Size(180, 20);
            this.txtConditionParameter.TabIndex = 2;
            // 
            // ConditionControlWithTextBoxBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Center = new System.Drawing.Point(117, 50);
            this.Controls.Add(this.txtConditionParameter);
            this.Name = "ConditionControlWithTextBoxBase";
            this.Size = new System.Drawing.Size(204, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtConditionParameter;
    }
}
