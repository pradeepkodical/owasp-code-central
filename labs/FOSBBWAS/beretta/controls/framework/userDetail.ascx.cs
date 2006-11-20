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
	public class userDetail : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtUsername;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtFirstname;
		protected System.Web.UI.WebControls.TextBox txtLastname;
		protected System.Web.UI.WebControls.TextBox txtOrganisation;
		protected System.Web.UI.WebControls.DropDownList dropDownType;
		protected System.Web.UI.WebControls.CheckBox chkIsActive;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdCancel;

		protected Button cmdChangePassword;
		protected Panel panelError;
		protected Label lblError;

		protected user objUser=new user();
		protected int intUserId=0;
		protected DropDownList dropDownRole;
		protected Button cmdAddRole;
		protected ListBox lstRoles;
		protected System.Web.UI.WebControls.ValidationSummary Validationsummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator valEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected Button cmdRemoveRole;

		private void Page_Load(object sender, System.EventArgs e)
		{

			if(Page.IsPostBack==false)
			{
				try
				{	
					intUserId=System.Convert.ToInt32(Request.QueryString["userId"]);
				}
				catch
				{
					intUserId=0;
				}
			
				ViewState["UrlReferrer"] = "" + Request.UrlReferrer.ToString();	
				ViewState["userId"]=intUserId.ToString();

				dropDownRole_bind();
				lstRoles_bind();

				if(intUserId !=0)
				{
					txtPassword.Enabled=false;
					cmdChangePassword.Text="Change";
					cmdAdd.Text="Update";
					page_bind();
				}
				else
				{
					txtPassword.Enabled=true;
					chkIsActive.Checked=true;
					cmdChangePassword.Text="Cancel";
				}
			}
			else
			{
				intUserId=System.Convert.ToInt32(ViewState["userId"]);
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
			this.cmdAddRole.Click += new System.EventHandler(this.cmdAddRole_click);
			this.cmdRemoveRole.Click += new System.EventHandler(this.cmdRemoveRole_click);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstRoles_bind()
		{
			DataSet objDataSet=new DataSet();
			objDataSet=rolesDataAccess.getAllForUser(intUserId);

			lstRoles.Items.Clear();
					
			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{

				ListItem objItem=new ListItem();
				objItem.Text="" + objDataRow["roleName"].ToString();
				objItem.Value="" + objDataRow["id"].ToString();

				lstRoles.Items.Add(objItem);

				objItem=null;
			}
		}

		private void cmdRemoveRole_click(object sender, System.EventArgs e)
		{	
			if(lstRoles.SelectedItem==null) return;

			rolesDataAccess.deleteUserRole(System.Convert.ToInt32(lstRoles.SelectedItem.Value));
			
			lstRoles_bind();
		}

		private void cmdAddRole_click(object sender, System.EventArgs e)
		{
			if(dropDownRole.SelectedItem==null) return;

			if (page_save()==false) 
			{
				return;
			}

			rolesDataAccess.addUserRole(intUserId, System.Convert.ToInt32(dropDownRole.SelectedItem.Value));

			lstRoles_bind();

			dropDownRole.SelectedIndex=0;
		}

		private void dropDownRole_bind()
		{
			DataSet objDataSet=new DataSet();
			objDataSet=rolesDataAccess.getAll();

			dropDownRole.Items.Clear();

			ListItem objNull=new ListItem();
			objNull.Text="--";
			objNull.Value="0";

			dropDownRole.Items.Add(objNull);

			
			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{

				ListItem objItem=new ListItem();
				objItem.Text="" + objDataRow["roleName"].ToString();
				objItem.Value="" + objDataRow["id"].ToString();

				dropDownRole.Items.Add(objItem);

				objItem=null;
			}
		}

		private void page_bind()
		{
			objUser.id=intUserId;
			objUser.populate();


			txtUsername.Text="" + objUser.username;
		
			txtOrganisation.Text="" + objUser.organisation;
			txtFirstname.Text="" + objUser.firstName;
			txtLastname.Text="" + objUser.lastName;
			txtEmail.Text="" + objUser.email;

			dropDownType.ClearSelection();

			foreach(ListItem objListItem in dropDownType.Items)
			{
				if(objListItem.Value=="" + objUser.type.ToString()) 
				{
					objListItem.Selected=true;
					break;
				}
				
			}

			if(objUser.isActive==0)
			{
				chkIsActive.Checked=false;
			}
			else
			{
				chkIsActive.Checked=true;
			}


			
		}

		private bool page_validate()
		{

			bool bolError=false;
			string strTmpError="";

			if(dropDownType.SelectedItem==null || dropDownType.SelectedIndex==0)
			{
				bolError=true;
				strTmpError+="Please select user type<BR>";
			}

			if(intUserId==0)
			{
				if(txtPassword.Text.Trim()=="")
				{
					bolError=true;
					strTmpError+="Password cannot be blank<BR>";

				}

			}
			else
			{

				if(cmdChangePassword.Text=="Cancel" && txtPassword.Text.Trim()=="")
				{
					bolError=true;
					strTmpError+="Password cannot be blank<BR>";

				}
			}

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
			
			if (page_save()==true) 
			{
				Response.Redirect("" + ViewState["UrlReferrer"].ToString());
			}

		}

		private bool page_save()
		{
			panelError.Visible=false;
			lblError.Text="";

			if(page_validate()==false)
			{
				return false;
			}
			

			if(intUserId!=0)
			{
				objUser.id=intUserId;
				objUser.populate();
			}

			objUser.username="" + txtUsername.Text;
			
			objUser.organisation="" + txtOrganisation.Text;
			objUser.firstName="" + txtFirstname.Text;
			objUser.lastName="" + txtLastname.Text;
			objUser.email="" + txtEmail.Text;

			objUser.type=System.Convert.ToInt32(dropDownType.SelectedItem.Value);

			

			if(chkIsActive.Checked==true)
			{
				objUser.isActive=1;
			}
			else
			{
				objUser.isActive=0;
			}

			//Only change password if user has seleced to
			

			if(intUserId!=0)
			{
				objUser.update();

				if(cmdChangePassword.Text=="Cancel")
				{
					objUser.password="" + txtPassword.Text;	
					objUser.generatePassword();
					objUser.updatePassword();
				}

			}
			else
			{
				objUser.add();

				objUser.password="" + txtPassword.Text;	
				objUser.generatePassword();
				objUser.updatePassword();
			}

			intUserId=objUser.id;
			ViewState["userId"]=intUserId.ToString();

			cmdChangePassword.Text="Change";
			txtPassword.Enabled=false;

			return true;
		}

		private void cmdChangePassword_Click(object sender, System.EventArgs e)
		{
			if(cmdChangePassword.Text=="Change")
			{
				txtPassword.Enabled=true;
				cmdChangePassword.Text="Cancel";
			}
			else
			{
				txtPassword.Enabled=false;
				cmdChangePassword.Text="Change";
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("" + ViewState["UrlReferrer"].ToString());
		}
	}
}
