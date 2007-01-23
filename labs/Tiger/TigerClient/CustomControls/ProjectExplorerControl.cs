using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.CustomControls
{
    public partial class ProjectExplorerControl : UserControl
    {
        public event EventHandler CloseButtonClick;
        public event EventHandler SelectedObjectChanged;

        protected Document.Project project = null;

        public ProjectExplorerControl()
        {
            InitializeComponent();
            treeViewAdapter.TreeView = tree;
        }

        public void SelectNodeFor(Document.DocumentPart part)
        {
            if (part != null)
            {
                TreeNode[] foundNodes = tree.Nodes.Find(part.ID.ToString(), true);
                if (foundNodes.Length != 0) tree.SelectedNode = foundNodes[0];
            }
        }

        public object SelectedObject
        {
            get
            {
                if (tree.SelectedNode == null)
                    return null;
                else
                    return tree.SelectedNode.Tag;
            }
        }

        public Document.Project Project
        {
            get { return project; }
            set
            {
                if (project != null)
                    project.Modified -= new EventHandler<Document.DocumentPartModifiedEventArgs>(OnDocumentModified);

                project = value;
                LoadTree();
                if (tree.Nodes.Count != 0) tree.SelectedNode = tree.Nodes[0];
                
                if (project != null)
                    project.Modified += new EventHandler<Document.DocumentPartModifiedEventArgs>(OnDocumentModified);
            }
        }

        public void ReloadProject()
        {
            Document.Project p = project;
            Project = null;
            Project = p;
        }

        private void LoadTree()
        {
            tree.BeginUpdate();
            tree.Nodes.Clear();

            if (project != null)
            {
                treeViewAdapter.AddNodeFor(project, false);
                tree.Nodes[0].Expand();
                //tree.Nodes[0].ContextMenuStrip = contextMenuTest;
            }

            tree.EndUpdate();
        }

        private void windowHeaderControl1_MouseDown(object sender, MouseEventArgs e)
        {
            tree.Focus();
        }

        private void ProjectExplorerControl_Leave(object sender, EventArgs e)
        {
            windowHeaderControl1.IsActive = false;
        }

        private void ProjectExplorerControl_Enter(object sender, EventArgs e)
        {
            windowHeaderControl1.IsActive = true;
        }

        private void windowHeaderControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if (CloseButtonClick != null)
                CloseButtonClick(this, e);
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SelectedObjectChanged != null)
                SelectedObjectChanged(this, new EventArgs());
        }

        private void OnDocumentModified(object sender, Document.DocumentPartModifiedEventArgs e)
        {
            switch (e.ModificationType)
            {
                case Document.DocumentPartModificationType.ChildDocumentPartsCleared:
                    treeViewAdapter.ClearChildNodesFor(e.AffectedDocumentPart, e.PropertyName);
                    break;
                case Document.DocumentPartModificationType.DocumentPartAdded:
                    treeViewAdapter.AddNodeFor(e.AffectedDocumentPart, true);
                    break;
                case Document.DocumentPartModificationType.DocumentPartRemoved:
                    treeViewAdapter.RemoveNodeFor(e.AffectedDocumentPart);
                    break;
                case Document.DocumentPartModificationType.DocumentPartPropertyModified:
                    treeViewAdapter.RefreshNodeFor(e.AffectedDocumentPart);
                    break;
            }
        }

        private void tree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageKey == "folder_open")
                e.Node.ImageKey = e.Node.SelectedImageKey = "folder_closed";
        }

        private void tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageKey == "folder_closed")
                e.Node.ImageKey = e.Node.SelectedImageKey = "folder_open";
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewHitTestInfo i = tree.HitTest(e.Location);
                if (i.Location == TreeViewHitTestLocations.Label || i.Location == TreeViewHitTestLocations.Image || i.Location == TreeViewHitTestLocations.StateImage)
                {
                    tree.SelectedNode = e.Node;
                    Document.DocumentPart part = e.Node.Tag as Document.DocumentPart;
                    ContextMenuStrip menu = treeViewAdapter.GetContextMenuFor(part);
                    if (menu != null) menu.Show(tree.PointToScreen(e.Location));
                }
            }
        }
    }
}
