using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DefAppTestWeb
{
	/// <summary>
	/// Summary description for webuploadform.
	/// </summary>
	public class webuploadform : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Page.IsPostBack)
			{
				HttpPostedFile files = File1.PostedFile;
				if (files.ContentLength > 0)
				{
						string paths = Server.MapPath("/DefAppTestWeb/Upload/");
						char[] ch = {'\\'};
						string[] fileParts = files.FileName.Split(ch);
						string fileName = fileParts[fileParts.Length-1];
						paths += fileName;
						files.SaveAs(paths);
						Label1.Text = "File Saved Successfully to " + paths;
					}
				RetrieveFileList();
			}
		}
		private DataTable RetrieveFileList()
		{
			DataTable dataTab = new DataTable();
			dataTab.Columns.Add(new DataColumn("FileName"));
			string paths = Server.MapPath("/DefAppTestWeb/Upload/");
			string[] FileNames = Directory.GetFiles(paths);
			for(int i =0;i<FileNames.Length;i++)
			{
				
				
				DataRow row = dataTab.NewRow();
				row.ItemArray.SetValue(FileNames[i],0);
				dataTab.Rows.Add(row);
				//FileNames[i]
			}
			DataGrid1.DataSource = dataTab;
			DataGrid1.DataBind();
			return dataTab;
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}