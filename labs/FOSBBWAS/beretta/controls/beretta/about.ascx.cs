namespace sourceControl.controls.beretta
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for credits.
	/// </summary>
	public class about : System.Web.UI.UserControl
	{

		protected Label lblAppVersion;
		protected Label lblFrameworkVersion;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Page.IsPostBack==false)
			{
				page_bind();
			}
		}

		private void page_bind()
		{
			lblAppVersion.Text=devCafe.framework.keyDataAccess.get("appVersion");
			lblFrameworkVersion.Text=devCafe.framework.keyDataAccess.get("frameworkVersion");
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
