using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Owasp.SiteGenerator.utils
{
    class WindowsForms
    {
        public static void loadDirectoriesIntoListBox(ListBox lbToPopulate, string strPathToDirectoriesToLoad, string strSearchPattern)
        {
            lbToPopulate.Items.Clear();
            foreach (DirectoryInfo diToProcess in new DirectoryInfo(strPathToDirectoriesToLoad).GetDirectories(strSearchPattern))
                if (diToProcess.Name.Substring(0, 1) != "_")						// hide all dirs that start with an _
                    lbToPopulate.Items.Add(diToProcess.Name);
            if (lbToPopulate.Items.Count > 0)
                lbToPopulate.SelectedIndex = 0;
        }

        public static void loadFilesIntoListView(ListView lvToPopulate, string strPathToFilesToLoad, string strFileFilter)
        {
            lvToPopulate.Items.Clear();
            foreach (FileInfo fiToProcess in new DirectoryInfo(strPathToFilesToLoad).GetFiles(strFileFilter))
                lvToPopulate.Items.Add(fiToProcess.Name);
        }

        public static void loadFilesIntoListBox(ListBox lbToPopulate, string strPathToFilesToLoad, string strFileFilter)
        {
            lbToPopulate.Items.Clear();
            foreach (FileInfo fiToProcess in new DirectoryInfo(strPathToFilesToLoad).GetFiles(strFileFilter))
                lbToPopulate.Items.Add(fiToProcess.Name);
            if (lbToPopulate.Items.Count > 0)
                lbToPopulate.SelectedIndex = 0;
        }

        public static void loadFilesIntoComboBox(ComboBox cbToPopulate, string strPathToFilesToLoad, string strFileFilter)
        {
            cbToPopulate.Items.Clear();
            foreach (FileInfo fiToProcess in new DirectoryInfo(strPathToFilesToLoad).GetFiles(strFileFilter))
                cbToPopulate.Items.Add(fiToProcess.Name);
            if (cbToPopulate.Items.Count > 0)
                cbToPopulate.SelectedIndex = 0;
        }
        /*
        public static void populateListBoxWithFiles(ListBox lbListBoxToPopulate, string strPathToFiles,string strExtension)
        { 
            lbListBoxToPopulate.Items.Clear();
            foreach (string strFilePath in Directory.GetFiles(strPathToFiles,strExtension))           
                lbListBoxToPopulate.Items.Add(Path.GetFileName(strFilePath));            
        }*/
    }
}
