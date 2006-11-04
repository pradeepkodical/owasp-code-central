using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmIssueTracking.
	/// </summary>
	public class frmIssueTracking : System.Windows.Forms.Form
	{
		private Owasp.VulnReport.ascx.ascxIssueTracking ascxIssueTracking1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIssueTracking()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ascxIssueTracking1 = new Owasp.VulnReport.ascx.ascxIssueTracking();
			this.SuspendLayout();
			// 
			// ascxIssueTracking1
			// 
			this.ascxIssueTracking1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ascxIssueTracking1.Location = new System.Drawing.Point(8, 0);
			this.ascxIssueTracking1.Name = "ascxIssueTracking1";
			this.ascxIssueTracking1.Size = new System.Drawing.Size(840, 368);
			this.ascxIssueTracking1.TabIndex = 0;
			// 
			// frmIssueTracking
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 374);
			this.Controls.Add(this.ascxIssueTracking1);
			this.Name = "frmIssueTracking";
			this.Text = "Issue Tracking";
			this.Load += new System.EventHandler(this.frmIssueTracking_Load);
			this.ResumeLayout(false);
            this.FormClosing += new FormClosingEventHandler(frmIssueTracking_FormClosing);

        }
        #endregion

        /// <summary>
        /// Make sure the user wants to close the form without saving any of its data.
        /// </summary>
        void frmIssueTracking_FormClosing(object sender, FormClosingEventArgs e)
        {
            ascxIssueTracking1.checkForUnSavedDataAndPromptForSave();
        }
		

		private void frmIssueTracking_Load(object sender, System.EventArgs e)
		{
			if (!this.DesignMode)
				ascxIssueTracking1.loadReportFilesIntoListbox();
		}
	}
}
