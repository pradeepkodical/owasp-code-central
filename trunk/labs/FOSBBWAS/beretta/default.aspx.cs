/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: Main page. Loads relevant layout.ascx as determined by layoutId which then loads modules
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using devCafe.framework;

namespace sourceControl
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel panelPlaceHolder;
		public int intPageId=0;
		public string siteRoot="" + settings.siteRoot;
	

		private void Page_Load(object sender, System.EventArgs e)
		{


			//Hosts Allow security check
			if(Application["useHostsAllow"].ToString()=="true")
			{
				checkHostsAllow();
			}

			if(Application["enforceSecureConnection"].ToString()=="true")
			{
				checkSecureConnection();
			}


			
			try
			{	
				intPageId=System.Convert.ToInt32(Request.QueryString["pageId"]);
			}
			catch
			{
				intPageId=0;
			}

			//Log potential SQL injection attacks

			try
			{
				
				if (Request.QueryString["pageId"].ToString().IndexOf("'") != -1)
				{
					systemEventsDataAccess.add(19, Request.RawUrl, 0, Request.UserHostAddress.ToString());
				}

				if (Request.QueryString["pageId"].ToString().IndexOf("/") != -1)
				{
					systemEventsDataAccess.add(19, Request.RawUrl, 0, Request.UserHostAddress.ToString());
				}

				if (Request.QueryString["pageId"].ToString().IndexOf("\\") != -1)
				{
					systemEventsDataAccess.add(19, Request.RawUrl, 0, Request.UserHostAddress.ToString());
				}

				if (Request.QueryString["pageId"].ToString().IndexOf("-") != -1)
				{
					systemEventsDataAccess.add(19, Request.RawUrl, 0, Request.UserHostAddress.ToString());
				}
				
				if (Request.QueryString["pageId"].ToString().IndexOf("+") != -1)
				{
					systemEventsDataAccess.add(19, Request.RawUrl, 0, Request.UserHostAddress.ToString());
				}
				

				if (Request.QueryString["pageId"].ToString().IndexOf("|") != -1)
				{
					systemEventsDataAccess.add(19, Request.RawUrl, 0, Request.UserHostAddress.ToString());
				}
			}
			catch
			{
			}

			try
			{
				if (checkRoles()==false) return;
			}
			catch(System.Exception ex)
			{
				string strTest=ex.Message;
			}

			try
			{
				if("" + Request.QueryString["action"].ToString()=="logoff")
				{
					clearCookies();
					panelPlaceHolder.Controls.Add(base.LoadControl("~\\layouts\\blank\\layout.ascx"));
			
				}
				else
				{

					
				

				}
			}
			catch
			{
				
			}

			if("" + Session["userId"]=="")
			{
				panelPlaceHolder.Controls.Add(base.LoadControl("~\\layouts\\blank\\layout.ascx"));
				return;
			}
			else if("" + Session["userId"]!="")
			{
				
					
				try
				{
					panelPlaceHolder.Controls.Add(base.LoadControl("~\\layouts\\" + tabDataAccess.getLayoutPathForTab(intPageId)));
					return;
				}
				catch
				{
					panelPlaceHolder.Controls.Add(base.LoadControl("~\\layouts\\blank\\layout.ascx"));
				}
			}


			
		}


		private void clearCookies()
		{
			Session["username"]="";
			Session["userId"]="";
			Session["userType"]="";
			Session["firstName"]="";
			Session["lastName"]="";
			Session["userRoles"]="";
			
			Session["username"]=null;
			Session["userId"]=null;
			Session["userType"]=null;
			Session["firstName"]=null;
			Session["lastName"]=null;
			Session["userRoles"]=null;
			
			System.Web.Security.FormsAuthentication.SignOut();
	
			Response.Cookies.Clear();

			Response.Redirect("~/default.aspx");
		}

		private void checkSecureConnection()
		{
			if(Request.IsSecureConnection==false)
			{
				systemEventsDataAccess.add(13, Request.RawUrl, 0, Request.UserHostAddress);
				Response.Clear();
				Response.End();
			}

		}


		private void checkHostsAllow()
		{
			DataSet objDataSet=new DataSet();
			string strUserIp="";
			bool bolAllowAccess=false;
			strUserIp="" + Request.UserHostAddress.ToString();

			objDataSet=	security.getAllHostsAllow();

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				if(objDataRow["ip"].ToString()==strUserIp)
				{
					bolAllowAccess=true;
					break;
				}

			}

			if(bolAllowAccess==false)
			{
				systemEventsDataAccess.add(12, Request.RawUrl, 0, strUserIp);
				Response.Clear();
				Response.End();


			}

		}
	

		private bool checkRoles()
		{
			string strTab="";
			string strUserRoles="" + Session["userRoles"].ToString();
			string[] strTmpTabRoles;
			string[] strTmpUserRoles;
			bool bolAllowAccess=false;

			strTab="" + tabDataAccess.getRolesForTab(intPageId);

			//Is anon access allowed?
			if(strTab=="") return true;

			strTmpTabRoles=strTab.Split(';');
			strTmpUserRoles=strUserRoles.Split(';');

			foreach(string strTmpTab in strTmpTabRoles)
			{
				foreach(string strTmpUser in strTmpUserRoles)
				{
					if(strTmpUser==strTmpTab && strTmpUser!="" && strTmpTab!="")
					{	
						bolAllowAccess=true;
						break;
					}	
				}

				if (bolAllowAccess==true) break;
			}

			if(bolAllowAccess==false)
			{
				systemEventsDataAccess.add(18, Request.RawUrl, System.Convert.ToInt32(Session["userId"]), Request.UserHostAddress);
				Response.Clear();

				panelPlaceHolder.Controls.Add(base.LoadControl("~\\layouts\\blank\\layout.ascx"));

				panelPlaceHolder.Controls.Add(base.LoadControl("~\\controls\\framework\\noAccess.ascx"));

				
			}

			return bolAllowAccess;
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
