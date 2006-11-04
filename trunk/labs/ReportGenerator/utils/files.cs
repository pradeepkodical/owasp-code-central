using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for files.
	/// </summary>
    /// 09-Sep-2006 - Mike : Modified the GetFileContents method by removing the try/catch and adding in 
    ///                      parameter for prompting the user if the file is not found.  I did this because
    ///                      I kept getting prompts for the release notes and users don't usually care about
    ///                      those files.  
	public class files
	{
		public files()
		{
		}

		public static string returnUniqueFileName(string strExtension)
		{
			if (strExtension.Length>0 && strExtension[0] != '.')
				strExtension = "." + strExtension;
			return Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + strExtension;
		}

		public static string returnFullPathToUniqueFileName(string strTargetDir, string strExtension)
		{
			return Path.Combine(Environment.CurrentDirectory,Path.Combine(strTargetDir,returnUniqueFileName(strExtension)));
		}

        public static string GetFileContents(string strFileToLoad)
        {
            return GetFileContents(strFileToLoad, true);
        }

        /// <summary>
        ///   This method loads a file and then streams back the contents as a string.  
        /// </summary>
        /// <param name="strFileToLoad">The file we wish to get the contents of</param>
        /// <param name="PromptUserForDifferentFileLocation">Specifies if we want the user to try
        /// and find the file somewhere else or not.  If it is a non-essential file than we 
        /// probably don't care if the user sees it or not.</param>
        /// <returns>The contents of the specified file</returns>
		public static string GetFileContents(string strFileToLoad, bool PromptUserForDifferentFileLocation)
		{
			string strFileContents = "";
            if (!System.IO.File.Exists(strFileToLoad))
            {
                if (PromptUserForDifferentFileLocation && 
                    DialogResult.Yes == MessageBox.Show("File does not exist. " + Environment.NewLine +
                                                         Environment.NewLine + "Do you want to try to find it?",
                                                         "Error Opening File",
                                                         MessageBoxButtons.YesNo))
                {
                    OpenFileDialog od = new OpenFileDialog();
                    od.InitialDirectory = Environment.CurrentDirectory;
                    od.Multiselect = false;
                    if (od.ShowDialog() == DialogResult.OK)
                    {
                        return GetFileContents(od.FileName);	
                    }
                }
                    
            } 
            else 
            {
			    StreamReader srFileContents= new StreamReader(strFileToLoad);
			    strFileContents = srFileContents.ReadToEnd();
			    srFileContents.Close();
            }
			return strFileContents;
		}
		

		public static void SaveFileWithStringContents(string strFile,string strFileContent)
		{
			if (File.Exists(strFile)) 
			{				
				File.Delete(strFile);
			}
			using (FileStream fs = File.Create(strFile)) 
			{
				Byte[] info = new UTF8Encoding(true).GetBytes(strFileContent);				
				fs.Write(info, 0, info.Length);
			}
		}

		public static string openFileDialogAndGetFileName()
		{			
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = Environment.CurrentDirectory ;
			openFileDialog1.Filter = "All files (*.*)|*.*" ;
			openFileDialog1.FilterIndex = 1 ;
			openFileDialog1.RestoreDirectory = true ;

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
				return openFileDialog1.FileName;			
			else
				return "";					
		}

		public static void deleteAllFilesInDirectory(string strDirectory)
		{			
			foreach(FileInfo fiToDelete in new DirectoryInfo(strDirectory).GetFiles())
				fiToDelete.Delete();
		}

		// this code snippet was based on the code from http://www.eggheadcafe.com/articles/20050821.asp
		public static ArrayList returnPathToAllFilesInFolder_Recursively(string strDirPath)
		{
			ArrayList mid = new ArrayList();
			bool Empty = true;
			foreach(string file in Directory.GetFiles(strDirPath)) // add each file in directory
			{
				mid.Add(file);
				Empty = false;
			}
			if(Empty)
				if(Directory.GetDirectories(strDirPath).Length == 0) // if directory is completely empty, add it
					mid.Add(strDirPath + @"/");
			foreach(string dirs in Directory.GetDirectories(strDirPath)) // do this recursively
				foreach(object obj in returnPathToAllFilesInFolder_Recursively(dirs))
					mid.Add(obj);
			return mid;
			// return file list
		} 

		public static void createDirectoryIfRequired(string strPathToCheck)
		{
			string strDirPath=Path.GetDirectoryName(strPathToCheck);			
			if(!Directory.Exists(strDirPath))  
				Directory.CreateDirectory(strDirPath);		
		}

		public static bool deleteDirectoryAfterConfirmation(string strFirstQuestion, string strSecondQuestion, string strDirectoryToDelete)
		{
			if (DialogResult.Yes ==  MessageBox.Show(strFirstQuestion ,"Delete confirmation Message",MessageBoxButtons.YesNo))
			{
				if (DialogResult.Yes ==  MessageBox.Show(strSecondQuestion,"Delete re-confirmation Message",MessageBoxButtons.YesNo))
				{					
					try
					{						
						Directory.Delete(strDirectoryToDelete,true);	// This will delete all files in all subdirectories
						return true;
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message); 						
					}					
				}
			}	
			return false;
		}

		public static bool deleteFileAfterConfirmation(string strFirstQuestion, string strSecondQuestion, string strFileToDelete)
		{
			if (DialogResult.Yes ==  MessageBox.Show(strFirstQuestion,"Delete confirmation Message",MessageBoxButtons.YesNo))
			{
				if (DialogResult.Yes ==  MessageBox.Show(strSecondQuestion,"Delete re-confirmation Message",MessageBoxButtons.YesNo))
				{					
					try
					{						
						File.Delete(strFileToDelete);
						return true;
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message); 
					}					
				}
			}	
			return true;
		}
	}

}
