using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for AuthenticTest.
	/// </summary>
	/// 

	public class frmAuthenticTest : System.Windows.Forms.Form
	{

        private utils.authentic authUtils = new utils.authentic();
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtXsdFile;
		private System.Windows.Forms.TextBox txtXmlFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSpsFile;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btTest;
		private System.Windows.Forms.Label lbTextChanged;
		private System.Windows.Forms.Label lbKeyPressed;
		private System.Windows.Forms.Button btnApplyHooks;
		private System.Windows.Forms.TextBox txtDebugInformation;
		private System.Windows.Forms.Label lbCurrentSelectedControl;
		private System.Windows.Forms.Button btSelectPreviousElement;
		private System.Windows.Forms.Button btSelectPreviousWord;
		private System.Windows.Forms.Button btAssignIssueID;
        private Button btTest2;
        private Label lbLeftShift;
        private Label lbLeftCtrl;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 

		private System.ComponentModel.Container components = null;

		public frmAuthenticTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		/// 
				
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuthenticTest));
            this.axAuthentic1 = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXsdFile = new System.Windows.Forms.TextBox();
            this.txtXmlFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpsFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btTest = new System.Windows.Forms.Button();
            this.lbTextChanged = new System.Windows.Forms.Label();
            this.lbKeyPressed = new System.Windows.Forms.Label();
            this.btnApplyHooks = new System.Windows.Forms.Button();
            this.txtDebugInformation = new System.Windows.Forms.TextBox();
            this.lbCurrentSelectedControl = new System.Windows.Forms.Label();
            this.btSelectPreviousElement = new System.Windows.Forms.Button();
            this.btSelectPreviousWord = new System.Windows.Forms.Button();
            this.btAssignIssueID = new System.Windows.Forms.Button();
            this.btTest2 = new System.Windows.Forms.Button();
            this.lbLeftShift = new System.Windows.Forms.Label();
            this.lbLeftCtrl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic1)).BeginInit();
            this.SuspendLayout();
            // 
            // axAuthentic1
            // 
            this.axAuthentic1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.axAuthentic1.Enabled = true;
            this.axAuthentic1.Location = new System.Drawing.Point(0, 88);
            this.axAuthentic1.Name = "axAuthentic1";
            this.axAuthentic1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic1.OcxState")));
            this.axAuthentic1.Size = new System.Drawing.Size(744, 320);
            this.axAuthentic1.TabIndex = 0;
            this.axAuthentic1.SelectionChanged += new System.EventHandler(this.axAuthentic1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "XSD file:";
            this.label1.Visible = false;
            // 
            // txtXsdFile
            // 
            this.txtXsdFile.Location = new System.Drawing.Point(56, 8);
            this.txtXsdFile.Name = "txtXsdFile";
            this.txtXsdFile.Size = new System.Drawing.Size(272, 20);
            this.txtXsdFile.TabIndex = 2;
            this.txtXsdFile.Visible = false;
            // 
            // txtXmlFile
            // 
            this.txtXmlFile.Location = new System.Drawing.Point(56, 32);
            this.txtXmlFile.Name = "txtXmlFile";
            this.txtXmlFile.Size = new System.Drawing.Size(272, 20);
            this.txtXmlFile.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xml file:";
            // 
            // txtSpsFile
            // 
            this.txtSpsFile.Location = new System.Drawing.Point(56, 56);
            this.txtSpsFile.Name = "txtSpsFile";
            this.txtSpsFile.Size = new System.Drawing.Size(272, 20);
            this.txtSpsFile.TabIndex = 2;
            this.txtSpsFile.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "SPS file:";
            this.label3.Visible = false;
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(496, 32);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(72, 24);
            this.btTest.TabIndex = 3;
            this.btTest.Text = "Test";
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // lbTextChanged
            // 
            this.lbTextChanged.ForeColor = System.Drawing.Color.Red;
            this.lbTextChanged.Location = new System.Drawing.Point(384, 32);
            this.lbTextChanged.Name = "lbTextChanged";
            this.lbTextChanged.Size = new System.Drawing.Size(80, 16);
            this.lbTextChanged.TabIndex = 4;
            this.lbTextChanged.Text = "Text Changed";
            this.lbTextChanged.Visible = false;
            // 
            // lbKeyPressed
            // 
            this.lbKeyPressed.Location = new System.Drawing.Point(384, 48);
            this.lbKeyPressed.Name = "lbKeyPressed";
            this.lbKeyPressed.Size = new System.Drawing.Size(80, 16);
            this.lbKeyPressed.TabIndex = 5;
            this.lbKeyPressed.Text = "...";
            // 
            // btnApplyHooks
            // 
            this.btnApplyHooks.Location = new System.Drawing.Point(576, 32);
            this.btnApplyHooks.Name = "btnApplyHooks";
            this.btnApplyHooks.Size = new System.Drawing.Size(104, 24);
            this.btnApplyHooks.TabIndex = 6;
            this.btnApplyHooks.Text = "Apply Hooks";
            // 
            // txtDebugInformation
            // 
            this.txtDebugInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugInformation.Location = new System.Drawing.Point(752, 88);
            this.txtDebugInformation.Multiline = true;
            this.txtDebugInformation.Name = "txtDebugInformation";
            this.txtDebugInformation.Size = new System.Drawing.Size(136, 312);
            this.txtDebugInformation.TabIndex = 7;
            // 
            // lbCurrentSelectedControl
            // 
            this.lbCurrentSelectedControl.Location = new System.Drawing.Point(384, 72);
            this.lbCurrentSelectedControl.Name = "lbCurrentSelectedControl";
            this.lbCurrentSelectedControl.Size = new System.Drawing.Size(328, 16);
            this.lbCurrentSelectedControl.TabIndex = 5;
            this.lbCurrentSelectedControl.Text = "...";
            // 
            // btSelectPreviousElement
            // 
            this.btSelectPreviousElement.Location = new System.Drawing.Point(336, 56);
            this.btSelectPreviousElement.Name = "btSelectPreviousElement";
            this.btSelectPreviousElement.Size = new System.Drawing.Size(16, 24);
            this.btSelectPreviousElement.TabIndex = 8;
            this.btSelectPreviousElement.Text = "<";
            this.btSelectPreviousElement.Click += new System.EventHandler(this.btSelectPreviousElement_Click);
            // 
            // btSelectPreviousWord
            // 
            this.btSelectPreviousWord.Location = new System.Drawing.Point(336, 24);
            this.btSelectPreviousWord.Name = "btSelectPreviousWord";
            this.btSelectPreviousWord.Size = new System.Drawing.Size(16, 24);
            this.btSelectPreviousWord.TabIndex = 8;
            this.btSelectPreviousWord.Text = "w";
            this.btSelectPreviousWord.Click += new System.EventHandler(this.btSelectPreviousWord_Click);
            // 
            // btAssignIssueID
            // 
            this.btAssignIssueID.Location = new System.Drawing.Point(376, 0);
            this.btAssignIssueID.Name = "btAssignIssueID";
            this.btAssignIssueID.Size = new System.Drawing.Size(104, 24);
            this.btAssignIssueID.TabIndex = 9;
            this.btAssignIssueID.Text = "Assign Issue ID";
            this.btAssignIssueID.Click += new System.EventHandler(this.btAssignIssueID_Click);
            // 
            // btTest2
            // 
            this.btTest2.Location = new System.Drawing.Point(706, 33);
            this.btTest2.Name = "btTest2";
            this.btTest2.Size = new System.Drawing.Size(75, 23);
            this.btTest2.TabIndex = 10;
            this.btTest2.Text = "test2";
            this.btTest2.UseVisualStyleBackColor = true;
            this.btTest2.Click += new System.EventHandler(this.btTest2_Click);
            // 
            // lbLeftShift
            // 
            this.lbLeftShift.AutoSize = true;
            this.lbLeftShift.Location = new System.Drawing.Point(466, 69);
            this.lbLeftShift.Name = "lbLeftShift";
            this.lbLeftShift.Size = new System.Drawing.Size(49, 13);
            this.lbLeftShift.TabIndex = 11;
            this.lbLeftShift.Text = "Left Shift";
            this.lbLeftShift.Visible = false;
            // 
            // lbLeftCtrl
            // 
            this.lbLeftCtrl.AutoSize = true;
            this.lbLeftCtrl.Location = new System.Drawing.Point(531, 69);
            this.lbLeftCtrl.Name = "lbLeftCtrl";
            this.lbLeftCtrl.Size = new System.Drawing.Size(43, 13);
            this.lbLeftCtrl.TabIndex = 11;
            this.lbLeftCtrl.Text = "Left Ctrl";
            this.lbLeftCtrl.Visible = false;
            // 
            // frmAuthenticTest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(896, 406);
            this.Controls.Add(this.lbLeftCtrl);
            this.Controls.Add(this.lbLeftShift);
            this.Controls.Add(this.btTest2);
            this.Controls.Add(this.btAssignIssueID);
            this.Controls.Add(this.btSelectPreviousElement);
            this.Controls.Add(this.txtDebugInformation);
            this.Controls.Add(this.btnApplyHooks);
            this.Controls.Add(this.lbKeyPressed);
            this.Controls.Add(this.lbTextChanged);
            this.Controls.Add(this.txtXmlFile);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.txtXsdFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axAuthentic1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSpsFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCurrentSelectedControl);
            this.Controls.Add(this.btSelectPreviousWord);
            this.KeyPreview = true;
            this.Name = "frmAuthenticTest";
            this.Text = "AuthenticTest";
            this.Load += new System.EventHandler(this.AuthenticTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btTest_Click(object sender, System.EventArgs e)
		{
            OrgBasePaths obp = OrgBasePaths.GetPaths();

			configVariablesForKeyboardHook();
            txtXmlFile.Text = @"Z:\ABN\ORG data\testProject\Target\finding 1.xml";
			string strPathToXmlFile = txtXmlFile.Text;
			utils.authentic.loadXmlFileInTargetAuthenticView( axAuthentic1,strPathToXmlFile,
                                                              obp.ProjectSchemaPath, 
                                                              obp.SpsFindingsPath);
			
		}

		public void configVariablesForKeyboardHook()
		{			
			if ((authUtils.CurrentKeyboardHook == null) || (!authUtils.CurrentKeyboardHook.IsInstalled)) 
				authUtils.installKeyboardHookInCurrentThread();		
			authUtils.AuthenticObject = axAuthentic1;
            authUtils.CurrentControl = (ContainerControl)this;
		}

		private void axAuthentic1_SelectionChanged(object sender, System.EventArgs e)
		{
			axAuthentic1.Select();
			AxXMLSPYPLUGINLib.AxAuthentic axAuth = (AxXMLSPYPLUGINLib.AxAuthentic)sender;
			XMLSPYPLUGINLib.AuthenticEventClass auEvent = (XMLSPYPLUGINLib.AuthenticEventClass)axAuth.@event;

            txtDebugInformation.Text = auEvent.keyCode + txtDebugInformation.Text;

            return;
		}

		private void AuthenticTest_Load(object sender, System.EventArgs e)
		{
			btTest_Click(null,null);
		}

		private void btSelectPreviousElement_Click(object sender, System.EventArgs e)
		{
    		utils.authentic.authentic_SelectPreviousTag(axAuthentic1);
		}

		private void btSelectPreviousWord_Click(object sender, System.EventArgs e)
		{
            // TODO: Find out if frmAuthenticTest.btSelectPreviousWord method is even needed.
		}

		private void assignIssueIdToFinding(XMLSPYPLUGINLib.AuthenticRange xspyElementToEdit)
		{
			object pElementNames = null;
			axAuthentic1.AuthenticView.WholeDocument.Select();
			axAuthentic1.AuthenticView.Selection.GetElementHierarchy(ref pElementNames);		
		}

		private void btAssignIssueID_Click(object sender, System.EventArgs e)
		{			
			try 
			{
				XMLSPYPLUGINLib.XMLData xdXmlData =  axAuthentic1.AuthenticView.Selection.FirstXMLData;
				while (xdXmlData.Name != "Finding")
				{
					xdXmlData = xdXmlData.Parent;
				}	
				if (xdXmlData.HasChildren)
				{
					XMLSPYPLUGINLib.XMLData xdXmlDataAttr = xdXmlData.GetFirstChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
					try
					{
						while( xdXmlDataAttr.Name != "Issue-id")
						{					
							xdXmlDataAttr = xdXmlData.GetNextChild();												
						}
						xdXmlDataAttr.TextValue="XXXX";
						return;
					}
					catch 
					{}					
					xdXmlDataAttr = axAuthentic1.CreateChild(XMLSPYPLUGINLib.SPYXMLDataKind.spyXMLDataAttr);
					xdXmlDataAttr.Name = "Issue-id";
					xdXmlDataAttr.TextValue = "YYYYY";
					xdXmlData.AppendChild(xdXmlDataAttr);		
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void btTest2_Click(object sender, EventArgs e)
        {

        }		
	}
}

