using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Owasp.SiteGenerator
{
    /// <summary>
    /// This class is created a singleton to be used as the holder for the current 
    /// site mappings. 
    /// 
    /// Initially Developed: October 07, 2006
    /// </summary>
    public sealed class SiteMapping
    {
        // Static members are lazily initialized.
        // .NET guarantees thread safety for static initialization
        private static readonly SiteMapping instance =
          new SiteMapping();

        private XmlDocument xdMapping = new XmlDocument();

        #region Private Methods
        // For singletons we need to make sure the UserProfile constructor is private
        private SiteMapping()
        {
            // Add any initalization we need here
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// This allows for the calling object to get at the instance of the SiteMapping
        /// </summary>
        /// <returns>The instance of the UserProfile</returns>
        public static SiteMapping GetSiteMapping()
        {
            return instance;
        }

        public XmlDocument Mapping
        {
            get
            {
                return this.xdMapping;
            }
        }

        /// <summary>
        /// This allows a calling object to switch the mappings.
        /// </summary>
        /// <param name="mappingToLoad">Path to file that contains a new mapping</param>
        public void LoadNewMapping(string mappingToLoad)
        {
            if (File.Exists(mappingToLoad))
                xdMapping.Load(mappingToLoad);
        }

        #endregion
    }
}
