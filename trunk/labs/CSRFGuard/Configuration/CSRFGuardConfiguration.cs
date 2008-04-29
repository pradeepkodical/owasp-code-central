using System;
using System.Collections;

namespace org.owasp.csrfguard
{
	/// <summary>
	/// Summary description for CSRFGuardConfiguration.
	/// </summary>
	public class CSRFGuardConfiguration : AppConfiguration
	{
		public string extensionWhitelistPattern = "\\.(gif|jpg|png|css|js|ico|swf|axd|pdf)$";
		public string defaultCSRFTokenName = "OWASP_CSRFTOKEN";
		// indexes for the values stored in session
		public string tokenNameSessionIdx = "TOKEN_NAME";
		public string tokenValueSessionIdx = "TOKEN_VALUE";
		// whether to use a static CSRFToken name or not
		public bool useRandomCSRFTokenName = true;
		public string staticCSRFTokenName = null;
		// Simplifies CSRF detection by allowing access to URLs if no GET or POST parameters were sent on the request (assumption is that it takes parameters to actually perform a CSRF which may or may not be the case in your application)
		public bool skipDetectOnParameterlessURLRequests = true;
		public ArrayList skipDetectForTheseURLs = new ArrayList();
        public ArrayList CSRFHandlers = new ArrayList();   
        public string ResponseFilterClass = "org.owasp.csrfguard.ResponseFilters.RegExFilter";    // default class
        public string CSRFHandlers_RedirectToUrl_Url = null;
        public string CSRFHandlers_PrintError_ErrorText = null;
        public string CSRFHandler_pluginFolder = "plugins/";
		
		// constructor
		public CSRFGuardConfiguration(string configFile) : base(configFile)
		{
			// do nothing extra than calling the base class method
		}
	}
}