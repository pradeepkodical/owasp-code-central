namespace beretta.Web.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using beretta.Objects;

	/// <summary>
	///		Summary description for recordSession.
	/// </summary>
	public class recordSession : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Panel panelMessage;
		protected System.Web.UI.WebControls.Button cmdRecord;
		protected System.Web.UI.WebControls.Button cmdPause;
		protected System.Web.UI.WebControls.Button cmdStop;
		protected System.Web.UI.WebControls.Panel panelRecord;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtSessionName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label lblHiddenId;
		protected System.Web.UI.WebControls.TextBox txtSessionDescription;
		protected System.Web.UI.WebControls.TextBox txtUrl;
		protected System.Web.UI.WebControls.Button cmdStartRecordingNewSession;
		protected System.Web.UI.WebControls.Panel panelHtml;
		protected System.Web.UI.WebControls.Panel panelRetrievedSite;
		protected Panel panelInitialSessionSetup;
		protected TextBox txtApplicationBaseUrl;
		protected TextBox txtPayload;
		protected TextBox txtCurrentURL;
		protected session objSession=new session();
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected urls objUrl=new urls();
		protected formRedirectSubmission objFormRedirect=new formRedirectSubmission();
		protected string strHtml="";
		protected string strPayload="";
		protected string strRedirectUrl="";
		protected payload objPayload=new payload();
		protected formSubmitter objFormSubmitter=new formSubmitter();
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected int intTmp=0;

		private void Page_Load(object sender, System.EventArgs e)
		{
	
			try
			{

				//Start new recording session
				if ("" + Request.QueryString["action"]=="reset")
				{
					clearSession();

				}

				if ("" + Session["sessionId"] !="")
				{
					objSession.id=System.Convert.ToInt32(Session["sessionId"]);
					objSession.populate();

				}

				//Set Buttons
				if (Session["mode"].ToString()=="record")
				{
					cmdRecord.Enabled=false;
					cmdPause.Enabled=true;
					cmdStop.Enabled=true;

				}

				if (Session["mode"].ToString()=="pause")
				{
					cmdRecord.Enabled=true;
					cmdPause.Enabled=false;
					cmdStop.Enabled=true;

				}

				try
				{
					strRedirectUrl="" + Request.QueryString["pageUrl"].ToString();		
				}
				catch
				{

				}

				//Get Form Submission
				if ("" + Session["mode"].ToString()=="record")
				{
				
					string strPayload="" + Request.Form;

					//replace modified view state field
					strPayload=strPayload.Replace("__RETREIVEDVIEWSTATE", "__VIEWSTATE");		
						
					//add this payload if we are in record mode
					objPayload.payloadName="Auto Generated for " + objSession.sessionName + ", " + Session["url"].ToString(); 
					objPayload.description="" + Session["url"].ToString();
					objPayload.payloadData="" + strPayload;
					objPayload.payloadOrder=System.Convert.ToInt32(Session["payloadOrder"]);
					objPayload.type=0;
					objPayload.add();			

					txtPayload.Text="" + objPayload.payloadData;
					txtCurrentURL.Text="" + strRedirectUrl;
					payloadDataAccess.addSessionPayload(System.Convert.ToInt32(Session["sessionId"]), objPayload.id, System.Convert.ToInt32(Session["urlId"]),  System.Convert.ToInt32(Session["payloadOrder"]));
	
					intTmp=System.Convert.ToInt32(Session["payloadOrder"]);
					intTmp=intTmp+1;
		
					Session["payloadOrder"]=intTmp.ToString();
					
				}

				//Display Results of form submission on page
				if("" + Session["mode"].ToString()=="pause" || Session["mode"].ToString()=="record")
				{

							
					
					//Increment recording values
					intTmp=System.Convert.ToInt32(Session["order"]);
					intTmp=intTmp+1;
					Session["order"]=intTmp;

					objUrl.description="Auto Generated URL";
					objUrl.sessionId=System.Convert.ToInt32(Session["sessionId"]);
					objUrl.sessionOrder=System.Convert.ToInt32(Session["order"]);
					objUrl.url=strRedirectUrl;
					objUrl.add();

					Session["urlId"]=objUrl.id.ToString();
					Session["url"]="" + objUrl.url;
					
					strHtml="" + objFormSubmitter.submitData("" + objPayload.payloadData, strRedirectUrl, true, "POST", "");
					
					strHtml=strHtml.Replace("__VIEWSTATE", "__RETREIVEDVIEWSTATE");
					strHtml=objFormRedirect.rewriteForm(strHtml, System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot") + "default.aspx?pageId=46&pageUrl=" + System.Web.HttpUtility.UrlEncode(strRedirectUrl), System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot") + "default.aspx?pageId=46&pageUrl=", objSession.applicationBaseUrl);
					
					Literal objLiteral=new Literal();
					objLiteral.Text=strHtml;
					panelHtml.Controls.Add(objLiteral);

					panelInitialSessionSetup.Visible=false;
					panelRecord.Visible=true;
					panelRetrievedSite.Visible=true;
				}

				
				else if ("" + Session["mode"].ToString()=="start")
				{
					Session["mode"]="record";
				}

			}
			catch
			{

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
			this.cmdRecord.Click += new System.EventHandler(this.cmdRecord_Click);
			this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
			this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
			this.cmdStartRecordingNewSession.Click += new System.EventHandler(this.cmdStartRecordingNewSession_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdStartRecordingNewSession_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid==false) return;

			clearSession();

			//Set up a new session

			objSession.sessionName="" + txtSessionName.Text;
			objSession.sessionDescription="" + txtSessionDescription.Text;
			objSession.authenticationType=0;
			objSession.applicationBaseUrl="" + txtApplicationBaseUrl.Text;
			objSession.add();

			panelInitialSessionSetup.Visible=false;
			panelRecord.Visible=true;
			panelRetrievedSite.Visible=true;

			Session["sessionId"]="" + objSession.id.ToString();
			Session["mode"]="record";
			Session["order"]="0";
			Session["payloadOrder"]="0";
			

			cmdRecord.Enabled=false;

			objUrl.description="Auto Generated URL";
			objUrl.sessionId=objSession.id;
			objUrl.sessionOrder=System.Convert.ToInt32(Session["order"]);
			objUrl.url=txtUrl.Text;
			objUrl.add();

			Session["url"]="" + objUrl.url;

			Session["urlId"]=objUrl.id.ToString();


			//Get Page
			strHtml="" + objFormRedirect.getUrlAndRedirect(txtUrl.Text, System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot") + "default.aspx?pageId=46&pageUrl=" + System.Web.HttpUtility.UrlEncode(txtUrl.Text),  System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot") + "default.aspx?pageId=46&pageUrl=", objSession.applicationBaseUrl);
			strHtml=strHtml.Replace("__VIEWSTATE", "__RETREIVEDVIEWSTATE");

			Literal objLiteral=new Literal();
			objLiteral.Text=strHtml;

			panelHtml.Controls.Add(objLiteral);
		}

		
		private void cmdPause_Click(object sender, System.EventArgs e)
		{
			Session["mode"]="pause";
			cmdPause.Enabled=false;
			cmdRecord.Enabled=true;
		}

		private void cmdRecord_Click(object sender, System.EventArgs e)
		{
			Session["mode"]="record";
			cmdPause.Enabled=true;
			cmdRecord.Enabled=false;
		}

		private void cmdStop_Click(object sender, System.EventArgs e)
		{
			clearSession();
			
			cmdStop.Enabled=false;
			cmdRecord.Enabled=false;
			cmdPause.Enabled=false;

			panelRecord.Visible=true;
			panelMessage.Visible=true;
			lblMessage.Text="Recording of new session finished";
			panelRetrievedSite.Visible=false;
		}

		private void clearSession()
		{
			
			Session["sessionId"]="";
			Session["mode"]="";
			Session["order"]="";
			Session["urlId"]="";
			Session["url"]="";

			cmdStop.Visible=false;
			cmdRecord.Visible=false;
			cmdPause.Visible=false;
		}
	}
}
