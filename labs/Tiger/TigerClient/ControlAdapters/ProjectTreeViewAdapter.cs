using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TigerClient.ControlAdapters
{
    class ProjectTreeViewAdapter
    {
        protected Document.Project project;
        protected TreeView treeView;

        public ProjectTreeViewAdapter(Document.Project project, TreeView treeView)
        {
            this.project = project;
            this.treeView = treeView;
        }

        public void PopulateProjectTree()
        {
            treeView.BeginUpdate();



            treeView.EndUpdate();
        }
    }
}
