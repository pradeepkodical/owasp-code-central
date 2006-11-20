/* Author: Alex Mackey
 * Date: 27/06/2005
 * Version: 1.0
 * Purpose: Manage FRAMEWORK_tabs 
 */
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using devCafe.framework;

namespace sourceControl.controls.framework
{
	


	/// <summary>
	///		Summary description for manageTabs.
	/// </summary>
	public class manageTabs : System.Web.UI.UserControl
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
	
		protected System.Web.UI.WebControls.TextBox txtPageName;
		protected System.Web.UI.WebControls.TextBox txtAllowedRoles;
		protected DropDownList dropDownLayouts;

		

		protected System.Web.UI.WebControls.LinkButton lnkNew;
		protected System.Web.UI.WebControls.Button cmdSearch;
		protected System.Web.UI.WebControls.TextBox txtListGroupName;
		protected TextBox txtSectionName;
		

		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.Panel panelNew;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected tab objTab=new tab();
		protected Panel panelModules;
		protected DropDownList dropDownModules;
		protected Button cmdAddModules;
		protected ListBox lstModules;
		protected Button cmdRemoveModules;
		protected Button cmdCloseModules;
		
		private void Page_Load(object sender, System.EventArgs e) 
		{
		
			if (Page.IsPostBack==false)
			{
				dropDownLayouts_bind();
				selectRefreshType();

				
			}
				
				
			
		}

		
		private void cmdCloseModules_click(object sender, System.EventArgs e)
		{
			panelModules_reset();
			panelModules.Visible=false;
			
		}

		private void cmdRemoveModules_click(object sender, System.EventArgs e)
		{

			if(lstModules.SelectedItem==null) return;
			
			moduleDataAccess.removeModuleFromPage(System.Convert.ToInt32(lstModules.SelectedItem.Value));
			
			panelModules_bind();
		}


		private void cmdAddModules_click(object sender, System.EventArgs e)
		{

			if(dropDownModules.SelectedItem==null) return;
			if(dropDownModules.SelectedItem.Value=="0") return;

			moduleDataAccess.addModuleToPage(System.Convert.ToInt32(ViewState["tabId"]), System.Convert.ToInt32(dropDownModules.SelectedItem.Value), 0);
			
			panelModules_bind();
		}

		private void panelModules_bind()
		{
			int intTabId=System.Convert.ToInt32(ViewState["tabId"].ToString());
			
			lstModules.Items.Clear();
			dropDownModules.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=moduleDataAccess.getAll();

			ListItem objNull=new ListItem();
			objNull.Text="--";
			objNull.Value="0";
			
			dropDownModules.Items.Add(objNull);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Text="" + objDataRow["src"].ToString();
				objListItem.Value="" + objDataRow["id"].ToString();
				
				dropDownModules.Items.Add(objListItem);

				objListItem=null;

			}


			DataSet objDataSet2=new DataSet();

			objDataSet2=tabDataAccess.getAllModulesForTabDataSet(intTabId);

			foreach(DataRow objDataRow2 in objDataSet2.Tables[0].Rows)
			{
				ListItem objListItem2=new ListItem();

				objListItem2.Text="" + objDataRow2["src"].ToString();
				objListItem2.Value="" + objDataRow2["id"].ToString();
				
				lstModules.Items.Add(objListItem2);

				objListItem2=null;

			}


		}

		private void panelModules_reset()
		{
			dropDownModules.ClearSelection();
			lstModules.Items.Clear();
			ViewState["tabId"]="";
		}

		private void dropDownLayouts_bind()
		{
			
			DataSet objDataSet=new DataSet();
			objDataSet=layoutDataAccess.getAll();

			dropDownLayouts.Items.Clear();

			ListItem objNull=new ListItem();

			objNull.Text="--";
			objNull.Value="0";

			dropDownLayouts.Items.Add(objNull);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Text="" + objDataRow["layoutName"].ToString();
				objListItem.Value="" + objDataRow["id"].ToString();

				dropDownLayouts.Items.Add(objListItem);

				objListItem=null;
			}


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
				objDataView.RowFilter="pageName LIKE'" + strAlphabet + "%'";
			}

			if (strSectionName != "")
			{
				if (objDataView.RowFilter != "") 
				{
					objDataView.RowFilter=objDataView.RowFilter + " AND pageName LIKE'%" + strSectionName + "%'";
				}
				else
				{
					objDataView.RowFilter="pageName LIKE'%" + strSectionName + "%'";
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
			objDataSet = tabDataAccess.getAll();
		
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

				objTab.id=intItemId;
				objTab.delete();
								
			}

			if (strCommandName == "cmdModules")
			{
				intItemId = (int) dbgrid.DataKeys[intId];

				panelModules_reset();

				ViewState["tabId"]=intItemId.ToString();

				panelModules_bind();

				panelModules.Visible=true;
								
			}

			

			if (strCommandName =="cmdEdit")
			{
				intItemId = (int) dbgrid.DataKeys[intId];

				objTab.id=intItemId;
				objTab.populate();
				
				panelNew_reset();
				panelNew.Visible=true;

				
				txtPageName.Text="" + objTab.pageName;
				txtAllowedRoles.Text="" + objTab.allowedRoles;

				dropDownLayouts.ClearSelection();

				foreach(ListItem objListItem in dropDownLayouts.Items)
				{
					if (objListItem.Value==objTab.layoutId.ToString())
					{
						objListItem.Selected=true;
					}

				}
	

				ViewState["id"]="" + objTab.id.ToString();

				cmdAdd.Text="Update";
					
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
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.lnkNew.Click += new System.EventHandler(this.lnkNew_Click);
			this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.cmdCloseModules.Click += new System.EventHandler(this.cmdCloseModules_click);
			this.cmdAddModules.Click += new System.EventHandler(this.cmdAddModules_click);
			this.cmdRemoveModules.Click += new System.EventHandler(this.cmdRemoveModules_click);
		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			
			if(ViewState["id"].ToString()!="")
			{
				objTab.id=System.Convert.ToInt32(ViewState["id"]);
				objTab.populate();
			}

			
			objTab.pageName="" + txtPageName.Text;
			objTab.allowedRoles="" + txtAllowedRoles.Text;
			objTab.layoutId=System.Convert.ToInt32(dropDownLayouts.SelectedItem.Value);
			
			if(ViewState["id"].ToString()=="")
			{
				objTab.add();
			}
			else
			{
				objTab.update();
			}

			selectRefreshType();

			panelNew_reset();
			panelNew.Visible=false;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			panelNew_reset();
			panelNew.Visible=false;
		}

		private void lnkNew_Click(object sender, System.EventArgs e)
		{
			panelNew_reset();
			panelNew.Visible=true;
		
			
		}

		private void panelNew_reset()
		{
			ViewState["id"]="";
			txtPageName.Text="";
			txtAllowedRoles.Text="";
			dropDownLayouts.SelectedIndex=0;
			cmdAdd.Text="Add";

		}
	}
}
