/* Author: Alex Mackey
 * Date: 28/06/2005
 * Version: 1.0
 * Purpose: Manage FRAMEWORK_listItems
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
	///		Summary description for listItems.
	/// </summary>
	public class listItems : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtListItemName;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.ListBox lstItems;
		protected System.Web.UI.WebControls.Button cmdUp;
		protected System.Web.UI.WebControls.Button cmdDelete;
		protected System.Web.UI.WebControls.Button cmdDown;
		protected int intGroupId=0;
		protected listGroup objListGroup=new listGroup();
		protected frameworkListItems objListItems=new frameworkListItems();
		protected System.Web.UI.WebControls.Label lblTitle;
		protected CheckBox chkIsDefault;
		protected Button cmdEdit;
		protected Button cmdCancel;
		protected System.Web.UI.WebControls.Label lblTitle2;
		protected LinkButton lnkBack;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Page.IsPostBack==false)
			{
				try
				{
					ViewState["urlReferrer"]="" + Request.UrlReferrer.ToString();

					intGroupId=System.Convert.ToInt32(Request.QueryString["id"]);
					ViewState["groupId"]="" + intGroupId.ToString();

					objListGroup.id=intGroupId;
					objListGroup.populate();

					lblTitle.Text="Editing list items for list group: " + objListGroup.listGroupName;

				}
				catch
				{

				}

				page_bind();
			}
			else
			{
				intGroupId=System.Convert.ToInt32(ViewState["groupId"]);
			}
		}

		private void page_bind()
		{
			lstItems.Items.Clear();

			DataSet objDataSet=new DataSet();
			objDataSet=listItemsDataAccess.getAllForGroup(intGroupId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Value="" + objDataRow["id"].ToString();

				if(objDataRow["isDefault"].ToString()=="1")
				{
					objListItem.Text="" + objDataRow["listItemName"].ToString() + " (default)";
				}
				else
				{
					objListItem.Text="" + objDataRow["listItemName"].ToString();
				}

				lstItems.Items.Add(objListItem);

				objListItem=null;

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
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
			this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			this.lnkBack.Click += new System.EventHandler(this.lnkBack_click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			ViewState["id"]="";
			txtListItemName.Text="";
			chkIsDefault.Checked=false;
			cmdAdd.Text="Add";

			page_bind();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			
			if(cmdAdd.Text=="Update")
			{
				objListItems.id=System.Convert.ToInt32(ViewState["id"]);
				objListItems.populate();
			}

			objListItems.listItemName=txtListItemName.Text;
			objListItems.groupId=intGroupId;

			if(chkIsDefault.Checked==true)
			{
				objListItems.isDefault=1;
			}
			else
			{
				objListItems.isDefault=0;
			}

			if(cmdAdd.Text=="Add")
			{
				objListItems.listItemOrder=lstItems.Items.Count + 1;
				objListItems.add();
			}
			else
			{
				objListItems.update();
			}

			ViewState["id"]="";
			txtListItemName.Text="";
			chkIsDefault.Checked=false;
			cmdAdd.Text="Add";

			page_bind();
		}

		private void cmdUp_Click(object sender, System.EventArgs e)
		{
			
			int intX=0;
			int intY=0;

			try
			{
				ListItem objMyListItem;

				objMyListItem=lstItems.SelectedItem;							  

				foreach(ListItem tmpListItem in lstItems.Items)
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
		
				lstItems.Items.Remove(objMyListItem);
				lstItems.ClearSelection();
				lstItems.Items.Insert(intY - 1, objMyListItem);
			
				intX=0;

				foreach(ListItem tmpListItem in lstItems.Items)
				{
					listItemsDataAccess.updateOrder(System.Convert.ToInt32(tmpListItem.Value), intX);
					intX++;
				}

				page_bind();

			}
			catch(System.Exception ex)
			{
				string strTmp=ex.Message;
				return;
			}

		}

		private void cmdDown_Click(object sender, System.EventArgs e)
		{
			int intX=0;
			int intY=0;

			try
			{
				if (lstItems.SelectedItem==null) return;

				ListItem objMyListItem;
				objMyListItem=lstItems.SelectedItem;

				foreach(ListItem tmpListItem in lstItems.Items)
				{
					if (tmpListItem.Selected==true)
					{
						intY=intX;
						if (intY==lstItems.Items.Count-1)
						{
							return;
						}
					}	
					
					intX=intX+1;
				}
		
				lstItems.Items.Remove(objMyListItem);
				lstItems.ClearSelection();

				lstItems.Items.Insert(intY+1, objMyListItem);
			
				intX=0;

				foreach(ListItem tmpListItem in lstItems.Items)
				{
					listItemsDataAccess.updateOrder(System.Convert.ToInt32(tmpListItem.Value), intX);	
					intX++;
				}
			
				page_bind();

			}

			catch
			{
				return;
			}
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if (lstItems.SelectedItem ==null) return;

			listItemsDataAccess.delete(System.Convert.ToInt32(lstItems.SelectedItem.Value));

			page_bind();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			if (lstItems.SelectedItem ==null) return;

			objListItems.id=System.Convert.ToInt32(lstItems.SelectedItem.Value);
			objListItems.populate();

			txtListItemName.Text="" + objListItems.listItemName;

			if(objListItems.isDefault==1)
			{
				chkIsDefault.Checked=true;
			}
			else
			{
				chkIsDefault.Checked=false;
			}

			ViewState["id"]="" + objListItems.id.ToString();

			cmdAdd.Text="Update";

		}

		
		private void lnkBack_click(object sender, System.EventArgs e)
		{
			Response.Redirect("" + ViewState["urlReferrer"].ToString());

		}
	}
}
