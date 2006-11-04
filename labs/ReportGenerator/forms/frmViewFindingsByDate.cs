using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmViewFindingsByDate.
	/// </summary>
	public class frmViewFindingsByDate : System.Windows.Forms.Form
	{
		public Owasp.VulnReport.ascx.ascxViewFindingsBydate ascxViewFindingsBydate1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmViewFindingsByDate()
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
			this.ascxViewFindingsBydate1 = new Owasp.VulnReport.ascx.ascxViewFindingsBydate();
			this.SuspendLayout();
			// 
			// ascxViewFindingsBydate1
			// 
			this.ascxViewFindingsBydate1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ascxViewFindingsBydate1.Location = new System.Drawing.Point(0, 0);
			this.ascxViewFindingsBydate1.Name = "ascxViewFindingsBydate1";
			this.ascxViewFindingsBydate1.Size = new System.Drawing.Size(832, 336);
			this.ascxViewFindingsBydate1.TabIndex = 0;
			// 
			// frmViewFindingsByDate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(832, 334);
			this.Controls.Add(this.ascxViewFindingsBydate1);
			this.Name = "frmViewFindingsByDate";
			this.Text = "frmViewFindingsByDate";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
