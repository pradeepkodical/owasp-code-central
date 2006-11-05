namespace Owasp.SiteGenerator.ascx
{
    partial class ascxFileTransformation
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
            this.lvFileTransformations = new System.Windows.Forms.ListView();
            this.chFileTransformationFilter = new System.Windows.Forms.ColumnHeader();
            this.chOriginalFileName = new System.Windows.Forms.ColumnHeader();
            this.chTransformedFileName = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvFileTransformations
            // 
            this.lvFileTransformations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileTransformations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileTransformationFilter,
            this.chOriginalFileName,
            this.chTransformedFileName});
            this.lvFileTransformations.FullRowSelect = true;
            this.lvFileTransformations.Location = new System.Drawing.Point(0, 0);
            this.lvFileTransformations.Name = "lvFileTransformations";
            this.lvFileTransformations.Size = new System.Drawing.Size(865, 355);
            this.lvFileTransformations.TabIndex = 11;
            this.lvFileTransformations.UseCompatibleStateImageBehavior = false;
            this.lvFileTransformations.View = System.Windows.Forms.View.Details;
            // 
            // chFileTransformationFilter
            // 
            this.chFileTransformationFilter.Text = "File Transformation Filter";
            this.chFileTransformationFilter.Width = 10;
            // 
            // chOriginalFileName
            // 
            this.chOriginalFileName.Text = "Original File Name";
            this.chOriginalFileName.Width = 263;
            // 
            // chTransformedFileName
            // 
            this.chTransformedFileName.Text = "Transformed File Name";
            this.chTransformedFileName.Width = 415;
            // 
            // ascxFileTransformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lvFileTransformations);
            this.Name = "ascxFileTransformation";
            this.Size = new System.Drawing.Size(865, 355);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView lvFileTransformations;
        private System.Windows.Forms.ColumnHeader chFileTransformationFilter;
        private System.Windows.Forms.ColumnHeader chOriginalFileName;
        private System.Windows.Forms.ColumnHeader chTransformedFileName;


    }
}
