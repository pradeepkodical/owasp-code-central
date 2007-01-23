using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.Report
{
    public partial class ProjectPage : UserControl, Wizard.IWizardPage
    {
        protected Wizard.IWizard wizard;
        protected Report.Project project;

        public ProjectPage()
        {
            InitializeComponent();
        }

        public void DisplayData()
        {
            if (project != null)
            {
                txtProjectName.Text = project.Name;
                txtProjectDescription.Text = project.Description;
                dtpStartDate.Value = project.TimeStarted.Date;
                dtpStartTime.Value = project.TimeStarted;
                dtpEndDate.Value = project.TimeFinished.Date;
                dtpEndTime.Value = project.TimeFinished;
                txtTesterName.Text = project.TestersName;
                txtTestersComments.Text = project.TestersComments;
            }
        }

        #region IWizardPage Members

        public TigerClient.Wizard.IWizard Wizard
        {
            get { return wizard; }
            set { wizard = value; }
        }

        public string Caption
        {
            get { return "Project Details"; }
        }

        public string Description
        {
            get { return "Use this page to enter project details."; }
        }

        public bool IsVisible
        {
            get { return this.Visible; }
            set { this.Visible = value; }
        }

        public object PageData
        {
            get { return project; }
            set
            {
                project = (Report.Project)value;
                DisplayData();
            }
        }

        public void UpdateData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
