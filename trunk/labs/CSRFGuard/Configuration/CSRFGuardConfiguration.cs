using System;
using System.Collections;

namespace org.owasp.csrfguard
{
	/// <summary>
	/// Summary description for CSRFGuardConfiguration.
	/// </summary>
	public class CSRFGuardConfiguration : AppConfiguration
	{
		public String extensionWhitelistPattern = "\\.(gif|jpg|png|css|js|ico|swf|axd|pdf)$";
		public String defaultCSRFTokenName = "OWASP_CSRFTOKEN";
		// indexes for the values stored in session
		public String tokenNameSessionIdx = "TOKEN_NAME";
		public String tokenValueSessionIdx = "TOKEN_VALUE";
		// whether to use a static CSRFToken name or not
		public bool useRandomCSRFTokenName = true;
		public String staticCSRFTokenName = null;
		// Simplifies CSRF detection by allowing access to URLs if no GET or POST parameters were sent on the request (assumption is that it takes parameters to actually perform a CSRF which may or may not be the case in your application)
		public bool skipDetectOnParameterlessURLRequests = true;
		public ArrayList skipDetectForTheseURLs = new ArrayList();
		
		// constructor
		public CSRFGuardConfiguration(string configFile) : base(configFile)
		{
			// do nothing extra than calling the base class method
		}
	}
}