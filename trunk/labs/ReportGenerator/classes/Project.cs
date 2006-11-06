using System;
using System.Collections.Generic;
using System.Text;

namespace Owasp.VulnReport
{
    /// <summary>
    /// This class holds information for the current project.  This 
    /// will include things like the next project id and other
    /// specific paths. 
    /// 
    /// It will be implemented as a singleton for the time being.  The reason
    /// it is being implemented this way is because of the user controls will
    /// need to access some of the project information. 
    /// </summary>
    public sealed class Project
    {
        // Static members are lazily initialized.
        // .NET guarantees thread safety for static initialization
        private static readonly Project instance = new Project();

        private int currentFindingId = 0;
        private string currentProjectNumber = "";

        #region Private Methods
        // For singletons we need to make sure the Project constructor is private
        private Project()
        {
            // Add any initalization we need here
        }
        #endregion

        #region Properties
        public int FindingId
        {
            get
            {
                return currentFindingId;
            }
            set
            {
                currentFindingId = value;
            }
        }

        public string ProjectNumber
        {
            get
            {
                return currentProjectNumber;
            }
            set
            {
                currentProjectNumber = value;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// This allows for the calling object to get at the instance of the UserProfile
        /// </summary>
        /// <returns>The instance of the UserProfile</returns>
        public static Project GetProject()
        {
            return instance;
        }

        #endregion
    }
}
