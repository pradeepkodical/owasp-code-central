using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.ControlAdapters
{
    public partial class TreeViewAdapter : Component
    {
        public TreeViewAdapter()
        {
            InitializeComponent();
        }

        public TreeViewAdapter(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected TreeView treeView;

        public TreeView TreeView
        {
            get { return treeView; }
            set { treeView = value; }
        }

        public ContextMenuStrip GetContextMenuFor(Document.DocumentPart part)
        {
            if (part == null) return null;

            if (part is Document.Alert)
            {
                return ctxAlert;
            }
            else if (part is Document.TestParameter)
            {
                return ctxTestParameter;
            }
            else if (part is Document.AutomatedTest)
            {
                return ctxTest;
            }
            else if (part is Document.Target)
            {
                return ctxTarget;
            }
            else if (part is Document.Project)
            {
                return ctxProject;
            }
            else
                throw new ApplicationException("Internal error: Invalid document part type: " + part.GetType().ToString());
        }

        public void AddNodeFor(Document.DocumentPart part, bool refreshParent)
        {
            if (part is Document.Alert)
            {
                AddAlert(part as Document.Alert, null, refreshParent);
            }
            else if (part is Document.TestParameter)
            {
                AddTestParameter(part as Document.TestParameter, null, refreshParent);
            }
            else if (part is Document.AutomatedTest)
            {
                AddTest(part as Document.AutomatedTest, null, refreshParent);
            }
            else if (part is Document.Target)
            {
                AddTarget(part as Document.Target, null, refreshParent);
            }
            else if (part is Document.Project)
            {
                AddProject(part as Document.Project);
            }
            else
                throw new ApplicationException("Internal error: Invalid document part type: " + part.GetType().ToString());
        }

        private void AddProject(Document.Project project)
        {
            TreeNode projectNode = new TreeNode(project.DisplayName);
            projectNode.Tag = project;
            projectNode.ImageKey = projectNode.SelectedImageKey = (project.IsValid ? "project" : "project_invalid");
            projectNode.Name = project.ID.ToString();
            projectNode.ToolTipText = project.ErrorMessage;
            //projectNode.ContextMenuStrip = ctxProject;
            treeView.Nodes.Add(projectNode);

            TreeNode targetContainer = projectNode;
            if (Settings.Default.ShowTargetsInFolders)
            {
                targetContainer = projectNode.Nodes.Add("Targets");
                targetContainer.ImageKey = targetContainer.SelectedImageKey = "folder_closed";
                targetContainer.Name = "Targets";
            }

            foreach (Document.Target t in project.Targets)
                AddTarget(t, targetContainer, false);
        }

        private void AddTarget(Document.Target target, TreeNode containerNode, bool refreshParent)
        {
            // 1. If the container node is not provided, we must find it first
            if (containerNode == null)
            {
                TreeNode projectNode = treeView.Nodes.Find(target.Parent.ID.ToString(), true)[0];

                if (Settings.Default.ShowTargetsInFolders)
                    containerNode = projectNode.Nodes.Find("Targets", false)[0];
                else
                    containerNode = projectNode;
            }

            TreeNode targetNode = new TreeNode(target.DisplayName);
            targetNode.Tag = target;
            targetNode.ImageKey = targetNode.SelectedImageKey = (target.IsValid ? "target" : "target_invalid");
            targetNode.Name = target.ID.ToString();
            targetNode.ToolTipText = target.ErrorMessage;
            //targetNode.ContextMenuStrip = ctxTarget;
            containerNode.Nodes.Add(targetNode);

            TreeNode testsContainer = targetNode;
            if (Settings.Default.ShowTestsInFolders)
            {
                testsContainer = targetNode.Nodes.Add("Automated Tests");
                testsContainer.ImageKey = testsContainer.SelectedImageKey = "folder_closed";
                testsContainer.Name = "Automated Tests";
            }

            foreach (Document.AutomatedTest test in target.AutomatedTests)
                AddTest(test, testsContainer, false);

            if (refreshParent) RefreshProject(target.Parent as Document.Project);
        }

        private void AddTest(Document.AutomatedTest test, TreeNode containerNode, bool refreshParent)
        {
            // 1. If the container node is not provided, we must find it first
            if (containerNode == null)
            {
                TreeNode targetNode = treeView.Nodes.Find(test.Parent.ID.ToString(), true)[0];

                if (Settings.Default.ShowTestsInFolders)
                    containerNode = targetNode.Nodes.Find("Automated Tests", false)[0];
                else
                    containerNode = targetNode;
            }

            TreeNode testNode = new TreeNode(test.DisplayName);
            testNode.Tag = test;
            testNode.ImageKey = testNode.SelectedImageKey = (test.IsValid ? "test" : "test_invalid");
            testNode.Name = test.ID.ToString();
            testNode.ToolTipText = test.ErrorMessage;
            //testNode.ContextMenuStrip = ctxTest;
            containerNode.Nodes.Add(testNode);

            // Parameters
            TreeNode parametersContainer = testNode;
            if (Settings.Default.ShowTestParametersInFolders)
            {
                parametersContainer = testNode.Nodes.Add("Parameters");
                parametersContainer.ImageKey = parametersContainer.SelectedImageKey = "folder_closed";
                parametersContainer.Name = "Parameters";
            }

            foreach (Document.TestParameter parameter in test.Parameters)
                AddTestParameter(parameter, parametersContainer, false);

            // Alerts
            TreeNode alertsContainer = testNode;
            if (Settings.Default.ShowAlertsInFolders)
            {
                alertsContainer = testNode.Nodes.Add("Alerts");
                alertsContainer.ImageKey = alertsContainer.SelectedImageKey = "folder_closed";
                alertsContainer.Name = "Alerts";
            }

            foreach (Document.Alert alert in test.Alerts)
                AddAlert(alert, alertsContainer, false);

            if (refreshParent) RefreshTarget(test.Parent as Document.Target);
        }

        private void AddTestParameter(Document.TestParameter parameter, TreeNode containerNode, bool refreshParent)
        {
            // 1. If the container node is not provided, we must find it first
            if (containerNode == null)
            {
                TreeNode testNode = treeView.Nodes.Find(parameter.Parent.ID.ToString(), true)[0];

                if (Settings.Default.ShowTestParametersInFolders)
                    containerNode = testNode.Nodes.Find("Parameters", false)[0];
                else
                    containerNode = testNode;
            }

            TreeNode parameterNode = new TreeNode(parameter.DisplayName);
            parameterNode.Tag = parameter;
            parameterNode.ImageKey = parameterNode.SelectedImageKey = (parameter.IsValid ? "parameter" : "parameter_invalid");
            parameterNode.Name = parameter.ID.ToString();
            parameterNode.ToolTipText = parameter.ErrorMessage;

            containerNode.Nodes.Add(parameterNode);
            //parameterNode.ContextMenuStrip = ctxTestParameter;

            if (refreshParent) RefreshTest(parameter.Parent as Document.AutomatedTest);
        }

        private void AddAlert(Document.Alert alert, TreeNode containerNode, bool refreshParent)
        {
            // 1. If the container node is not provided, we must find it first
            if (containerNode == null)
            {
                TreeNode testNode = treeView.Nodes.Find(alert.Parent.ID.ToString(), true)[0];

                if (Settings.Default.ShowAlertsInFolders)
                    containerNode = testNode.Nodes.Find("Alerts", false)[0];
                else
                    containerNode = testNode;
            }

            TreeNode alertNode = new TreeNode(alert.DisplayName);
            alertNode.Tag = alert;
            alertNode.ImageKey = alertNode.SelectedImageKey = (alert.IsValid ? "alert" : "alert_invalid");
            alertNode.Name = alert.ID.ToString();
            alertNode.ToolTipText = alert.ErrorMessage;

            containerNode.Nodes.Add(alertNode);
            //parameterNode.ContextMenuStrip = ctxTestParameter;

            if (refreshParent) RefreshTest(alert.Parent as Document.AutomatedTest);
        }

        //////////////////////////////////////////////////////////////////////////////////////////

        public void RefreshNodeFor(Document.DocumentPart part)
        {
            if (part is Document.Alert)
            {
                RefreshAlert(part as Document.Alert);
            }
            else if (part is Document.TestParameter)
            {
                RefreshTestParameter(part as Document.TestParameter);
            }
            else if (part is Document.AutomatedTest)
            {
                RefreshTest(part as Document.AutomatedTest);
            }
            else if (part is Document.Target)
            {
                RefreshTarget(part as Document.Target);
            }
            else if (part is Document.Project)
            {
                RefreshProject(part as Document.Project);
            }
            else
                throw new ApplicationException("Internal error: Invalid document part type: " + part.GetType().ToString());
        }

        private void RefreshAlert(Document.Alert alert)
        {
            TreeNode alertNode = treeView.Nodes.Find(alert.ID.ToString(), true)[0];
            alertNode.Text = alert.DisplayName;
            alertNode.ImageKey = alertNode.SelectedImageKey = (alert.IsValid ? "alert" : "alert_invalid");
            alertNode.ToolTipText = alert.ErrorMessage;

            RefreshTest(alert.Parent as Document.AutomatedTest);
        }

        private void RefreshTestParameter(Document.TestParameter parameter)
        {
            TreeNode parameterNode = treeView.Nodes.Find(parameter.ID.ToString(), true)[0];
            parameterNode.Text = parameter.DisplayName;
            parameterNode.ImageKey = parameterNode.SelectedImageKey = (parameter.IsValid ? "parameter" : "parameter_invalid");
            parameterNode.ToolTipText = parameter.ErrorMessage;

            RefreshTest(parameter.Parent as Document.AutomatedTest);
        }

        private void RefreshTest(Document.AutomatedTest test)
        {
            TreeNode testNode = treeView.Nodes.Find(test.ID.ToString(), true)[0];
            testNode.Text = test.DisplayName;
            testNode.ImageKey = testNode.SelectedImageKey = (test.IsValid ? "test" : "test_invalid");
            testNode.Name = test.ID.ToString();
            testNode.ToolTipText = test.ErrorMessage;

            RefreshTarget(test.Parent as Document.Target);
        }

        private void RefreshTarget(Document.Target target)
        {
            TreeNode targetNode = treeView.Nodes.Find(target.ID.ToString(), true)[0];
            targetNode.Text = target.DisplayName;
            targetNode.Tag = target;
            targetNode.ImageKey = targetNode.SelectedImageKey = (target.IsValid ? "target" : "target_invalid");
            targetNode.Name = target.ID.ToString();
            targetNode.ToolTipText = target.ErrorMessage;

            RefreshProject(target.Parent as Document.Project);
        }

        private void RefreshProject(Document.Project project)
        {
            TreeNode projectNode = treeView.Nodes.Find(project.ID.ToString(), true)[0];
            projectNode.Text = project.DisplayName;
            projectNode.Tag = project;
            projectNode.ImageKey = projectNode.SelectedImageKey = (project.IsValid ? "project" : "project_invalid");
            projectNode.Name = project.ID.ToString();
            projectNode.ToolTipText = project.ErrorMessage;
        }

        //////////////////////////////////////////////////////////////////////////////////////////

        public void RemoveNodeFor(Document.DocumentPart part)
        {
            if (part is Document.Alert)
            {
                RemoveAlert(part as Document.Alert);
            }
            else if (part is Document.TestParameter)
            {
                RemoveTestParameter(part as Document.TestParameter);
            }
            else if (part is Document.AutomatedTest)
            {
                RemoveTest(part as Document.AutomatedTest);
            }
            else if (part is Document.Target)
            {
                RemoveTarget(part as Document.Target);
            }
            else if (part is Document.Project)
            {
                //RemoveProject(part as Document.Project);
            }
            else
                throw new ApplicationException("Internal error: Invalid document part type: " + part.GetType().ToString());
        }

        private void RemoveAlert(Document.Alert alert)
        {
            TreeNode alertNode = treeView.Nodes.Find(alert.ID.ToString(), true)[0];
            alertNode.Parent.Nodes.Remove(alertNode);

            RefreshTest(alert.Parent as Document.AutomatedTest);
        }

        private void RemoveTestParameter(Document.TestParameter parameter)
        {
            TreeNode parameterNode = treeView.Nodes.Find(parameter.ID.ToString(), true)[0];
            parameterNode.Parent.Nodes.Remove(parameterNode);

            RefreshTest(parameter.Parent as Document.AutomatedTest);
        }

        private void RemoveTest(Document.AutomatedTest test)
        {
            TreeNode testNode = treeView.Nodes.Find(test.ID.ToString(), true)[0];
            testNode.Parent.Nodes.Remove(testNode);

            RefreshTarget(test.Parent as Document.Target);
        }

        private void RemoveTarget(Document.Target target)
        {
            TreeNode targetNode = treeView.Nodes.Find(target.ID.ToString(), true)[0];
            targetNode.Parent.Nodes.Remove(targetNode);

            RefreshProject(target.Parent as Document.Project);
        }

        //////////////////////////////////////////////////////////////////////////////////////////

        public void ClearChildNodesFor(Document.DocumentPart part, string collectionName)
        {
            if (part is Document.AutomatedTest)
            {
                ClearChildNodesTest(part as Document.AutomatedTest, collectionName);
            }
            else if (part is Document.Target)
            {
                ClearChildNodesTarget(part as Document.Target, collectionName);
            }
            else if (part is Document.Project)
            {
                ClearChildNodesProject(part as Document.Project, collectionName);
            }
            else
                throw new ApplicationException("Internal error: Invalid document part type: " + part.GetType().ToString());
        }

        private void ClearChildNodesTest(Document.AutomatedTest test, string collectionName)
        {
            if (collectionName == "Parameters")
            {
                TreeNode parametersContainer = treeView.Nodes.Find(test.ID.ToString(), true)[0];
                if (Settings.Default.ShowTestParametersInFolders)
                    parametersContainer = parametersContainer.Nodes.Find("Parameters", false)[0];

                parametersContainer.Nodes.Clear();

                //RefreshTest(test);
            }
            else if (collectionName == "Alerts")
            {
                TreeNode testNode = treeView.Nodes.Find(test.ID.ToString(), true)[0];
                if (Settings.Default.ShowAlertsInFolders)
                {
                    TreeNode alertsContainer = testNode.Nodes.Find("Alerts", false)[0];
                    alertsContainer.Nodes.Clear();
                }
                else
                {
                    List<TreeNode> nodesToRemove = new List<TreeNode>();

                    foreach (TreeNode child in testNode.Nodes)
                        if (child.Tag is Document.Alert) nodesToRemove.Add(child);

                    foreach (TreeNode nodeToRemove in nodesToRemove)
                        testNode.Nodes.Remove(nodeToRemove);
                }
            }

            RefreshTest(test);
        }

        private void ClearChildNodesTarget(Document.Target target, string collectionName)
        {
            if (collectionName == "Automated Tests")
            {
                TreeNode testsContainer = treeView.Nodes.Find(target.ID.ToString(), true)[0];
                if (Settings.Default.ShowTestsInFolders)
                    testsContainer = testsContainer.Nodes.Find("Automated Tests", false)[0];

                testsContainer.Nodes.Clear();

                RefreshTarget(target);
            }
        }

        private void ClearChildNodesProject(Document.Project project, string collectionName)
        {
            if (collectionName == "Targets")
            {
                TreeNode targetsContainer = treeView.Nodes.Find(project.ID.ToString(), true)[0];
                if (Settings.Default.ShowTargetsInFolders)
                    targetsContainer = targetsContainer.Nodes.Find("Targets", false)[0];

                targetsContainer.Nodes.Clear();

                RefreshProject(project);
            }
        }

        private void ctxProjectAddTarget_Click(object sender, EventArgs e)
        {
            Document.Project project = treeView.SelectedNode.Tag as Document.Project;
            Document.Target newTarget = new Document.Target();
            project.Targets.Add(newTarget);

            TreeNode[] findNodes = treeView.Nodes.Find(newTarget.ID.ToString(), true);
            if (findNodes.Length != 0)
                treeView.SelectedNode = findNodes[0];
        }

        private void ctxTargetAddTest_Click(object sender, EventArgs e)
        {
            Document.Target target = treeView.SelectedNode.Tag as Document.Target;
            Document.AutomatedTest newTest = new TigerClient.Document.AutomatedTest();
            target.AutomatedTests.Add(newTest);

            TreeNode[] findNodes = treeView.Nodes.Find(newTest.ID.ToString(), true);
            if (findNodes.Length != 0)
                treeView.SelectedNode = findNodes[0];
        }

        private void ctxTestAddTestParameter_Click(object sender, EventArgs e)
        {
            Document.AutomatedTest test = treeView.SelectedNode.Tag as Document.AutomatedTest;
            Document.TestParameter newTestParameter = new TigerClient.Document.TestParameter();
            test.Parameters.Add(newTestParameter);

            TreeNode[] findNodes = treeView.Nodes.Find(newTestParameter.ID.ToString(), true);
            if (findNodes.Length != 0)
                treeView.SelectedNode = findNodes[0];
        }

        private void ctxTargetDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete '" + treeView.SelectedNode.Text + "'?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Document.Target target = treeView.SelectedNode.Tag as Document.Target;
                Document.Project project = target.Parent as Document.Project;
                project.Targets.Remove(target);
            }
        }

        private void ctxTestDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete '" + treeView.SelectedNode.Text + "'?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Document.AutomatedTest test = treeView.SelectedNode.Tag as Document.AutomatedTest;
                Document.Target target = test.Parent as Document.Target;
                target.AutomatedTests.Remove(test);
            }
        }

        private void ctxTestParameterDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete '" + treeView.SelectedNode.Text + "'?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Document.TestParameter parameter = treeView.SelectedNode.Tag as Document.TestParameter;
                Document.AutomatedTest test = parameter.Parent as Document.AutomatedTest;
                test.Parameters.Remove(parameter);
            }
        }

        private void ctxTestTestRun_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                Document.AutomatedTest test = treeView.SelectedNode.Tag as Document.AutomatedTest;
                //if (test != null) test.Run(true);
                if (test != null)
                {
                    Utilities.frmSingleTestRunner f = new TigerClient.Utilities.frmSingleTestRunner();
                    f.Run(test);
                }

                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void ctxAlertDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete '" + treeView.SelectedNode.Text + "'?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Document.Alert alert = treeView.SelectedNode.Tag as Document.Alert;
                Document.AutomatedTest test = alert.Parent as Document.AutomatedTest;
                test.Alerts.Remove(alert);
            }
        }

        private void ctxTestAddAlert_Click(object sender, EventArgs e)
        {
            Document.AutomatedTest test = treeView.SelectedNode.Tag as Document.AutomatedTest;
            Document.Alert newAlert = new TigerClient.Document.Alert();
            test.Alerts.Add(newAlert);

            TreeNode[] findNodes = treeView.Nodes.Find(newAlert.ID.ToString(), true);
            if (findNodes.Length != 0)
                treeView.SelectedNode = findNodes[0];
        }
    }
}
