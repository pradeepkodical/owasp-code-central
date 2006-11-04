using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using System.Xml;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmCreatingPPTs.
	/// </summary>
	public class frmCreatingPPTs : System.Windows.Forms.Form
	{
		

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCreatingPPTs()
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
			// 
			// frmCreatingPPTs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 278);
			this.Name = "frmCreatingPPTs";
			this.Text = "frmCreatingPPTs";
//			this.Load += new System.EventHandler(this.frmCreatingPPTs_Load);

		}
		#endregion
	}
}
