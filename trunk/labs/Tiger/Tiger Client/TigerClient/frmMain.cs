// Tiger Client 1.0
// Copyright (C) 2007 Boris Maletic
//
// This program is free software; you can redistribute it and/or modify it under 
// the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with this program;
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TigerClient
{
    public partial class frmMain : Form
    {
        private bool propertiesVisible = true;
        private bool projectExplorerVisible = true;
        private CustomControls.ProjectRunnerControl projectRunner;
        private bool isProjectExecuting;

        public frmMain()
        {
            InitializeComponent();

            projectRunner = new TigerClient.CustomControls.ProjectRunnerControl();
            projectRunner.Dock = DockStyle.Fill;
            projectRunner.ProjectCompleted += new EventHandler(projectRunner_ProjectCompleted);


            mnuViewShowTargetsInFolders.Checked = Settings.Default.ShowTargetsInFolders;
            mnuViewShowTestsInFolders.Checked = Settings.Default.ShowTestsInFolders;
            mnuViewShowTestParametersInFolders.Checked = Settings.Default.ShowTestParametersInFolders;
            mnuViewShowAlertsInFolders.Checked = Settings.Default.ShowAlertsInFolders;
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            Close();
        }

        private void projectExplorerControl1_CloseButtonClick(object sender, EventArgs e)
        {
            projectExplorerVisible = false;
            ShowHidePanes();
        }

        private void propertiesControl1_CloseButtonClick(object sender, EventArgs e)
        {
            propertiesVisible = false;
            ShowHidePanes();
        }

        private void mnuViewProjectExplorer_Click(object sender, EventArgs e)
        {
            projectExplorerVisible = true;
            ShowHidePanes();
        }

        private void mnuViewPropertiesWindow_Click(object sender, EventArgs e)
        {
            propertiesVisible = true;
            ShowHidePanes();
        }

        private void ShowHidePanes()
        {
            splitContainer2.Panel1Collapsed = !projectExplorerVisible;
            splitContainer2.Panel2Collapsed = !propertiesVisible;

            splitContainer1.Panel2Collapsed = !(projectExplorerVisible || propertiesVisible);
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void projectExplorerControl1_SelectedObjectChanged(object sender, EventArgs e)
        {
            propertiesControl1.SelectedObject = projectExplorerControl1.SelectedObject;
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private bool SaveAs()
        {
            bool success = false;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                try
                {
                    Document.DocumentManager.ActiveDocument.SaveAs(saveDialog.FileName);
                    Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Tiger";
                    //Text = System.IO.Path.GetFileName(saveDialog.FileName) + " - OWASP Tiger";
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Failed to save project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }

            return success;
        }

        private bool Save()
        {
            bool success = false;

            //if (!string.IsNullOrEmpty(Document.DocumentManager.ActiveDocument.FileName))
            if (!string.IsNullOrEmpty(Document.DocumentManager.ActiveDocument.FilePath))
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                try
                {
                    Document.DocumentManager.ActiveDocument.Save();
                    Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Tiger";
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to save project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                System.Windows.Forms.Cursor.Current = Cursors.Default;
                return success;
            }
            else
            {
                return SaveAs();
            }
        }

        private void Open()
        {
            if (Document.DocumentManager.ActiveDocument != null)
            {
                if (Document.DocumentManager.ActiveDocument.IsModified)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save the changes to the curent document?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool saveSucceeded = Save();
                        if (!saveSucceeded) return; // If the doc is still dirty, it means that Save failed. We must not replace the current document with another one.
                    }
                    else if (dr == DialogResult.Cancel) return;
                }
            }

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document.Project p = Document.Project.LoadFromFile(openDialog.FileName);
                    projectExplorerControl1.Project = p;
                    Document.DocumentManager.ActiveDocument = p;
                    p.Modified += new EventHandler<Document.DocumentPartModifiedEventArgs>(OnDocumentModified);

                    Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Tiger";

                    splitContainer1.Panel1.SuspendLayout();
                    splitContainer1.Panel1.BackColor = SystemColors.AppWorkspace;
                    splitContainer1.Panel1.Controls.Clear();
                    splitContainer1.Panel1.ResumeLayout();

                    //Text = System.IO.Path.GetFileName(openDialog.FileName) + " - OWASP Tiger";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to open project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void tbtnFileOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tbtnFileSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tbtnFileNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            frmNewProject f = new frmNewProject();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(f.Template))
                    New();
                else
                    NewFromTemplate(f.Template);
            }
        }

        private void New()
        {
            if (Document.DocumentManager.ActiveDocument != null)
            {
                if (Document.DocumentManager.ActiveDocument.IsModified)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save the changes to the curent document?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool savingSucceeded = Save();
                        if (!savingSucceeded) return; // If the doc is still dirty, it means that Save failed. We must not replace the current document with another one.
                    }
                    else if (dr == DialogResult.Cancel) return;
                }
            }

            Document.Project p = Document.Project.New();
            projectExplorerControl1.Project = p;
            Document.DocumentManager.ActiveDocument = p;
            p.Modified += new EventHandler<Document.DocumentPartModifiedEventArgs>(OnDocumentModified);

            Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Tiger";

            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel1.BackColor = SystemColors.AppWorkspace;
            splitContainer1.Panel1.Controls.Clear();
            splitContainer1.Panel1.ResumeLayout();
        }

        private void NewFromTemplate(string templateFilePath)
        {
            if (Document.DocumentManager.ActiveDocument != null)
            {
                if (Document.DocumentManager.ActiveDocument.IsModified)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save the changes to the curent document?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool savingSucceeded = Save();
                        if (!savingSucceeded) return; // If the doc is still dirty, it means that Save failed. We must not replace the current document with another one.
                    }
                    else if (dr == DialogResult.Cancel) return;
                }
            }

            Document.Project p = Document.Project.NewFromTemplate(templateFilePath);
            projectExplorerControl1.Project = p;
            Document.DocumentManager.ActiveDocument = p;
            p.Modified += new EventHandler<Document.DocumentPartModifiedEventArgs>(OnDocumentModified);

            Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Tiger";

            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel1.BackColor = SystemColors.AppWorkspace;
            splitContainer1.Panel1.Controls.Clear();
            splitContainer1.Panel1.ResumeLayout();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            New();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Document.DocumentManager.ActiveDocument != null)
            {
                if (Document.DocumentManager.ActiveDocument.IsModified)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save the changes to the curent document?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    
                    if (dr == DialogResult.Yes)
                    {
                        bool savingSucceeded = Save();
                        if (!savingSucceeded)
                        {
                            if (MessageBox.Show("Do you still want to exit the application?", "Failed to save document", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                e.Cancel = true;
                        }
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void OnDocumentModified(object sender, Document.DocumentPartModifiedEventArgs e)
        {
            Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Tiger";
            propertiesControl1.Refresh();
        }

        private void mnuViewShowTargetsInFolders_Click(object sender, EventArgs e)
        {
            mnuViewShowTargetsInFolders.Checked = !mnuViewShowTargetsInFolders.Checked;
            Settings.Default.ShowTargetsInFolders = mnuViewShowTargetsInFolders.Checked;
            projectExplorerControl1.ReloadProject();
        }

        private void mnuViewShowTestsInFolders_Click(object sender, EventArgs e)
        {
            mnuViewShowTestsInFolders.Checked = !mnuViewShowTestsInFolders.Checked;
            Settings.Default.ShowTestsInFolders = mnuViewShowTestsInFolders.Checked;
            projectExplorerControl1.ReloadProject();
        }

        private void mnuViewShowTestParametersInFolders_Click(object sender, EventArgs e)
        {
            mnuViewShowTestParametersInFolders.Checked = !mnuViewShowTestParametersInFolders.Checked;
            Settings.Default.ShowTestParametersInFolders = mnuViewShowTestParametersInFolders.Checked;
            projectExplorerControl1.ReloadProject();
        }

        private void mnuProject_DropDownOpening(object sender, EventArgs e)
        {
            if (isProjectExecuting)
            {
                mnuProjectAddTarget.Enabled = false;
                mnuProjectAddTest.Enabled = false;
                mnuProjectAddTestParameter.Enabled = false;
                mnuProjectRun.Enabled = false;
                mnuProjectStop.Enabled = true;
            }
            else
            {
                mnuProjectAddTarget.Enabled = true;
                mnuProjectRun.Enabled = true;
                mnuProjectStop.Enabled = false;

                Document.Target target = propertiesControl1.SelectedObject as Document.Target;
                mnuProjectAddTest.Enabled = (target != null);

                Document.AutomatedTest test = propertiesControl1.SelectedObject as Document.AutomatedTest;
                mnuProjectAddTestParameter.Enabled = (test != null);
            }
        }

        private void mnuProjectAddTarget_Click(object sender, EventArgs e)
        {
            Document.Target newTarget = new Document.Target();
            projectExplorerControl1.Project.Targets.Add(newTarget);
            projectExplorerControl1.SelectNodeFor(newTarget);
        }

        private void mnuProjectAddTest_Click(object sender, EventArgs e)
        {
            Document.Target target = projectExplorerControl1.SelectedObject as Document.Target;
            if (target != null)
            {
                Document.AutomatedTest newTest = new TigerClient.Document.AutomatedTest();
                target.AutomatedTests.Add(newTest);
                projectExplorerControl1.SelectNodeFor(newTest);
            }
        }

        private void mnuProjectAddTestParameter_Click(object sender, EventArgs e)
        {
            Document.AutomatedTest test = projectExplorerControl1.SelectedObject as Document.AutomatedTest;
            if (test != null)
            {
                Document.TestParameter newParameter = new TigerClient.Document.TestParameter();
                test.Parameters.Add(newParameter);
                projectExplorerControl1.SelectNodeFor(newParameter);
            }
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            (new AboutBox()).ShowDialog();
        }

        private void tbtnProjectRun_Click(object sender, EventArgs e)
        {
            RunProject();
        }

        private void mnuProjectRun_Click(object sender, EventArgs e)
        {
            RunProject();
        }

        private void RunProject()
        {
            if (projectExplorerControl1.Project.IsValid)
            {
                splitContainer1.Panel1.Controls.Clear();
                splitContainer1.Panel1.BackColor = SystemColors.Control;

                splitContainer1.Panel1.Controls.Add(projectRunner);
                projectRunner.Focus();

                projectRunner.Project = projectExplorerControl1.Project;
                IsProjectExecuting = true;
                projectRunner.Run();
            }
            else
                MessageBox.Show("Project cannot be run because it contains invalid items.", "Run Project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuViewShowAlertsInFolders_Click(object sender, EventArgs e)
        {
            mnuViewShowAlertsInFolders.Checked = !mnuViewShowAlertsInFolders.Checked;
            Settings.Default.ShowAlertsInFolders = mnuViewShowAlertsInFolders.Checked;
            projectExplorerControl1.ReloadProject();
        }

        private void tbtnProjectStop_Click(object sender, EventArgs e)
        {
            StopProject();
        }

        private void mnuProjectStop_Click(object sender, EventArgs e)
        {
            StopProject();
        }

        private void StopProject()
        {
            projectRunner.Stop();
            IsProjectExecuting = false;
        }

        private void projectRunner_ProjectCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("All tests are finished.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsProjectExecuting = false;
        }

        private bool IsProjectExecuting
        {
            get { return isProjectExecuting; }
            set
            {
                isProjectExecuting = value;

                tbtnProjectRun.Enabled = !value;
                tbtnProjectStop.Enabled = value;
                tbtnFileNew.Enabled = !value;
                tbtnFileOpen.Enabled = !value;
                tbtnFileSave.Enabled = !value;
                //mnuProjectRun.Enabled = !value;

                //mnuProjectStop.Enabled = value;

                projectExplorerControl1.Enabled = !value;
                propertiesControl1.Enabled = !value;
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control) && tbtnFileNew.Enabled)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                New();
            }
        }

        private void mnuHelpUserManual_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "http://www.owasp.org/index.php/Tiger_User_Manual");
        }

        private void mnuFile_DropDownOpening(object sender, EventArgs e)
        {
            mnuFileExit.Enabled = !isProjectExecuting;
            mnuFileNew.Enabled = !isProjectExecuting;
            mnuFileOpen.Enabled = !isProjectExecuting;
            mnuFileSave.Enabled = !isProjectExecuting;
            mnuFileSaveAs.Enabled = !isProjectExecuting;
        }
    }
}