namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for PostMessageForm.
	/// </summary>
	public partial class PostMessageForm : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblErrorMessage.Text = "";
			// Put user code to initialize the page here
			LoadPostedMessages();
		}

		private void LoadPostedMessages()
		{
			lblPostedMessages.Text = "";
			dataClasses.postedMessage[] allPostedMessages = Global.objUsersCommunity.WS_GetPostedMessages("");
			lblPostedMessages.Text = "<table width=\"100%\" border=0>";
			foreach(dataClasses.postedMessage objPostedMessage in allPostedMessages)
			{
				object[] userDetails = Global.objUserManagement.WS_GetUserDetail_using_userID("",objPostedMessage.userID.ToString());
				string userName = userDetails[1].ToString();
				lblPostedMessages.Text +=	"<tr><td width=200 valign=top  bgcolor='#F5EFFF'>" + 
											"	<b>" + objPostedMessage.messageSubject + 
											"	</b><br/> (by: "+userName  + 
											"	on: "+objPostedMessage.messageDate.ToShortDateString() +")" + 
											" </td>";
				lblPostedMessages.Text += "<td valign=top bgcolor='#F5EFFF'>";
				lblPostedMessages.Text += objPostedMessage.messageText;
				lblPostedMessages.Text += "</td></tr>";
				lblPostedMessages.Text += "<tr><td>    <br>    </td></tr>";
			}						
		}

		protected void btnPostMessage_Click(object sender, System.EventArgs e)
		{
			if ("" == txtSubject.Text)			
				lblErrorMessage.Text=  "Error : You have to enter a Message Subject<br/>";				
			if ("" == txtText.Text)			
				lblErrorMessage.Text+=  "Error : You have to enter a Message Text<br/>";							
			if ("" == lblErrorMessage.Text)		
			{
				string userId = (string)Session["userID"].ToString();
				string messageSubject = txtSubject.Text;
				string messageText = txtText.Text;
				Global.objUsersCommunity.WS_PostMessage("",userId,messageSubject,messageText);
			}
			LoadPostedMessages();
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
		}
		#endregion
	}
}
