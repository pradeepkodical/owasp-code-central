namespace beretta.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using beretta.Objects;
	using System.Text.RegularExpressions;
	using System.IO;

	/// <summary>
	///		Summary description for manageSignatures.
	/// </summary>
	public class manageSignatures : System.Web.UI.UserControl
	{

	

		protected System.Web.UI.WebControls.Panel panelAdd;
		protected System.Web.UI.WebControls.DataGrid dbgrid;

		protected System.Web.UI.WebControls.Label lblHiddenId;
		
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdClose;
		protected System.Web.UI.WebControls.LinkButton lnkAdd;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Panel panelError;
		protected System.Web.UI.WebControls.TextBox txtSignatureName;
		protected System.Web.UI.WebControls.TextBox txtSignatureValue;
		protected System.Web.UI.WebControls.RadioButton radOperatorEquals;
		protected System.Web.UI.WebControls.RadioButton radOperatorNotEqual;
		protected System.Web.UI.WebControls.TextBox txtSignatureDescription;
		protected System.Web.UI.WebControls.TextBox txtSignatureMessage;
		protected System.Web.UI.WebControls.TextBox txtSignatureOrder;
		protected RadioButton radStringMatch;
		protected RadioButton radRegex;
		protected signatures objSignatures=new signatures();
		protected signaturesDataAccess objSignaturesDataAccess=new signaturesDataAccess();
		protected TextBox txtTestUrl;
		protected Panel panelTestResult;
		protected Button cmdGet;
		private formSubmitter objFormSubmitter=new formSubmitter();
		protected Label lblResult;
		protected Button cmdReset;
		protected RadioButton radInfo;
		protected RadioButton radWarning;
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected Microsoft.Web.UI.WebControls.MultiPage sessionTabs;
		protected RadioButton radCritical;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Page.IsPostBack==false)
			{
				dbGrid_bind();
			}
		}


		private void dbGrid_bind()
		{
			DataSet objDataSet=new DataSet();
			objDataSet=signaturesDataAccess.getAll();

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

				signaturesDataAccess.delete(intItemId);
				dbGrid_bind();
			}

			if (strCommandName == "cmdUpdate")
			{
				intItemId = (int) dbgrid.DataKeys[intId];

				objSignatures.id=intItemId;
				objSignatures.populate();

				txtSignatureName.Text="" + objSignatures.signatureName;
				txtSignatureValue.Text="" + objSignatures.signatureValue;

				if (objSignatures.signatureOperator=="=")
				{
					radOperatorEquals.Checked=true;
				}
				else
				{
					radOperatorNotEqual.Checked=true;

				}

				if (objSignatures.signatureType==0)
				{
					radStringMatch.Checked=true;
					radRegex.Checked=false;
				}
				else
				{
					radRegex.Checked=true;
					radStringMatch.Checked=false;

				}

				txtSignatureDescription.Text="" + objSignatures.signatureDescription;
				txtSignatureMessage.Text="" + objSignatures.signatureMessage;
				txtSignatureOrder.Text="" + objSignatures.signatureOrder.ToString();

				radInfo.Checked=false;
				radWarning.Checked=false;
				radCritical.Checked=false;

				switch(objSignatures.signatureMessageType)
				{
					case 0: 
						radInfo.Checked=true;

						break;
					case 1: 
						radWarning.Checked=true;
						break;
					case 2: 
						radCritical.Checked=true;
						break;

				}

				

				lblHiddenId.Text=intItemId.ToString();

				cmdAdd.Text="Update";

		

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
		

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			panelAdd.Visible=false;
			panelAdd_reset();
		}

		private void panelAdd_reset()
		{
			txtSignatureName.Text="";
			txtSignatureValue.Text="";

			radOperatorEquals.Checked=true;
			

			txtSignatureDescription.Text="";
			txtSignatureMessage.Text="";
			txtSignatureOrder.Text="";

			radStringMatch.Checked=true;
			cmdAdd.Text="Add";
	


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


			if (txtSignatureName.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Signature Name is blank<BR>";
			}

			if (txtSignatureValue.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Signature Value is blank<BR>";
			}


			if (txtSignatureDescription.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Signature Description is blank<BR>";
			}


			if (txtSignatureMessage.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Signature Message is blank<BR>";
			}


			if (txtSignatureOrder.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Signature Order is blank<BR>";
			}
			else
			{
				int intTest=0;
				try
				{
					intTest=System.Convert.ToInt32(txtSignatureOrder.Text);
				}
				catch
				{
					bolError=true;
					strTmpError=strTmpError + "Signature Order is invalid<BR>";
				}
			}

		

			if (bolError==true)
			{
				panelError.Visible=true;
				lblErrorMessage.Text=strTmpError;

				return;
			}
			
			objSignatures.signatureName= "" + txtSignatureName.Text;
			objSignatures.signatureValue="" + txtSignatureValue.Text;

			if (radOperatorEquals.Checked==true)
			{
				objSignatures.signatureOperator="=";
			}
			else
			{
				objSignatures.signatureOperator="!=";

			}

			if (radStringMatch.Checked==true)
			{
				objSignatures.signatureType=0;
			}
			else
			{
				objSignatures.signatureType=1;

			}

			objSignatures.signatureDescription="" + txtSignatureDescription.Text;
			objSignatures.signatureMessage="" + txtSignatureMessage.Text;
			objSignatures.signatureOrder=System.Convert.ToInt32(txtSignatureOrder.Text);


			if (radInfo.Checked==true)
			{
				objSignatures.signatureMessageType=0;
			}
			else if (radWarning.Checked==true)
			{
				objSignatures.signatureMessageType=1;
			}
			else if (radCritical.Checked==true)
			{
				objSignatures.signatureMessageType=2;
			}

			if (lblHiddenId.Text=="")
			{
				objSignatures.add();
			}
			else
			{
				objSignatures.id=System.Convert.ToInt32(lblHiddenId.Text);
				objSignatures.update();

			}

			panelAdd_reset();
			panelAdd.Visible=false;

			dbGrid_bind();
			
		}
	


		private void cmdReset_click(object sender, System.EventArgs e)
		{

			panelTestResult.Controls.Clear();

		}


		private void cmdGet_click(object sender, System.EventArgs e)
		{
			string strUrl="";
			string strReturn="";
			
			
			

			bool bolMatch=false;
		

			Literal objLiteral=new Literal();

			strUrl="" + txtTestUrl.Text;

			if (strUrl=="") return;

			strReturn="" + webClient.getPage(strUrl);

			objLiteral.Text=strReturn;
			
			panelTestResult.Controls.Add(objLiteral);
			

			if (radStringMatch.Checked==true)
			{
				//String Match

				if (radOperatorEquals.Checked==true)
				{
					if (strReturn.IndexOf(txtSignatureValue.Text) != -1 && strReturn != "" + txtSignatureValue.Text)
					{	
						bolMatch=true;
					}
					else
					{

						bolMatch=false;
					}

				}
				else
				{
					if (strReturn.IndexOf(txtSignatureValue.Text) == -1)
					{	
						bolMatch=true;
					}
					else
					{

						bolMatch=false;
					}

				}
			}
			else
			{

				//Regex
				if (radOperatorEquals.Checked==true)
				{
					if (Regex.IsMatch(strReturn, txtSignatureValue.Text)==true)
					{	
						bolMatch=true;
					}
					else
					{

						bolMatch=false;
					}

				}
				else
				{
					if (Regex.IsMatch(strReturn, txtSignatureValue.Text)==false)
					{	
						bolMatch=true;
					}
					else
					{

						bolMatch=false;
					}

				}

			}


			if (bolMatch==true)
			{
				lblResult.Text="Matches Signature";
			}
			else
			{
				lblResult.Text="No Match";
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
			this.lnkAdd.Click += new System.EventHandler(this.lnkAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.cmdAdd.Click +=new System.EventHandler(this.cmdAdd_Click);
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			this.cmdGet.Click += new System.EventHandler(this.cmdGet_click);


		}
		#endregion
	}
}
