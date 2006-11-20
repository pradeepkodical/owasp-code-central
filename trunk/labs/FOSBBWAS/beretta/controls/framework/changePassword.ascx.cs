/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: Allows currently logged in user to change password
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
	///		Summary description for changePassword.
	/// </summary>
	public class changePassword : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtExistingPassword;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.TextBox txtConfirmPassword;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Panel panelError;
		protected System.Web.UI.WebControls.Button cmdChangePassword;
		
		protected user objUser=new user();

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
			this.cmdChangePassword.Click += new System.EventHandler(this.cmdChangePassword_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdChangePassword_Click(object sender, System.EventArgs e)
		{
			string strTmpError="";
			bool bolError=false;

			objUser.id=System.Convert.ToInt32(Session["userId"]);
			objUser.populate();

            panelError.Visible=false;
			lblError.Text="";

			if(txtExistingPassword.Text=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Existing password cannot be blank<BR>";
			}

			if(txtPassword.Text=="")
			{	
				bolError=true;
				strTmpError=strTmpError + "Password cannot be blank<BR>";
			}

			if(txtConfirmPassword.Text=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Confirm Password cannot be blank<BR>";
			}

			if(txtConfirmPassword.Text!=txtPassword.Text)
			{
				bolError=true;
				strTmpError=strTmpError + "Password and Confirm Password do not match<BR>";
			}


			if(bolError==false)
			{

				if (security.login(objUser.username, txtExistingPassword.Text)==0)
				{
					bolError=true;
					strTmpError=strTmpError + "Existing password is incorrect<BR>";

					systemEventsDataAccess.add(16, objUser.username, objUser.id, Request.UserHostAddress.ToString());
				}

			}

			if(bolError==true)
			{
				panelError.Visible=true;
				lblError.Text="" + strTmpError;
				return;
			}

			
			objUser.password=txtPassword.Text;
			objUser.generatePassword();
			objUser.updatePassword();

			systemEventsDataAccess.add(15, objUser.username, objUser.id, Request.UserHostAddress.ToString());

			Response.Redirect("" + ViewState["urlReferrer"].ToString());

			
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			txtExistingPassword.Text="";
			txtPassword.Text="";
			txtConfirmPassword.Text="";
		}
	}
}
