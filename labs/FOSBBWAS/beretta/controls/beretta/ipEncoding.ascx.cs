using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using beretta.support;

namespace beretta.Web
{
	

	/// <summary>
	///		Summary description for ipEncoding.
	/// </summary>
	public class ipEncoding : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtIp1;
		protected System.Web.UI.WebControls.DropDownList dropDownEncoding;
		protected System.Web.UI.WebControls.Button cmdConvert;
		protected System.Web.UI.WebControls.TextBox txtIp2;
		protected System.Web.UI.WebControls.TextBox txtIp3;
		protected System.Web.UI.WebControls.TextBox txtIp4;
		protected System.Web.UI.WebControls.TextBox txtResult;

		
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
			this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdConvert_Click(object sender, System.EventArgs e)
		{
			string strIp="";

			try
			{
				strIp="" + txtIp1.Text + "." + txtIp2.Text + "." + txtIp3.Text + "." + txtIp4.Text;

				if (dropDownEncoding.SelectedItem.Value.ToString()=="0")
				{
					txtResult.Text="" + beretta.support.ipEncoding.ipToOctal(strIp);
				}

				if (dropDownEncoding.SelectedItem.Value.ToString()=="1")
				{
					txtResult.Text="" + beretta.support.ipEncoding.ipToHex(strIp);
				}

				if (dropDownEncoding.SelectedItem.Value.ToString()=="2")
				{
					txtResult.Text="" + beretta.support.ipEncoding.ipToDword(strIp);
				}

			}
			catch
			{
				txtResult.Text="Invalid IP Address";
			}

			

		}
	}
}
