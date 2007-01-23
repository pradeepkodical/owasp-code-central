namespace TigerClient.ControlAdapters
{
    partial class TreeViewAdapter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewAdapter));
            this.ctxTestParameter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxTarget = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAlert = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxTestParameterDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestAddAlert = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestAddTestParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestTestRun = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTargetAddTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTargetDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxProjectAddTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxAlertDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestParameter.SuspendLayout();
            this.ctxTest.SuspendLayout();
            this.ctxTarget.SuspendLayout();
            this.ctxProject.SuspendLayout();
            this.ctxAlert.SuspendLayout();
            // 
            // ctxTestParameter
            // 
            this.ctxTestParameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxTestParameterDelete});
            this.ctxTestParameter.Name = "ctxTestParameter";
            this.ctxTestParameter.Size = new System.Drawing.Size(117, 26);
            // 
            // ctxTest
            // 
            this.ctxTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxTestAddAlert,
            this.ctxTestAddTestParameter,
            this.toolStripSeparator1,
            this.ctxTestTestRun,
            this.toolStripSeparator3,
            this.ctxTestDelete});
            this.ctxTest.Name = "ctxTest";
            this.ctxTest.Size = new System.Drawing.Size(158, 104);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // ctxTarget
            // 
            this.ctxTarget.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxTargetAddTest,
            this.toolStripSeparator2,
            this.ctxTargetDelete});
            this.ctxTarget.Name = "ctxTarget";
            this.ctxTarget.Size = new System.Drawing.Size(129, 54);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // ctxProject
            // 
            this.ctxProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxProjectAddTarget});
            this.ctxProject.Name = "ctxProject";
            this.ctxProject.Size = new System.Drawing.Size(140, 26);
            // 
            // ctxAlert
            // 
            this.ctxAlert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAlertDelete});
            this.ctxAlert.Name = "ctxAlert";
            this.ctxAlert.Size = new System.Drawing.Size(117, 26);
            // 
            // ctxTestParameterDelete
            // 
            this.ctxTestParameterDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctxTestParameterDelete.Image")));
            this.ctxTestParameterDelete.Name = "ctxTestParameterDelete";
            this.ctxTestParameterDelete.Size = new System.Drawing.Size(116, 22);
            this.ctxTestParameterDelete.Text = "&Delete";
            this.ctxTestParameterDelete.Click += new System.EventHandler(this.ctxTestParameterDelete_Click);
            // 
            // ctxTestAddAlert
            // 
            this.ctxTestAddAlert.Image = global::TigerClient.Properties.Resources.add_alert;
            this.ctxTestAddAlert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ctxTestAddAlert.Name = "ctxTestAddAlert";
            this.ctxTestAddAlert.Size = new System.Drawing.Size(157, 22);
            this.ctxTestAddAlert.Text = "Add &Alert";
            this.ctxTestAddAlert.Click += new System.EventHandler(this.ctxTestAddAlert_Click);
            // 
            // ctxTestAddTestParameter
            // 
            this.ctxTestAddTestParameter.Image = global::TigerClient.Properties.Resources.AddParameter;
            this.ctxTestAddTestParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ctxTestAddTestParameter.Name = "ctxTestAddTestParameter";
            this.ctxTestAddTestParameter.Size = new System.Drawing.Size(157, 22);
            this.ctxTestAddTestParameter.Text = "Add &Parameter";
            this.ctxTestAddTestParameter.Click += new System.EventHandler(this.ctxTestAddTestParameter_Click);
            // 
            // ctxTestTestRun
            // 
            this.ctxTestTestRun.Image = global::TigerClient.Properties.Resources.PlayHS;
            this.ctxTestTestRun.Name = "ctxTestTestRun";
            this.ctxTestTestRun.Size = new System.Drawing.Size(157, 22);
            this.ctxTestTestRun.Text = "&Test Run";
            this.ctxTestTestRun.Click += new System.EventHandler(this.ctxTestTestRun_Click);
            // 
            // ctxTestDelete
            // 
            this.ctxTestDelete.Image = global::TigerClient.Properties.Resources.DeleteHS;
            this.ctxTestDelete.Name = "ctxTestDelete";
            this.ctxTestDelete.Size = new System.Drawing.Size(157, 22);
            this.ctxTestDelete.Text = "&Delete";
            this.ctxTestDelete.Click += new System.EventHandler(this.ctxTestDelete_Click);
            // 
            // ctxTargetAddTest
            // 
            this.ctxTargetAddTest.Image = global::TigerClient.Properties.Resources.AddTest;
            this.ctxTargetAddTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ctxTargetAddTest.Name = "ctxTargetAddTest";
            this.ctxTargetAddTest.Size = new System.Drawing.Size(128, 22);
            this.ctxTargetAddTest.Text = "&Add Test";
            this.ctxTargetAddTest.Click += new System.EventHandler(this.ctxTargetAddTest_Click);
            // 
            // ctxTargetDelete
            // 
            this.ctxTargetDelete.Image = global::TigerClient.Properties.Resources.DeleteHS;
            this.ctxTargetDelete.Name = "ctxTargetDelete";
            this.ctxTargetDelete.Size = new System.Drawing.Size(128, 22);
            this.ctxTargetDelete.Text = "&Delete";
            this.ctxTargetDelete.Click += new System.EventHandler(this.ctxTargetDelete_Click);
            // 
            // ctxProjectAddTarget
            // 
            this.ctxProjectAddTarget.Image = global::TigerClient.Properties.Resources.Add_Target_2;
            this.ctxProjectAddTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ctxProjectAddTarget.Name = "ctxProjectAddTarget";
            this.ctxProjectAddTarget.Size = new System.Drawing.Size(139, 22);
            this.ctxProjectAddTarget.Text = "&Add Target";
            this.ctxProjectAddTarget.Click += new System.EventHandler(this.ctxProjectAddTarget_Click);
            // 
            // ctxAlertDelete
            // 
            this.ctxAlertDelete.Image = global::TigerClient.Properties.Resources.DeleteHS;
            this.ctxAlertDelete.Name = "ctxAlertDelete";
            this.ctxAlertDelete.Size = new System.Drawing.Size(116, 22);
            this.ctxAlertDelete.Text = "&Delete";
            this.ctxAlertDelete.Click += new System.EventHandler(this.ctxAlertDelete_Click);
            this.ctxTestParameter.ResumeLayout(false);
            this.ctxTest.ResumeLayout(false);
            this.ctxTarget.ResumeLayout(false);
            this.ctxProject.ResumeLayout(false);
            this.ctxAlert.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxTestParameter;
        private System.Windows.Forms.ToolStripMenuItem ctxTestParameterDelete;
        private System.Windows.Forms.ContextMenuStrip ctxTest;
        private System.Windows.Forms.ContextMenuStrip ctxTarget;
        private System.Windows.Forms.ContextMenuStrip ctxProject;
        private System.Windows.Forms.ToolStripMenuItem ctxProjectAddTarget;
        private System.Windows.Forms.ToolStripMenuItem ctxTestAddTestParameter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctxTestDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxTargetDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxTargetAddTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctxTestTestRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip ctxAlert;
        private System.Windows.Forms.ToolStripMenuItem ctxAlertDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxTestAddAlert;
    }
}
