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
	///		Summary description for testPayload.
	/// </summary>
	public class testPayload : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Panel panelPage;
		protected System.Web.UI.WebControls.TextBox txtUrl;
		protected System.Web.UI.WebControls.TextBox txtPayload;
		protected System.Web.UI.WebControls.Button cmdSubmitPayload;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.Button cmdClear;
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected Microsoft.Web.UI.WebControls.MultiPage sessionTabs;
		private formSubmitter objFormSubmitter=new formSubmitter();
		protected CheckBox chkSignatures;
		protected Panel panelMatchingSignatures;
		protected beretta.Objects.signaturesDataAccess objSignaturesDataAccess=new signaturesDataAccess();
		protected DropDownList dropDownPayloads;
		protected DropDownList dropDownMode;
		protected DropDownList dropDownUserAgent;
		protected TextBox txtRepeat;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Page.IsPostBack==false)
			{
				dropDownPayloads_bind();
				dropDownUserAgent_bind();
				dropDownUserAgent_bind();

				panelPage.Visible=false;
			}
			else
			{
				panelPage.Visible=true;
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
			
			this.Load += new System.EventHandler(this.Page_Load);
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.cmdSubmitPayload.Click += new System.EventHandler(this.cmdSubmitPayload_Click);
			this.dropDownPayloads.SelectedIndexChanged += new System.EventHandler(this.dropDownPayloads_SelectedIndexChange);
			}
		#endregion

		private void cmdSubmitPayload_Click(object sender, System.EventArgs e)
		{
			string strUrl="";
			string strPayloadData="";
			string strReturn="";
		
			int intRepeat=0;
			int intX=0;

			try
			{
				intRepeat=System.Convert.ToInt32(txtRepeat.Text);
			}
			catch
			{
				intRepeat=0;
			}
	

			Literal objLiteral=new Literal();

			strUrl="" + txtUrl.Text;

			if (strUrl=="") return;

			strPayloadData="" + txtPayload.Text;



			try
			{


				strPayloadData= beretta.support.encoding.encodeFormElements(strPayloadData);
				while (intX<intRepeat)
				{
					strReturn="" + objFormSubmitter.submitData(strPayloadData, strUrl, true, dropDownMode.SelectedItem.Value.ToString(), dropDownUserAgent.SelectedItem.Text);
					intX++;
				}
				
				strReturn=strReturn.Replace("<form", "<oldform");
				strReturn=strReturn.Replace("<FORM", "<oldform");
				strReturn=strReturn.Replace("<Form", "<oldform");

				strReturn=strReturn.Replace("</form", "</oldform");
				strReturn=strReturn.Replace("</FORM", "</oldform");
				strReturn=strReturn.Replace("</Form", "</oldform");

				strReturn=strReturn.Replace("__VIEWSTATE", "__OLDVIEWSTATE");


				objLiteral.Text=strReturn;
				panelPage.Controls.Add(objLiteral);
			}
			catch(System.Exception ex)
			{
				Label objLabel=new Label();
					
				objLabel.Text="" + ex.Message;
			
				panelPage.Controls.Add(objLabel);

			}


			if (chkSignatures.Checked==true)
			{				
				checkSignatures(strReturn);
			}

		}

		private void checkSignatures(string strInput)
		{

			DataSet objSignaturesDataSet=new DataSet();
			objSignaturesDataSet=signaturesDataAccess.getAll();


			//Check if result matches any signatures
			foreach(DataRow objSignatureRow in objSignaturesDataSet.Tables[0].Rows)
			{
				
				HyperLink objSignatureLink=new HyperLink();
				Literal objLiteral=new Literal();
	
				objLiteral.Text="<BR><BR>";

				//Signature type 0 check for occurence of string
				if (objSignatureRow["signatureType"].ToString()=="0")
				{

					//Equal to
					if (objSignatureRow["signatureOperator"].ToString()=="=")
					{
						string strTest=objSignatureRow["signatureValue"].ToString();
						if (strInput.IndexOf(objSignatureRow["signatureValue"].ToString())==-1 && strInput != objSignatureRow["signatureValue"].ToString())
						{
							//no result
									
						}
						else
						{
							
							objSignatureLink.Text="" + objSignatureRow["signatureName"].ToString();
							objSignatureLink.NavigateUrl="~/signatureInfo.aspx?id=" + objSignatureRow["id"].ToString();
							objSignatureLink.CssClass="normal";
							
							panelMatchingSignatures.Controls.Add(objSignatureLink);
							
						}
					}

					//Not equal to
					if (objSignatureRow["signatureOperator"].ToString()=="!=")
					{
						if (strInput.IndexOf(objSignatureRow["signatureValue"].ToString())==-1 && strInput != objSignatureRow["signatureValue"].ToString())
						{
									
							//no match
						}
						else
						{
							objSignatureLink.Text="" + objSignatureRow["signatureName"].ToString();
							objSignatureLink.NavigateUrl="~/signatureInfo.aspx?id=" + objSignatureRow["id"].ToString();
							objSignatureLink.CssClass="normal";
							
							panelMatchingSignatures.Controls.Add(objLiteral);
							panelMatchingSignatures.Controls.Add(objSignatureLink);
								
						}
					}
					
				}

					//Signature type 1 user regular expression
				else if (objSignatureRow["signatureType"].ToString()=="1")
				{

					if (System.Text.RegularExpressions.Regex.IsMatch(strInput, objSignatureRow["signatureValue"].ToString(), System.Text.RegularExpressions.RegexOptions.None))
					{
						objSignatureLink.Text="" + objSignatureRow["signatureName"].ToString();
						objSignatureLink.NavigateUrl="~/signatureInfo.aspx?id=" + objSignatureRow["id"].ToString();
						objSignatureLink.CssClass="normal";
							
						panelMatchingSignatures.Controls.Add(objLiteral);
						panelMatchingSignatures.Controls.Add(objSignatureLink);
					}
					else
					{
						//no match
					}
						
				}

				objLiteral=null;
				objSignatureLink=null;


			}

			if (panelMatchingSignatures.Controls.Count==0)
			{
				Label objLabel=new Label();
				objLabel.CssClass="normal";
				objLabel.Text="No matching signatures";
				objLabel.Font.Bold=true;

				panelMatchingSignatures.Controls.Add(objLabel);

			}

		}



		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			panelPage.Controls.Clear();
			txtUrl.Text="";
			txtPayload.Text="";
			panelMatchingSignatures.Controls.Clear();
		}

		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			panelMatchingSignatures.Controls.Clear();
			panelPage.Controls.Clear();
		}

		

		private void dropDownPayloads_bind()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=payloadDataAccess.getAll();

			dropDownPayloads.Items.Clear();

			ListItem objNullItem=new ListItem();
			objNullItem.Text="--";
			objNullItem.Value="0";

			dropDownPayloads.Items.Add(objNullItem);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Value="" + objDataRow["id"];
				objListItem.Text="" + objDataRow["payloadName"];

				dropDownPayloads.Items.Add(objListItem);

				objListItem=null;

			}

		}


		private void dropDownUserAgent_bind()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=devCafe.framework.listItemsDataAccess.getAllForGroupByName("USERAGENT");

			dropDownUserAgent.Items.Clear();

			ListItem objNullItem=new ListItem();
			objNullItem.Text="--";
			objNullItem.Value="0";

			dropDownPayloads.Items.Add(objNullItem);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				ListItem objListItem=new ListItem();

				objListItem.Value="" + objDataRow["id"];
				objListItem.Text="" + objDataRow["listItemName"];

				dropDownUserAgent.Items.Add(objListItem);

				objListItem=null;

			}

		}

		private void dropDownPayloads_SelectedIndexChange(object sender, System.EventArgs e)
		{
			if (dropDownPayloads.SelectedIndex==0) return;

			payload objPayload=new payload();

			objPayload.id=System.Convert.ToInt32(dropDownPayloads.SelectedItem.Value);
			objPayload.populate();

			txtPayload.Text="" + objPayload.payloadData;
				
		}

	}
}
