/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: System events (FRAMEWORK_systemEvents)
 */
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using devCafe.framework;


namespace sourceControl.controls
{

	/// <summary>
	///		Summary description for systemEvents.
	/// </summary>
	public class systemEvents : System.Web.UI.UserControl
	{

		protected DataGrid dgSystemEvents;
		protected DropDownList dropDownEventTypes;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Page.IsPostBack==false)
			{
				
				page_bind();
				dropDownEventTypes_bind();
			}
		}

		private void page_bind()
		{
			DataSet objDataSet=new DataSet();
			DataView objDataView=new DataView();

			objDataSet=systemEventsDataAccess.getAll();
	

			objDataView.Table=objDataSet.Tables[0];

			if(dropDownEventTypes.SelectedItem!=null && dropDownEventTypes.SelectedItem.Value!="0")
			{
				objDataView.RowFilter="eventTypeId=" + dropDownEventTypes.SelectedItem.Value.ToString();
			}
			else
			{
				objDataView.RowFilter="";
			}

		
			dgSystemEvents.DataSource=objDataView;
			dgSystemEvents.DataBind();

			if(objDataView.Table.Rows.Count<11)
			{
				dgSystemEvents.AllowPaging=false;
			}
			else
			{
				dgSystemEvents.AllowPaging=true;
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
			this.dropDownEventTypes.SelectedIndexChanged += new System.EventHandler(this.dropDownEventTypes_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dropDownEventTypes_bind()
		{
			DataSet objEventTypes=new DataSet();
			objEventTypes=systemEventsDataAccess.getAllEventTypes();

			dropDownEventTypes.Items.Clear();

			ListItem objNull=new ListItem();
			objNull.Text="--";
			objNull.Value="0";
			
			dropDownEventTypes.Items.Add(objNull);

			foreach(DataRow objDataRow in objEventTypes.Tables[0].Rows)
			{

				ListItem objListItem=new ListItem();
				objListItem.Text=objDataRow["eventDescription"].ToString();
				objListItem.Value=objDataRow["id"].ToString();

				dropDownEventTypes.Items.Add(objListItem);

				objListItem=null;
			}
			

		}

		private void dropDownEventTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
			dgSystemEvents.CurrentPageIndex=0;

			page_bind();
		}
	
		public void dbgrid_SelectedIndexChanged(System.Object o, System.Web.UI.WebControls.DataGridPageChangedEventArgs e) 
		{																																		
			int newPage=e.NewPageIndex;
			dgSystemEvents.CurrentPageIndex=newPage;
						
			page_bind();
		
		}
	}
}
