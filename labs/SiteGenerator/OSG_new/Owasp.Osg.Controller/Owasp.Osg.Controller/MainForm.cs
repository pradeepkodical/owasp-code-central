using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Owasp.Osg.Controller.Controls;
using Owasp.Osg.Controller.Communicator;

namespace Owasp.Osg.Controller
{
    public partial class MainForm : Form
    {
			  public Listener listener;

			  public MainForm()
        {
            InitializeComponent(); 
					  listener = new Listener();
					  listener.Begin();
        }

			  public void showMsg(string s) { MessageBox.Show(s); }

        private void fileTransformationListControl1_CloseButtonClick(object sender, EventArgs e)
        {
            fileTransformationListControl1.Visible = false;
            horizontalSplitContainer.Panel2Collapsed = true;
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbtnFileSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tbtnFileOpen_Click(object sender, EventArgs e)
        {
            Open();
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
                    siteTreeControl1.Project = p;
                    Document.DocumentManager.ActiveDocument = p;
                    //p.Modified += new EventHandler<Document.DocumentPartModifiedEventArgs>(OnDocumentModified);

                    Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Site Generator";

                    //splitContainer1.Panel1.SuspendLayout();
                    //splitContainer1.Panel1.BackColor = SystemColors.AppWorkspace;
                    //splitContainer1.Panel1.Controls.Clear();
                    //splitContainer1.Panel1.ResumeLayout();

                    //Text = System.IO.Path.GetFileName(openDialog.FileName) + " - OWASP Site Generator";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to open project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private bool Save()
        {
            bool success = false;

            if (!string.IsNullOrEmpty(Document.DocumentManager.ActiveDocument.FilePath))
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                try
                {
                    Document.DocumentManager.ActiveDocument.Save();
                    Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Site Generator";
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

        private bool SaveAs()
        {
            bool success = false;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                try
                {
                    Document.DocumentManager.ActiveDocument.SaveAs(saveDialog.FileName);
                    Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Site Generator";
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

            Document.Project project = Document.Project.New();

            // Demo document creation
            project.Site.Contents.Add(new Document.File("1.aspx", "1-a.aspx"));
            project.Site.Contents.Add(new Document.File("2.aspx", "2-a.aspx"));

            Document.Folder folder = new Owasp.Osg.Controller.Document.Folder("pages");
            folder.Contents.Add(new Document.File("1.htm", "1-a.htm"));
            folder.Contents.Add(new Document.File("2.htm", "2-a.htm"));

            Document.Folder folder2 = new Owasp.Osg.Controller.Document.Folder("jsp");
            folder2.Contents.Add(new Document.File("1.jsp", "1-a.jsp"));
            folder2.Contents.Add(new Document.File("2.jsp", "2-a.jsp"));

            folder.Contents.Add(folder2);
            project.Site.Contents.Add(folder);

            // END: Demo document creation
            
            siteTreeControl1.Project = project;

            Document.DocumentManager.ActiveDocument = project;
            //p.Modified += new EventHandler<Document.DocumentPartModifiedEventArgs>(OnDocumentModified);

            Text = Document.DocumentManager.ActiveDocument.Title + " - OWASP Tiger";

            //splitContainer1.Panel1.SuspendLayout();
            //splitContainer1.Panel1.BackColor = SystemColors.AppWorkspace;
            //splitContainer1.Panel1.Controls.Clear();
            //splitContainer1.Panel1.ResumeLayout();
        }

        private void tbtnFileNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void tbtnProjectRun_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet :(");
        }
    }
}
