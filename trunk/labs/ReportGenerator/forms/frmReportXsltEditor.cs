using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmReportXsltEditor.
	/// </summary>
	public class frmReportXsltEditor : System.Windows.Forms.Form
	{
		private Owasp.VulnReport.ascx.ascxXsltEditor ascxXsltEditor1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReportXsltEditor()
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
			this.ascxXsltEditor1 = new Owasp.VulnReport.ascx.ascxXsltEditor();
			this.SuspendLayout();
			// 
			// ascxXsltEditor1
			// 
			this.ascxXsltEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ascxXsltEditor1.Location = new System.Drawing.Point(0, 0);
			this.ascxXsltEditor1.Name = "ascxXsltEditor1";
			this.ascxXsltEditor1.Size = new System.Drawing.Size(784, 496);
			this.ascxXsltEditor1.TabIndex = 0;
			// 
			// frmReportXsltEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 502);
			this.Controls.Add(this.ascxXsltEditor1);
			this.Name = "frmReportXsltEditor";
			this.Text = "Report Xslt Editor";
			this.ResumeLayout(false);
		}
		#endregion
	}
}
