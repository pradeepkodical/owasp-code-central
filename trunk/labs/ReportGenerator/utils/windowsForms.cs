using System;
using System.Windows.Forms;
using System.IO;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for windowsForms.
	/// </summary>
	public class windowsForms
	{
		public windowsForms()
		{
		}


		public static bool loadDirectoriesIntoListBox(ListBox lbToPopulate, string strPathToDirectoriesToLoad ,string strSearchPattern)
		{	
			try
			{
				lbToPopulate.Items.Clear();
				foreach(DirectoryInfo diToProcess in new DirectoryInfo(strPathToDirectoriesToLoad).GetDirectories(strSearchPattern))
                    if (diToProcess.Name.Substring(0, 1) != "_" && diToProcess.Name !="CVS")						// hide all dirs that start with an _ and are called CVS
						lbToPopulate.Items.Add(diToProcess.Name);
				if (lbToPopulate.Items.Count>0)
					lbToPopulate.SelectedIndex=0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in loadDirectoriesIntoListBox:" + ex.Message);
				return false;
			}
			return true;
		}

		public static bool loadDirectoriesIntoComboBox(ComboBox cbToPopulate, string strPathToDirectoriesToLoad ,string strSearchPattern)
		{	
			try
			{
				cbToPopulate.Items.Clear();
				foreach(DirectoryInfo diToProcess in new DirectoryInfo(strPathToDirectoriesToLoad).GetDirectories(strSearchPattern))
					if (cbToPopulate.Name.Substring(0,1) != "_")						// hide all dirs that start with an _
						cbToPopulate.Items.Add(diToProcess.Name);
				if (cbToPopulate.Items.Count>0)
					cbToPopulate.SelectedIndex=0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in loadDirectoriesIntoComboBox:" + ex.Message);
				return false;
			}
			return true;
		}

		public static bool loadFilesIntoListView(ListView lvToPopulate, string strPathToFilesToLoad, string strFileFilter)
		{
			try
			{
				lvToPopulate.Items.Clear();
				foreach(FileInfo fiToProcess in new DirectoryInfo(strPathToFilesToLoad).GetFiles(strFileFilter))
					lvToPopulate.Items.Add(fiToProcess.Name);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in loadFilesIntoListView:" + ex.Message);
				return false;
			}
			return true;
		}
		
		public static bool loadFilesIntoListBox(ListBox lbToPopulate, string strPathToFilesToLoad, string strFileFilter)
		{	
			try
			{
				lbToPopulate.Items.Clear();
				foreach(FileInfo fiToProcess in new DirectoryInfo(strPathToFilesToLoad).GetFiles(strFileFilter))
					lbToPopulate.Items.Add(fiToProcess.Name);
				if (lbToPopulate.Items.Count>0)
					lbToPopulate.SelectedIndex=0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in loadFilesIntoListBox:" + ex.Message);
				return false;
			}
			return true;
		}

		public static bool loadFilesIntoComboBox(ComboBox cbToPopulate, string strPathToFilesToLoad, string strFileFilter)
		{		
			try
			{
				cbToPopulate.Items.Clear();
				foreach(FileInfo fiToProcess in new DirectoryInfo(strPathToFilesToLoad).GetFiles(strFileFilter))
					cbToPopulate.Items.Add(fiToProcess.Name);
				if (cbToPopulate.Items.Count>0)
					cbToPopulate.SelectedIndex=0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error in loadFilesIntoComboBox:" + ex.Message);
				return false;
			}
			return true;
		}

		public static int findItemInListBox(ListBox lbListBoxToSearch, string strItemToFind)
		{
			for(int i =0 ; i<lbListBoxToSearch.Items.Count;i++)
				if (lbListBoxToSearch.Items[i].ToString() == strItemToFind)
					return i;
			return -1;
		}

		public static void addMessageToTextBox_top(TextBox tbToUpadate, string strMessageToAdd)
		{
			tbToUpadate.Text =  "[" + DateTime.Now.ToShortTimeString()+"] " + strMessageToAdd + Environment.NewLine + tbToUpadate.Text ; 
		}

		public static void addMessageToTextBox_bottom(TextBox tbToUpadate, string strMessageToAdd)
		{
			tbToUpadate.Text += Environment.NewLine  + "[" + DateTime.Now.ToShortTimeString()+"] " + strMessageToAdd; 
		}
	}
}
