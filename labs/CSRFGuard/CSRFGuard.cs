using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Diagnostics;
using org.owasp.csrfguard.Actions;
using System.Reflection;

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
        private HttpSessionState _session;
		private bool _skipDetect = false;
		private bool _attackDetected;
		#endregion
		
		public CSRFGuard(object sender)
		{
			_httpApp = (HttpApplication)sender;
            _session = _httpApp.Session;
			_context = _httpApp.Context;
			_response = _httpApp.Context.Response;

            setupCSRFTokenNameAndValue();

            // do we need to do anything?  Configure the object options.
            setupSkipDetect();
			
			// Check for CSRF and store the results in object properties for later retrieval
            if (!SkipDetect)
            {
                detectCSRFAttempt();
            }

            // take action
            if (AttackDetected)
            {
                handleCSRFAttempt();
            }
		}
		
        // properties 
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

        public HttpSessionState ClientSession
        {
            get
            {
                return _session;
            }
        }
		
		// methods

        /// <summary>
        /// Check the csrf token name and value in the current asp.net session and create one if not existing already
        /// </summary>
        private void setupCSRFTokenNameAndValue()
        {
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
                }
                else
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
        }

        /// <summary>
        /// Applies rules to determine whether we need to skip detection, based on config items and the request properties.
        /// </summary>
        private void setupSkipDetect()
        {
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
        }

		// analyzes the session to detect a CSRF attack.
        private void detectCSRFAttempt()
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

        /**
        * Handle a detected CSRF attepmpt.  This will use the configuration for what to do next (e.g. redirect, kill session, log, etc.)
        **/
        void handleCSRFAttempt()
        {

            // instantiate the dynamic classes specified in the config file, or the default.  Then tell it to take action.
            foreach (string hclass in App.Configuration.CSRFHandlers)
            {
                EventLog log = new EventLog();
                #region debug logging
                log.Source = "Application";
                log.WriteEntry("DEBUG:  Executing Action " + hclass, EventLogEntryType.Error);
                #endregion
                try
                {
                    Type type = Type.GetType(hclass, true);
                    ICSRFHandler handler = Activator.CreateInstance(type) as ICSRFHandler;
                    handler.Initialize(_httpApp);
                    handler.TakeAction();
                }
                catch (TypeLoadException e)
                {
                    log.WriteEntry("Got exception " + e.Message, EventLogEntryType.Error);
                }
            }

            // TODO:  support plugins by looking for anything that implements ICSRFHandler interface in a given plugin directory
            try
            {
                string[] pluginFiles = Directory.GetFiles(App.Configuration.CSRFHandler_pluginFolder);
                foreach (string file in pluginFiles)
                {
                    Type objType = null;
                    try
                    {
                        // load the plugin assembly
                        Assembly plugin = Assembly.Load(file);
                        if (plugin != null)
                        {
                            objType = plugin.GetType(file, true);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    try
                    {
                        // now, instantiate the object and do stuff.
                        if (objType != null)
                        {
                            ICSRFHandler handlerPlugin = Activator.CreateInstance(objType) as ICSRFHandler;
                            handlerPlugin.Initialize(_httpApp);
                            handlerPlugin.TakeAction();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }

            _response.End();
        }

        // Utility methods
		
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
	}
}
