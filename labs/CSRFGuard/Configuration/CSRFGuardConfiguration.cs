using System.Collections;

namespace Org.Owasp.CsrfGuard
{
    /// <summary>
    /// Summary description for CSRFGuardConfiguration.
    /// </summary>
    public class CSRFGuardConfiguration : AppConfiguration
    {
        public string ExtensionWhitelistPattern = "\\.(gif|jpg|png|css|js|ico|swf|axd|pdf)$";
        public int CSRFTokenLengthInBytes = 16; // 128 bits
        public int CSRFRandomTokenNameLengthInBytes = 8; // 64 bits
        // indexes for the values stored in session
        public string TokenNameSessionIdx = "TOKEN_NAME";
        public string TokenValueSessionIdx = "TOKEN_VALUE";
        // whether to use a static CSRFToken name or not
        public bool UseRandomCSRFTokenName = true;
        public string staticCSRFTokenName = "OWASP_CSRFTOKEN";
        // Simplifies CSRF detection by allowing access to URLs if no GET or POST parameters were sent on the request (assumption is that it takes parameters to actually perform a CSRF which may or may not be the case in your application)
        public bool SkipDetectOnParameterlessURLRequests = true;
        public ArrayList SkipDetectForTheseURLs = new ArrayList();
        public ArrayList CSRFHandlers = new ArrayList();
        public string CSRFHandlers_RedirectToUrl_Url = null;
        public string CSRFHandlers_PrintError_ErrorText = null;
        public string CSRFHandler_pluginFolder = "plugins/";
        public string ResponseFilter = "Org.Owasp.CsrfGuard.ResponseFilters.RegexFilter";

        // constructor
        public CSRFGuardConfiguration(string configFile) : base(configFile)
        {
            // do nothing extra than calling the base class method
        }
    }
}