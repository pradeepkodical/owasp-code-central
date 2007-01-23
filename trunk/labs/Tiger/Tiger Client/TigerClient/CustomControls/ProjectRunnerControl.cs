using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.CustomControls
{
    public partial class ProjectRunnerControl : UserControl
    {
        private Document.Project project;
        private int executingTargetsCount;
        private object executingTargetsCountLock = new object();
        private DateTime timeTestsStarted;
        private DateTime timeTestsCompleted;

        public event EventHandler ProjectCompleted;

        public ProjectRunnerControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
        }

        public Document.Project Project
        {
            get { return project; }
            set { project = value; }
        }

        public void Run()
        {
            if (project == null)
                throw new InvalidOperationException("No project is set.");

            if (!project.IsValid)
                throw new InvalidOperationException("Only valid projects can be run.");

            executingTargetsCount = project.Targets.Count;

            btnStop.Enabled = true;
            btnCreateReport.Enabled = false;

            targetsPanel.SuspendLayout();

            targetsPanel.Controls.Clear();

            foreach (Document.Target target in project.Targets)
            {
                if (target.AutomatedTests.Count != 0)
                {
                    CustomControls.TargetControl tc = new TigerClient.CustomControls.TargetControl();
                    tc.Target = target;
                    tc.TargetCompleted += new EventHandler(tc_TargetCompleted);
                    targetsPanel.Controls.Add(tc);
                }
            }

            targetsPanel.ResumeLayout();

            Show();
            Refresh();

            timeTestsStarted = DateTime.Now;

            foreach (CustomControls.TargetControl tc in targetsPanel.Controls)
                tc.Run();
        }

        public void Stop()
        {
            foreach (CustomControls.TargetControl tc in targetsPanel.Controls)
                tc.Stop();
        }

        private void TestRunnerControl_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = targetsPanel.Bounds;
            r.Inflate(1, 1);

            ControlPaint.DrawVisualStyleBorder(e.Graphics, r);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            Stop();
        }

        private void tc_TargetCompleted(object sender, EventArgs e)
        {
            bool isProjectCompleted = false;

            lock (executingTargetsCountLock)
            {
                executingTargetsCount--;
                if (executingTargetsCount == 0) isProjectCompleted = true;
            }

            if (isProjectCompleted)
            {
                timeTestsCompleted = DateTime.Now;

                if (ProjectCompleted != null)
                    ProjectCompleted(this, new EventArgs());

                btnStop.Enabled = false;
                btnCreateReport.Enabled = true;
            }
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            string html = CreateHtmlReport();
            string tempFile = System.IO.Path.GetTempFileName();
            using (System.IO.StreamWriter sw = System.IO.File.CreateText(tempFile))
            {
                sw.Write(html);
            }

            Report.frmReportViewer f = new TigerClient.Report.frmReportViewer();
            //f.ShowHtml(html);
            f.ShowFile(tempFile);
        }

        private string GetReportArtworkFolderPath()
        {
            string path = null;
            try
            {
                path = System.Configuration.ConfigurationManager.AppSettings["ReportArtworkFolderPath"];
            }
            catch { }

            if (string.IsNullOrEmpty(path))
                path = "..\\..\\Report Images";

            if (System.IO.Path.IsPathRooted(path))
                return path;
            else
                return (System.IO.Path.Combine(Application.StartupPath, path));
        }

        private string CreateHtmlReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Verdana, Arial, Helvetica; font-size: 8pt; }");
            sb.AppendLine("h1 { font-size: 20pt; margin-bottom: 12pt; border-bottom: solid 1px lightblue;}");
            //sb.AppendLine("div.projectName { font-size: 12pt; }");
            sb.AppendLine("div.projectDescription { margin-top: 12pt; margin-bottom: 12pt; }");
            //sb.AppendLine("div.projectTimeContainer { margin-top: 12pt; }");
            sb.AppendLine("span.projectTimeLabel { font-weight: bold; }");
            sb.AppendLine("div.targetContainer { margin-top: 16pt; }");
            sb.AppendLine("div.targetSectionCaption { border-bottom: solid 1px lightblue; font-size: 12pt; font-weight: bold; margin-bottom: 4pt; }");
            sb.AppendLine("div.targetContents { margin-left: 10pt; }");
            sb.AppendLine("div.targetDescription { margin-top: 8pt; }");
            sb.AppendLine("div.targetPathContainer { margin-top: 12pt; }");
            sb.AppendLine("span.targetPathLabel { font-weight: bold; }");
            //sb.AppendLine("span.targetPath { }");
            //sb.AppendLine("div.testSectionCaption { border-bottom: solid 1px lightblue; font-size: 8pt; font-weight: bold; margin-top: 6pt; margin-bottom: 6pt; }");
            sb.AppendLine("table.testsTable { margin-top: 12pt; border: solid 1px silver; }");
            sb.AppendLine("table.testsTable td { border-bottom: solid 1px #E0E0E0; vertical-align: top; }");
            sb.AppendLine("thead { font-family: Verdana, Arial, Helvetica; font-size: 8pt; font-weight: bold; background-color: whitesmoke; }");
            sb.AppendLine("tbody { font-family: Verdana, Arial, Helvetica; font-size: 8pt; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");

            System.Xml.XmlWriterSettings xws = new System.Xml.XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;

            using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(sb, xws))
            {

                xw.WriteStartElement("body");

                // 1. Project display name
                xw.WriteStartElement("h1");
                //xw.WriteAttributeString("class", "projectName");
                xw.WriteString(project.DisplayName);
                xw.WriteEndElement(); // h1

                // 2. Project description
                if (!string.IsNullOrEmpty(project.Description))
                {
                    xw.WriteStartElement("div");
                    xw.WriteAttributeString("class", "projectDescription");
                    xw.WriteString(project.Description);
                    xw.WriteEndElement(); // div
                }

                // 3. Test start and end times
                xw.WriteStartElement("div");
                xw.WriteAttributeString("class", "projectTimeContainer");
                xw.WriteStartElement("span");
                xw.WriteAttributeString("class", "projectTimeLabel");
                xw.WriteString("Tests started: ");
                xw.WriteEndElement(); // span
                xw.WriteStartElement("span");
                xw.WriteAttributeString("class", "projectTime");
                xw.WriteString(timeTestsStarted.ToString());
                xw.WriteEndElement(); // span
                xw.WriteEndElement(); // div

                xw.WriteStartElement("div");
                xw.WriteAttributeString("class", "projectTimeContainer");
                xw.WriteStartElement("span");
                xw.WriteAttributeString("class", "projectTimeLabel");
                xw.WriteString("Tests finished: ");
                xw.WriteEndElement(); // span
                xw.WriteStartElement("span");
                xw.WriteAttributeString("class", "projectTime");
                xw.WriteString(timeTestsCompleted.ToString());
                xw.WriteEndElement(); // span
                xw.WriteEndElement(); // div

                // 4. Targets
                Document.Target target;
                TargetControl targetControl;

                foreach (Control ctl in targetsPanel.Controls)
                {
                    //if (!(ctl is TargetControl)) break;

                    targetControl = ctl as TargetControl;
                    target = targetControl.Target;

                    xw.WriteStartElement("div");
                    xw.WriteAttributeString("class", "targetContainer");

                    // 4.1 Name
                    xw.WriteStartElement("div");
                    xw.WriteAttributeString("class", "targetSectionCaption");
                    xw.WriteString(target.DisplayName);
                    xw.WriteEndElement(); // div

                    xw.WriteStartElement("div");
                    xw.WriteAttributeString("class", "targetContents");

                    // 4.2 Path
                    xw.WriteStartElement("div");
                    xw.WriteAttributeString("class", "targetPathContainer");

                    xw.WriteStartElement("span");
                    xw.WriteAttributeString("class", "targetPathLabel");
                    xw.WriteString("Path: ");
                    xw.WriteEndElement(); // div.targetPathLabel

                    xw.WriteStartElement("span");
                    xw.WriteAttributeString("class", "targetPath");
                    xw.WriteString(target.Path);
                    xw.WriteEndElement(); // div.targetPath

                    xw.WriteEndElement(); // div.targetPathContainer

                    // 4.3 Description
                    if (!string.IsNullOrEmpty(target.Description))
                    {
                        xw.WriteStartElement("div");
                        xw.WriteAttributeString("class", "targetDescription");
                        xw.WriteString(target.Description);
                        xw.WriteEndElement(); // div.targetDescription
                    }

                    // 4.4 Tests
                    if (target.AutomatedTests.Count != 0)
                    {
                        xw.WriteStartElement("table");
                        xw.WriteAttributeString("class", "testsTable");
                        xw.WriteAttributeString("cellspacing", "0");
                        xw.WriteAttributeString("cellpadding", "3");

                        xw.WriteStartElement("thead");
                        xw.WriteStartElement("tr");

                        xw.WriteStartElement("td");
                        xw.WriteAttributeString("style", "width: 20px");
                        xw.WriteRaw("&nbsp;");
                        xw.WriteEndElement(); // td

                        xw.WriteStartElement("td");
                        //xw.WriteAttributeString("style", "width: 20px");
                        xw.WriteString("Test");
                        xw.WriteEndElement(); // td

                        xw.WriteStartElement("td");
                        //xw.WriteAttributeString("style", "width: 20px");
                        xw.WriteString("Message");
                        xw.WriteEndElement(); // td

                        xw.WriteEndElement(); // tr
                        xw.WriteEndElement(); // thead

                        xw.WriteStartElement("tbody");

                        //TargetControl tctl = ctl as TargetControl;
                        foreach (Control ctl2 in targetControl.automatedTestsPanel.Controls)
                        {
                            if (ctl2 is AutomatedTestControl)
                            {
                                AutomatedTestControl actl = ctl2 as AutomatedTestControl;
                                xw.WriteStartElement("tr");

                                xw.WriteStartElement("td");
                                xw.WriteStartElement("img");
                                xw.WriteAttributeString("src", System.IO.Path.Combine(GetReportArtworkFolderPath(), actl.StatusImageFileName));
                                xw.WriteEndElement(); // img
                                xw.WriteEndElement(); // td

                                xw.WriteElementString("td", actl.AutomatedTest.DisplayName);
                                xw.WriteElementString("td", actl.FinalStatusMessage);
                                xw.WriteEndElement(); // tr
                            }
                        }

                        xw.WriteEndElement(); // tbody
                        xw.WriteEndElement(); // table.testsTable
                    }

                    //
                    xw.WriteEndElement(); // div.targetContents
                    xw.WriteEndElement(); // div.targetContainer
                }

                // body
                xw.WriteEndElement(); // body
            }

            sb.AppendLine();
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
