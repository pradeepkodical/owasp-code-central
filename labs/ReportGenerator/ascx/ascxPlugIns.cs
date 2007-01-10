using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using ICSharpCode.TextEditor.Document;
using System.CodeDom.Compiler;
using System.Reflection;

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
        private CompilerResults crSelectedPluginAction_CompilerResults;

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
        private ICSharpCode.TextEditor.TextEditorControl tecPlugIns_Action;
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
        private Label lbPhraseNotFound;
        private Label lbFind;
        private TextBox txtTextToFind;
        private Button btFindText;
        private GroupBox groupBox1;
        private Button btCompilePlugIn;
        private Button btPlugInRunSelectecAction;
        private ComboBox cbPlugin_Actions;
        private CheckBox cboxPlugRunParam_DebugTextBox;
        private CheckBox cboxPlugRunParam_SelectedXmlFile;
        private CheckBox cboxPlugRunParam_TextBox;
        private CheckBox cboxPlugRunParam_WebBrowser;
        private TabControl tcPluginsDataAndExecution;
        private TabPage tpPluginExecutionOutput_TextBoxAndWebBrowser;
        private TabPage tpPlugIndata;
        private Label label5;
        private Label label1;
        private WebBrowser wbPluginExecution_OutputWebBrowser;
        private TextBox tbPluginExecution_OutputTextBox;
        private Label label7;
        private Label label6;
        private DataGridView dgvPluginSettings;
        private DataGridViewTextBoxColumn cName;
        private DataGridViewTextBoxColumn cValue;
        private TabPage tpPluginExecutionOutput_DataGrid;
        private CheckBox cboxPlugRunParam_DataGrid;
        private DataGridView dgvOutputDataGridView;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPlugIn = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCreatePlugInFile = new System.Windows.Forms.Button();
            this.btDeletePlugInFile = new System.Windows.Forms.Button();
            this.txtNewPlugInFileName = new System.Windows.Forms.TextBox();
            this.btReloadPluginData = new System.Windows.Forms.Button();
            this.gbPlugInActions = new System.Windows.Forms.GroupBox();
            this.cboxPlugRunParam_DebugTextBox = new System.Windows.Forms.CheckBox();
            this.cboxPlugRunParam_TextBox = new System.Windows.Forms.CheckBox();
            this.cboxPlugRunParam_WebBrowser = new System.Windows.Forms.CheckBox();
            this.cboxPlugRunParam_SelectedXmlFile = new System.Windows.Forms.CheckBox();
            this.btPlugInRunSelectecAction = new System.Windows.Forms.Button();
            this.cbPlugin_Actions = new System.Windows.Forms.ComboBox();
            this.btCompilePlugIn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlugInArguments = new System.Windows.Forms.TextBox();
            this.btExecuteAction = new System.Windows.Forms.Button();
            this.lbPlugInXmlFiles = new System.Windows.Forms.ListBox();
            this.cbCurrentPlugIns = new System.Windows.Forms.ComboBox();
            this.tcPluginsDataAndExecution = new System.Windows.Forms.TabControl();
            this.tpPlugIndata = new System.Windows.Forms.TabPage();
            this.axAuthentic_Plugin = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.rtbPlugInData = new System.Windows.Forms.RichTextBox();
            this.lbRtbCursorPosition = new System.Windows.Forms.Label();
            this.lbUnsavedPlugIndata = new System.Windows.Forms.Label();
            this.cbEditMode = new System.Windows.Forms.ComboBox();
            this.lblPlugIndataSaved = new System.Windows.Forms.Label();
            this.lbPlugInDataXmlBreaksXsdSchema = new System.Windows.Forms.Label();
            this.btSavePlugInData = new System.Windows.Forms.Button();
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wbPluginExecution_OutputWebBrowser = new System.Windows.Forms.WebBrowser();
            this.tbPluginExecution_OutputTextBox = new System.Windows.Forms.TextBox();
            this.tpEditPlugIn = new System.Windows.Forms.TabPage();
            this.dgvPluginSettings = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPhraseNotFound = new System.Windows.Forms.Label();
            this.lbFind = new System.Windows.Forms.Label();
            this.txtTextToFind = new System.Windows.Forms.TextBox();
            this.btFindText = new System.Windows.Forms.Button();
            this.btPlugInCompile = new System.Windows.Forms.Button();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            this.btSavePlugIn = new System.Windows.Forms.Button();
            this.tecPlugIns_Action = new ICSharpCode.TextEditor.TextEditorControl();
            this.txtNewPlugInName = new System.Windows.Forms.TextBox();
            this.btDeletePlugIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAvailablePlugIns = new System.Windows.Forms.ListBox();
            this.btCreateNewPlugIn = new System.Windows.Forms.Button();
            this.lbPlugInFileSaved = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDebugMessages = new System.Windows.Forms.TextBox();
            this.tpPluginExecutionOutput_DataGrid = new System.Windows.Forms.TabPage();
            this.dgvOutputDataGridView = new System.Windows.Forms.DataGridView();
            this.cboxPlugRunParam_DataGrid = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tpPlugIn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPlugInActions.SuspendLayout();
            this.tcPluginsDataAndExecution.SuspendLayout();
            this.tpPlugIndata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Plugin)).BeginInit();
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.SuspendLayout();
            this.tpEditPlugIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPluginSettings)).BeginInit();
            this.tpPluginExecutionOutput_DataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputDataGridView)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(731, 426);
            this.tabControl1.TabIndex = 2;
            // 
            // tpPlugIn
            // 
            this.tpPlugIn.Controls.Add(this.splitContainer1);
            this.tpPlugIn.Location = new System.Drawing.Point(4, 22);
            this.tpPlugIn.Name = "tpPlugIn";
            this.tpPlugIn.Size = new System.Drawing.Size(723, 400);
            this.tpPlugIn.TabIndex = 1;
            this.tpPlugIn.Text = "Plug-Ins";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btCreatePlugInFile);
            this.groupBox1.Controls.Add(this.btDeletePlugInFile);
            this.groupBox1.Controls.Add(this.txtNewPlugInFileName);
            this.groupBox1.Location = new System.Drawing.Point(7, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 58);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // btCreatePlugInFile
            // 
            this.btCreatePlugInFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreatePlugInFile.Location = new System.Drawing.Point(137, 12);
            this.btCreatePlugInFile.Name = "btCreatePlugInFile";
            this.btCreatePlugInFile.Size = new System.Drawing.Size(50, 42);
            this.btCreatePlugInFile.TabIndex = 6;
            this.btCreatePlugInFile.Text = "Create";
            this.btCreatePlugInFile.Click += new System.EventHandler(this.btCreatePlugInFile_Click);
            // 
            // btDeletePlugInFile
            // 
            this.btDeletePlugInFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeletePlugInFile.Location = new System.Drawing.Point(3, 34);
            this.btDeletePlugInFile.Name = "btDeletePlugInFile";
            this.btDeletePlugInFile.Size = new System.Drawing.Size(103, 20);
            this.btDeletePlugInFile.TabIndex = 7;
            this.btDeletePlugInFile.Text = "Delete Plug-In";
            this.btDeletePlugInFile.Click += new System.EventHandler(this.btDeletePlugInFile_Click);
            // 
            // txtNewPlugInFileName
            // 
            this.txtNewPlugInFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPlugInFileName.Location = new System.Drawing.Point(3, 12);
            this.txtNewPlugInFileName.Name = "txtNewPlugInFileName";
            this.txtNewPlugInFileName.Size = new System.Drawing.Size(115, 20);
            this.txtNewPlugInFileName.TabIndex = 8;
            // 
            // btReloadPluginData
            // 
            this.btReloadPluginData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReloadPluginData.Location = new System.Drawing.Point(160, 4);
            this.btReloadPluginData.Name = "btReloadPluginData";
            this.btReloadPluginData.Size = new System.Drawing.Size(39, 20);
            this.btReloadPluginData.TabIndex = 4;
            this.btReloadPluginData.Text = "R";
            this.btReloadPluginData.Click += new System.EventHandler(this.btReloadPluginData_Click);
            // 
            // gbPlugInActions
            // 
            this.gbPlugInActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPlugInActions.Controls.Add(this.cboxPlugRunParam_DebugTextBox);
            this.gbPlugInActions.Controls.Add(this.cboxPlugRunParam_DataGrid);
            this.gbPlugInActions.Controls.Add(this.cboxPlugRunParam_TextBox);
            this.gbPlugInActions.Controls.Add(this.cboxPlugRunParam_WebBrowser);
            this.gbPlugInActions.Controls.Add(this.cboxPlugRunParam_SelectedXmlFile);
            this.gbPlugInActions.Controls.Add(this.btPlugInRunSelectecAction);
            this.gbPlugInActions.Controls.Add(this.cbPlugin_Actions);
            this.gbPlugInActions.Controls.Add(this.btCompilePlugIn);
            this.gbPlugInActions.Controls.Add(this.label4);
            this.gbPlugInActions.Location = new System.Drawing.Point(6, 7);
            this.gbPlugInActions.Name = "gbPlugInActions";
            this.gbPlugInActions.Size = new System.Drawing.Size(192, 169);
            this.gbPlugInActions.TabIndex = 2;
            this.gbPlugInActions.TabStop = false;
            this.gbPlugInActions.Text = "Actions";
            // 
            // cboxPlugRunParam_DebugTextBox
            // 
            this.cboxPlugRunParam_DebugTextBox.AutoSize = true;
            this.cboxPlugRunParam_DebugTextBox.Location = new System.Drawing.Point(9, 90);
            this.cboxPlugRunParam_DebugTextBox.Name = "cboxPlugRunParam_DebugTextBox";
            this.cboxPlugRunParam_DebugTextBox.Size = new System.Drawing.Size(100, 17);
            this.cboxPlugRunParam_DebugTextBox.TabIndex = 6;
            this.cboxPlugRunParam_DebugTextBox.Text = "Debug TextBox";
            this.cboxPlugRunParam_DebugTextBox.UseVisualStyleBackColor = true;
            // 
            // cboxPlugRunParam_TextBox
            // 
            this.cboxPlugRunParam_TextBox.AutoSize = true;
            this.cboxPlugRunParam_TextBox.Location = new System.Drawing.Point(95, 128);
            this.cboxPlugRunParam_TextBox.Name = "cboxPlugRunParam_TextBox";
            this.cboxPlugRunParam_TextBox.Size = new System.Drawing.Size(65, 17);
            this.cboxPlugRunParam_TextBox.TabIndex = 6;
            this.cboxPlugRunParam_TextBox.Text = "TextBox";
            this.cboxPlugRunParam_TextBox.UseVisualStyleBackColor = true;
            // 
            // cboxPlugRunParam_WebBrowser
            // 
            this.cboxPlugRunParam_WebBrowser.AutoSize = true;
            this.cboxPlugRunParam_WebBrowser.Location = new System.Drawing.Point(9, 128);
            this.cboxPlugRunParam_WebBrowser.Name = "cboxPlugRunParam_WebBrowser";
            this.cboxPlugRunParam_WebBrowser.Size = new System.Drawing.Size(87, 17);
            this.cboxPlugRunParam_WebBrowser.TabIndex = 6;
            this.cboxPlugRunParam_WebBrowser.Text = "WebBrowser";
            this.cboxPlugRunParam_WebBrowser.UseVisualStyleBackColor = true;
            // 
            // cboxPlugRunParam_SelectedXmlFile
            // 
            this.cboxPlugRunParam_SelectedXmlFile.AutoSize = true;
            this.cboxPlugRunParam_SelectedXmlFile.Location = new System.Drawing.Point(9, 108);
            this.cboxPlugRunParam_SelectedXmlFile.Name = "cboxPlugRunParam_SelectedXmlFile";
            this.cboxPlugRunParam_SelectedXmlFile.Size = new System.Drawing.Size(150, 17);
            this.cboxPlugRunParam_SelectedXmlFile.TabIndex = 6;
            this.cboxPlugRunParam_SelectedXmlFile.Text = "Selected Xml file with data";
            this.cboxPlugRunParam_SelectedXmlFile.UseVisualStyleBackColor = true;
            // 
            // btPlugInRunSelectecAction
            // 
            this.btPlugInRunSelectecAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPlugInRunSelectecAction.Location = new System.Drawing.Point(150, 47);
            this.btPlugInRunSelectecAction.Name = "btPlugInRunSelectecAction";
            this.btPlugInRunSelectecAction.Size = new System.Drawing.Size(36, 21);
            this.btPlugInRunSelectecAction.TabIndex = 5;
            this.btPlugInRunSelectecAction.Text = "Run";
            this.btPlugInRunSelectecAction.UseVisualStyleBackColor = true;
            this.btPlugInRunSelectecAction.Click += new System.EventHandler(this.btPlugInRunSelectecAction_Click);
            // 
            // cbPlugin_Actions
            // 
            this.cbPlugin_Actions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPlugin_Actions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlugin_Actions.FormattingEnabled = true;
            this.cbPlugin_Actions.Location = new System.Drawing.Point(10, 47);
            this.cbPlugin_Actions.Name = "cbPlugin_Actions";
            this.cbPlugin_Actions.Size = new System.Drawing.Size(138, 21);
            this.cbPlugin_Actions.TabIndex = 4;
            // 
            // btCompilePlugIn
            // 
            this.btCompilePlugIn.Location = new System.Drawing.Point(10, 20);
            this.btCompilePlugIn.Name = "btCompilePlugIn";
            this.btCompilePlugIn.Size = new System.Drawing.Size(86, 23);
            this.btCompilePlugIn.TabIndex = 3;
            this.btCompilePlugIn.Text = "Compile PlugIn";
            this.btCompilePlugIn.UseVisualStyleBackColor = true;
            this.btCompilePlugIn.Click += new System.EventHandler(this.btCompilePlugIn_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Plug-in Arguments";
            // 
            // txtPlugInArguments
            // 
            this.txtPlugInArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlugInArguments.Location = new System.Drawing.Point(78, 114);
            this.txtPlugInArguments.Multiline = true;
            this.txtPlugInArguments.Name = "txtPlugInArguments";
            this.txtPlugInArguments.Size = new System.Drawing.Size(47, 10);
            this.txtPlugInArguments.TabIndex = 1;
            // 
            // btExecuteAction
            // 
            this.btExecuteAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExecuteAction.Location = new System.Drawing.Point(131, 110);
            this.btExecuteAction.Name = "btExecuteAction";
            this.btExecuteAction.Size = new System.Drawing.Size(67, 21);
            this.btExecuteAction.TabIndex = 0;
            this.btExecuteAction.Text = "Execute Action";
            this.btExecuteAction.Click += new System.EventHandler(this.btExecuteAction_Click);
            // 
            // lbPlugInXmlFiles
            // 
            this.lbPlugInXmlFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlugInXmlFiles.Location = new System.Drawing.Point(3, 28);
            this.lbPlugInXmlFiles.Name = "lbPlugInXmlFiles";
            this.lbPlugInXmlFiles.Size = new System.Drawing.Size(195, 69);
            this.lbPlugInXmlFiles.TabIndex = 1;
            this.lbPlugInXmlFiles.SelectedIndexChanged += new System.EventHandler(this.lbPlugInXmlFiles_SelectedIndexChanged);
            // 
            // cbCurrentPlugIns
            // 
            this.cbCurrentPlugIns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCurrentPlugIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrentPlugIns.Location = new System.Drawing.Point(3, 4);
            this.cbCurrentPlugIns.Name = "cbCurrentPlugIns";
            this.cbCurrentPlugIns.Size = new System.Drawing.Size(151, 21);
            this.cbCurrentPlugIns.TabIndex = 0;
            this.cbCurrentPlugIns.SelectedIndexChanged += new System.EventHandler(this.cbCurrentPlugIns_SelectedIndexChanged);
            // 
            // tcPluginsDataAndExecution
            // 
            this.tcPluginsDataAndExecution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPluginsDataAndExecution.Controls.Add(this.tpPlugIndata);
            this.tcPluginsDataAndExecution.Controls.Add(this.tpPluginExecutionOutput_TextBoxAndWebBrowser);
            this.tcPluginsDataAndExecution.Controls.Add(this.tpPluginExecutionOutput_DataGrid);
            this.tcPluginsDataAndExecution.Location = new System.Drawing.Point(3, 6);
            this.tcPluginsDataAndExecution.Name = "tcPluginsDataAndExecution";
            this.tcPluginsDataAndExecution.SelectedIndex = 0;
            this.tcPluginsDataAndExecution.Size = new System.Drawing.Size(498, 385);
            this.tcPluginsDataAndExecution.TabIndex = 38;
            // 
            // tpPlugIndata
            // 
            this.tpPlugIndata.Controls.Add(this.axAuthentic_Plugin);
            this.tpPlugIndata.Controls.Add(this.rtbPlugInData);
            this.tpPlugIndata.Controls.Add(this.lbRtbCursorPosition);
            this.tpPlugIndata.Controls.Add(this.lbUnsavedPlugIndata);
            this.tpPlugIndata.Controls.Add(this.cbEditMode);
            this.tpPlugIndata.Controls.Add(this.lblPlugIndataSaved);
            this.tpPlugIndata.Controls.Add(this.lbPlugInDataXmlBreaksXsdSchema);
            this.tpPlugIndata.Controls.Add(this.btSavePlugInData);
            this.tpPlugIndata.Location = new System.Drawing.Point(4, 22);
            this.tpPlugIndata.Name = "tpPlugIndata";
            this.tpPlugIndata.Padding = new System.Windows.Forms.Padding(3);
            this.tpPlugIndata.Size = new System.Drawing.Size(600, 301);
            this.tpPlugIndata.TabIndex = 0;
            this.tpPlugIndata.Text = "PlugIn Data";
            this.tpPlugIndata.UseVisualStyleBackColor = true;
            // 
            // axAuthentic_Plugin
            // 
            this.axAuthentic_Plugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_Plugin.Enabled = true;
            this.axAuthentic_Plugin.Location = new System.Drawing.Point(6, 35);
            this.axAuthentic_Plugin.Name = "axAuthentic_Plugin";
            this.axAuthentic_Plugin.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_Plugin.OcxState")));
            this.axAuthentic_Plugin.Size = new System.Drawing.Size(588, 260);
            this.axAuthentic_Plugin.TabIndex = 3;
            this.axAuthentic_Plugin.SelectionChanged += new System.EventHandler(this.axAuthentic_Plugin_SelectionChanged);
            // 
            // rtbPlugInData
            // 
            this.rtbPlugInData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPlugInData.Location = new System.Drawing.Point(6, 35);
            this.rtbPlugInData.Name = "rtbPlugInData";
            this.rtbPlugInData.Size = new System.Drawing.Size(588, 244);
            this.rtbPlugInData.TabIndex = 36;
            this.rtbPlugInData.Text = "";
            this.rtbPlugInData.SelectionChanged += new System.EventHandler(this.rtbPlugInData_SelectionChanged);
            this.rtbPlugInData.TextChanged += new System.EventHandler(this.rtbPlugInData_TextChanged);
            // 
            // lbRtbCursorPosition
            // 
            this.lbRtbCursorPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRtbCursorPosition.AutoSize = true;
            this.lbRtbCursorPosition.Location = new System.Drawing.Point(480, 282);
            this.lbRtbCursorPosition.Name = "lbRtbCursorPosition";
            this.lbRtbCursorPosition.Size = new System.Drawing.Size(19, 13);
            this.lbRtbCursorPosition.TabIndex = 7;
            this.lbRtbCursorPosition.Text = "....";
            this.lbRtbCursorPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbUnsavedPlugIndata
            // 
            this.lbUnsavedPlugIndata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedPlugIndata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedPlugIndata.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedPlugIndata.Location = new System.Drawing.Point(347, 5);
            this.lbUnsavedPlugIndata.Name = "lbUnsavedPlugIndata";
            this.lbUnsavedPlugIndata.Size = new System.Drawing.Size(107, 21);
            this.lbUnsavedPlugIndata.TabIndex = 28;
            this.lbUnsavedPlugIndata.Text = "Unsaved Data";
            this.lbUnsavedPlugIndata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedPlugIndata.Visible = false;
            // 
            // cbEditMode
            // 
            this.cbEditMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditMode.Items.AddRange(new object[] {
            "Authentic",
            "Notepad"});
            this.cbEditMode.Location = new System.Drawing.Point(6, 7);
            this.cbEditMode.Name = "cbEditMode";
            this.cbEditMode.Size = new System.Drawing.Size(81, 21);
            this.cbEditMode.TabIndex = 35;
            this.cbEditMode.SelectedIndexChanged += new System.EventHandler(this.cbEditMode_SelectedIndexChanged);
            // 
            // lblPlugIndataSaved
            // 
            this.lblPlugIndataSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlugIndataSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlugIndataSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPlugIndataSaved.Location = new System.Drawing.Point(334, 5);
            this.lblPlugIndataSaved.Name = "lblPlugIndataSaved";
            this.lblPlugIndataSaved.Size = new System.Drawing.Size(120, 20);
            this.lblPlugIndataSaved.TabIndex = 27;
            this.lblPlugIndataSaved.Text = "Plug-in data Saved";
            this.lblPlugIndataSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlugIndataSaved.Visible = false;
            // 
            // lbPlugInDataXmlBreaksXsdSchema
            // 
            this.lbPlugInDataXmlBreaksXsdSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlugInDataXmlBreaksXsdSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlugInDataXmlBreaksXsdSchema.ForeColor = System.Drawing.Color.Red;
            this.lbPlugInDataXmlBreaksXsdSchema.Location = new System.Drawing.Point(173, 4);
            this.lbPlugInDataXmlBreaksXsdSchema.Name = "lbPlugInDataXmlBreaksXsdSchema";
            this.lbPlugInDataXmlBreaksXsdSchema.Size = new System.Drawing.Size(168, 25);
            this.lbPlugInDataXmlBreaksXsdSchema.TabIndex = 25;
            this.lbPlugInDataXmlBreaksXsdSchema.Text = "Xml breaks XSD schema!!";
            this.lbPlugInDataXmlBreaksXsdSchema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPlugInDataXmlBreaksXsdSchema.Visible = false;
            this.lbPlugInDataXmlBreaksXsdSchema.Click += new System.EventHandler(this.lbPlugInDataXmlBreaksXsdSchema_Click);
            // 
            // btSavePlugInData
            // 
            this.btSavePlugInData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSavePlugInData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSavePlugInData.Location = new System.Drawing.Point(460, 5);
            this.btSavePlugInData.Name = "btSavePlugInData";
            this.btSavePlugInData.Size = new System.Drawing.Size(120, 22);
            this.btSavePlugInData.TabIndex = 26;
            this.btSavePlugInData.Text = "Save Plug-In Data";
            this.btSavePlugInData.Click += new System.EventHandler(this.btSavePlugInData_Click);
            // 
            // tpPluginExecutionOutput_TextBoxAndWebBrowser
            // 
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Controls.Add(this.label5);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Controls.Add(this.label1);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Controls.Add(this.wbPluginExecution_OutputWebBrowser);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Controls.Add(this.tbPluginExecution_OutputTextBox);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Location = new System.Drawing.Point(4, 22);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Name = "tpPluginExecutionOutput_TextBoxAndWebBrowser";
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Size = new System.Drawing.Size(600, 301);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.TabIndex = 1;
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.Text = "Output - TextBox And WebBrowser";
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Output: WebBrowser";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output: TextBox";
            // 
            // wbPluginExecution_OutputWebBrowser
            // 
            this.wbPluginExecution_OutputWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbPluginExecution_OutputWebBrowser.Location = new System.Drawing.Point(17, 189);
            this.wbPluginExecution_OutputWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPluginExecution_OutputWebBrowser.Name = "wbPluginExecution_OutputWebBrowser";
            this.wbPluginExecution_OutputWebBrowser.Size = new System.Drawing.Size(577, 106);
            this.wbPluginExecution_OutputWebBrowser.TabIndex = 1;
            // 
            // tbPluginExecution_OutputTextBox
            // 
            this.tbPluginExecution_OutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPluginExecution_OutputTextBox.Location = new System.Drawing.Point(17, 23);
            this.tbPluginExecution_OutputTextBox.Multiline = true;
            this.tbPluginExecution_OutputTextBox.Name = "tbPluginExecution_OutputTextBox";
            this.tbPluginExecution_OutputTextBox.Size = new System.Drawing.Size(577, 142);
            this.tbPluginExecution_OutputTextBox.TabIndex = 0;
            // 
            // tpEditPlugIn
            // 
            this.tpEditPlugIn.Controls.Add(this.dgvPluginSettings);
            this.tpEditPlugIn.Controls.Add(this.label7);
            this.tpEditPlugIn.Controls.Add(this.label6);
            this.tpEditPlugIn.Controls.Add(this.lbPhraseNotFound);
            this.tpEditPlugIn.Controls.Add(this.lbFind);
            this.tpEditPlugIn.Controls.Add(this.txtTextToFind);
            this.tpEditPlugIn.Controls.Add(this.btFindText);
            this.tpEditPlugIn.Controls.Add(this.btPlugInCompile);
            this.tpEditPlugIn.Controls.Add(this.lbUnsavedData);
            this.tpEditPlugIn.Controls.Add(this.btSavePlugIn);
            this.tpEditPlugIn.Controls.Add(this.tecPlugIns_Action);
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
            // dgvPluginSettings
            // 
            this.dgvPluginSettings.AllowUserToOrderColumns = true;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPluginSettings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvPluginSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPluginSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPluginSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cValue});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPluginSettings.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgvPluginSettings.Location = new System.Drawing.Point(177, 35);
            this.dgvPluginSettings.Name = "dgvPluginSettings";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPluginSettings.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvPluginSettings.RowHeadersWidth = 15;
            this.dgvPluginSettings.RowTemplate.Height = 15;
            this.dgvPluginSettings.Size = new System.Drawing.Size(631, 129);
            this.dgvPluginSettings.TabIndex = 40;
            this.dgvPluginSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPluginSettings_CellContentClick);
            // 
            // cName
            // 
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.Width = 80;
            // 
            // cValue
            // 
            this.cValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cValue.HeaderText = "Value";
            this.cValue.Name = "cValue";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Plugin Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Plugin Action Code";
            // 
            // lbPhraseNotFound
            // 
            this.lbPhraseNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPhraseNotFound.ForeColor = System.Drawing.Color.Red;
            this.lbPhraseNotFound.Location = new System.Drawing.Point(358, 308);
            this.lbPhraseNotFound.Name = "lbPhraseNotFound";
            this.lbPhraseNotFound.Size = new System.Drawing.Size(296, 24);
            this.lbPhraseNotFound.TabIndex = 38;
            this.lbPhraseNotFound.Text = "Phrase not Found";
            this.lbPhraseNotFound.Visible = false;
            // 
            // lbFind
            // 
            this.lbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFind.Location = new System.Drawing.Point(157, 307);
            this.lbFind.Name = "lbFind";
            this.lbFind.Size = new System.Drawing.Size(40, 16);
            this.lbFind.TabIndex = 37;
            this.lbFind.Text = "Find:";
            // 
            // txtTextToFind
            // 
            this.txtTextToFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTextToFind.Location = new System.Drawing.Point(197, 304);
            this.txtTextToFind.Name = "txtTextToFind";
            this.txtTextToFind.Size = new System.Drawing.Size(96, 20);
            this.txtTextToFind.TabIndex = 35;
            this.txtTextToFind.Text = "xml";
            // 
            // btFindText
            // 
            this.btFindText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFindText.Location = new System.Drawing.Point(309, 304);
            this.btFindText.Name = "btFindText";
            this.btFindText.Size = new System.Drawing.Size(48, 20);
            this.btFindText.TabIndex = 36;
            this.btFindText.Text = "Find";
            this.btFindText.Click += new System.EventHandler(this.btFindText_Click);
            // 
            // btPlugInCompile
            // 
            this.btPlugInCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPlugInCompile.Location = new System.Drawing.Point(664, 299);
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
            // tecPlugIns_Action
            // 
            this.tecPlugIns_Action.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tecPlugIns_Action.Location = new System.Drawing.Point(160, 183);
            this.tecPlugIns_Action.Name = "tecPlugIns_Action";
            this.tecPlugIns_Action.ShowEOLMarkers = true;
            this.tecPlugIns_Action.ShowSpaces = true;
            this.tecPlugIns_Action.ShowTabs = true;
            this.tecPlugIns_Action.ShowVRuler = true;
            this.tecPlugIns_Action.Size = new System.Drawing.Size(648, 110);
            this.tecPlugIns_Action.TabIndex = 4;
            this.tecPlugIns_Action.Enter += new System.EventHandler(this.tecPlugIns_Enter);
            // 
            // txtNewPlugInName
            // 
            this.txtNewPlugInName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewPlugInName.Location = new System.Drawing.Point(8, 270);
            this.txtNewPlugInName.Name = "txtNewPlugInName";
            this.txtNewPlugInName.Size = new System.Drawing.Size(72, 20);
            this.txtNewPlugInName.TabIndex = 3;
            // 
            // btDeletePlugIn
            // 
            this.btDeletePlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeletePlugIn.Location = new System.Drawing.Point(8, 299);
            this.btDeletePlugIn.Name = "btDeletePlugIn";
            this.btDeletePlugIn.Size = new System.Drawing.Size(136, 24);
            this.btDeletePlugIn.TabIndex = 2;
            this.btDeletePlugIn.Text = "Delete Plug-In";
            this.btDeletePlugIn.Click += new System.EventHandler(this.btDeletePlugIn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Available Plug-Ins";
            // 
            // lbAvailablePlugIns
            // 
            this.lbAvailablePlugIns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAvailablePlugIns.Location = new System.Drawing.Point(8, 32);
            this.lbAvailablePlugIns.Name = "lbAvailablePlugIns";
            this.lbAvailablePlugIns.Size = new System.Drawing.Size(136, 212);
            this.lbAvailablePlugIns.TabIndex = 0;
            this.lbAvailablePlugIns.SelectedIndexChanged += new System.EventHandler(this.lbAvailablePlugIns_SelectedIndexChanged);
            // 
            // btCreateNewPlugIn
            // 
            this.btCreateNewPlugIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateNewPlugIn.Location = new System.Drawing.Point(88, 270);
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
            this.label3.Location = new System.Drawing.Point(8, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Debug Messages:";
            // 
            // txtDebugMessages
            // 
            this.txtDebugMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugMessages.Location = new System.Drawing.Point(102, 437);
            this.txtDebugMessages.Multiline = true;
            this.txtDebugMessages.Name = "txtDebugMessages";
            this.txtDebugMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebugMessages.Size = new System.Drawing.Size(637, 105);
            this.txtDebugMessages.TabIndex = 6;
            // 
            // tpPluginExecutionOutput_DataGrid
            // 
            this.tpPluginExecutionOutput_DataGrid.Controls.Add(this.dgvOutputDataGridView);
            this.tpPluginExecutionOutput_DataGrid.Location = new System.Drawing.Point(4, 22);
            this.tpPluginExecutionOutput_DataGrid.Name = "tpPluginExecutionOutput_DataGrid";
            this.tpPluginExecutionOutput_DataGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tpPluginExecutionOutput_DataGrid.Size = new System.Drawing.Size(490, 359);
            this.tpPluginExecutionOutput_DataGrid.TabIndex = 2;
            this.tpPluginExecutionOutput_DataGrid.Text = "Output - DataGrid";
            this.tpPluginExecutionOutput_DataGrid.UseVisualStyleBackColor = true;
            // 
            // dgvOutputDataGridView
            // 
            this.dgvOutputDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputDataGridView.Location = new System.Drawing.Point(3, 2);
            this.dgvOutputDataGridView.Name = "dgvOutputDataGridView";
            this.dgvOutputDataGridView.Size = new System.Drawing.Size(483, 354);
            this.dgvOutputDataGridView.TabIndex = 0;
            // 
            // cboxPlugRunParam_DataGrid
            // 
            this.cboxPlugRunParam_DataGrid.AutoSize = true;
            this.cboxPlugRunParam_DataGrid.Location = new System.Drawing.Point(9, 149);
            this.cboxPlugRunParam_DataGrid.Name = "cboxPlugRunParam_DataGrid";
            this.cboxPlugRunParam_DataGrid.Size = new System.Drawing.Size(68, 17);
            this.cboxPlugRunParam_DataGrid.TabIndex = 6;
            this.cboxPlugRunParam_DataGrid.Text = "DataGrid";
            this.cboxPlugRunParam_DataGrid.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcPluginsDataAndExecution);
            this.splitContainer1.Size = new System.Drawing.Size(717, 394);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 39;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Location = new System.Drawing.Point(1, 1);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbPlugInXmlFiles);
            this.splitContainer2.Panel1.Controls.Add(this.cbCurrentPlugIns);
            this.splitContainer2.Panel1.Controls.Add(this.btReloadPluginData);
            this.splitContainer2.Panel1.Controls.Add(this.btExecuteAction);
            this.splitContainer2.Panel1.Controls.Add(this.txtPlugInArguments);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbPlugInActions);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(205, 396);
            this.splitContainer2.SplitterDistance = 137;
            this.splitContainer2.TabIndex = 0;
            // 
            // ascxPlugIns
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDebugMessages);
            this.Controls.Add(this.label3);
            this.Name = "ascxPlugIns";
            this.Size = new System.Drawing.Size(747, 550);
            this.Load += new System.EventHandler(this.ascxPlugIns_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPlugIn.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPlugInActions.ResumeLayout(false);
            this.gbPlugInActions.PerformLayout();
            this.tcPluginsDataAndExecution.ResumeLayout(false);
            this.tpPlugIndata.ResumeLayout(false);
            this.tpPlugIndata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Plugin)).EndInit();
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.ResumeLayout(false);
            this.tpPluginExecutionOutput_TextBoxAndWebBrowser.PerformLayout();
            this.tpEditPlugIn.ResumeLayout(false);
            this.tpEditPlugIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPluginSettings)).EndInit();
            this.tpPluginExecutionOutput_DataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
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
            //tecPlugins_ConfigData.Text = utils.files.GetFileContents(strPlugInFileToLoad);

            // clear DataGrid
            dgvPluginSettings.Rows.Clear();
            // put this on a sub called 'loadPluginXmlFileIntoDataGridAndTextEditor'
            // LoadPlugin Xml file into an XmlDocument
            XmlDocument xdPlugin = new XmlDocument();
            xdPlugin.Load(strPlugInFileToLoad);
            // Get Plug in data
            XmlNodeList xelPlugin = xdPlugin.GetElementsByTagName("PlugIn");
            if (xelPlugin.Count != 1)
            {
                MessageBox.Show("Only one PlugIn per file is currently supported");
                return;
            }
            //Populate DataGrid with attributes
            foreach (XmlAttribute xaAttribute in xelPlugin[0].Attributes)
                dgvPluginSettings.Rows.Add(new object[2] { xaAttribute.Name, xaAttribute.Value });            

            // Get action code
            XmlNodeList xelAction = xdPlugin.GetElementsByTagName("action");
            if (xelAction.Count != 1)
            {
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Note: There was no Action in this Plug-in");
            }
            else             
            {
                string strActionCode = xelAction[0].InnerXml;
                strActionCode = strActionCode.Replace("<![CDATA[", "").Replace("]]>",""); // remove CDATA 
                string strTempFileForActionCode = Path.GetTempFileName()+".cs";
                utils.files.SaveFileWithStringContents(strTempFileForActionCode,strActionCode);
                tecPlugIns_Action.LoadFile(strTempFileForActionCode);
            }
            //tecPlugIns_Action.LoadFile(strPlugInFileToLoad);
            utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Loaded Plug-in template: " + lbAvailablePlugIns.Text);
        }

        private void btSavePlugIn_Click(object sender, System.EventArgs e)
        {
            // put this on a sub called 'savePluginXmlFileFromDataGridAndTextEditor'
            XmlDocument xdPlugInXmlDocument = new XmlDocument();
            // create document element
            XmlNode xnPlugIns = xdPlugInXmlDocument.CreateElement("PlugIns");            
            // create element to hold the plugin information
            XmlNode xnPlugIn = xdPlugInXmlDocument.CreateElement("PlugIn");
            // get the values from the data grid and put them in attributes
            foreach (DataGridViewRow dgvcAttributesRow in dgvPluginSettings.Rows)
            {
                if (null != dgvcAttributesRow.Cells[0].Value)
                {
                    XmlAttribute xaAttribute = xdPlugInXmlDocument.CreateAttribute(dgvcAttributesRow.Cells[0].Value.ToString());
                    xaAttribute.Value = dgvcAttributesRow.Cells[1].Value.ToString();
                    xnPlugIn.Attributes.Append(xaAttribute);
                }
            }
            // create elemtent to hold the plugin source code
            XmlNode xnAction = xdPlugInXmlDocument.CreateElement("action");
            xnAction.InnerXml = "<![CDATA[" + tecPlugIns_Action.Text + "]]>";            
            //now that all element objects are populated append them
            xnPlugIn.AppendChild(xnAction);
            xnPlugIns.AppendChild(xnPlugIn);
            xdPlugInXmlDocument.AppendChild(xnPlugIns);            
            //xdPlugIn.AppendChild();

            xdPlugInXmlDocument.Save(strPlugInFileToLoad);
            //tecPlugIns_Action.SaveFile(strPlugInFileToLoad);
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
                {
                    strActionSourceCode = xnPlugIn.ChildNodes[0].InnerText;
                    // auto compile when loaded                    
                }
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
                this.tecPlugIns_Action.Document.DocumentChanged += new ICSharpCode.TextEditor.Document.DocumentEventHandler(Document_DocumentChanged);
            }
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

        private void btFindText_Click(object sender, EventArgs e)
        {
            lbPhraseNotFound.Visible = false;
            int iOriginalTextCaret = tecPlugIns_Action.ActiveTextAreaControl.TextArea.Caret.Offset;
            int iOffsetOfEndOfCurrentSelection = tecPlugIns_Action.ActiveTextAreaControl.TextArea.Caret.Offset +
                 tecPlugIns_Action.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText.Length;

            int iFoundPos = tecPlugIns_Action.Text.IndexOf(txtTextToFind.Text, iOffsetOfEndOfCurrentSelection);  //start from the cursor position
            if (iFoundPos == -1) // didn't find anything
                iFoundPos = tecPlugIns_Action.Text.IndexOf(txtTextToFind.Text, 0); // start from the top
            if (iFoundPos > -1)      // if there is a match process it
            {
                tecPlugIns_Action.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
                tecPlugIns_Action.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(new DefaultSelection(tecPlugIns_Action.Document,
                    tecPlugIns_Action.Document.OffsetToPosition(iFoundPos),
                    tecPlugIns_Action.Document.OffsetToPosition(iFoundPos + txtTextToFind.Text.Length)));

                tecPlugIns_Action.ActiveTextAreaControl.Caret.Position = tecPlugIns_Action.ActiveTextAreaControl.TextArea.SelectionManager.SelectionCollection[0].StartPosition;
                tecPlugIns_Action.ActiveTextAreaControl.TextArea.ScrollToCaret();


                tecPlugIns_Action.ActiveTextAreaControl.TextArea.SelectionManager.FireSelectionChanged();
            }
            else
            {
                lbPhraseNotFound.Visible = true;
                lbPhraseNotFound.Text = string.Format("Provided search string not found: '{0}'", txtTextToFind.Text);
            }
            if (iOriginalTextCaret == tecPlugIns_Action.ActiveTextAreaControl.TextArea.Caret.Offset)
            {
                lbPhraseNotFound.Visible = true;
                lbPhraseNotFound.Text = string.Format("No more matches for '{0}'", txtTextToFind.Text);
            }
        }

        private void btCompilePlugIn_Click(object sender, EventArgs e)
        {
            loadXmlFileAndPopulateVars();
            //CompileAndExecuteRoutine asyncDelegate = new CompileAndExecuteRoutine(this.CompileAndExecute);
            //IAsyncResult result = asyncDelegate.BeginInvoke(fileName, newargs, strReferenceAssembliesToAdd, this, null, null);

            crSelectedPluginAction_CompilerResults = utils.scriptHost.compileAndReturnCompilerResults(strActionSourceCode, strReferenceAssemblies);
            if (crSelectedPluginAction_CompilerResults == null)
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Compilation Errors"); 
            else
            {
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Compilation OK, Populating Combo box with available methods"); 
                cbPlugin_Actions.Items.Clear();
                foreach (Type tType in crSelectedPluginAction_CompilerResults.CompiledAssembly.GetTypes())
                    foreach (MethodInfo miMethodInfo in tType.GetMethods())
                        switch (miMethodInfo.Name)
                        { 
                            case "ToString":        // ignore these since they exist in every class
                            case "GetType":
                            case "GetHashCode":
                            case "Equals":
                                break;
                            default:
                                cbPlugin_Actions.Items.Add(miMethodInfo.Name);
                                break;
                        }
                if (cbPlugin_Actions.Items.Count > 0)
                    cbPlugin_Actions.SelectedIndex = 0;
            }
        }

        private void btPlugInRunSelectecAction_Click(object sender, EventArgs e)
        {
//            dgvOutputDataGridView.Columns.Add("

//            DataGridViewColumn asd = new DataGridViewColumn();
 //           asd.CellTemplate = asd.DataGridView();
            if (null == crSelectedPluginAction_CompilerResults)      // if this plugin has not been compiled
            {
                btCompilePlugIn_Click(null,null);                    // try to compiler it
                if (null == crSelectedPluginAction_CompilerResults)  // and try again (if this fail is because there is an error in the compilation
                {
                    utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Error: no plug-in compiled");
                    return;
    }
            }
            // Get the Type of the class to reflect
            Type[] tTypesFromCurrentAssembly = crSelectedPluginAction_CompilerResults.CompiledAssembly.GetTypes();
            if (tTypesFromCurrentAssembly.Length != 1)
            {
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, "Error in btPlugInRunSelectecAction_Click: currently only one Type in tTypesFromCurrentAssembly is supported");
                return;
            }
            // Calculate the params:
            List<object> loParameters = new List<object>();
            if (true == cboxPlugRunParam_DebugTextBox.Checked)
                loParameters.Add(txtDebugMessages);
            if (true == cboxPlugRunParam_WebBrowser.Checked)
                loParameters.Add(wbPluginExecution_OutputWebBrowser);
            if (true == cboxPlugRunParam_TextBox.Checked)
                loParameters.Add(tbPluginExecution_OutputTextBox);
            if (true == cboxPlugRunParam_DataGrid.Checked)
                loParameters.Add(dgvOutputDataGridView);
            object[] oaParameters = loParameters.ToArray();

            // get the method metadata
            MethodInfo miMethodToExecute = tTypesFromCurrentAssembly[0].GetMethod(cbPlugin_Actions.Text);
/*
            if (miMethodToExecute.GetParameters().Length > 0)
            {
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, string.Format("Error in executing Method {0} since it has parameters (currently only methods with no parameters are supported)", cbPlugin_Actions.Text));
                return;
            }            
 */
            // execute it (note:change this so that this is executed in a different thread)
            try
            {
                object oExecutionResult = miMethodToExecute.Invoke(crSelectedPluginAction_CompilerResults.CompiledAssembly, oaParameters);
                if (null == oExecutionResult)
                    utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, string.Format("Method {0} sucessfully executed. No objects returned", cbPlugin_Actions.Text));
                else
                    utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, string.Format("Method {0} sucessfully executed: Object returned {1}:", cbPlugin_Actions.Text, oExecutionResult)); 
            }
            catch (Exception ex)
            { 
                utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, string.Format("Error in executing selected method: {0}",ex.Message));
                if (null != ex.InnerException)
                    utils.windowsForms.addMessageToTextBox_top(txtDebugMessages, string.Format("  Inner Exception: {0}", ex.InnerException.Message));
            }
            // check for results            
            
        }

        private void dgvPluginSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

	public class PlugIn
	{
        /// TODO: Need to figure out what this was supposed to do.
	}	
}
