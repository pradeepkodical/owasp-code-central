using System;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for GlobalVariables.
	/// </summary>
	public class GlobalVariables
	{

        public static string strBaseDir;
        public static string strSpecialFile = "DevPath.org";
        public static string strDefaultOrgConfigDirName = "ORG_CONFIG_FILES";
        public static string strPathToUserProfileDir = "UserProfiles";      // this needs to be hardcoded

		public static int iNextProjectsFindingIdValue = 0;	
		public static string strCurrentProjectNumberValue = "";	
		public static ascxProjects cAscxProjects;	
		public static string strPathToSPS_Findings;        
		public static string strPathToSPS_Findings_SimpleMode;
		public static string strPathToSPS_Targets;
		public static string strPathToSPS_Projects;
		public static string strPathToSPS_ExecutiveSummary;
		public static string strPathToSPS_RecommendationsDatabase;
		public static string strPathToSPS_IssueTracking_JustItemsAndStatus;
		public static string strPathToSPS_IssueTracking_WithResolutionInfo;		
		public static string strPathToSPS_TargetTasks;		
		public static string strPathToFopEngine;			
		public static string strPathToSpsFiles;
		public static string strPathToXsdFiles;
		public static string strPathToRecommendationsXmlSchema;		
		public static string strPathToProjectSchema;
		public static string strPathToTemplateFile_Findings;
		public static string strPathToTemplateFile_EmptyProjectXmlFile;	
		public static string strPathToTemplateFile_EmptyConsolidatedProjectXmlFile;	
		public static string strPathToPlugIns;
		public static string strPathToXslt_TargetDetail;
		public static string strPathToXslt_Reports;
		public static string strPathToXslt_Reports_DataFilters;
		public static string strPathToXslt_Reports_HtmlReports;
		public static string strPathToXslt_Reports_PdfReports_IssueTracking;
		public static string strPathToXslt_Reports_PdfReports_LiveProjects;
        public static string strXsltNamespace;
        public static string strTempFileFolder;
        public static string strConsolidatedReportsFolder;        

		public GlobalVariables()
		{

		}

		public static void loadGlobalVariables()
		{		
	        UserProfile upCurrentUser = UserProfile.GetUserProfile();

			// from this point onwards all files will point to GlobalVariables.strPathToProjectFiles             
            GlobalVariables.strPathToSpsFiles = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["pathToSpsFiles"]));
            GlobalVariables.strPathToXsdFiles = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["pathToXsdFiles"]));
            GlobalVariables.strPathToFopEngine = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, ConfigurationManager.AppSettings["pathToFopEngine"]));
            GlobalVariables.strPathToProjectSchema = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["projectXmlSchema"]));
            GlobalVariables.strPathToXslt_TargetDetail = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["pathToXslt_TargetDetail"]));
            GlobalVariables.strPathToXslt_Reports = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["pathToXslt_Reports"]));
            GlobalVariables.strPathToPlugIns = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["pathToPlugIns"]));
            GlobalVariables.strPathToRecommendationsXmlSchema = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir,ConfigurationManager.AppSettings["recommendationsXmlSchema"]));
            GlobalVariables.strPathToSPS_Findings =                         Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles, ConfigurationManager.AppSettings["defaultSpsFile_Findings"]));
			GlobalVariables.strPathToSPS_Findings_SimpleMode =				Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_Findings_SimpleMode"]));				
			GlobalVariables.strPathToSPS_Targets =							Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_Targets"]));	
			GlobalVariables.strPathToSPS_Projects =							Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_Projects"]));	
			GlobalVariables.strPathToSPS_ExecutiveSummary =					Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_ExecutiveSummary"]));	
			GlobalVariables.strPathToSPS_RecommendationsDatabase =			Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_Recommendations"]));				
			GlobalVariables.strPathToSPS_IssueTracking_JustItemsAndStatus = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_IssueTracking_JustItemsAndStatus"]));				
			GlobalVariables.strPathToSPS_IssueTracking_WithResolutionInfo = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_IssueTracking_WithResolutionInfo"]));							
			GlobalVariables.strPathToSPS_TargetTasks =						Path.GetFullPath(Path.Combine(GlobalVariables.strPathToSpsFiles,ConfigurationManager.AppSettings["defaultSpsFile_TargetTasks"]));
            GlobalVariables.strPathToTemplateFile_Findings = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["templateFile_Findings"]));
            GlobalVariables.strPathToTemplateFile_EmptyProjectXmlFile = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["templateFile_EmptyProjectXmlFile"]));
            GlobalVariables.strPathToTemplateFile_EmptyConsolidatedProjectXmlFile = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["templateFile_ConsolidatedProjectXmlFile"]));
            //GlobalVariables.strPathToUserProfileDir = Path.GetFullPath(Path.Combine(GlobalVariables.strBaseDir, ConfigurationManager.AppSettings["pathToUserProfileDir"]));
            
            GlobalVariables.strXsltNamespace = ConfigurationManager.AppSettings["xsltNamespace"];
            GlobalVariables.strTempFileFolder = ConfigurationManager.AppSettings["tempFileFolder"];
            GlobalVariables.strConsolidatedReportsFolder = ConfigurationManager.AppSettings["consolidatedReportsFolder"];
            
			strPathToXslt_Reports_DataFilters = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToXslt_Reports ,"Data Filters - Issue Tracking"));
			strPathToXslt_Reports_HtmlReports = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToXslt_Reports ,"Html Reports - Issue Tracking"));
			strPathToXslt_Reports_PdfReports_IssueTracking  = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToXslt_Reports ,"Pdf Reports - Issue Tracking"));
			strPathToXslt_Reports_PdfReports_LiveProjects  = Path.GetFullPath(Path.Combine(GlobalVariables.strPathToXslt_Reports ,"Pdf Reports - Live Projects"));		
		}
		
		public static void deleteTempFilesAndTerminateProcess()
		{
			deleteTempFiles();
            terminateProcess();
		}

        public static void terminateProcess()
        {
            Environment.Exit(-1);
        }


				
		public static void deleteTempFiles()
		{
            UserProfile up = UserProfile.GetUserProfile();
            try
            {
                if (Directory.Exists(up.TempDirectoryPath))
                    Directory.Delete(up.TempDirectoryPath, true);
            }
            catch (IOException eio)
            {
                MessageBox.Show("Problem removing temporary files: " + eio.Message);
            }
		}
	}
}


