using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using beretta.support;
using System.Collections;

namespace beretta.Web
{
	

	/// <summary>
	///		Summary description for analyzeForm.
	/// </summary>
	public class analyzeForm : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtUrl;
		protected System.Web.UI.WebControls.Button cmdGet;
		protected System.Web.UI.WebControls.DataGrid dgForm;
		protected beretta.Objects.formSubmitter objFormSubmitter=new beretta.Objects.formSubmitter();
		protected Panel panelError;
		protected Label lblError;
		protected TextBox txtServer;
		protected TextBox txtProtocolVersion;
		protected PlaceHolder placeHolderHeaders;
		protected PlaceHolder placeHolderFormSubmission;

		protected beretta.Objects.response objResponse= new beretta.Objects.response();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			string strHeader="";

			panelError.Visible=false;
			lblError.Text="";


			try
			{
				strHtml=objFormSubmitter.getPage(txtUrl.Text, true, "");
			}
			catch(System.Exception ex)
			{
				panelError.Visible=true;
				lblError.Text="Error retrieving URL " + ex.Message;
				return;
			}

			int intX=0;
			
			while (intX!= objFormSubmitter.objWebHeaderCollection.Keys.Count)
			{

				strHeader=strHeader + objFormSubmitter.objWebHeaderCollection.GetKey(intX) + ", ";
			
				strHeader=strHeader + "   " + objFormSubmitter.objWebHeaderCollection.GetValues(intX).GetValue(0) + "<BR>";			
				intX++;
			}


			Literal objLiteral=new Literal();
			Literal objLiteral2=new Literal();

			objLiteral.Text=strHeader;
			
			placeHolderHeaders.Controls.Add(objLiteral);
			txtProtocolVersion.Text="" + objFormSubmitter.protocolVersion;
			txtServer.Text="" + objFormSubmitter.server;

			objResponse.input=strHtml;
			objResponse.analyze();

			dgForm.DataSource=objResponse.objFormElements;
			dgForm.DataBind();

			objLiteral2.Text=objResponse.formSubmission[0] + "<BR><BR>" + objResponse.formSubmission[1];
			placeHolderFormSubmission.Controls.Add(objLiteral2);

			

		}
	}
}
