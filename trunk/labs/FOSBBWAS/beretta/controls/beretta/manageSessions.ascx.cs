namespace beretta.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using beretta.Objects;
	using System.Threading;

	/// <summary>
	///		Summary description for manageSessions.
	/// </summary>
	public class manageSessions : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lnkNew;
		protected System.Web.UI.WebControls.DataGrid dbgrid;

		private beretta.objects.beretta objBeretta=new beretta.objects.beretta();
		private beretta.Objects.session objSession=new session();

		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected Microsoft.Web.UI.WebControls.MultiPage sessionTabs;
		protected System.Web.UI.WebControls.Button cmdClose;
		protected System.Web.UI.WebControls.Panel panelSession;
		protected DropDownList dropDownUrl;
		private sessionDataAccess objSessionDataAccess=new sessionDataAccess();
		private payloadDataAccess objPayloadDataAccess=new payloadDataAccess();
		private signaturesDataAccess objSignaturesDataAccess=new signaturesDataAccess();
		protected TextBox txtSessionName;
		protected TextBox txtSessionDescription;
		protected TextBox txtApplicationBaseUrl;
		protected Button cmdPayloadUp;
		protected Button cmdPayloadDown;
		protected CheckBox chkAutoScan;
		protected CheckBox chkEncoding;

		protected TextBox txtUrl;
		protected TextBox txtUrlDescription;
		protected Button cmdAddUrl;
		protected ListBox lstUrls;
		protected Button cmdRemoveUrl;

		protected Label lblUrlCount;
	
		protected Button cmdInitiate;

		protected Label lblHiddenId;

		protected Panel panelError;
		protected Label lblError;
		protected ListBox lstAllPayloads;
		protected ListBox lstSessionPayloads;
		protected Button cmdAddPayload;
		protected Button cmdRemovePayload;
		private int intSessionId=0;
	
		private urls objUrl=new urls();
		private urlsDataAccess objUrlsDataAccess=new urlsDataAccess();
		protected RadioButton radNoAuthentication;
		protected RadioButton radFormsAuthentication;
		protected RadioButton radBasicAuthentication;
		protected RadioButton radPassportAuthentication;
		protected RadioButton radRawFormsSubmission;
		protected Panel panelAuthenticationDetailsForm;
		protected Panel panelRawFormsSubmission;
		protected TextBox txtRawLogonPageUrl;
		protected TextBox txtRawSubmission;

		protected TextBox txtLogonPageUrl;
		protected TextBox txtUsername;
		protected TextBox txtPassword;
		protected TextBox txtUsernameFieldName;
		protected TextBox txtPasswordFieldName;
		protected TextBox txtSubmitButtonFieldName;
		protected TextBox txtBaseSpiderUrl;
		protected Button cmdSpiderUrl;

		protected DropDownList dropDownUrl2;
		protected ListBox lstSessionSignatures;
		protected Button cmdAddSignature;
		protected Button cmdRemoveSignature;
		protected ListBox lstAllSignatures;

		protected Button cmdSignatureUp;
		protected Button cmdSignatureDown;
		protected Button cmdUrlUp;
		protected Button cmdUrlDown;
		protected sessionFormsLogon objSessionFormsLogon=new sessionFormsLogon();
		protected sessionRawLogon objRawLogon=new sessionRawLogon();
		protected Panel panelReport;
		protected HyperLink lnkReport;
		private Spider.Spider m_spider;
		protected Button cmdRefreshUrl;
		protected ListBox lstGlobalAllPayloads;
		protected ListBox lstGlobalPayloads;
		protected Button cmdAddGlobalPayload;
		protected Button cmdRemoveGlobalPayload;
		protected Button cmdGlobalAll;
		protected Button cmdGlobalAllRemove;
		
		protected ListBox lstGlobalSignatures;
		protected Button cmdAddGlobalSignature;
		protected Button cmdRemoveGlobalSignature;
		protected Button cmdGlobalSignatureAll;
		protected Button cmdGlobalSignatureAllRemove;
		protected ListBox lstGlobalAllSignatures;
		
		protected DropDownList dropDownUserAgent;


		private void dropDownUserAgent_bind()
		{

			DataSet objDataSet=new DataSet();

			objDataSet=devCafe.framework.listItemsDataAccess.getAllForGroupByName("USERAGENT");

			dropDownUserAgent.Items.Clear();

			ListItem objNullItem=new ListItem();
			objNullItem.Text="--";
			objNullItem.Value="0";

			dropDownUserAgent.Items.Add(objNullItem);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Value="" + objDataRow["id"];
				objListItem.Text="" + objDataRow["listItemName"];

				dropDownUserAgent.Items.Add(objListItem);

				objListItem=null;

			}
		}


		private void cmdRemoveGlobalSignature_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstGlobalSignatures.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstGlobalSignatures.SelectedItem;

			
				lstGlobalAllSignatures.Items.Add(objListItem);
				lstGlobalSignatures.Items.Remove(objListItem);
			

				lstGlobalAllSignatures.ClearSelection();
				lstGlobalAllSignatures.ClearSelection();

				
			}
			catch
			{
			}

			lstGlobalSignatures_save();

		}

		private void cmdAddGlobalSignature_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstGlobalAllSignatures.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstGlobalAllSignatures.SelectedItem;

				
				lstGlobalSignatures.Items.Add(objListItem);
				lstGlobalAllSignatures.Items.Remove(objListItem);

				lstGlobalSignatures.ClearSelection();
			
				lstGlobalAllSignatures.ClearSelection();

			}
			catch
			{
			}

			lstGlobalSignatures_save();

		}



		private void lstGlobalAllSignatures_bind()
		{
			lstGlobalAllSignatures.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=signaturesDataAccess.getAllForManageSessionScreen(intSessionId, 0);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["signatureName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstGlobalAllSignatures.Items.Add(objListItem);

				objListItem=null;
			}

		}

		private void lstGlobalSignatures_bind()
		{
			
			lstGlobalSignatures.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=signaturesDataAccess.getSelectedForManageSessionScreen(intSessionId, 0);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["signatureName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstGlobalSignatures.Items.Add(objListItem);

				objListItem=null;
			}

		}

		

		private void cmdGlobalSignatureAllRemove_click(object sender, System.EventArgs e)
		{
			signaturesDataAccess.deleteAllSessionSignaturesForSession(intSessionId, 0);

			lstGlobalAllSignatures_bind();
			lstGlobalSignatures_bind();

		}


		private void cmdGlobalSignatureAll_click(object sender, System.EventArgs e)
		{
			foreach(ListItem objGlobalAll in lstGlobalAllSignatures.Items)
			{

				ListItem objListItem=new ListItem();
				objListItem=objGlobalAll;

				
				lstGlobalSignatures.Items.Add(objListItem);
				

				lstGlobalSignatures.ClearSelection();
			
				lstGlobalAllSignatures.ClearSelection();
			}

			lstGlobalAllSignatures.Items.Clear();

			lstGlobalSignatures_save();

		}

		
		
		private void lstGlobalSignatures_save()
		{

			int intX=0;
			signaturesDataAccess.deleteAllSessionSignaturesForSession(intSessionId, 0);

			foreach(ListItem objListItem in lstGlobalSignatures.Items)
			{
				signaturesDataAccess.addSessionSignature(intSessionId, System.Convert.ToInt32(objListItem.Value), 0, intX);
				intX++;
			}


		}

		private void cmdGlobalAllRemove_click(object sender, System.EventArgs e)
		{
			payloadDataAccess.deleteAllSessionPayloadsForSession(intSessionId, 0);

			lstGlobalAllPayloads_bind();
			lstGlobalPayloads_bind();

		}


		private void cmdGlobalAll_click(object sender, System.EventArgs e)
		{
			foreach(ListItem objGlobalAll in lstGlobalAllPayloads.Items)
			{

				ListItem objListItem=new ListItem();
				objListItem=objGlobalAll;

				
				lstGlobalPayloads.Items.Add(objListItem);
				

				lstGlobalPayloads.ClearSelection();
			
				lstGlobalAllPayloads.ClearSelection();
			}

			lstGlobalAllPayloads.Items.Clear();

			lstGlobalPayloads_save();

		}


		private void cmdRemoveGlobalPayload_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstGlobalPayloads.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstGlobalPayloads.SelectedItem;

			
				lstGlobalAllPayloads.Items.Add(objListItem);
				lstGlobalPayloads.Items.Remove(objListItem);
			

				lstGlobalPayloads.ClearSelection();
				lstGlobalAllPayloads.ClearSelection();

				
			}
			catch
			{
			}

			lstGlobalPayloads_save();

		}


		private void cmdAddGlobalPayload_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstGlobalAllPayloads.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstGlobalAllPayloads.SelectedItem;

				
				lstGlobalPayloads.Items.Add(objListItem);
				lstGlobalAllPayloads.Items.Remove(objListItem);

				lstGlobalPayloads.ClearSelection();
			
				lstGlobalAllPayloads.ClearSelection();

			}
			catch
			{
			}

			lstGlobalPayloads_save();

		}


		private void lstGlobalPayloads_save()
		{

			int intX=0;
			payloadDataAccess.deleteAllSessionPayloadsForSession(intSessionId, 0);

			foreach(ListItem objListItem in lstGlobalPayloads.Items)
			{
				payloadDataAccess.addSessionPayload(intSessionId, System.Convert.ToInt32(objListItem.Value), 0, intX);
				intX++;
			}


		}

		
		private void lstGlobalAllPayloads_bind()
		{
			lstGlobalAllPayloads.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=payloadDataAccess.getAllForManageSessionScreen(intSessionId, 0);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["payloadName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstGlobalAllPayloads.Items.Add(objListItem);

				objListItem=null;
			}

		}


		private void lstGlobalPayloads_bind()
		{
			
			lstGlobalPayloads.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=payloadDataAccess.getSelectedForManageSessionScreen(intSessionId, 0);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["payloadName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstGlobalPayloads.Items.Add(objListItem);

				objListItem=null;
			}

		}









		private void cmdSpiderUrl_click(object sender, System.EventArgs e)
		{

			string strNewGuid="" + System.Guid.NewGuid();

			System.IO.Directory.CreateDirectory(Server.MapPath("~/temp/" + strNewGuid + "/"));

			m_spider = new Spider.Spider();
			m_spider.OutputPath = Server.MapPath("~/temp/" + strNewGuid + "/");
			m_spider.sessionId=intSessionId;
			m_spider.Start(new Uri(this.txtBaseSpiderUrl.Text), 1);

			lstUrls_bind();

			lblUrlCount_bind();

		}

		private void cmdRefreshUrl_click(object sender, System.EventArgs e)
		{
			lstUrls_bind();
			lblUrlCount_bind();
		}

		public void SpiderThread()
		{
			m_spider = new Spider.Spider();
			//m_spider.re = this;
			m_spider.OutputPath = "";
			
			int threads = 1;

			if(threads<1) threads = 1;
				
				try
				{
					m_spider.Start(new Uri(this.txtBaseSpiderUrl.Text),threads);
				}
				catch( UriFormatException ex)
				{
					Response.Write(ex.Message);
					return;
				}
			
			

		}

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Page.IsPostBack==false)
			{
				selectRefreshType();
				
			}
			else
			{
				try
				{
					intSessionId=System.Convert.ToInt32(ViewState["sessionId"]);
				
				}
				catch
				{

					intSessionId=0;
				}

			

			}

		

			
		}


		private void radFormsAuthentication_checked(object sender, System.EventArgs e)
		{
			hideAuthenticationPanels();
			
			panelAuthenticationDetails_bind();

		}

	

		private void lblUrlCount_bind()
		{

			lblUrlCount.Text="Url count: " + urlsDataAccess.getCountForSession(intSessionId).ToString();

		}


		private void hideAuthenticationPanels()
		{
			panelAuthenticationDetailsForm.Visible=false;
			panelRawFormsSubmission.Visible=false;

		}

		private void panelAuthenticationDetails_bind()
		{
			hideAuthenticationPanels();

			if (radNoAuthentication.Checked==true)
			{
				hideAuthenticationPanels();

			}

			if (radFormsAuthentication.Checked==true)
			{
				
				panelAuthenticationDetailsForm.Visible=true;
				
				try
				{
					objSessionFormsLogon.sessionId=intSessionId;
					objSessionFormsLogon.populateBySessionId();

					txtLogonPageUrl.Text="" + objSessionFormsLogon.loginPageUrl;
					txtUsername.Text="" + objSessionFormsLogon.username;
					txtPassword.Text="" + objSessionFormsLogon.password;
					txtUsernameFieldName.Text=""+ objSessionFormsLogon.usernameFieldName;
					txtPasswordFieldName.Text=""+ objSessionFormsLogon.passwordFieldName;
					txtSubmitButtonFieldName.Text=""+ objSessionFormsLogon.submitButtonFieldName;

				}
				catch
				{

				}
			}

			if (radRawFormsSubmission.Checked==true)
			{
				
				
				panelRawFormsSubmission.Visible=true;
				
				try
				{
					objRawLogon.sessionId=intSessionId;
					objRawLogon.populateBySessionId();

					txtRawLogonPageUrl.Text="" + objRawLogon.loginPageUrl;
					txtRawSubmission.Text="" + objRawLogon.rawSubmission; 
				}
				catch
				{

				}

				
			}

		


		}


		private void dropDownUrl_selectedIndexChanged(object sender, System.EventArgs e)
		{

			if (dropDownUrl.SelectedItem.Value=="0") 
			{
				lstSessionPayloads.Items.Clear();
				lstAllPayloads.Items.Clear();
				return;
			}


			lstSessionPayloads_bind(System.Convert.ToInt32(dropDownUrl.SelectedItem.Value));
			lstAllPayloads_bind(System.Convert.ToInt32(dropDownUrl.SelectedItem.Value));
		}

		private void dropDownUrl2_selectedIndexChanged(object sender, System.EventArgs e)
		{

			if (dropDownUrl2.SelectedItem.Value=="0") 
			{
				lstSessionSignatures.Items.Clear();
				lstAllSignatures.Items.Clear();
				return;
			}

			lstSessionSignatures_bind(System.Convert.ToInt32(dropDownUrl2.SelectedItem.Value));
			lstAllSignatures_bind(System.Convert.ToInt32(dropDownUrl2.SelectedItem.Value));
		}

		private void selectRefreshType()
		{

			DataSet objDataSet=new DataSet();
			objDataSet=sessionDataAccess.getAll();

			if (objDataSet.Tables[0].Rows.Count<11)
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
				sessionDataAccess.delete(intItemId);
				selectRefreshType();
			
			}


			if (strCommandName == "cmdUpdate")
			{
				intItemId = (int) dbgrid.DataKeys[intId];
				panelSession_bind(intItemId);
				panelSession.Visible=true;
			}

		}

		
		private void panelSession_bind(int intId)
		{
			
			objSession.id=intId;
			objSession.populate();	

			dropDownUserAgent_bind();

			cmdAdd.Text="Update";

			txtSessionName.Text= "" + objSession.sessionName;
			txtSessionDescription.Text="" + objSession.sessionDescription;
			txtApplicationBaseUrl.Text="" + objSession.applicationBaseUrl;

			dropDownUserAgent.ClearSelection();

			foreach(ListItem objListItem in dropDownUserAgent.Items)
			{
				if(objListItem.Value==objSession.userAgent.ToString())
				{
					objListItem.Selected=true;
					break;
				}
			}

			if(objSession.useAutoScan==1)
			{
				chkAutoScan.Checked=true;
			}
			else
			{
				chkAutoScan.Checked=false;
			}

			if (objSession.authenticationType==0)
			{
				radNoAuthentication.Checked=true;
				radFormsAuthentication.Checked=false;
				radRawFormsSubmission.Checked=false;
			}
			else if (objSession.authenticationType==1)
			{
				radNoAuthentication.Checked=false;
				radFormsAuthentication.Checked=true;
				radRawFormsSubmission.Checked=false;
			}
			else if (objSession.authenticationType==2)
			{
				radNoAuthentication.Checked=false;
				radFormsAuthentication.Checked=false;
				radRawFormsSubmission.Checked=true;
			}
			

			
			ViewState["sessionId"]=intId.ToString();
			
			intSessionId=intId;
			lblUrlCount_bind();
		
			lstUrls_bind();
			dropDownUrl_bind();
			panelAuthenticationDetails_bind();

			lstGlobalAllPayloads_bind();
			lstGlobalPayloads_bind();

			lstGlobalAllSignatures_bind();
			lstGlobalSignatures_bind();

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
						
			selectRefreshType();
		
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

			this.cmdAddGlobalSignature.Click += new System.EventHandler(this.cmdAddGlobalSignature_click);
			this.cmdRemoveGlobalSignature.Click += new System.EventHandler(this.cmdRemoveGlobalSignature_click);

			this.cmdGlobalSignatureAllRemove.Click += new System.EventHandler(this.cmdGlobalSignatureAllRemove_click);
			this.cmdGlobalSignatureAll.Click += new System.EventHandler(this.cmdGlobalSignatureAll_click);

			this.cmdGlobalAllRemove.Click += new System.EventHandler(this.cmdGlobalAllRemove_click);
			this.cmdGlobalAll.Click += new System.EventHandler(this.cmdGlobalAll_click);

			this.cmdAddGlobalPayload.Click += new System.EventHandler(this.cmdAddGlobalPayload_click);
			this.cmdRemoveGlobalPayload.Click+=new System.EventHandler(this.cmdRemoveGlobalPayload_click);

			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			this.lnkNew.Click += new System.EventHandler(this.lnkNew_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.cmdAddPayload.Click += new System.EventHandler(this.cmdAddPayload_click);
			this.cmdRemovePayload.Click += new System.EventHandler(this.cmdRemovePayload_click);

			this.cmdAddSignature.Click += new System.EventHandler(this.cmdAddSignature_click);
			this.cmdRemoveSignature.Click += new System.EventHandler(this.cmdRemoveSignatures_click);

			this.cmdInitiate.Click += new System.EventHandler(this.cmdInitiate_click);

			this.cmdRemoveUrl.Click += new System.EventHandler(this.cmdRemoveUrl_click);
			this.cmdAddUrl.Click += new System.EventHandler(this.cmdAddUrl_click);
			this.dropDownUrl.SelectedIndexChanged += new System.EventHandler(this.dropDownUrl_selectedIndexChanged);
			this.dropDownUrl2.SelectedIndexChanged += new System.EventHandler(this.dropDownUrl2_selectedIndexChanged);
			this.cmdPayloadUp.Click += new System.EventHandler(this.cmdPayloadUp_click);
			this.cmdPayloadDown.Click += new System.EventHandler(this.cmdPayloadDown_click);

			this.cmdSignatureUp.Click += new System.EventHandler(this.cmdSignatureUp_click);
			this.cmdSignatureDown.Click += new System.EventHandler(this.cmdSignatureDown_click);
			this.cmdUrlUp.Click += new System.EventHandler(this.cmdUrlUp_click);
			this.cmdUrlDown.Click += new System.EventHandler(this.cmdUrlDown_click);
			this.radFormsAuthentication.CheckedChanged += new System.EventHandler(this.radFormsAuthentication_checked);
			this.radRawFormsSubmission.CheckedChanged += new System.EventHandler(this.radFormsAuthentication_checked);
			this.radNoAuthentication.CheckedChanged += new System.EventHandler(this.radFormsAuthentication_checked);

			this.cmdSpiderUrl.Click += new System.EventHandler(this.cmdSpiderUrl_click);
			this.cmdRefreshUrl.Click += new System.EventHandler(this.cmdRefreshUrl_click);
		}
		#endregion

		private void panelSession_reset()
		{
			cmdAdd.Text="Add";
			txtSessionName.Text="";
			txtSessionDescription.Text="";
		
			lblHiddenId.Text="";

			panelError.Visible=false;
			lblError.Text="";
			
			//forms authentication panel			
			txtLogonPageUrl.Text="";
			txtUsername.Text="";
			txtPassword.Text="";
			txtUsernameFieldName.Text="";
			txtPasswordFieldName.Text="";
			txtSubmitButtonFieldName.Text="";

			//raw logon
			txtRawLogonPageUrl.Text="";
			txtRawSubmission.Text="";
			
			hideAuthenticationPanels();

			radNoAuthentication.Checked=true;

			panelReport.Visible=false;

		}

		private void lnkNew_Click(object sender, System.EventArgs e)
		{
			panelSession_reset();
			panelSession.Visible=true;

			dropDownUserAgent_bind();
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			panelSession_reset();
			panelSession.Visible=false;
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			page_save();
			panelSession_reset();

			panelSession.Visible=false;
		}


		private bool page_save()
		{
			bool bolError=false;
			string strTmpError="The following errors occurred:<BR><BR>";

			panelError.Visible=false;



			if (txtSessionName.Text.Trim()=="")
			{	
				bolError=true;
				strTmpError += "Session Name is blank<BR>";
			}

			if (txtSessionDescription.Text.Trim()=="")
			{	
				bolError=true;
				strTmpError += "Session Description is blank<BR>";
			}


			if (txtApplicationBaseUrl.Text.Trim()=="")
			{	
				bolError=true;
				strTmpError += "Application Base Url is blank<BR>";
			}


			
			if (bolError==true)
			{	

				panelError.Visible=true;
				lblError.Text="" + strTmpError;
				return false;
			}

			objSession.sessionName="" + txtSessionName.Text.Trim();
			objSession.sessionDescription="" + txtSessionDescription.Text.Trim();
			objSession.applicationBaseUrl="" + txtApplicationBaseUrl.Text.Trim();
		
			objSession.userAgent=System.Convert.ToInt32(dropDownUserAgent.SelectedItem.Value);

			if (radNoAuthentication.Checked==true)
			{
				objSession.authenticationType=0;
			}
			else if (radFormsAuthentication.Checked==true)
			{
				objSession.authenticationType=1;
			}
			else if (radRawFormsSubmission.Checked==true)
			{
				objSession.authenticationType=2;
			}
			

			if(chkAutoScan.Checked==true)
			{
				objSession.useAutoScan=1;
			}
			else
			{
				objSession.useAutoScan=0;
			}

			if(intSessionId==0)
			{
				objSession.add();
			}
			else
			{
				objSession.id=System.Convert.ToInt32(intSessionId);
				objSession.update();

			}

			//Save Authentication types

			if (radFormsAuthentication.Checked==true)
			{
				

				objSessionFormsLogon.deleteBySessionId();
				objSessionFormsLogon.loginPageUrl="" + txtLogonPageUrl.Text;
				objSessionFormsLogon.username = "" + txtUsername.Text;
				objSessionFormsLogon.password= "" + txtPassword.Text;
				objSessionFormsLogon.usernameFieldName="" + txtUsernameFieldName.Text;
				objSessionFormsLogon.passwordFieldName="" + txtPasswordFieldName.Text;
				objSessionFormsLogon.submitButtonFieldName="" + txtSubmitButtonFieldName.Text;
				objSessionFormsLogon.sessionId=objSession.id;
				objSessionFormsLogon.add();

			}
			else if (radRawFormsSubmission.Checked==true)
			{
			
				objRawLogon.deleteBySessionId();
				objRawLogon.loginPageUrl="" + txtRawLogonPageUrl.Text;
				objRawLogon.rawSubmission="" + txtRawSubmission.Text; 
				objRawLogon.sessionId=objSession.id;

				objRawLogon.add();

			}


		
			

			selectRefreshType();

			return true;


		}


		private void lstSessionPayloads_save()
		{

			int intX=0;
			int intUrlId=System.Convert.ToInt32(dropDownUrl.SelectedItem.Value);
			payloadDataAccess.deleteAllSessionPayloadsForSession(intSessionId, intUrlId);

			foreach(ListItem objListItem in lstSessionPayloads.Items)
			{
				payloadDataAccess.addSessionPayload(intSessionId, System.Convert.ToInt32(objListItem.Value), intUrlId, intX);
				intX++;
			}


		}


		private void lstSessionSignatures_save()
		{
			int intX=0;
			int intUrlId=System.Convert.ToInt32(dropDownUrl2.SelectedItem.Value);


			signaturesDataAccess.deleteAllSessionSignaturesForSession(intSessionId, intUrlId);

			
			foreach(ListItem objListItem in lstSessionSignatures.Items)
			{
				signaturesDataAccess.addSessionSignature(intSessionId, System.Convert.ToInt32(objListItem.Value), intUrlId, intX);
				intX++;
			}


		}


		private void cmdAddPayload_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstAllPayloads.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstAllPayloads.SelectedItem;

				
				lstSessionPayloads.Items.Add(objListItem);
				lstAllPayloads.Items.Remove(objListItem);

				lstSessionPayloads.ClearSelection();
			
				lstAllPayloads.ClearSelection();

			}
			catch
			{
			}

			lstSessionPayloads_save();

		}


		private void cmdAddSignature_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstAllSignatures.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstAllSignatures.SelectedItem;

				
				lstSessionSignatures.Items.Add(objListItem);
				lstAllSignatures.Items.Remove(objListItem);

				lstSessionSignatures.ClearSelection();
			
				lstAllSignatures.ClearSelection();

			}
			catch
			{
			}

			lstSessionSignatures_save();

		}

		private void cmdRemovePayload_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstSessionPayloads.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstSessionPayloads.SelectedItem;

			
				lstAllPayloads.Items.Add(objListItem);
				lstSessionPayloads.Items.Remove(objListItem);
			

				lstSessionPayloads.ClearSelection();
				lstAllPayloads.ClearSelection();

				
			}
			catch
			{
			}

			lstSessionPayloads_save();

		}


		private void cmdRemoveSignatures_click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstSessionSignatures.SelectedItem==null) return;

				ListItem objListItem=new ListItem();
				objListItem=lstSessionSignatures.SelectedItem;

			
				lstAllSignatures.Items.Add(objListItem);
				lstSessionSignatures.Items.Remove(objListItem);
			

				lstSessionSignatures.ClearSelection();
				lstAllSignatures.ClearSelection();

				
			}
			catch
			{
			}

			lstSessionSignatures_save();

		}


		private void cmdPayloadUp_click(object sender, System.EventArgs e)
		{

			try
			{
			
				if (lstSessionPayloads.SelectedItem==null) return;

				ListItem objMyListItem;

				objMyListItem=lstSessionPayloads.SelectedItem;							  
		
				int intX=0;
				int intY=0;

				foreach(ListItem tmpListItem in lstSessionPayloads.Items)
				{
					if (tmpListItem.Selected==true)
					{
						intY=intX;
						if (intY==0)
						{
							return;
						}
					}	
					
					intX=intX+1;

				}
		
	
				lstSessionPayloads.Items.Remove(objMyListItem);
				lstSessionPayloads.ClearSelection();

				lstSessionPayloads.Items.Insert(intY-1, objMyListItem);
			

				lstSessionPayloads_save();
				lstSessionPayloads_bind(System.Convert.ToInt32(dropDownUrl.SelectedItem.Value));

			}
			catch
			{
			}
			

		}

		private void cmdSignatureUp_click(object sender, System.EventArgs e)
		{

			
			try
			{
				if (lstSessionSignatures.SelectedItem==null) return;

				ListItem objMyListItem;

				objMyListItem=lstSessionSignatures.SelectedItem;							  
		
				int intX=0;
				int intY=0;

				foreach(ListItem tmpListItem in lstSessionSignatures.Items)
				{
					if (tmpListItem.Selected==true)
					{
						intY=intX;
						if (intY==0)
						{
							return;
						}
					}	
					
					intX=intX+1;

				}
		
	
				lstSessionSignatures.Items.Remove(objMyListItem);
				lstSessionSignatures.ClearSelection();

				lstSessionSignatures.Items.Insert(intY-1, objMyListItem);
			

				lstSessionSignatures_save();
				lstSessionSignatures_bind(System.Convert.ToInt32(dropDownUrl2.SelectedItem.Value));

			}
			catch
			{
			}
			

		}

		private void cmdUrlUp_click(object sender, System.EventArgs e)
		{

			try
			{
		
				if (lstUrls.SelectedItem==null) return;

				ListItem objMyListItem;

				objMyListItem=lstUrls.SelectedItem;							  
		
				int intX=0;
				int intY=0;

				foreach(ListItem tmpListItem in lstUrls.Items)
				{
					if (tmpListItem.Selected==true)
					{
						intY=intX;
						if (intY==0)
						{
							return;
						}
					}	
					
					intX=intX+1;

				}
		
	
				lstUrls.Items.Remove(objMyListItem);
				lstUrls.ClearSelection();

				lstUrls.Items.Insert(intY-1, objMyListItem);
			

				intX=0;
				foreach(ListItem tmpListItem in lstUrls.Items)
				{
					urlsDataAccess.updateOrder(System.Convert.ToInt32(tmpListItem.Value), intX);

					intX++;
				}

				lstUrls_bind();

			}
			catch
			{

			}

			
		
			

		}


		private void cmdPayloadDown_click(object sender, System.EventArgs e)
		{

		
			try
			{

				if (lstSessionPayloads.SelectedItem==null) return;


				ListItem objMyListItem;
				objMyListItem=lstSessionPayloads.SelectedItem;

				int intX=0;
				int intY=0;

				foreach(ListItem tmpListItem in lstSessionPayloads.Items)
				{

					if (tmpListItem.Selected==true)
					{
						intY=intX;
						if (intY==lstSessionPayloads.Items.Count-1)
						{
							return;
						}
					}	
					

					intX=intX+1;

				}
		
	
				lstSessionPayloads.Items.Remove(objMyListItem);
				lstSessionPayloads.ClearSelection();

				lstSessionPayloads.Items.Insert(intY+1, objMyListItem);
			
				lstSessionPayloads_save();
				lstSessionPayloads_bind(System.Convert.ToInt32(dropDownUrl.SelectedItem.Value));

			}
			catch
			{

			}

			
					

		}
		

		private void cmdSignatureDown_click(object sender, System.EventArgs e)
		{

		

			try
			{
				if (lstSessionSignatures.SelectedItem==null) return;


				ListItem objMyListItem;
				objMyListItem=lstSessionSignatures.SelectedItem;

				int intX=0;
				int intY=0;

				foreach(ListItem tmpListItem in lstSessionSignatures.Items)
				{

					if (tmpListItem.Selected==true)
					{
						intY=intX;
						if (intY==lstSessionSignatures.Items.Count-1)
						{
							return;
						}
					}	
					

					intX=intX+1;

				}
		
	
				lstSessionSignatures.Items.Remove(objMyListItem);
				lstSessionSignatures.ClearSelection();

				lstSessionSignatures.Items.Insert(intY+1, objMyListItem);
			
				lstSessionSignatures_save();
				lstSessionSignatures_bind(System.Convert.ToInt32(dropDownUrl2.SelectedItem.Value));

			}
			catch
			{

			}

			
					

		}

		
		private void cmdUrlDown_click(object sender, System.EventArgs e)
		{

		

			try
			{
				if (lstUrls.SelectedItem==null) return;


				ListItem objMyListItem;
				objMyListItem=lstUrls.SelectedItem;

				int intX=0;
				int intY=0;

				foreach(ListItem tmpListItem in lstUrls.Items)
				{

					if (tmpListItem.Selected==true)
					{
						intY=intX;
						if (intY==lstUrls.Items.Count-1)
						{
							return;
						}
					}	
					

					intX=intX+1;

				}
		
	
				lstUrls.Items.Remove(objMyListItem);
				lstUrls.ClearSelection();

				lstUrls.Items.Insert(intY+1, objMyListItem);
			
				intX=0;
				foreach(ListItem tmpListItem in lstUrls.Items)
				{
					urlsDataAccess.updateOrder(System.Convert.ToInt32(tmpListItem.Value), intX);

					intX++;
				}

				lstUrls_bind();

			}
			catch
			{

			}

			
					

		}
		private void lstSessionSignatures_bind(int intUrlId)
		{
			lstSessionSignatures.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=signaturesDataAccess.getSelectedForManageSessionScreen(intSessionId, intUrlId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["signatureName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstSessionSignatures.Items.Add(objListItem);

				objListItem=null;
			}


		}

		private void lstSessionPayloads_bind(int intUrlId)
		{
			lstSessionPayloads.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=payloadDataAccess.getSelectedForManageSessionScreen(intSessionId, intUrlId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["payloadName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstSessionPayloads.Items.Add(objListItem);

				objListItem=null;
			}


		}

		private void lstAllPayloads_bind(int intUrlId)
		{
			lstAllPayloads.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=payloadDataAccess.getAllForManageSessionScreen(intSessionId, intUrlId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["payloadName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstAllPayloads.Items.Add(objListItem);

				objListItem=null;
			}


		}

		private void lstAllSignatures_bind(int intUrlId)
		{
			lstAllSignatures.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=signaturesDataAccess.getAllForManageSessionScreen(intSessionId, intUrlId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["signatureName"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				lstAllSignatures.Items.Add(objListItem);

				objListItem=null;
			}


		}


		/// <summary>
		/// Initiates Session Test
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdInitiate_click(object sender, System.EventArgs e)
		{

			string strFileName="";

			if (page_save()==false)
			{
				return;
			}


			strFileName="" + objBeretta.initiate(intSessionId);

			panelReport.Visible=true;
			lnkReport.NavigateUrl="~/output/" + strFileName;

		}

	
		private void cmdRemoveUrl_click(object sender, System.EventArgs e)
		{
			if (lstUrls.SelectedItem==null) return;
			
			ListItem objListItem=new ListItem();

			objListItem=lstUrls.SelectedItem;
			
			urlsDataAccess.delete(System.Convert.ToInt32(objListItem.Value));
			
			lstUrls.ClearSelection();
			lstUrls.Items.Remove(objListItem);

			dropDownUrl_bind();

		}

		private void cmdAddUrl_click(object sender, System.EventArgs e)
		{
			if (txtUrl.Text.Trim()=="")
			{
				return;
			}
				
			objUrl.url="" + txtUrl.Text.Trim();
			objUrl.description="" + txtUrlDescription.Text;
			objUrl.sessionId=intSessionId;
			objUrl.sessionOrder=lstUrls.Items.Count;

			objUrl.add();

			txtUrl.Text="";
			txtUrlDescription.Text="";

			lstUrls_bind();

			dropDownUrl_bind();


		}


		private void lstUrls_bind()
		{

			DataSet objDataSet=new DataSet();
			objDataSet=urlsDataAccess.getAllForSession(intSessionId);

			lstUrls.Items.Clear();

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Text=System.Convert.ToString(objDataRow["url"]) + " (" + System.Convert.ToString(objDataRow["description"]) + ")";
				objListItem.Value=System.Convert.ToString(objDataRow["id"]);

				lstUrls.Items.Add(objListItem);

				objListItem=null;

			}
		}
	

		private void dropDownUrl_bind()
		{
			dropDownUrl.Items.Clear();
			dropDownUrl2.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=urlsDataAccess.getAllForSession(intSessionId);


			ListItem objNull=new ListItem();
	
			objNull.Text="--";
			objNull.Value="0";
			dropDownUrl.Items.Add(objNull);
			dropDownUrl2.Items.Add(objNull);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{

				ListItem objListItem=new ListItem();
				objListItem.Value=objDataRow["id"].ToString();
				objListItem.Text=objDataRow["url"].ToString() + " " + objDataRow["description"].ToString();

				dropDownUrl.Items.Add(objListItem);
				dropDownUrl2.Items.Add(objListItem);

				objListItem=null;


			}

		}
	}
}
