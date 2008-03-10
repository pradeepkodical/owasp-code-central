using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Owasp.Osg.Controller.Controls
{
    public partial class SiteTreeControl : UserControl
    {
        Document.Project project;

        public SiteTreeControl()
        {
            InitializeComponent();
        }

        public Document.Project Project
        {
            get { return project; }
            set
            {
                project = value;
                ReloadNodes();
            }
        }

        protected void ReloadNodes()
        {
            treeControl.BeginUpdate();
            treeControl.Nodes.Clear();

            if (project != null)
                CreateNodeForDocumentPart(project.Site, null);

            treeControl.EndUpdate();
        }

        protected void CreateNodeForDocumentPart(Document.DocumentPart documentPart, TreeNode parentNode)
        {
            if (documentPart is Document.Site)
            {
                Document.Site site = documentPart as Document.Site;
                TreeNode node = new TreeNode("site: " + project.Name);
                node.Tag = site;
                node.ImageKey = node.SelectedImageKey = "site";
                
                foreach (Document.DocumentPart childPart in site.Contents)
                    CreateNodeForDocumentPart(childPart, node);

                treeControl.Nodes.Add(node);
            }
            else if (documentPart is Document.Folder)
            {
                Document.Folder folder = documentPart as Document.Folder;
                TreeNode node = new TreeNode("folder: " + folder.Name);
                node.Tag = folder;
                node.ImageKey = node.SelectedImageKey = "folder_closed";

                foreach (Document.DocumentPart childPart in folder.Contents)
                    CreateNodeForDocumentPart(childPart, node);

                parentNode.Nodes.Add(node);
            }
            else // File
            {
                Document.File file = documentPart as Document.File;
                TreeNode node = new TreeNode("file: " + file.Name + ", mapped to: " + file.MappedTo);
                node.Tag = file;
                node.ImageKey = node.SelectedImageKey = "parameter";

                parentNode.Nodes.Add(node);
            }
        }
    }
}
