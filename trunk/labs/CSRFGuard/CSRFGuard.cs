using System;
using System.Text.RegularExpressions;
using System.Web;

namespace org.owasp.csrfguard
{
	/// <summary>
	/// Summary description for CSRFGuard.
	/// </summary>
	public class CSRFGuard
	{
		#region Fields
		private HttpApplication _httpApp;
		private HttpContext _context;
		private HttpResponse _response;
		private bool _skipDetect = false;
		private bool _attackDetected;
		#endregion
		
		public CSRFGuard(object sender)
		{
			_httpApp = (HttpApplication)sender;
			_context = _httpApp.Context;
			_response = _httpApp.Context.Response;
			
			// If no token yet, this is the first request so set one to be used on the response and then set the flag to indicate checking is not required
			if (CsrfSessionTokenValue == null)
			{
				CsrfSessionTokenValue = Util.generateToken(16);	// 128 random bytes
				_skipDetect = true;
			}
			
			if (CsrfSessionTokenName == null)
			{
				if (App.Configuration.useRandomCSRFTokenName)
				{
					CsrfSessionTokenName = Util.generateToken(8);	// 64 random bytes
				} else
				{
					if (App.Configuration.staticCSRFTokenName != null)
					{
						CsrfSessionTokenName = App.Configuration.staticCSRFTokenName;	
					} 
					else
					{
						CsrfSessionTokenName = App.Configuration.defaultCSRFTokenName;						
					}
				}
			}
			
			// ignore requests to URLs when no parameters are passed as this would not represent a CSRF attack in most cases (TODO:  make this a configurable option)
			if (!formOrQueryStringParamsPassed() && App.Configuration.skipDetectOnParameterlessURLRequests)
			{
				_skipDetect = true;
			}
			
			// ignore URLs that don't represent CSRF risk (e.g. a request for a GIF)
			// SECURITY NOTE:  DO NOT USE THE FULL URL, only FilePath, else attackers could pad arbitrary chars to the URL parameters to fool the regex.
			if (URLHasWhitelistedExtension(_context.Request.FilePath))
			{
				_skipDetect = true;
			}
			
			// TODO:  Allow specifying a list of relative URLs to bypass detection on								
			// ArrayList test = App.Configuration.skipDetectForTheseURLs;
			
			// Check for CSRF and store the results for later retrieval
			detectCSRFAttempt();
		}
		
		#region Properties
		public String CsrfSessionTokenValue
		{
			get
			{
				return (String)HttpContext.Current.Session[App.Configuration.tokenValueSessionIdx];
			}
			
			set
			{
				HttpContext.Current.Session[App.Configuration.tokenValueSessionIdx] = value;
			}
		}
		
		public String CsrfSessionTokenName
		{
			get
			{
				return (String)HttpContext.Current.Session[App.Configuration.tokenNameSessionIdx];
			}
			
			set
			{
				HttpContext.Current.Session[App.Configuration.tokenNameSessionIdx] = value;
			}
		}
		
		public bool SkipDetect
		{
			get
			{
				return _skipDetect;
			}
		}
		
		public bool AttackDetected
		{
			get
			{
				return _attackDetected;
			}
		}
		
		public HttpResponse Response
		{
			get
			{
				return _response;
			}
		}
		#endregion
		
		#region Methods
		// analyzes the session to detect a CSRF attack.
		public void detectCSRFAttempt()
		{
			// check only when URL is not in the whitelist pattern
			if (!SkipDetect)
			{
				_attackDetected = true;	// fail safe
						
				// TODO:  data input validation on Request value
				// Does the request have a CSRF token embedded?  Does it match the one in session?  If not, we caught an attack.
				if (_context.Request[CsrfSessionTokenName] != null)
				{
					if (CsrfSessionTokenValue == _context.Request[CsrfSessionTokenName])
					{
						_attackDetected = false;
					}
				}
			}
		}
		
		// checks the request URL path (without parameters!!!) for whether it matches a whitelist of file extensions to ignore
		private bool URLHasWhitelistedExtension(String filePath)
		{
			Regex whitelistRegex = new Regex(App.Configuration.extensionWhitelistPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			
			if (whitelistRegex.IsMatch(filePath))
			{
				return true;
			}
			return false;
		}
		
		// determines whether a URL was accessed directly without any extra query or POST parameters
		private bool formOrQueryStringParamsPassed()
		{
			if (_context.Request.QueryString.Count == 0 && _context.Request.Form.Count == 0)
			{
				return false;
			}
			return true;
		}
		#endregion
	}
}
