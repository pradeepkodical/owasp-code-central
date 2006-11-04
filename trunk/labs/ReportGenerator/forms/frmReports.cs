using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmReports.
	/// </summary>
	public class frmReports : System.Windows.Forms.Form
	{
		private Owasp.VulnReport.ascx.ascxReports ascxReports1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReports()
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
			this.ascxReports1 = new Owasp.VulnReport.ascx.ascxReports();
			this.SuspendLayout();
			// 
			// ascxReports1
			// 
			this.ascxReports1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ascxReports1.Location = new System.Drawing.Point(0, 0);
			this.ascxReports1.Name = "ascxReports1";
			this.ascxReports1.Size = new System.Drawing.Size(816, 456);
			this.ascxReports1.TabIndex = 0;
			// 
			// frmReports
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ascxReports1);
			this.Name = "frmReports";
			this.Text = "Reports";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
