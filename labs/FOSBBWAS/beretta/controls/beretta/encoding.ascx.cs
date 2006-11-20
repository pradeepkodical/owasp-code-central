namespace beretta.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Text;

	/// <summary>
	///		Summary description for encoding.
	/// </summary>
	public class encoding : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtTextToEncode;
		protected System.Web.UI.WebControls.DropDownList dropDownEncodingType;
		protected System.Web.UI.WebControls.Button cmdGet;
		protected System.Web.UI.WebControls.TextBox txtResults;
		protected System.Web.UI.LosFormatter objLosFormatter=new System.Web.UI.LosFormatter();


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
			string strTextToEncode="" + txtTextToEncode.Text;
			string strResults="";

			if (strTextToEncode=="") return;
			if (dropDownEncodingType.SelectedItem==null) return;
			if (dropDownEncodingType.SelectedIndex==0) return;


			if (dropDownEncodingType.SelectedItem.Value.ToString()=="1")
			{
				strResults="" + Server.UrlEncode(strTextToEncode);

			}
			else if (dropDownEncodingType.SelectedItem.Value.ToString()=="2")
			{
				strResults="" + Server.HtmlEncode(strTextToEncode);

			}
			else if (dropDownEncodingType.SelectedItem.Value.ToString()=="3")
			{
				
				strResults="" + beretta.support.encoding.toHex(strTextToEncode);
			}
			else if (dropDownEncodingType.SelectedItem.Value.ToString()=="4")
			{
				strResults="" + beretta.support.encoding.toHexHtml(strTextToEncode);

			}
			else if (dropDownEncodingType.SelectedItem.Value.ToString()=="5")
			{
				strResults="" + beretta.support.encoding.convertToDecimal(strTextToEncode);

			}
			


			txtResults.Text=strResults;
		}
	}

	

}
