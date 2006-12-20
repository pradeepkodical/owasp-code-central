using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxPlugIns.
	/// </summary>
    public class ascxPlugIns : System.Windows.Forms.UserControl
    {
        private string strPlugInFileToLoad;
        private string strPathToLoadedPlugInXmlFolder;
        private string strPathToCurrentPluginFiles;
        private string strFullPathToXsdFile;
        private string strFullPathToXmlFile;
        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

        private string strPathToSpsFile;
        private string strPathToXsdFile;
        private string strTemplateXmlFile;
        private string strPathToXmlFiles;
        private string strActionSourceCode;
        private string[] strReferenceAssemblies;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPlugIn;
        private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_Plugin;
        private System.Windows.Forms.GroupBox gbPlugInActions;
        private System.Windows.Forms.Button btExecuteAction;
        private System.Windows.Forms.ListBox lbPlugInXmlFiles;
        private System.Windows.Forms.ComboBox cbCurrentPlugIns;
        private System.Windows.Forms.TabPage tpEditPlugIn;
        private System.Windows.Forms.Label lbUnsavedData;
        private System.Windows.Forms.Button btSavePlugIn;
        private ICSharpCode.TextEditor.TextEditorControl tecPlugIns;
        private System.Windows.Forms.TextBox txtNewPlugInName;
        private System.Windows.Forms.Button btDeletePlugIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbAvailablePlugIns;
        private System.Windows.Forms.Button btCreateNewPlugIn;
        private System.Windows.Forms.Label lbPlugInFileSaved;
        private System.Windows.Forms.Button btReloadPluginData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDebugMessages;
        private System.Windows.Forms.TextBox txtPlugInArguments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPlugInCompile;
        private TextBox txtNewPlugInFileName;
        private Button btDeletePlugInFile;
        private Button btCreatePlugInFile;
        private Label lbPlugInDataXmlBreaksXsdSchema;
        private Button btSavePlugInData;
        private Label lblPlugIndataSaved;
        private Label lbUnsavedPlugIndata;
        private ComboBox cbEditMode;
        private RichTextBox rtbPlugInData;
        private Label lbRtbCursorPosition;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ascxPlugIns()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxPlugIns));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPlugIn = new System.Windows.Forms.TabPage();
            this.lbRtbCursorPosition = new System.Windows.Forms.Label();
            this.rtbPlugInData = new System.Windows.Forms.RichTextBox();
            this.cbEditMode = new System.Windows.Forms.ComboBox();
            this.btSavePlugInData = new System.Windows.Forms.Button();
            this.lbPlugInDataXmlBreaksXsdSchema = new System.Windows.Forms.Label();
            this.txtNewPlugInFileName = new System.Windows.Forms.TextBox();
            this.btDeletePlugInFile = new System.Windows.Forms.Button();
            this.btCreatePlugInFile = new System.Windows.Forms.Button();
            this.btReloadPluginData = new System.Windows.Forms.Button();
            this.axAuthentic_Plugin = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.gbPlugInActions = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlugInArguments = new System.Windows.Forms.TextBox();
            this.btExecuteAction = new System.Windows.Forms.Button();
            this.lbPlugInXmlFiles = new System.Windows.Forms.ListBox();
            this.cbCurrentPlugIns = new System.Windows.Forms.ComboBox();
            this.lbUnsavedPlugIndata = new System.Windows.Forms.Label();
            this.lblPlugIndataSaved = new System.Windows.Forms.Label();
            this.tpEditPlugIn = new System.Windows.Forms.TabPage();
            this.btPlugInCompile = new System.Windows.Forms.Button();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            this.btSavePlugIn = new System.Windows.Forms.Button();
            this.tecPlugIns = new ICSharpCode.TextEditor.TextEditorControl();
            this.txtNewPlugInName = new System.Windows.Forms.TextBox();
            this.btDeletePlugIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAvailablePlugIns = new System.Windows.Forms.ListBox();
            this.btCreateNewPlugIn = new System.Windows.Forms.Button();
            this.lbPlugInFileSaved = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDebugMessages = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tpPlugIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Plugin)).BeginInit();
            this.gbPlugInActions.SuspendLayout();
            this.tpEditPlugIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpPlugIn);
            this.tabControl1.Controls.Add(this.tpEditPlugIn);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 360);
            this.tabControl1.TabIndex = 2;
            // 
            // tpPlugIn
            // 
            this.tpPlugIn.Controls.Add(this.lbRtbCursorPosition);
            this.tpPlugIn.Controls.Add(this.rtbPlugInData);
            this.tpPlugIn.Controls.Add(this.cbEditMode);
            this.tpPlugIn.Controls.Add(this.btSavePlugInData);
            this.tpPlugIn.Controls.Add(this.lbPlugInDataXmlBreaksXsdSchema);
            this.tpPlugIn.Controls.Add(this.txtNewPlugInFileName);
            this.tpPlugIn.Controls.Add(this.btDeletePlugInFile);
            this.tpPlugIn.Controls.Add(this.btCreatePlugInFile);
            this.tpPlugIn.Controls.Add(this.btReloadPluginData);
            this.tpPlugIn.Controls.Add(this.axAuthentic_Plugin);
            this.tpPlugIn.Controls.Add(this.gbPlugInActions);
            this.tpPlugIn.Controls.Add(this.lbPlugInXmlFiles);
            this.tpPlugIn.Controls.Add(this.cbCurrentPlugIns);
            this.tpPlugIn.Controls.Add(this.lbUnsavedPlugIndata);
            this.tpPlugIn.Controls.Add(this.lblPlugIndataSaved);
            this.tpPlugIn.Location = new System.Drawing.Point(4, 22);
            this.tpPlugIn.Name = "tpPlugIn";
            this.tpPlugIn.Size = new System.Drawing.Size(816, 334);
            this.tpPlugIn.TabIndex = 1;
            this.tpPlugIn.Text = "Plug-Ins";
            // 
            // lbRtbCursorPosition
            // 
            this.lbRtbCursorPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRtbCursorPosition.AutoSize = true;
            this.lbRtbCursorPosition.Location = new System.Drawing.Point(726, 313);
            this.lbRtbCursorPosition.Name = "lbRtbCursorPosition";
            this.lbRtbCursorPosition.Size = new System.Drawing.Size(19, 13);
            this.lbRtbCursorPosition.TabIndex = 7;
            this.lbRtbCursorPosition.Text = "....";
            this.lbRtbCursorPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtbPlugInData
            // 
            this.rtbPlugInData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPlugInData.Location = new System.Drawing.Point(200, 32);
            this.rtbPlugInData.Name = "rtbPlugInData";
            this.rtbPlugInData.Size = new System.Drawing.Size(608, 278);
            this.rtbPlugInData.TabIndex = 36;
            this.rtbPlugInData.Text = "";
            this.rtbPlugInData.SelectionChanged += new System.EventHandler(this.rtbPlugInData_SelectionChanged);
            this.rtbPlugInData.TextChanged += new System.EventHandler(this.rtbPlugInData_TextChanged);
            // 
            // cbEditMode
            // 
            this.cbEditMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditMode.Items.AddRange(new object[] {
            "Authentic",
            "Notepad"});
            this.cbEditMode.Location = new System.Drawing.Point(200, 9);
            this.cbEditMode.Name = "cbEditMode";
            this.cbEditMode.Size = new System.Drawing.Size(81, 21);
            this.cbEditMode.TabIndex = 35;
            this.cbEditMode.SelectedIndexChanged += new System.EventHandler(this.cbEditMode_SelectedIndexChanged);
            // 
            // btSavePlugInData
            // 
            this.btSavePlugInData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSavePlugInData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSavePlugInData.Location = new System.Drawing.Point(689, 6);
            this.btSavePlugInData.Name = "btSavePlugInData";
            this.btSavePlugInData.Size = new System.Drawing.Size(120, 22);
            this.btSavePlugInData.TabIndex = 26;
            this.btSavePlugInData.Text = "Save Plug-In Data";
            this.btSavePlugInData.Click += new System.EventHandler(this.btSavePlugInData_Click);
            // 
            // lbPlugInDataXmlBreaksXsdSchema
            // 
            this.lbPlugInDataXmlBreaksXsdSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlugInDataXmlBreaksXsdSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlugInDataXmlBreaksXsdSchema.ForeColor = System.Drawing.Color.Red;
            this.lbPlugInDataXmlBreaksXsdSchema.Location = new System.Drawing.Point(391, 4);
            this.lbPlugInDataXmlBreaksXsdSchema.Name = "lbPlugInDataXmlBreaksXsdSchema";
            this.lbPlugInDataXmlBreaksXsdSchema.Size = new System.Drawing.Size(168, 25);
            this.lbPlugInDataXmlBreaksXsdSchema.TabIndex = 25;
            this.lbPlugInDataXmlBreaksXsdSchema.Text = "Xml breaks XSD schema!!";
            this.lbPlugInDataXmlBreaksXsdSchema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPlugInDataXmlBreaksXsdSchema.Visible = false;
            this.lbPlugInDataXmlBreaksXsdSchema.Click += new System.EventHandler(this.lbPlugInDataXmlBreaksXsdSchema_Click);
            // 
            // txtNewPlugInFileName
            // 
            this.txtNewPlugInFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewPlugInFileName.Location = new System.Drawing.Point(8, 159);
            this.txtNewPlugInFileName.Name = "txtNewPlugInFileName";
            this.txtNewPlugInFileName.Size = new System.Drawing.Size(126, 20);
            this.txtNewPlugInFileName.TabIndex = 8;
            // 
            // btDeletePlugInFile
            // 
            this.btDeletePlugInFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeletePlugInFile.Location = new System.Drawing.Point(8, 188);
            this.btDeletePlugInFile.Name = "btDeletePlugInFile";
            this.btDeletePlugInFile.Size = new System.Drawing.Size(96, 20);
            this.btDeletePlugInFile.TabIndex = 7;
            this.btDeletePlugInFile.Text = "Delete Plug-In";
            this.btDeletePlugInFile.Click += new System.EventHandler(this.btDeletePlugInFile_Click);
            // 
            // btCreatePlugInFile
            // 
            this.btCreatePlugInFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreatePlugInFile.Location = new System.Drawing.Point(140, 159);
            this.btCreatePlugInFile.Name = "btCreatePlugInFile";
            this.btCreatePlugInFile.Size = new System.Drawing.Size(52, 49);
            this.btCreatePlugInFile.TabIndex = 6;
            this.btCreatePlugInFile.Text = "Create";
            this.btCreatePlugInFile.Click += new System.EventHandler(this.btCreatePlugInFile_Click);
            // 
            // btReloadPluginData
            // 
            this.btReloadPluginData.Location = new System.Drawing.Point(172, 8);
            this.btReloadPluginData.Name = "btReloadPluginData";
            this.btReloadPluginData.Size = new System.Drawing.Size(20, 20);
            this.btReloadPluginData.TabIndex = 4;
            this.btReloadPluginData.Text = "R";
            this.btReloadPluginData.Click += new System.EventHandler(this.btReloadPluginData_Click);
            // 
            // axAuthentic_Plugin
            // 
            this.axAuthentic_Plugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_Plugin.Enabled = true;
            this.axAuthentic_Plugin.Location = new System.Drawing.Point(200, 32);
            this.axAuthentic_Plugin.Name = "axAuthentic_Plugin";
            this.axAuthentic_Plugin.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_Plugin.OcxState")));
            this.axAuthentic_Plugin.Size = new System.Drawing.Size(608, 296);
            this.axAuthentic_Plugin.TabIndex = 3;
            this.axAuthentic_Plugin.SelectionChanged += new System.EventHandler(this.axAuthentic_Plugin_SelectionChanged);
            // 
            // gbPlugInActions
            // 
            this.gbPlugInActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPlugInActions.Controls.Add(this.label4);
            this.gbPlugInActions.Controls.Add(this.txtPlugInArguments);
            this.gbPlugInActions.Controls.Add(this.btExecuteAction);
            this.gbPlugInActions.Location = new System.Drawing.Point(8, 214);
            this.gbPlugInActions.Name = "gbPlugInActions";
            this.gbPlugInActions.Size = new System.Drawing.Size(184, 114);
            this.gbPlugInActions.TabIndex = 2;
            this.gbPlugInActions.TabStop = false;
            this.gbPlugInActions.Text = "Actions";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Plug-in Arguments";
            // 
            // txtPlugInArguments
            // 
            this.txtPlugInArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlugInArguments.Location = new System.Drawing.Point(8, 65);
            this.txtPlugInArguments.Multiline = true;
            this.txtPlugInArguments.Name = "txtPlugInArguments";
            this.txtPlugInArguments.Size = new System.Drawing.Size(168, 41);
            this.txtPlugInArguments.TabIndex = 1;
            // 
            // btExecuteAction
            // 
            this.btExecuteAction.Location = new System.Drawing.Point(9, 19);
            this.btExecuteAction.Name = "btExecuteAction";
            this.btExecuteAction.Size = new System.Drawing.Size(168, 24);
            this.btExecuteAction.TabIndex = 0;
            this.btExecuteAction.Text = "Execute Action";
            this.btExecuteAction.Click += new System.EventHandler(this.btExecuteAction_Click);
            // 
            // lbPlugInXmlFiles
            // 
            this.lbPlugInXmlFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPlugInXmlFiles.Location = new System.Drawing.Point(8, 32);
            this.lbPlugInXmlFiles.Name = "lbPlugInXmlFiles";
            this.lbPlugInXmlFiles.Size = new System.Drawing.Size(184, 121);
            this.lbPlugInXmlFiles.TabIndex = 1;
            this.lbPlugInXmlFiles.SelectedIndexChanged += new System.EventHandler(this.lbPlugInXmlFiles_SelectedIndexChanged);
            // 
            // cbCurrentPlugIns
            // 
            this.cbCurrentPlugIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrentPlugIns.Location = new System.Drawing.Point(8, 8);
            this.cbCurrentPlugIns.Name = "cbCurrentPlugIns";
            this.cbCurrentPlugIns.Size = new System.Drawing.Size(160, 21);
            this.cbCurrentPlugIns.TabIndex = 0;
            this.cbCurrentPlugIns.SelectedIndexChanged += new System.EventHandler(this.cbCurrentPlugIns_SelectedIndexChanged);
            // 
            // lbUnsavedPlugIndata
            // 
            this.lbUnsavedPlugIndata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedPlugIndata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedPlugIndata.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedPlugIndata.Location = new System.Drawing.Point(571, 5);
            this.lbUnsavedPlugIndata.Name = "lbUnsavedPlugIndata";
            this.lbUnsavedPlugIndata.Size = new System.Drawing.Size(107, 21);
            this.lbUnsavedPlugIndata.TabIndex = 28;
            this.lbUnsavedPlugIndata.Text = "Unsaved Data";
            this.lbUnsavedPlugIndata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedPlugIndata.Visible = false;
            // 
            // lblPlugIndataSaved
            // 
            this.lblPlugIndataSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlugIndataSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlugIndataSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPlugIndataSaved.Location = new System.Drawing.Point(565, 5);
            this.lblPlugIndataSaved.Name = "lblPlugIndataSaved";
            this.lblPlugIndataSaved.Size = new System.Drawing.Size(120, 20);
            this.lblPlugIndataSaved.TabIndex = 27;
            this.lblPlugIndataSaved.Text = "Plug-in data Saved";
            this.lblPlugIndataSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlugIndataSaved.Visible = false;
            // 
            // tpEditPlugIn
            // 
            this.tpEditPlugIn.Controls.Add(this.btPlugInCompile);
            this.tpEditPlugIn.Controls.Add(this.lbUnsavedData);
            this.tpEditPlugIn.Controls.Add(this.btSavePlugIn);
            this.tpEditPlugIn.Controls.Add(this.tecPlugIns);
            this.tpEditPlugIn.Controls.Add(this.txtNewPlugInName);
            this.tpEditPlugIn.Controls.Add(this.btDeletePlugIn);
            this.tpEditPlugIn.Controls.Add(this.label2);
            this.tpEditPlugIn.Controls.Add(this.lbAvailablePlugIns);
            this.tpEditPlugIn.Controls.Add(this.btCreateNewPlugIn);
            this.tpEditPlugIn.Controls.Add(this.lbPlugInFileSaved);
            this.tpEditPlugIn.Location = new System.Drawing.Point(4, 22);
            this.tpEditPlugIn.Name = "tpEditPlugIn";
            this.tpEditPlugIn.Size = new System.Drawing.Size(816, 334);
            this.tpEditPlugIn.TabIndex = 0;
            this.tpEditPlugIn.Text = "Edit Plug-In";
            this.tpEditPlugIn.Visible = false;
            // 
            // btPlugInCompile
            // 
            this.btPlugInCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPlugInCompile.Location = new System.Drawing.Point(664, 304);
            this.btPlugInCompile.Name = "btPlugInCompile";
            this.btPlugInCompile.Size = new System.Drawing.Size(144, 24);
            this.btPlugInCompile.TabIndex = 29;
            this.btPlugInCompile.Text = "Save and Compile";
            this.btPlugInCompile.Click += new System.EventHandler(this.btPlugInCompile_Click);
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(592, 5);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(112, 24);
            this.lbUnsavedData.TabIndex = 27;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // btSavePlugIn
            // 
            this.btSavePlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSavePlugIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSavePlugIn.Location = new System.Drawing.Point(712, 4);
            this.btSavePlugIn.Name = "btSavePlugIn";
            this.btSavePlugIn.Size = new System.Drawing.Size(96, 24);
            this.btSavePlugIn.TabIndex = 26;
            this.btSavePlugIn.Text = "Save Plug-In ";
            this.btSavePlugIn.Click += new System.EventHandler(this.btSavePlugIn_Click);
            // 
            // tecPlugIns
            // 
            this.tecPlugIns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tecPlugIns.Location = new System.Drawing.Point(160, 32);
            this.tecPlugIns.Name = "tecPlugIns";
            this.tecPlugIns.ShowEOLMarkers = true;
            this.tecPlugIns.ShowSpaces = true;
            this.tecPlugIns.ShowTabs = true;
            this.tecPlugIns.ShowVRuler = true;
            this.tecPlugIns.Size = new System.Drawing.Size(648, 264);
            this.tecPlugIns.TabIndex = 4;
            this.tecPlugIns.Enter += new System.EventHandler(this.tecPlugIns_Enter);
            this.tecPlugIns.Load += new System.EventHandler(this.tecPlugIns_Load);
            // 
            // txtNewPlugInName
            // 
            this.txtNewPlugInName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewPlugInName.Location = new System.Drawing.Point(8, 275);
            this.txtNewPlugInName.Name = "txtNewPlugInName";
            this.txtNewPlugInName.Size = new System.Drawing.Size(72, 20);
            this.txtNewPlugInName.TabIndex = 3;
            // 
            // btDeletePlugIn
            // 
            this.btDeletePlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeletePlugIn.Location = new System.Drawing.Point(8, 304);
            this.btDeletePlugIn.Name = "btDeletePlugIn";
            this.btDeletePlugIn.Size = new System.Drawing.Size(136, 24);
            this.btDeletePlugIn.TabIndex = 2;
            this.btDeletePlugIn.Text = "Delete Plug-In";
            this.btDeletePlugIn.Click += new System.EventHandler(this.btDeletePlugIn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Available Plug-Ins";
            // 
            // lbAvailablePlugIns
            // 
            this.lbAvailablePlugIns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAvailablePlugIns.Location = new System.Drawing.Point(8, 32);
            this.lbAvailablePlugIns.Name = "lbAvailablePlugIns";
            this.lbAvailablePlugIns.Size = new System.Drawing.Size(136, 225);
            this.lbAvailablePlugIns.TabIndex = 0;
            this.lbAvailablePlugIns.SelectedIndexChanged += new System.EventHandler(this.lbAvailablePlugIns_SelectedIndexChanged);
            // 
            // btCreateNewPlugIn
            // 
            this.btCreateNewPlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateNewPlugIn.Location = new System.Drawing.Point(88, 275);
            this.btCreateNewPlugIn.Name = "btCreateNewPlugIn";
            this.btCreateNewPlugIn.Size = new System.Drawing.Size(56, 20);
            this.btCreateNewPlugIn.TabIndex = 2;
            this.btCreateNewPlugIn.Text = "Create";
            this.btCreateNewPlugIn.Click += new System.EventHandler(this.btCreateNewPlugIn_Click);
            // 
            // lbPlugInFileSaved
            // 
            this.lbPlugInFileSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlugInFileSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlugInFileSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbPlugInFileSaved.Location = new System.Drawing.Point(576, 6);
            this.lbPlugInFileSaved.Name = "lbPlugInFileSaved";
            this.lbPlugInFileSaved.Size = new System.Drawing.Size(136, 24);
            this.lbPlugInFileSaved.TabIndex = 28;
            this.lbPlugInFileSaved.Text = "Plug-In file saved";
            this.lbPlugInFileSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPlugInFileSaved.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(16, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Debug Messages";
            // 
            // txtDebugMessages
            // 
            this.txtDebugMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugMessages.Location = new System.Drawing.Point(16, 392);
            this.txtDebugMessages.Multiline = true;
            this.txtDebugMessages.Name = "txtDebugMessages";
            this.txtDebugMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebugMessages.Size = new System.Drawing.Size(816, 104);
            this.txtDebugMessages.TabIndex = 6;
            // 
            // ascxPlugIns
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDebugMessages);
            this.Controls.Add(this.label3);
            this.Name = "ascxPlugIns";
            this.Size = new System.Drawing.Size(840, 504);
            this.Load += new System.EventHandler(this.ascxPlugIns_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPlugIn.ResumeLayout(false);
            this.tpPlugIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Plugin)).EndInit();
            this.gbPlugInActions.ResumeLayout(false);
            this.gbPlugInActions.PerformLayout();
            this.tpEditPlugIn.ResumeLayout(false);
            this.tpEditPlugIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private void btCreateNewPlugIn_Click(object sender, System.EventArgs e)
        {
            if (txtNewPlugInName.Text == "")
            {
                MessageBox.Show("You must type a name for the new Plug-In");
                return;
            }
            string strPluginDirectory = Path.Combine(obpPaths.PluginsPath, txtNewPlugInName.Text);
            string strPluginXmlDirectory = Path.Combine(strPluginDirectory, "xml");
            string strPluginFilenameXML = Path.Combine(strPluginDirectory, txtNewPlugInName.Text + ".xml");
            if (false == Directory.Exists(strPluginDirectory))
            {
                Directory.CreateDirectory(strPluginDirectory);
                Directory.CreateDirectory(strPluginXmlDirectory);
                if (false == File.Exists(strPluginFilenameXML))
                {
                    FileStream fsNewPlugInFile = File.Create(strPluginFilenameXML);
                    fsNewPlugInFile.Close();
                    LoadPlugInsIntoListAndComboBoxes();
                    utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Created Plug-in template: " + txtNewPlugInName.Text);
                }
                else
                    MessageBox.Show("Plug-In File Already exist");
            }
            else
                MessageBox.Show("Plug-In Directory Already exist");
        }

        private void LoadPlugInsIntoListAndComboBoxes()
        {
            if (-1 == cbEditMode.SelectedIndex)
                cbEditMode.SelectedIndex = 0; // make it 0 by default
            if (false == Directory.Exists(obpPaths.PluginsPath))
            {
                Directory.CreateDirectory(obpPaths.PluginsPath);
                return;
            }
            strPlugInFileToLoad = "";
            utils.windowsForms.loadDirectoriesIntoListBox(lbAvailablePlugIns, obpPaths.PluginsPath, "*");
            utils.windowsForms.loadDirectoriesIntoComboBox(cbCurrentPlugIns, obpPaths.PluginsPath, "*");
        }


        private void LoadPlugInXmlFiles()
        {
            strPathToCurrentPluginFiles = Path.Combine(obpPaths.PluginsPath, cbCurrentPlugIns.Text);
            strPathToLoadedPlugInXmlFolder = Path.Combine(strPathToCurrentPluginFiles, strPathToXmlFiles);
            utils.windowsForms.loadFilesIntoListBox(lbPlugInXmlFiles, strPathToLoadedPlugInXmlFolder, "*.xml");
            if (lbPlugInXmlFiles.Items.Count > 0)
            {
                lbPlugInXmlFiles.SelectedIndex = 0;
                axAuthentic_Plugin.Visible = true;
            }
            else
            {
                axAuthentic_Plugin.Visible = false;
            }
        }

        private void lbAvailablePlugIns_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            strPlugInFileToLoad = Path.Combine(obpPaths.PluginsPath, lbAvailablePlugIns.Text + "\\" + lbAvailablePlugIns.Text + ".xml"); // we expect to find the project file as an xml file with the same name as the selected directory
            tecPlugIns.LoadFile(strPlugInFileToLoad);
            utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Loaded Plug-in template: " + lbAvailablePlugIns.Text);
        }

        private void btSavePlugIn_Click(object sender, System.EventArgs e)
        {
            tecPlugIns.SaveFile(strPlugInFileToLoad);
            lbPlugInFileSaved.Visible = true;
            lbUnsavedData.Visible = false;
        }


        private void tecPlugIns_Enter(object sender, System.EventArgs e)
        {
            lbPlugInFileSaved.Visible = false;
        }

        // this is not working must find which one is the correct one to detect when a change has occured
        //		private void tecPlugIns_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        //		{
        //			MessageBox.Show("Keyup");
        //				lbUnsavedData.Visible = true;
        //		}

        private void Document_DocumentChanged(object sender, ICSharpCode.TextEditor.Document.DocumentEventArgs e)
        {
            lbUnsavedData.Visible = true;
        }

        private void btDeletePlugIn_Click(object sender, System.EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the Plug-In '" + lbAvailablePlugIns.Text + "' ?", "", MessageBoxButtons.YesNo))
            {
                string asd = Path.GetDirectoryName(strPlugInFileToLoad);
                Directory.Delete(Path.GetDirectoryName(strPlugInFileToLoad), true);
                LoadPlugInsIntoListAndComboBoxes();
            }
        }

        private void cbCurrentPlugIns_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            loadXmlFileAndPopulateVars();
            LoadPlugInXmlFiles();
        }

        private void loadXmlFileAndPopulateVars()
        {
            try
            {
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Loading Xml file and populating internal vars (from" + cbCurrentPlugIns.Text + ")");
                string strFullPathToPlugInXmlFileToLoad = Path.Combine(obpPaths.PluginsPath, cbCurrentPlugIns.Text + "\\" + cbCurrentPlugIns.Text + ".xml");
                XmlDocument xdPlugInXmlFile = new XmlDocument();
                xdPlugInXmlFile.Load(strFullPathToPlugInXmlFileToLoad);
                XmlNodeList xnlPlugIns = xdPlugInXmlFile.GetElementsByTagName("PlugIn");
                if (xnlPlugIns.Count > 1)
                    MessageBox.Show("Note: there are more than one Plug-In in this Plug-ins File. Only the first one will be processed");
                if (xnlPlugIns.Count == 0)
                {
                    MessageBox.Show("There are NO (i.e. zero) Plug-In in this Plug-ins File");
                    return;
                }
                XmlNode xnPlugIn = xnlPlugIns[0];
                strPathToXmlFiles = xnPlugIn.Attributes.GetNamedItem("pathToXmlFiles").InnerText;
                strPathToSpsFile = xnPlugIn.Attributes.GetNamedItem("pathToSpsFile").InnerText;
                strPathToXsdFile = xnPlugIn.Attributes.GetNamedItem("pathToXsdFile").InnerText;
                strTemplateXmlFile = xnPlugIn.Attributes.GetNamedItem("templateXmlFile").InnerText;
                if ("" != strTemplateXmlFile)
                {
                    strTemplateXmlFile = Path.Combine(obpPaths.PluginsPath, cbCurrentPlugIns.Text + "\\" + strTemplateXmlFile);
                    txtNewPlugInFileName.Enabled = true;
                    btCreatePlugInFile.Enabled = true;
                }
                else
                {
                    txtNewPlugInFileName.Enabled = false;
                    btCreatePlugInFile.Enabled = false;
                }
                //resolve reference assemblies
                strReferenceAssemblies = getStringArrayOfReferenceAssembliesToLoad(Path.GetDirectoryName(strFullPathToPlugInXmlFileToLoad), xnPlugIn.Attributes.GetNamedItem("referenceAssemblies"), xnPlugIn.Attributes.GetNamedItem("referencePlugInAssemblies"));
                /*
                                XmlNode xnReferenceAssemblies = xnPlugIn.Attributes.GetNamedItem("referenceAssemblies");
                                if (null != xnReferenceAssemblies)
                                    strReferenceAssemblies = xnReferenceAssemblies.InnerText.Split(',');
                 * */
                if (xnPlugIn.ChildNodes.Count > 0)
                    strActionSourceCode = xnPlugIn.ChildNodes[0].InnerText;
                else
                    MessageBox.Show("There are no actions in this XML file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loadXmlFileAndPopulateVars:" + ex.Message);
            }
        }

        private void getSourceCodeFromXmlFile(string strXmlFileToProcess, ref string strSourceCode, ref string[] strReferenceAssemblies)
        {
            try
            {
                XmlDocument xdPlugInXmlFile = new XmlDocument();
                xdPlugInXmlFile.Load(strXmlFileToProcess);
                XmlNodeList xnlPlugIns = xdPlugInXmlFile.GetElementsByTagName("PlugIn");
                if (xnlPlugIns.Count > 1)
                    MessageBox.Show("Note: there are more than one Plug-In in this Plug-ins File. Only the first one will be processed");
                if (xnlPlugIns.Count == 0)
                {
                    MessageBox.Show("There are NO (i.e. zero) Plug-In in this Plug-ins File");
                    return;
                }
                XmlNode xnPlugIn = xnlPlugIns[0];

                //resolve reference assemblies
                strReferenceAssemblies = getStringArrayOfReferenceAssembliesToLoad(Path.GetDirectoryName(strPlugInFileToLoad), xnPlugIn.Attributes.GetNamedItem("referenceAssemblies"), xnPlugIn.Attributes.GetNamedItem("referencePlugInAssemblies"));

                if (xnPlugIn.ChildNodes.Count > 0)
                    strSourceCode = xnPlugIn.ChildNodes[0].InnerText;
                else
                    MessageBox.Show("There are no actions in this XML file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getSourceCodeFromXmlFile:" + ex.Message);
            }
        }

        private void lbPlugInXmlFiles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lbPlugInXmlFiles.SelectedIndex > -1)
            {
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Loading Plug-in: " + lbPlugInXmlFiles.Text);
                this.strFullPathToXmlFile = Path.Combine(strPathToLoadedPlugInXmlFolder, lbPlugInXmlFiles.Text);
                string strFullPathToSPSFile = Path.Combine(strPathToCurrentPluginFiles, strPathToSpsFile);
                this.strFullPathToXsdFile = Path.Combine(strPathToCurrentPluginFiles, strPathToXsdFile);

                switch (cbEditMode.Text)
                {
                    case "Authentic":
                        axAuthentic_Plugin.Visible = true;
                        rtbPlugInData.Visible = false;
                        lbRtbCursorPosition.Visible = false;
                        utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_Plugin,
                                                                         strFullPathToXmlFile,
                                                                         strFullPathToXsdFile,
                                                                         strFullPathToSPSFile);
                        break;
                    case "Notepad":
                        axAuthentic_Plugin.Visible = false;
                        rtbPlugInData.Visible = true;
                        lbRtbCursorPosition.Visible = true;
                        rtbPlugInData.Text = utils.files.GetFileContents(strFullPathToXmlFile);
                        break;
                    default:
                        MessageBox.Show("Unrecognized Edit Mode");
                        break;
                }
                lbUnsavedPlugIndata.Visible = false;
                txtPlugInArguments.Text = strFullPathToXmlFile;
                if (false == axAuthentic_Plugin.Visible) // which will only happen if there was a problem loading the XML file
                    utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, string.Format("Could not file files to load. Make sure that the SPS, XML and XSD are all there"));
                try
                {
                    // Verify file against schema but don't show MessageBox
                    new utils.xml.xsdVerification(this.strFullPathToXmlFile, this.strFullPathToXsdFile, lbPlugInDataXmlBreaksXsdSchema, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error in xsdVerification: {0}", ex.Message));
                }
            }

        }

        private void btExecuteAction_Click(object sender, System.EventArgs e)
        {
            utils.scriptHost.compileAndExecuteSourceCode(strActionSourceCode, txtPlugInArguments.Text, strReferenceAssemblies);
        }

        private void ascxPlugIns_Load(object sender, System.EventArgs e)
        {
            if (!this.DesignMode)
            {
                LoadPlugInsIntoListAndComboBoxes();

                // add this here to avoid being automatically deleted 
                this.tecPlugIns.Document.DocumentChanged += new ICSharpCode.TextEditor.Document.DocumentEventHandler(Document_DocumentChanged);
            }
        }

        private void tecPlugIns_Load(object sender, System.EventArgs e)
        {

        }

        private void btReloadPluginData_Click(object sender, System.EventArgs e)
        {
            loadXmlFileAndPopulateVars();
        }

        private void btPlugInCompile_Click(object sender, System.EventArgs e)
        {
            utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "------------------------------");
            utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Saving file: " + strPlugInFileToLoad);
            btSavePlugIn_Click(null, null);
            utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Starting Compilation");

            string[] strReferenceAssembliesToAdd = new string[0];
            string strPlugInSourceCode = "";
            getSourceCodeFromXmlFile(strPlugInFileToLoad, ref strPlugInSourceCode, ref strReferenceAssembliesToAdd);
            utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, utils.scriptHost.compileSourceCode(strPlugInSourceCode, strReferenceAssembliesToAdd, strPathToCurrentPluginFiles));
        }

        private void btCreatePlugInFile_Click(object sender, EventArgs e)
        {
            if ("" != strTemplateXmlFile)
            {
                string strNewPlugInFile = Path.Combine(strPathToLoadedPlugInXmlFolder, txtNewPlugInFileName.Text + ".xml");
                if (false == File.Exists(strNewPlugInFile))
                {
                    File.Copy(strTemplateXmlFile, strNewPlugInFile);
                    LoadPlugInXmlFiles();
                }
                else
                {
                    MessageBox.Show(string.Format("Error: File '{0}' already exists", strNewPlugInFile));
                }

            }
            else
                MessageBox.Show("Sorry, this plug-in template does not have a 'Template Xml File' assigned to it");
        }

        private void btDeletePlugInFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the Plug-In File '" + lbPlugInXmlFiles.Text + "' ?", "", MessageBoxButtons.YesNo))
            {
                string strFileToDelete = Path.Combine(strPathToLoadedPlugInXmlFolder, lbPlugInXmlFiles.Text);
                File.Delete(strFileToDelete);
                LoadPlugInXmlFiles();
            }
        }

        /// <summary>
        /// Resolve list of assemblies to load as references
        /// </summary>
        /// <param name="xnReferenceAssemblies">These assemblies will be loaded from the local Plug-in Directory; </param>
        /// <param name="xnReferencePluginAssemblies">These assemblys will be loaded from the current .Net Framework folder or from the GAC</param>
        /// <returns></returns>       
        private string[] getStringArrayOfReferenceAssembliesToLoad(string strLocalPluginDirectory, XmlNode xnReferenceAssemblies, XmlNode xnReferencePluginAssemblies)
        {
            List<string> lstrTmpListOfReferenceAssemblies = new List<string>();
            if (null != xnReferenceAssemblies)
                lstrTmpListOfReferenceAssemblies.AddRange(xnReferenceAssemblies.InnerText.Split(','));

            if (null != xnReferencePluginAssemblies)
            {
                string[] strTmpReferencesPlugInAssemblies = xnReferencePluginAssemblies.InnerText.Split(',');
                foreach (string strTmpReferencePlugInAssembly in strTmpReferencesPlugInAssemblies)
                {
                    string strPathToReferencePlugInAssemblyToLoad = Path.Combine(strLocalPluginDirectory, strTmpReferencePlugInAssembly);
                    if (true == File.Exists(strPathToReferencePlugInAssemblyToLoad))
                    {
                        lstrTmpListOfReferenceAssemblies.Add(strPathToReferencePlugInAssemblyToLoad);
                    }
                    else
                        utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, string.Format("Could not load Internal Plug-in Reference: {0}", strPathToReferencePlugInAssemblyToLoad));

                }
            }
            return lstrTmpListOfReferenceAssemblies.ToArray(); // return the generic string List converted to a String array 
        }

        private void btSavePlugInData_Click(object sender, EventArgs e)
        {
            // Since we are editing the XML file Directory one only needs to invoke the Authentic Save method or the RtB contents
            switch (cbEditMode.Text)
            {
                case "Authentic":
                    axAuthentic_Plugin.Save();
                    break;
                case "Notepad":
                    utils.files.SaveFileWithStringContents(this.strFullPathToXmlFile, rtbPlugInData.Text);
                    break;
                default:
                    MessageBox.Show("Unrecognized Edit Mode");
                    break;
            }

            lblPlugIndataSaved.Visible = true;
            lbUnsavedPlugIndata.Visible = false;
            // Verify file against schema and show a MessageBox with any errors
            new utils.xml.xsdVerification(this.strFullPathToXmlFile, this.strFullPathToXsdFile, lbPlugInDataXmlBreaksXsdSchema, true);
        }

        private void lbPlugInDataXmlBreaksXsdSchema_Click(object sender, EventArgs e)
        {
            // Verify file against schema and show a MessageBox with any errors
            new utils.xml.xsdVerification(this.strFullPathToXmlFile, this.strFullPathToXsdFile, lbPlugInDataXmlBreaksXsdSchema, true);
        }

        private void axAuthentic_Plugin_SelectionChanged(object sender, EventArgs e)
        {
            axAuthentic_Plugin.Select();
            lblPlugIndataSaved.Visible = false;
            if (axAuthentic_Plugin.Modified)
                lbUnsavedPlugIndata.Visible = true;
        }

        private void cbEditMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbPlugInXmlFiles_SelectedIndexChanged(null, null);
        }

        private void rtbPlugInData_TextChanged(object sender, EventArgs e)
        {
            lblPlugIndataSaved.Visible = false;
            lbUnsavedPlugIndata.Visible = true;            
        }

        private void rtbPlugInData_SelectionChanged(object sender, EventArgs e)
        {
            int iRowIndex = 0, iColIndex = 0;
            utils.windowsForms.getRowAndColFromRichTextBox(rtbPlugInData, ref iRowIndex, ref iColIndex);
            lbRtbCursorPosition.Text = string.Format("Row:{0} \t Col:{1}",iRowIndex, iColIndex);            
        }

    }

	public class PlugIn
	{
        /// TODO: Need to figure out what this was supposed to do.
	}	
}
