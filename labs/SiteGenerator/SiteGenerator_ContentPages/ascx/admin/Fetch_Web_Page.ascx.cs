namespace HacmeBank_v2_Website.ascx.admin
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for Fetch_Web_Page.
	/// </summary>
	public class Fetch_Web_Page : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtWebPageUrlToFetch;
		protected System.Web.UI.WebControls.Button btFetchWebPage;
		protected System.Web.UI.WebControls.Label lbWebPageContents;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btFetchWebPage.Click += new System.EventHandler(this.btFetchWebPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btFetchWebPage_Click(object sender, System.EventArgs e)
		{
			lbWebPageContents.Text = AdminFunctions.fetchWebPage(txtWebPageUrlToFetch.Text);			
		}
	}
}
