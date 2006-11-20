/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: Main login control
 */
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using devCafe.framework;

namespace sourceControl.controls
{
	

	/// <summary>
	///		Summary description for signIn.
	/// </summary>
	public class signIn : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtUsername;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button cmdLogin;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Panel panelMessage;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected user objUser=new user();
		public string siteRoot="" + settings.siteRoot;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Page.IsPostBack==false)
			{
				setFocus(txtUsername);
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
			this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void setFocus(System.Web.UI.Control ctrl)
		{
			string s = "<SCRIPT language='javascript'>document.getElementById('" + ctrl.ClientID + "').focus()</SCRIPT>";
			Page.RegisterStartupScript("focus", s);
		}

		private void cmdLogin_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid==false) return;

			string strUsername="";
			string strPassword="";
			int intUserId=0;

			panelMessage.Visible=false;
			lblMessage.Text="";

			strUsername=txtUsername.Text.Trim().Replace("'", "''");
			strPassword=txtPassword.Text.Trim().Replace("'", "''");


			intUserId=security.login(strUsername, strPassword);
			
			if(intUserId==0)
			{
				panelMessage.Visible=true;
				lblMessage.Text="Login Failed";

				systemEventsDataAccess.add(1, strUsername, 0, Request.UserHostAddress.ToString());

				return;
			}

			objUser.id=intUserId;
			objUser.populate();

			Session["username"]="" + objUser.username;
			Session["userId"]="" + objUser.id;
			Session["userType"]="" + objUser.type;
			Session["firstName"]="" + objUser.firstName;
			Session["lastName"]="" + objUser.lastName;
			Session["userRoles"]="" + objUser.userRoles;

			
			systemEventsDataAccess.add(17, strUsername, 0, Request.UserHostAddress.ToString());

			Response.Redirect("~/default.aspx?pageId=1");

		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			txtUsername.Text="";
			txtPassword.Text="";
		}
	}
}
