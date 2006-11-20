namespace beretta.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Text;
	using System.Configuration;

	/// <summary>
	///		Summary description for selectPage.
	/// </summary>
	public class selectPage : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtUrl;
		protected System.Web.UI.WebControls.Button cmdGet;
		protected System.Web.UI.WebControls.Panel panelRetrievedSite;
		protected System.Web.UI.WebControls.Panel panelHtml;
		protected beretta.Objects.formRedirectSubmission objFormRedirect=new beretta.Objects.formRedirectSubmission();
		private void Page_Load(object sender, System.EventArgs e)
		{
			
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
			this.cmdGet.Click += new System.EventHandler(this.cmdGet_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdGet_Click(object sender, System.EventArgs e)
		{
			string strHtml="";
		
			Literal objLiteral=new Literal();
			panelRetrievedSite.Visible=true;


			strHtml="" + objFormRedirect.getUrlAndRedirect(txtUrl.Text, System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot") + "default.aspx?pageId=37&pageUrl=" + System.Web.HttpUtility.UrlEncode(txtUrl.Text), System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot") + "displayFormSubmission.aspx?pageUrl=", ""); 

			strHtml=strHtml.Replace("__VIEWSTATE", "__OLDVIEWSTATE");

			objLiteral.Text=strHtml;

			panelHtml.Controls.Add(objLiteral);
			
			

		}
	}
}
