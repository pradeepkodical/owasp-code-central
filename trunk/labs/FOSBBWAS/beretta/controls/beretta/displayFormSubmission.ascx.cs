namespace beretta.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for displayFormSubmission.
	/// </summary>
	public class displayFormSubmission : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink hyperUrl;
		protected System.Web.UI.WebControls.HyperLink hyperBack;
		protected System.Web.UI.WebControls.TextBox txtFormResultsUnEncoded;
		protected System.Web.UI.WebControls.TextBox txtFormResults;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
			try
			{
				string strForm="" + Request.Form;

				//replace modified view state field
				strForm=strForm.Replace("__RETREIVEDVIEWSTATE", "__VIEWSTATE");
				strForm=strForm.Replace("__OLDVIEWSTATE", "__VIEWSTATE");

				txtFormResults.Text="" + strForm;
				txtFormResultsUnEncoded.Text="" + Server.UrlDecode(strForm);
				hyperUrl.Text="" + Request.QueryString["pageUrl"].ToString();
				hyperUrl.NavigateUrl="" + Request.QueryString["pageUrl"].ToString();

			}
			catch(System.Exception ex)
			{
				txtFormResults.Text="" + ex.Message;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}


		#endregion
	}
}
