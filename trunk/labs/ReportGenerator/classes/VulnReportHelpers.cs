using System;
using System.Windows.Forms;
using System.IO;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for VulnReportHelpers.
	/// </summary>
	public class VulnReportHelpers
	{
		public VulnReportHelpers()
		{
		}

        public static void setBaseDirBasedOnExecutionEnvironment()
        {
            string strFullPathToSpecialFile = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, GlobalVariables.strSpecialFile));
            if (true == File.Exists(strFullPathToSpecialFile))      // we are in development mode
                GlobalVariables.strBaseDir = Path.Combine(Environment.CurrentDirectory, utils.files.GetFileContents(strFullPathToSpecialFile)); // @"..\..\..\ORG\ORG_CONFIG_FILES";            
            else                                                    // we are in execution mode
                GlobalVariables.strBaseDir = Path.Combine(Environment.CurrentDirectory, GlobalVariables.strDefaultOrgConfigDirName);  
        }

		public static void createNewTargetAndAddItToListBox(ListBox lbTargetListBox, string strNewTargetName, string strFullPathToCurrentProject)
		{
			if (lbTargetListBox.Items.Contains(strNewTargetName))
			{
				MessageBox.Show("Target already exists, you cannot create a duplicating target!");	
				return;
			}
			int iNumberOfCurrentTargets = lbTargetListBox.Items.Count;

            // We need to remove any periods because it fouls up the loading of the xml files.
            string sanitizedTargetName = strNewTargetName.Replace('.', '_');
            string strFullPathToNewTarget = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject, sanitizedTargetName));
            string strFullPathToNewTargetXmlFile = Path.Combine(strFullPathToNewTarget, sanitizedTargetName) + ".xml";
            if (!Directory.Exists(strFullPathToNewTarget))
            {
                Directory.CreateDirectory(strFullPathToNewTarget);
            }
			
			File.Copy(GlobalVariables.strPathToTemplateFile_EmptyProjectXmlFile,strFullPathToNewTargetXmlFile);
            lbTargetListBox.Items.Add(sanitizedTargetName);
			lbTargetListBox.SelectedIndex = iNumberOfCurrentTargets;			
		}

		public static void createNewProjectAndAddItToListBox(ListBox lbTargetListBox, string strNewProjectName)
		{
            UserProfile up = UserProfile.GetUserProfile();
			string strFullPathToNewProject = Path.GetFullPath(Path.Combine(up.ProjectFilesPath, strNewProjectName));							
			Directory.CreateDirectory(strFullPathToNewProject);			
			string strFullPathToNewProjectXmlFile = Path.GetFullPath(Path.Combine(strFullPathToNewProject, strNewProjectName + ".xml"));				
			File.Copy(GlobalVariables.strPathToTemplateFile_EmptyProjectXmlFile,strFullPathToNewProjectXmlFile);
			lbTargetListBox.Items.Add(strNewProjectName);			
			lbTargetListBox.SelectedIndex = utils.windowsForms.findItemInListBox(lbTargetListBox, strNewProjectName);				
		}

        /// <summary>
        /// Make sure that the following folders and files exist.  If they do not then the
        /// program can not continue to run at least in a useable state.  
        /// 
        /// The following folders and files are required
        /// 
        /// - VulnReport_Files\templates
        ///   - _templateFile_ConsolidatedProjectXmlFile.xml
        ///   - _templateFile_EmptyProjectXmlFile.xml
        /// </summary>
        public static void confirmExistenceOfRequiredFilesAndFolders()
        {
            //if the org_config_files folder doesn't exist, three zip files need to be unzipped for first time users.            }
            if (!Directory.Exists(GlobalVariables.strBaseDir))
            {
                FileInfo fileconfig = new FileInfo("ORG_CONFIG_FILES.zip.txt");
                FileInfo fileFOP = new FileInfo("FOP.zip.txt");
                FileInfo fileAuthenticPlugin = new FileInfo("AuthenticPlugin.zip.txt");
                fileconfig.CopyTo("ORG_CONFIG_FILES.zip", true);
                fileFOP.CopyTo("FOP.zip", true);
                fileAuthenticPlugin.CopyTo("AuthenticPlugin.zip", true);
                utils.zip.unzipFile(Path.Combine(Environment.CurrentDirectory, "ORG_CONFIG_FILES.zip"), Environment.CurrentDirectory);
                utils.zip.unzipFile(Path.Combine(Environment.CurrentDirectory, "FOP.zip"), Environment.CurrentDirectory);
                utils.zip.unzipFile(Path.Combine(Environment.CurrentDirectory, "AuthenticPlugin.zip"), Environment.CurrentDirectory);
            }
            if (!Directory.Exists(Path.Combine(GlobalVariables.strBaseDir, "templates"))) 
                throw new Exception("The template folder is missing, please re-install");
            if (!File.Exists(Path.Combine(GlobalVariables.strBaseDir, "templates\\_templateFile_EmptyProjectXmlFile.xml")))
                throw new Exception("File: " + GlobalVariables.strBaseDir + "templates\\_templateFile_EmptyProjectXmlFile.xml is missing");
            if (!File.Exists(Path.Combine(GlobalVariables.strBaseDir, "templates\\_templateFile_ConsolidatedProjectXmlFile.xml")))
                throw new Exception("File: " + GlobalVariables.strBaseDir + "templates\\_templateFile_ConsolidatedProjectXmlFile.xml is missing");
        }
	}
}
