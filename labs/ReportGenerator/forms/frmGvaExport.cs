using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmExport.
	/// </summary>
	public class frmExport : System.Windows.Forms.Form
	{
		private Owasp.VulnReport.ascxExport ascxExport1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmExport()
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
			this.ascxExport1 = new Owasp.VulnReport.ascxExport();
			this.SuspendLayout();
			// 
			// ascxExport1
			// 
			this.ascxExport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ascxExport1.Location = new System.Drawing.Point(0, 0);
			this.ascxExport1.Name = "ascxExport1";
			this.ascxExport1.Size = new System.Drawing.Size(880, 424);
			this.ascxExport1.TabIndex = 0;
			// 
			// frmExport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(888, 430);
			this.Controls.Add(this.ascxExport1);
			this.Name = "frmExport";
			this.Text = "frmExport";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
