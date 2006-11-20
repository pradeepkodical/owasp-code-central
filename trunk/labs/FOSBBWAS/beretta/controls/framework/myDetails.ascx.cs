/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: User detail screen
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
	///		Summary description for userDetail.
	/// </summary>
	public class myDetails : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtFirstname;
		protected System.Web.UI.WebControls.TextBox txtLastname;
		protected System.Web.UI.WebControls.TextBox txtOrganisation;
		
	
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdCancel;

		protected Panel panelError;
		protected Label lblError;

		protected user objUser=new user();
		protected System.Web.UI.WebControls.ValidationSummary Validationsummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator valEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected int intUserId=0;

		private void Page_Load(object sender, System.EventArgs e)
		{

			if(Page.IsPostBack==false)
			{
				try
				{	
					intUserId=System.Convert.ToInt32(Session["userId"]);
				}
				catch
				{
					intUserId=0;
				}
			
				ViewState["UrlReferrer"] = "" + Request.UrlReferrer.ToString();	
			
				cmdAdd.Text="Update";
				page_bind();
				
			
			}
			else
			{
				intUserId=System.Convert.ToInt32(Session["userId"]);
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
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void page_bind()
		{
			objUser.id=intUserId;
			objUser.populate();


			
		
			txtOrganisation.Text="" + objUser.organisation;
			txtFirstname.Text="" + objUser.firstName;
			txtLastname.Text="" + objUser.lastName;
			txtEmail.Text="" + objUser.email;

			

			
			
		}

		private bool page_validate()
		{

			bool bolError=false;
			string strTmpError="";

			
			if(bolError==true)
			{
				panelError.Visible=true;
				lblError.Text=strTmpError;

			}

			if(bolError==true)
			{
				return false;
			}
			else
			{
				return true;
			}


		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			
			panelError.Visible=false;
			lblError.Text="";

			if(page_validate()==false)
			{
				return;
			}
			

			objUser.id=intUserId;
			objUser.populate();
			

			objUser.organisation="" + txtOrganisation.Text;
			objUser.firstName="" + txtFirstname.Text;
			objUser.lastName="" + txtLastname.Text;
			objUser.email="" + txtEmail.Text;

			objUser.update();

			


			Response.Redirect("" + ViewState["UrlReferrer"].ToString());
		}

		

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("" + ViewState["UrlReferrer"].ToString());
		}
	}
}
