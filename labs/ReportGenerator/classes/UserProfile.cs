using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;

namespace Owasp.VulnReport
{
    /// <summary>
    /// This class is used for holding the locations of the current User Profile.  Along
    /// with other information related to the current user profile. 
    /// 
    /// We are implementing this class as a singleton because we only need to keep track
    /// of the user profile once but access it from many different places.  The singleton
    /// pattern seemed to be the best fit.  
    /// 
    /// Initially Developed On: 09/12/2006 
    /// By: Mike de Libero
    /// </summary>
    
    public sealed class UserProfile
    {
        // Static members are lazily initialized.
        // .NET guarantees thread safety for static initialization
        private static readonly UserProfile instance = new UserProfile();

        private string userProfileFolder = "";
        private string userProfileFileName = "";
        private string userPathToProjectFiles = "";
        private string xsltNameSpace = ConfigurationManager.AppSettings["xsltNamespace"];
        private XmlDocument xdUserProfile = new XmlDocument();
        private string configuredTempFileFolder = ConfigurationManager.AppSettings["tempFileFolder"];
        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

        const string TempDirectoryNodeName = "tempRootDirectory";
        const string BaseDirectoryNodeName = "baseDirectory";

        #region Private Methods
        // For singletons we need to make sure the UserProfile constructor is private
        private UserProfile()
        {
            // Add any initalization we need here
        }
        #endregion

        /// <summary>
        /// This allows us to specify the file system location of the folder that holds the
        /// user profile information.
        /// 
        /// When setting the profile folder location if the directory does not exist it 
        /// will be created.
        /// </summary>
        public string ProfileFolder
        {
            get
            {
                return userProfileFolder;
            }
            set
            {
                if (!Directory.Exists(value))
                {
                    // then create it
                    Directory.CreateDirectory(value);
                }
                userProfileFolder = value;
            }

        }

        public string BaseDirectory
        {
            get
            {
                if (xdUserProfile.GetElementsByTagName(BaseDirectoryNodeName).Count > 0) 
                {
                    return xdUserProfile.GetElementsByTagName(BaseDirectoryNodeName)[0].InnerText;
                } 
                else 
                {
                    return "";
                }
            }
            set
            {
                // Make sure the value has a trailing slash so that other IO operations will work.
                if(!value.EndsWith("\\")) value += "\\";

                // see if we need to create the base directory node first
                if (xdUserProfile.GetElementsByTagName(BaseDirectoryNodeName).Count <= 0)
                {
                    XmlElement xeTempRootDirectory = xdUserProfile.CreateElement(BaseDirectoryNodeName,
                                                                                xsltNameSpace);
                    xdUserProfile.FirstChild.AppendChild(xeTempRootDirectory);
                }
                
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                xdUserProfile.GetElementsByTagName(BaseDirectoryNodeName)[0].InnerText = value;
                userPathToProjectFiles = value;
            }
        }

        public string TempDirectory
        {
            get
            {
                if (xdUserProfile.GetElementsByTagName(TempDirectoryNodeName).Count > 0)
                {
                    return xdUserProfile.GetElementsByTagName(TempDirectoryNodeName)[0].InnerText;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                // see if we need to create the temp root directory node first
                if (xdUserProfile.GetElementsByTagName(TempDirectoryNodeName).Count <= 0)
                {
                    XmlElement xeTempRootDirectory = xdUserProfile.CreateElement(TempDirectoryNodeName,
                                                                                 xsltNameSpace);
                    xdUserProfile.FirstChild.AppendChild(xeTempRootDirectory);
                }
                xdUserProfile.GetElementsByTagName(TempDirectoryNodeName)[0].InnerText = value;
            }
        }

        public string TempDirectoryPath
        {
            get
            {
                if ("%TEMP%" == TempDirectory.ToUpper())
                    return Path.GetFullPath(Path.Combine(Path.GetTempPath(), configuredTempFileFolder));
                else
                {
                    string TempFileFolderPath = Path.GetFullPath(Path.Combine(TempDirectory, configuredTempFileFolder));
                    if (!Directory.Exists(TempFileFolderPath))
                    {
                        Directory.CreateDirectory(TempFileFolderPath);
                    }

                    return TempFileFolderPath;
                }
            }
        }

        public string ProjectFilesPath
        {
            get
            {
                return userPathToProjectFiles;
            }
        }

        public string ConsolidatedReportsPath
        {
            get
            {
                if (!Directory.Exists(Path.Combine(BaseDirectory, obpPaths.ConsolidatedReportsPath)))
                {
                    Directory.CreateDirectory(Path.Combine(BaseDirectory, obpPaths.ConsolidatedReportsPath));
                }

                return Path.Combine(BaseDirectory, obpPaths.ConsolidatedReportsPath);
            }
        }

        #region Public Methods

        /// <summary>
        /// This allows for the calling object to get at the instance of the UserProfile
        /// </summary>
        /// <returns>The instance of the UserProfile</returns>
        public static UserProfile GetUserProfile()
        {
            return instance;
        }

        /// <summary>
        /// This allows a calling method to specify which user profile we need to load for 
        /// when we run the program.
        /// </summary>
        /// <param name="UserProfileXmlFile">The name of the file we wish to load</param>
        public void LoadUserProfile(string userProfileFile)
        {
            if (File.Exists(Path.Combine(userProfileFolder, userProfileFile)))
            {
                userProfileFileName = userProfileFile;
                string pathToUserProfileFile = Path.Combine( userProfileFolder,
                                                             userProfileFileName);
                xdUserProfile.Load(pathToUserProfileFile);
            }
            else
            {
                throw new IOException("The User profile file was not found");
            }
        }

        public void CreateUserProfile(string newProfileName)
        {
            xdUserProfile = new XmlDocument();

            XmlDeclaration xdXmlDeclaration = xdUserProfile.CreateXmlDeclaration("1.0", "UTF-8", "");
            XmlElement xeRootElement = xdUserProfile.CreateElement("userProfile", xsltNameSpace);

            xdUserProfile.AppendChild(xdXmlDeclaration);
            xdUserProfile.AppendChild(xeRootElement);

            XmlElement xebaseDirectory = xdUserProfile.CreateElement("baseDirectory", xsltNameSpace);
            XmlElement xeTempRootDirectory = xdUserProfile.CreateElement(TempDirectoryNodeName, xsltNameSpace);

            xebaseDirectory.InnerText = ConfigurationManager.AppSettings["_pathToProjectFiles"];
            xeTempRootDirectory.InnerText = configuredTempFileFolder;
            xeRootElement.AppendChild(xebaseDirectory);
            xeRootElement.AppendChild(xeTempRootDirectory);

            xdUserProfile.Save(Path.Combine(this.ProfileFolder, newProfileName + ".xml"));
        }

        public void Save()
        {
            if (File.Exists(Path.Combine(userProfileFolder, userProfileFileName)))
            {
                xdUserProfile.Save(Path.Combine(userProfileFolder,
                                                userProfileFileName));
            }
        }

        /// <summary>
        /// This sets the current working projects path to the archived area. 
        /// </summary>
        public void SwitchToArchivedProjects()
        {
            userPathToProjectFiles = Path.Combine(BaseDirectory, "_archive");
            if (!Directory.Exists(userPathToProjectFiles)) Directory.CreateDirectory(userPathToProjectFiles);
        }

        /// <summary>
        /// This sets the current working projects path to the future projects area.
        /// </summary>
        public void SwitchToFutureProjects()
        {
            userPathToProjectFiles = Path.Combine(BaseDirectory, "_futureProjects");
            if (!Directory.Exists(userPathToProjectFiles)) Directory.CreateDirectory(userPathToProjectFiles);
        }

        /// <summary>
        /// This sets the path to the current projects area.
        /// </summary>
        public void SwitchToCurrentProjects()
        {
            userPathToProjectFiles = BaseDirectory;
        }

        #endregion
    }
}
