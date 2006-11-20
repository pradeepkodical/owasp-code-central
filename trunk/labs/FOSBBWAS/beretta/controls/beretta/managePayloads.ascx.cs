namespace beretta.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using beretta.Objects;

	/// <summary>
	///		Summary description for managePasswordAttackConfig.
	/// </summary>
	public class managePayloads : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtUrl;
		protected System.Web.UI.WebControls.Panel panelAdd;
		protected System.Web.UI.WebControls.DataGrid dbgrid;
		protected payload objPayload=new payload();
		protected System.Web.UI.WebControls.Label lblHiddenId;
		
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdClose;
		protected System.Web.UI.WebControls.LinkButton lnkAdd;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Panel panelError;
		protected System.Web.UI.WebControls.TextBox txtPayloadName;
		protected System.Web.UI.WebControls.TextBox txtPayloadData;
		protected System.Web.UI.WebControls.TextBox txtPayloadOrder;


		protected payloadDataAccess objPayloadDataAccess=new payloadDataAccess();
		protected Panel panelTestResult;
		protected TextBox txtTestUrl;
		protected Button cmdGet;
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected Microsoft.Web.UI.WebControls.MultiPage sessionTabs;
		protected System.Web.UI.WebControls.LinkButton lnkUpdate;
		private formSubmitter objFormSubmitter=new formSubmitter();
		protected DropDownList dropDownType;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Page.IsPostBack==false)
			{
				dbGrid_bind();
			}
		}


		private void cmdGet_click(object sender, System.EventArgs e)
		{
			string strUrl="";
			string strPayloadData="";
			string strReturn="";
			int intTmp=0;

			Literal objLiteral=new Literal();

			strUrl="" + txtTestUrl.Text;

			if (strUrl=="") return;

			strPayloadData="" + txtPayloadData.Text;

			try
			{

				if (dropDownType.SelectedItem.Value=="0")
				{
					//form payload
					strReturn="" + objFormSubmitter.submitData(strPayloadData, strUrl, true, "POST", "");
				}
				else if (dropDownType.SelectedItem.Value=="2")
				{
					//url payload
			
					intTmp=strUrl.IndexOf("?");

					if (intTmp==-1)
					{
						strUrl=strUrl + "?" + strPayloadData;
					}
					else
					{
						strUrl=strUrl.Substring(0, intTmp + 1);
						strUrl=strUrl + "?" + strPayloadData;
					}				

					strReturn="" + objFormSubmitter.getPage(strUrl, true, "");
				}
				else if (dropDownType.SelectedItem.Value=="3")
				{
					//url payload
			
					intTmp=strUrl.IndexOf("?");

					strUrl=strUrl + "&" + strPayloadData;					

					strReturn="" + objFormSubmitter.getPage(strUrl, true, "");
				}
				

				objLiteral.Text=strReturn;
			
				panelTestResult.Controls.Add(objLiteral);
			}
			catch(System.Exception ex)
			{
				Label objLabel=new Label();
					
				objLabel.Text="" + ex.Message;
			
				panelTestResult.Controls.Add(objLabel);

			}
		}

		private void dbGrid_bind()
		{
			DataSet objDataSet=new DataSet();
			objDataSet=payloadDataAccess.getAll();

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

				payloadDataAccess.delete(intItemId);
				dbGrid_bind();
			}

			if (strCommandName == "cmdUpdate")
			{
				intItemId = (int) dbgrid.DataKeys[intId];

				lblHiddenId.Text=intItemId.ToString();

				objPayload.id=intItemId;
				objPayload.populate();

				txtPayloadName.Text="" + objPayload.payloadName;
				txtPayloadData.Text="" + objPayload.payloadData;
				txtDescription.Text="" + objPayload.description;
				txtPayloadOrder.Text="" + objPayload.payloadOrder;
				
				

				dropDownType.ClearSelection();

				foreach(ListItem objListItem in dropDownType.Items)
				{

					if(objListItem.Value==objPayload.type.ToString())
					{
						objListItem.Selected=true;
						break;
					}
				}

								

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
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			this.cmdGet.Click += new System.EventHandler(this.cmdGet_click);
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
			txtPayloadName.Text="";
			txtPayloadData.Text="";
			txtDescription.Text="";
			txtPayloadOrder.Text="";
			
			dropDownType.SelectedIndex=0;

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

			if (txtPayloadName.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Payload Name is blank<BR>";
			}

			if (txtPayloadData.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Payload Data is blank<BR>";
			}

			if (txtDescription.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Description is blank<BR>";
			}

			if (txtPayloadOrder.Text.Trim()=="")
			{
				bolError=true;
				strTmpError=strTmpError + "Payload Order is blank<BR>";
			}
			else
			{
				try
				{
					int intTest=0;
					intTest=System.Convert.ToInt32(txtPayloadOrder.Text);
				}
				catch
				{
					bolError=true;
					strTmpError=strTmpError + "Payload Order is invalid<BR>";
				}

			}

			

			if (bolError==true)
			{
				panelError.Visible=true;
				lblErrorMessage.Text=strTmpError;

				return;
			}
			

			objPayload.payloadName="" + txtPayloadName.Text;
			objPayload.payloadData="" + txtPayloadData.Text;
			objPayload.description="" +txtDescription.Text;
			objPayload.payloadOrder=System.Convert.ToInt32(txtPayloadOrder.Text);
				
			objPayload.type=System.Convert.ToInt32(dropDownType.SelectedItem.Value);


		

			if (lblHiddenId.Text=="")
			{
				objPayload.add();
			}
			else
			{
				objPayload.id=System.Convert.ToInt32(lblHiddenId.Text);
				objPayload.update();

			}

			panelAdd_reset();
			panelAdd.Visible=false;

			dbGrid_bind();
			
		}
	}
}
