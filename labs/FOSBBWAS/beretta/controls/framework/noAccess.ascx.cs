/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: Used when user tries to access project they dont have access to
 */

namespace sourceControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for noAccess.
	/// </summary>
	public class noAccess : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblNoAccess;

		protected LinkButton lnkBackToMyProjects;


		private void lnkBackToMyProjects_click(object sender, System.EventArgs e)
		{
			
			Response.Redirect("" + ViewState["urlReferrer"].ToString());
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Page.IsPostBack==false)
			{
				ViewState["urlReferrer"]="" + Request.UrlReferrer.ToString();
			}
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
			this.lnkBackToMyProjects.Click += new System.EventHandler(this.lnkBackToMyProjects_click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
