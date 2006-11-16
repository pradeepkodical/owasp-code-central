using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace Owasp.VulnReport
{
    /// <summary>
    /// This class is used to hold the base paths for a bunch of areas inside of 
    /// the ORG program.  It loads most of the values from the configuration
    /// file and sets them up compared to the base path.
    /// 
    /// Initially Developed On: 11/05/2006
    /// </summary>
    public sealed class OrgBasePaths
    {
        // Static members are lazily initialized.
        // .NET guarantees thread safety for static initialization
        private static readonly OrgBasePaths instance = new OrgBasePaths();
        private static string currentBasePath = "";

        private string spsFilePath = "";
        private string xsdFilePath = "";
        private string fopEnginePath = "";
        private string projectSchemaPath = "";
        private string xsltTargetDetailPath = "";
        private string xsltReportsPath = "";
        private string pluginsPath = "";
        private string recommendationXmlSchemaPath = "";
        private string simpleModeFindingsSpsPath = "";
        private string templateFindingsPath = "";
        private string templateEmptyProjectPath = "";
        private string templateEmptyConsolidatedProjectPath = "";
        private string consolidatedReportsFolderPath = "";
        private string xsltReportsDataFiltersPath = "";
        private string xsltReportsHtmlPath = "";
        private string xsltReportsPdfIssueTrackingPath = "";
        private string xsltReportsPdfLiveProjectsPath = "";

        // SPS path vars
        private string findingsSpsPath = "";
        private string targetsSpsPath = "";
        private string projectsSpsPath = "";
        private string executiveSummarySpsPath = "";
        private string recommendationsDbSpsPath = "";
        private string issueTrackingJustItemsAndStatusSpsPath = "";
        private string issueTrackingWithResolutionSpsPath = "";
        private string targetTasksSpsPath = "";

        #region Private Methods
        // For singletons we need to make sure the OrgBasePaths constructor is private
        private OrgBasePaths()
        {
            // Add any initalization we need here
        }
        #endregion

        #region Properties
        public static string BasePath
        {
            get
            {
                return currentBasePath;
            }
            set
            {
                currentBasePath = value;
            }
        }

        public string PathToSpsFiles { get{ return spsFilePath; } }

        public string ProjectSchemaPath { get{ return projectSchemaPath; } }

        public string EmptyProjectFilePath { get{ return templateEmptyProjectPath; } }

        public string EmptyConsolidatedProjectPath { get{ return templateEmptyConsolidatedProjectPath; } }

        public string FopEnginePath { get{ return fopEnginePath; } }

        public string XsltReportsPath { get { return xsltReportsPath; } }

        public string XsdFilePath { get { return xsdFilePath; } }

        public string XsltTargetDetailPath { get { return xsltTargetDetailPath; } }

        public string FindingsPath { get { return templateFindingsPath; } }

        public string XsltLiveProjectsReportPath { get { return xsltReportsPdfLiveProjectsPath; } }

        public string XsltReportDataFiltersPath { get { return xsltReportsDataFiltersPath; } }

        public string XsltReportHtmlPath { get { return xsltReportsHtmlPath; } }

        public string XsltIssueTrackingReportsPath { get { return xsltReportsPdfIssueTrackingPath; } }

        public string ConsolidatedReportsPath { get { return consolidatedReportsFolderPath; } }

        public string RecommendationSchemaPath { get { return recommendationXmlSchemaPath; } }

        public string PluginsPath { get { return pluginsPath; } } 

        // SPS Paths
        public string SpsProjectPath { get{ return projectsSpsPath; } }

        public string SpsExecutiveSummaryPath { get{ return executiveSummarySpsPath; } }

        public string SpsFindingsPath { get{ return findingsSpsPath; } }

        public string SpsSimpleModeFindingsPath { get { return simpleModeFindingsSpsPath; } }

        public string SpsRecommendationsDbPath { get { return recommendationsDbSpsPath; } }

        public string SpsTargetsPath { get { return targetsSpsPath; } }

        public string SpsIssueTrackingJustItemsAndStatusPath { get { return issueTrackingJustItemsAndStatusSpsPath; } }

        public string SpsIssueTrackingWithResolutionPath { get { return issueTrackingWithResolutionSpsPath; } }

        #endregion 

        #region Public Methods

        /// <summary>
        /// This allows for the calling object to get at the instance of the UserProfile
        /// </summary>
        /// <returns>The instance of the UserProfile</returns>
        public static OrgBasePaths GetPaths()
        {
            return instance;
        }

        public void initiatePaths()
        {
            xsdFilePath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["pathToXsdFiles"]));
            fopEnginePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, ConfigurationManager.AppSettings["pathToFopEngine"]));
            projectSchemaPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["projectXmlSchema"]));
            xsltTargetDetailPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["pathToXslt_TargetDetail"]));
            xsltReportsPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["pathToXslt_Reports"]));
            pluginsPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["pathToPlugIns"]));
            recommendationXmlSchemaPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["recommendationsXmlSchema"]));
            templateFindingsPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["templateFile_Findings"]));
            templateEmptyProjectPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["templateFile_EmptyProjectXmlFile"]));
            templateEmptyConsolidatedProjectPath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["templateFile_ConsolidatedProjectXmlFile"]));
            consolidatedReportsFolderPath = ConfigurationManager.AppSettings["consolidatedReportsFolder"];

            xsltReportsDataFiltersPath = Path.GetFullPath(Path.Combine(xsltReportsPath, "Data Filters - Issue Tracking"));
            xsltReportsHtmlPath = Path.GetFullPath(Path.Combine(xsltReportsPath, "Html Reports - Issue Tracking"));
            xsltReportsPdfIssueTrackingPath = Path.GetFullPath(Path.Combine(xsltReportsPath, "Pdf Reports - Issue Tracking"));
            xsltReportsPdfLiveProjectsPath = Path.GetFullPath(Path.Combine(xsltReportsPath, "Pdf Reports - Live Projects"));		

            // Initialize the sps specific paths, for the most part it uses the spsFilePath variable as a base
            spsFilePath = Path.GetFullPath(Path.Combine(currentBasePath, ConfigurationManager.AppSettings["pathToSpsFiles"]));
            findingsSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_Findings"]));
            simpleModeFindingsSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_Findings_SimpleMode"]));
            targetsSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_Targets"]));
            projectsSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_Projects"]));
            executiveSummarySpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_ExecutiveSummary"]));
            recommendationsDbSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_Recommendations"]));
            issueTrackingJustItemsAndStatusSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_IssueTracking_JustItemsAndStatus"]));
            issueTrackingWithResolutionSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_IssueTracking_WithResolutionInfo"]));
            targetTasksSpsPath = Path.GetFullPath(Path.Combine(spsFilePath, ConfigurationManager.AppSettings["defaultSpsFile_TargetTasks"]));
        }
        #endregion
    }
}
