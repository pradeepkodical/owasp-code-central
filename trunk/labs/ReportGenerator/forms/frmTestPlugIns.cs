using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmTestPlugIns.
	/// </summary>
	public class frmOrgPlugIns : System.Windows.Forms.Form
	{
		private Owasp.VulnReport.ascx.ascxPlugIns ascxPlugIns1;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOrgPlugIns()
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
            this.ascxPlugIns1 = new Owasp.VulnReport.ascx.ascxPlugIns();
            this.SuspendLayout();
            // 
            // ascxPlugIns1
            // 
            this.ascxPlugIns1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxPlugIns1.Location = new System.Drawing.Point(0, 0);
            this.ascxPlugIns1.Name = "ascxPlugIns1";
            this.ascxPlugIns1.Size = new System.Drawing.Size(848, 400);
            this.ascxPlugIns1.TabIndex = 0;
            this.ascxPlugIns1.Load += new System.EventHandler(this.ascxPlugIns1_Load);
            // 
            // frmOrgPlugIns
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(848, 398);
            this.Controls.Add(this.ascxPlugIns1);
            this.Name = "frmOrgPlugIns";
            this.Text = "ORG Plug-ins";
            this.ResumeLayout(false);

		}
		#endregion

		private void ascxPlugIns1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
