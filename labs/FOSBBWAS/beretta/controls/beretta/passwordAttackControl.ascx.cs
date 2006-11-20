namespace beretta.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using beretta.Modules.PasswordAttack;

	/// <summary>
	///		Summary description for passwordAttackControl.
	/// </summary>
	public class passwordAttackControl : System.Web.UI.UserControl
	{

		protected System.Web.UI.WebControls.Label lblTitleMessage;
		protected System.Web.UI.WebControls.Button cmdStart;
		protected System.Web.UI.WebControls.TextBox txtUrl;
	
		protected System.Web.UI.WebControls.Label lblAttackResults;
		protected System.Web.UI.WebControls.DropDownList dropDownPasswordAttackSessions;
		protected System.Web.UI.WebControls.Panel panelResults;
		
	
	
		protected passwordAttackDataAccess objPasswordAttackDataAccess=new passwordAttackDataAccess();


		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if (Page.IsPostBack==false)
			{
				

				string strMessage="";

				strMessage += "Total Usernames in dictionary: " + System.Convert.ToString(beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalUsernames() + "<BR>");
				strMessage += "Total Passwords in dictionary: " + System.Convert.ToString(beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalPasswords() + "<BR>");
				strMessage += "Total Attack Combinations: " + System.Convert.ToString((beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalPasswords() * beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalUsernames()) + "<BR>");

				lblTitleMessage.Text=strMessage;

				dropDownPasswordAttackSessions_bind();
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
			this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdStart_Click(object sender, System.EventArgs e)
		{
			if (dropDownPasswordAttackSessions.SelectedIndex != 0)
			{
				panelResults.Visible=true;

				try
				{
					lblAttackResults.Text="" + beretta.Modules.PasswordAttack.passwordAttackDataAccess.initiate(System.Convert.ToInt32(dropDownPasswordAttackSessions.SelectedItem.Value));
				}
				catch (System.Exception ex)
				{

					lblAttackResults.Text="An error has occurred " + ex.Message.ToString();
				}

				}
		}

		private void dropDownPasswordAttackSessions_bind()
		{

			DataSet objDataSet=new DataSet();
			objDataSet=beretta.Modules.PasswordAttack.passwordAttackDataAccess.getAllConfig();

			dropDownPasswordAttackSessions.Items.Clear();
			
			ListItem objNullItem=new ListItem();
			objNullItem.Text="--";
			objNullItem.Value="";

			dropDownPasswordAttackSessions.Items.Add(objNullItem);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Value=objDataRow["id"].ToString();
				objListItem.Text=objDataRow["description"].ToString();

				dropDownPasswordAttackSessions.Items.Add(objListItem);

				objListItem=null;

			}
		}
	}
}
