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
	///		Summary description for manageUsernames.
	/// </summary>
	public class manageUsernames : System.Web.UI.UserControl
	{

		private int intItemsPerPage = 11;
		
		protected System.Web.UI.WebControls.DataGrid dbgrid;
		protected System.Web.UI.WebControls.LinkButton LinkButton0;
		protected System.Web.UI.WebControls.LinkButton Linkbutton1;
		protected System.Web.UI.WebControls.LinkButton Linkbutton2;
		protected System.Web.UI.WebControls.LinkButton Linkbutton3;
		protected System.Web.UI.WebControls.LinkButton Linkbutton4;
		protected System.Web.UI.WebControls.LinkButton Linkbutton5;
		protected System.Web.UI.WebControls.LinkButton Linkbutton6;
		protected System.Web.UI.WebControls.LinkButton Linkbutton7;
		protected System.Web.UI.WebControls.LinkButton Linkbutton8;
		protected System.Web.UI.WebControls.LinkButton Linkbutton9;
		protected System.Web.UI.WebControls.LinkButton Linkbutton10;
		protected System.Web.UI.WebControls.LinkButton Linkbutton11;
		protected System.Web.UI.WebControls.LinkButton Linkbutton12;
		protected System.Web.UI.WebControls.LinkButton Linkbutton13;
		protected System.Web.UI.WebControls.LinkButton Linkbutton14;
		protected System.Web.UI.WebControls.LinkButton Linkbutton15;
		protected System.Web.UI.WebControls.LinkButton Linkbutton16;
		protected System.Web.UI.WebControls.LinkButton Linkbutton17;
		protected System.Web.UI.WebControls.LinkButton Linkbutton18;
		protected System.Web.UI.WebControls.LinkButton Linkbutton19;
		protected System.Web.UI.WebControls.LinkButton Linkbutton20;
		protected System.Web.UI.WebControls.LinkButton Linkbutton21;
		protected System.Web.UI.WebControls.LinkButton Linkbutton22;
		protected System.Web.UI.WebControls.LinkButton Linkbutton23;
		protected System.Web.UI.WebControls.LinkButton Linkbutton24;
		protected System.Web.UI.WebControls.LinkButton Linkbutton25;
		protected System.Web.UI.WebControls.LinkButton Linkbutton26;
		protected System.Web.UI.WebControls.TextBox txtHiddenAlphabet;
	
		protected System.Web.UI.WebControls.TextBox txtSectionName;
		protected System.Web.UI.WebControls.LinkButton lnkNew;
		protected System.Web.UI.WebControls.Button cmdSearch;
		protected System.Web.UI.WebControls.TextBox txtProductId;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected usernameDataAccess objUsernameDataAccess=new usernameDataAccess();


		
		private void Page_Load(object sender, System.EventArgs e) 
		{
		
			if (Page.IsPostBack==false)
			{
				selectRefreshType();

				
			}
				
				
			
		}

		
		private void lnkNew_click(object sender, System.EventArgs e)
		{
			dbgrid.ShowFooter=true;
		}

		
		private void selectRefreshType()
		{
			string strAlphabet, strSectionName;
			int intPageCount, intCurrentPage;

			DataSet objDataSet=new DataSet();
			DataView objDataView=new DataView();

			strSectionName="" + System.Text.RegularExpressions.Regex.Replace(txtSectionName.Text, "'","''"); 
		
			strAlphabet = "" + txtHiddenAlphabet.Text;

			objDataSet=dbGrid_bind();

			//search
			objDataView.Table=objDataSet.Tables[0];


			if (strAlphabet !="*" && strAlphabet !="")
			{
				objDataView.RowFilter="username LIKE'" + strAlphabet + "%'";
			}

			if (strSectionName != "")
			{
				if (objDataView.RowFilter != "") 
				{
					objDataView.RowFilter=objDataView.RowFilter + " AND username LIKE'%" + strSectionName + "%'";
				}
				else
				{
					objDataView.RowFilter="username LIKE'%" + strSectionName + "%'";
				}

			}

			

			//bind to grid
			dbgrid.DataSource = objDataView;

			if (objDataView.Count < intItemsPerPage) 
			{
				dbgrid.AllowPaging = false;
			}
			else
			{
				dbgrid.AllowPaging = true;
			}

			intPageCount = dbgrid.PageCount;
			intCurrentPage = dbgrid.CurrentPageIndex;

			//if a delete occurs we could be on an invalid page
			try
			{
				dbgrid.DataBind();

			}
		
			catch
			{
				if (intCurrentPage > 1) 
				{
					dbgrid.CurrentPageIndex = intCurrentPage - 1;
				}
			}

			dbgrid.DataBind();
		}
	
		
		private DataSet dbGrid_bind()
		{
			DataSet objDataSet =new DataSet();
			objDataSet = objUsernameDataAccess.getAll();
		
			return objDataSet;
		
		}


		private void cmdReset_click(object o, System.EventArgs e)
		{
			resetDataGrid();
			selectRefreshType();
		}

       
		protected void alphabet_onClick(object o, System.EventArgs e)
		{

			string strAlphabet;
			System.Web.UI.WebControls.LinkButton lnk=(System.Web.UI.WebControls.LinkButton) o;
			strAlphabet = lnk.CommandName;

			//reset search?
			if (strAlphabet == "*") 
			{

				resetDataGrid();

				return;
			}
            
			txtHiddenAlphabet.Text = strAlphabet;
			selectRefreshType();
		}


		public void dgCommand_onClick(System.Object o, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

			string strCommandName;
			int intId, intItemId;
			bool bolError=false;
			

			strCommandName = e.CommandName;
			intId=e.Item.ItemIndex;

			//delete an item 
			if (strCommandName == "cmdDelete")
			{
				intItemId = (int) dbgrid.DataKeys[intId];
				objUsernameDataAccess.delete(intItemId);


			
			}

			

			if (strCommandName=="cmdAdd")
			{
				System.Web.UI.WebControls.TextBox txtValue= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("txtValue");
				System.Web.UI.WebControls.TextBox txtOrder= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("txtOrder");
			
				if (txtValue.Text.Trim() != "" && txtOrder.Text.Trim() != "")
				{
				
					try
					{
						int intTest=0;
						
						intTest=System.Convert.ToInt32(txtOrder.Text);

					}
					catch
					{
						dbgrid.ShowFooter=false;
						return;
					}


					objUsernameDataAccess.add(txtValue.Text, System.Convert.ToInt32(txtOrder.Text));

				}

				dbgrid.ShowFooter=false;
			}

			if (strCommandName == "cmdUpdate")
			{
				intItemId = (int) dbgrid.DataKeys[intId];

				TextBox txtValue = new TextBox();
				TextBox txtOrder = new TextBox();

			
				txtValue = (TextBox) e.Item.FindControl("txtExistingValue");
				txtOrder= (TextBox) e.Item.FindControl("txtExistingOrder");
				
	
				if (txtValue.Text=="" || txtOrder.Text=="")
				{
					bolError = true;
					
				}

				if (bolError==true)
				{
					return;
				}

				try
				{
					int intTest=0;
						
					intTest=System.Convert.ToInt32(txtOrder.Text);

				}
				catch
				{
					return;
				}
				
				objUsernameDataAccess.update(intItemId, txtValue.Text, System.Convert.ToInt32(txtOrder.Text));

			}


			if (strCommandName=="cmdCancel")
			{							
				dbgrid.ShowFooter=false;
			}

			selectRefreshType();

		}
		
		
		public void resetDataGrid()
		{
		
			dbgrid.CurrentPageIndex = 0;
			
			txtSectionName.Text="";
		

			txtHiddenAlphabet.Text = "";
			selectRefreshType();	

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


		public void cmdSearch_click(System.Object o, System.EventArgs e)
		{
			selectRefreshType();

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
			this.Load += new System.EventHandler(this.Page_Load);
			this.lnkNew.Click += new System.EventHandler(this.lnkNew_click);
			this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
