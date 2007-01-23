using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TigerClient.Wizard;

namespace TigerClient.Report
{
    public partial class frmReportWizard : Form, Wizard.IWizard
    {
        private Report.Project projectReport;// = new TigerClient.Report.Project();
        private int currentPageIndex = -1;
        private List<Wizard.IWizardPage> pages = new List<IWizardPage>();

        public frmReportWizard()
        {
            InitializeComponent();
        }

        public void ShowReport(Report.Project project)
        {
            projectReport = project;
            ShowDialog();
        }

        #region IWizard Members

        public bool MoveNextEnabled
        {
            get { return btnNext.Enabled; }
            set { btnNext.Enabled = value; }
        }

        public bool MoveBackEnabled
        {
            get { return btnBack.Enabled; }
            set { btnBack.Enabled = value; }
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CreateWizardPages()
        {
            IWizardPage projectPage = new ProjectPage();
            projectPage.PageData = projectReport;

            IWizardPage[] pagesToAdd = new IWizardPage[] { projectPage };

            PanelPagesContainer.SuspendLayout();

            foreach (IWizardPage page in pagesToAdd)
            {
                pages.Add(page);
                Control ctl = page as Control;
                ctl.Dock = DockStyle.Fill;
                PanelPagesContainer.Controls.Add(ctl);
            }

            PanelPagesContainer.ResumeLayout();
        }

        private void frmReportWizard_Load(object sender, EventArgs e)
        {
            CreateWizardPages();
            if (pages.Count > 0) ShowPage(0);
        }

        private void ShowPage(int pageIndex)
        {
            PanelPagesContainer.SuspendLayout();

            try
            {
                if (currentPageIndex != -1) pages[currentPageIndex].IsVisible = false;

                MoveBackEnabled = (pageIndex > 0);

                if (pageIndex == (pages.Count - 1))
                    btnNext.Text = "&Finish";
                else
                    btnNext.Text = "&Next >";

                lblCaption.Text = pages[pageIndex].Caption;
                lblDescription.Text = pages[pageIndex].Description;

                pages[pageIndex].IsVisible = true;
                currentPageIndex = pageIndex;
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            PanelPagesContainer.ResumeLayout();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                pages[currentPageIndex].UpdateData();
                if (currentPageIndex < (pages.Count - 1))
                {
                    ShowPage(currentPageIndex + 1);
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentPageIndex > 0) ShowPage(currentPageIndex - 1);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, Panel1.ClientRectangle, Border3DStyle.Etched, Border3DSide.Bottom);
        }
    }
}