using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmSplashPage.
	/// </summary>
	public class frmSplashPage : System.Windows.Forms.Form
	{
		private Owasp.VulnReport.ascx.ascxSplashPage ascxSplashPage1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSplashPage(bool bByPassSplashPage)
		{            
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            if (bByPassSplashPage && !this.DesignMode) {
                ascxSplashPage1.byPassSplashPage();
                Close();
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashPage));
            this.ascxSplashPage1 = new Owasp.VulnReport.ascx.ascxSplashPage();
            this.SuspendLayout();
            // 
            // ascxSplashPage1
            // 
            this.ascxSplashPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ascxSplashPage1.Location = new System.Drawing.Point(0, 0);
            this.ascxSplashPage1.Name = "ascxSplashPage1";
            this.ascxSplashPage1.Size = new System.Drawing.Size(648, 408);
            this.ascxSplashPage1.TabIndex = 0;
            // 
            // frmSplashPage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(648, 414);
            this.ControlBox = false;
            this.Controls.Add(this.ascxSplashPage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSplashPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Owasp PenTest Reporter - Configuration Area";
            this.ResumeLayout(false);

		}
		#endregion
	}
}
