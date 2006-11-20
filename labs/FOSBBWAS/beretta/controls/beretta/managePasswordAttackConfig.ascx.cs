using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using beretta.Web;
using beretta.Modules.PasswordAttack;
using System.Text.RegularExpressions;
using System.Threading;

namespace beretta.Web
{


	/// <summary>
	///		Summary description for managePasswordAttackConfig.
	/// </summary>
	public class managePasswordAttackConfig : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtUrl;
		protected System.Web.UI.WebControls.Panel panelAdd;
		protected System.Web.UI.WebControls.DataGrid dbgrid;
		protected passwordAttackConfig objPasswordAttackConfig=new passwordAttackConfig();
		protected System.Web.UI.WebControls.Label lblHiddenId;
		protected System.Web.UI.WebControls.TextBox txtSuccessSignature;
		protected System.Web.UI.WebControls.RadioButton sigEquals;
		protected System.Web.UI.WebControls.RadioButton sigNotEqual;
		protected System.Web.UI.WebControls.RadioButton sigTypeStringMatch;
		protected System.Web.UI.WebControls.RadioButton sigTypeRegex;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdClose;
		protected System.Web.UI.WebControls.LinkButton lnkAdd;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Panel panelError;
		protected passwordAttackDataAccess objPasswordAttackConfigDataAccess=new passwordAttackDataAccess();
		protected TextBox txtFormSubmission;
			protected Label lblMessage;
		protected Label lblResult;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Page.IsPostBack==false)
			{
				string strMessage="";

				strMessage += "Total Usernames in dictionary: " + System.Convert.ToString(beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalUsernames() + "<BR>");
				strMessage += "Total Passwords in dictionary: " + System.Convert.ToString(beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalPasswords() + "<BR>");
				strMessage += "Total Attack Combinations: " + System.Convert.ToString((beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalPasswords() * beretta.Modules.PasswordAttack.passwordAttackDataAccess.getTotalUsernames()) + "<BR>");

				lblMessage.Text="" + strMessage;

				dbGrid_bind();
			}
		}


		private void dbGrid_bind()
		{
			DataSet objDataSet=new DataSet();
			objDataSet=beretta.Modules.PasswordAttack.passwordAttackDataAccess.getAllConfig();

			if (objDataSet.Tables[0].Rows.Count <11)
			{
				dbgrid.AllowPaging=false;
			}
			else
			{
				dbgrid.AllowPaging=true;
			}

			dbgrid.DataSource=objDataSet;
			dbgrid.DataBind();
		}

		private void runPasswordAttack(int intItemId)
		{
			
			string strFormSubmission="";
						
			objPasswordAttackConfig.id=intItemId;
			objPasswordAttackConfig.populate();

			strFormSubmission=objPasswordAttackConfig.formSubmission;

			DataSet objUsernameDataSet=new DataSet();
			DataSet objPasswordDataSet=new DataSet();

			objUsernameDataSet=beretta.Modules.PasswordAttack.passwordAttackDataAccess.getAllUsernames();
			objPasswordDataSet=beretta.Modules.PasswordAttack.passwordAttackDataAccess.getAllPasswords();


			string[] strTmp=new string[3];
		
			ThreadPool.SetMinThreads(20, 20);

			foreach(DataRow objUserDataRow in objUsernameDataSet.Tables[0].Rows)
			{
				
				foreach(DataRow objPasswordDataRow in objPasswordDataSet.Tables[0].Rows)
				{

					
					passwordAttackModule objPasswordAttackModule=new passwordAttackModule();


					objPasswordAttackModule.intId=System.Convert.ToInt32(strData[2]);
					objPasswordAttackModule.intSignatureType=objPasswordAttackConfig.signatureType;
					objPasswordAttackModule.strFormSubmission=objPasswordAttackConfig.formSubmission;
					objPasswordAttackModule.strUsername=strData[0];
					objPasswordAttackModule.strPassword=strData[1];
					objPasswordAttackModule.strUrl=objPasswordAttackConfig.url;
					objPasswordAttackModule.strSignature=objPasswordAttackConfig.successSignature;
					
					
					System.Threading.t

					objPasswordAttackModule=null;

     
							
				}
			}

		}

		

		


		public void dgCommand_onClick(System.Object o, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

			string strCommandName;
			int intId, intItemId;
		
			strCommandName = e.CommandName;
			intId=e.Item.ItemIndex;

			//delete an item 
			if (strCommandName == "cmdDelete")
			{
				intItemId = (int) dbgrid.DataKeys[intId];

				beretta.Modules.PasswordAttack.passwordAttackDataAccess.delete(intItemId);
				dbGrid_bind();
			}


			if (strCommandName == "cmdInitiate")
			{
				intItemId = (int) dbgrid.DataKeys[intId];
				runPasswordAttack(intItemId);

			}


			if (strCommandName == "cmdUpdate")
			{
				intItemId = (int) dbgrid.DataKeys[intId];

				objPasswordAttackConfig.id=intItemId;
				objPasswordAttackConfig.populate();

				txtDescription.Text=objPasswordAttackConfig.description;
				txtUrl.Text="" + objPasswordAttackConfig.url;
				txtFormSubmission.Text="" + objPasswordAttackConfig.formSubmission;
				txtSuccessSignature.Text="" + objPasswordAttackConfig.successSignature;
				lblHiddenId.Text=intItemId.ToString();

				cmdAdd.Text="Update";

				if (objPasswordAttackConfig.signatureOperator=="=")
				{
					sigEquals.Checked=true;
				}
				else
				{
					sigNotEqual.Checked=true;
				}

				if (objPasswordAttackConfig.signatureType==0)
				{
					sigTypeStringMatch.Checked=true;
				}
				else
				{
					sigTypeRegex.Checked=true;
				}
			

				panelAdd.Visible=true;

			}
		}


		public void dbgrid_OnItemDataBound(System.Object o, System.Web.UI.WebControls.DataGridItemEventArgs e)  

		{

			try
			{
				ImageButton cmdDelete = (ImageButton) e.Item.FindControl("cmdDelete");
				cmdDelete.Attributes["onclick"] = "javascript:return confirm('Are you sure you want to delete this item?')";
			}
			catch
			{
			}

		}


		public void dbgrid_SelectedIndexChanged(System.Object o, System.Web.UI.WebControls.DataGridPageChangedEventArgs e) 
		{																																		
			int newPage=e.NewPageIndex;
			dbgrid.CurrentPageIndex=newPage;
						
			dbGrid_bind();
		
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
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			this.lnkAdd.Click += new System.EventHandler(this.lnkAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			panelAdd.Visible=false;
			panelAdd_reset();
		}

		private void panelAdd_reset()
		{
			lblHiddenId.Text="";
			txtDescription.Text="";
			txtUrl.Text="";
			txtFormSubmission.Text="";
			txtSuccessSignature.Text="";

			cmdAdd.Text="Add";
			sigEquals.Checked=true;
			sigTypeStringMatch.Checked=true;


		}

		private void lnkAdd_Click(object sender, System.EventArgs e)
		{
			panelAdd_reset();
			panelAdd.Visible=true;
			
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			
			bool bolError=false;
			string strTmpError="The following errors have occurred:<BR><BR>";

			panelError.Visible=false;
			lblErrorMessage.Text="";


			if (txtDescription.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Description is blank<BR>";
			}

			if (txtUrl.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "URL is blank<BR>";
			}

			if (txtFormSubmission.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Form Submission is blank<BR>";
			}

		
			if (txtSuccessSignature.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Success Signature is blank<BR>";
			}

			if (bolError==true)
			{
				panelError.Visible=true;
				lblErrorMessage.Text=strTmpError;

				return;
			}
			

			objPasswordAttackConfig.description=txtDescription.Text.Trim();
			objPasswordAttackConfig.url=txtUrl.Text.Trim();
			objPasswordAttackConfig.formSubmission=txtFormSubmission.Text.Trim();
			objPasswordAttackConfig.successSignature=txtSuccessSignature.Text.Trim();

			if (sigEquals.Checked==true)
			{
				objPasswordAttackConfig.signatureOperator="=";
			}
			else
			{
				objPasswordAttackConfig.signatureOperator="!=";
			}


			if (sigTypeStringMatch.Checked==true)
			{
				objPasswordAttackConfig.signatureType=0;
			}
			else
			{
				objPasswordAttackConfig.signatureType=1;
			}

			objPasswordAttackConfig.status=0;
			objPasswordAttackConfig.matches="";

			if (lblHiddenId.Text=="")
			{
				objPasswordAttackConfig.add();
			}
			else
			{
				objPasswordAttackConfig.id=System.Convert.ToInt32(lblHiddenId.Text);
				objPasswordAttackConfig.update();

			}

			panelAdd_reset();
			panelAdd.Visible=false;

			dbGrid_bind();
			
		}
	}
}
