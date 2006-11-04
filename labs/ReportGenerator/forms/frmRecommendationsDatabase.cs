using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for frmRecommendationsDatabase.
	/// </summary>
	public class frmRecommendationsDatabase : System.Windows.Forms.Form
	{
		private Owasp.VulnReport.ascx.ascxRecommendations ascxRecommendations1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRecommendationsDatabase()
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
			this.ascxRecommendations1 = new Owasp.VulnReport.ascx.ascxRecommendations();
			this.SuspendLayout();
			// 
			// ascxRecommendations1
			// 
			this.ascxRecommendations1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ascxRecommendations1.Location = new System.Drawing.Point(0, 0);
			this.ascxRecommendations1.Name = "ascxRecommendations1";
			this.ascxRecommendations1.Size = new System.Drawing.Size(776, 504);
			this.ascxRecommendations1.TabIndex = 0;
			// 
			// frmRecommendationsDatabase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 502);
			this.Controls.Add(this.ascxRecommendations1);
			this.Name = "frmRecommendationsDatabase";
			this.Text = "Recommendations Database";
			this.Load += new System.EventHandler(this.frmRecommendationsDatabase_Load);
			this.ResumeLayout(false);
            this.FormClosing += new FormClosingEventHandler(frmRecommendationsDatabase_FormClosing);

		}

        /// <summary>
        /// This allows the user to save any unsaved data if they close the form by accident.
        /// </summary>
        void frmRecommendationsDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            ascxRecommendations1.checkForUnSavedDataAndPromptForSave();
        }
		#endregion

		private void frmRecommendationsDatabase_Load(object sender, System.EventArgs e)
		{
			if (!this.DesignMode)
				ascxRecommendations1.loadRecommendationsXmlFileIntoAuthenticEditor();
		}
	}
}
