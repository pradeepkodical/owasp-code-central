/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: Loads modules onto page
 */

namespace sourceControl.layouts.defaultLayout
{
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
	using System.Data.SqlClient;
	using devCafe.framework;

	/// <summary>
	///		Summary description for layout.
	/// </summary>
	public class layoutSB : System.Web.UI.UserControl
	{

		protected System.Web.UI.WebControls.Panel panelPlaceHolder;
		public int intPageId=0;
		public string siteRoot="" + settings.siteRoot;
		protected user objUser=new user();
		protected System.Web.UI.WebControls.Label lblTopBarMessage;
		protected System.Web.UI.WebControls.Image imgLoginOff;
		protected System.Web.UI.WebControls.HyperLink lnkLoginOff;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblBeretta;
		protected System.Web.UI.WebControls.Label lblWelcome;
	

		protected Label lblUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if("" + Session["userId"]=="")
			{
				panelPlaceHolder.Controls.Add(this.LoadControl("~\\controls\\signIn.ascx"));
				return;
			}


			try
			{
				intPageId=System.Convert.ToInt32(Request.QueryString["pageId"]);
			}
			catch
			{
				intPageId=0;
			}
			
			page_bind();
		}

		private void page_bind()
		{

			if (intPageId==0)
			{
				return;

			}

			SqlDataReader objDataReader;
		
			


			objDataReader=tabDataAccess.getAllModulesForTab(intPageId);

			while(objDataReader.Read())
			{
				
				 panelPlaceHolder.Controls.Add(base.LoadControl("~\\controls\\" + objDataReader.GetValue(0).ToString()));
				
			}


			objUser.id=System.Convert.ToInt32(Session["userId"]);
			objUser.populate();



			

			
			lblUser.Text="" + objUser.firstName + " " + objUser.lastName;
				
			
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
