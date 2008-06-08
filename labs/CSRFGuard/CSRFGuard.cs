using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using log4net;
using Org.Owasp.CsrfGuard.Actions;

namespace Org.Owasp.CsrfGuard
{
    /// <summary>
    /// Summary description for CSRFGuard.
    /// </summary>
    public class CSRFGuard
    {

        private HttpApplication _httpApp;
        private HttpContext _context;
        private HttpResponse _response;
        private HttpSessionState _session;
        private bool _skipDetect;
        private bool _attackDetected;
        private static readonly ILog _log = LogManager.GetLogger("CSRFGuard");

        public CSRFGuard(object sender)
        {
            _httpApp = (HttpApplication) sender;
            _session = _httpApp.Session;
            _context = _httpApp.Context;
            _response = _httpApp.Context.Response;

            SetupCSRFTokenNameAndValue();

            // do we need to do anything?  Configure the object options.
            SetupSkipDetect();

            // Check for CSRF and store the results in object properties for later retrieval
            if (!SkipDetect)
            {
                DetectCSRFAttempt();
            }

            // take action
            if (AttackDetected)
            {
                HandleCSRFAttempt();
            }
        }

        // properties 

        /// <summary>
        /// Gets and sets the CSRF token value in the HTTP session
        /// </summary>
        public String CsrfTokenValue
        {
            get { return (String) HttpContext.Current.Session[App.Configuration.TokenValueSessionIdx]; }

            set { HttpContext.Current.Session[App.Configuration.TokenValueSessionIdx] = value; }
        }

        /// <summary>
        /// Gets and sets the CSRF token name in the HTTP session
        /// </summary>
        public String CsrfTokenName
        {
            get { return (String) HttpContext.Current.Session[App.Configuration.TokenNameSessionIdx]; }

            set { HttpContext.Current.Session[App.Configuration.TokenNameSessionIdx] = value; }
        }

        public bool SkipDetect
        {
            get { return _skipDetect; }
        }

        public bool AttackDetected
        {
            get { return _attackDetected; }
        }

        public HttpResponse Response
        {
            get { return _response; }
        }

        public HttpSessionState ClientSession
        {
            get { return _session; }
        }

        // methods

        /// <summary>
        /// Check the csrf token name and value in the current asp.net session and create one if not existing already
        /// </summary>
        private void SetupCSRFTokenNameAndValue()
        {
            Token newToken = new RandomToken();
            // If no token yet, this is the first request so set one to be used on the response and then set the flag to indicate checking is not required
            if (CsrfTokenValue == null)
            {
                CsrfTokenValue = newToken.Value;
                _skipDetect = true;
            }

            if (CsrfTokenName == null)
            {
                if (App.Configuration.UseRandomCSRFTokenName)
                {
                    CsrfTokenName = newToken.Name;
                }
                else
                {
                    if (App.Configuration.staticCSRFTokenName != null)
                    {
                        newToken.Name = App.Configuration.staticCSRFTokenName;
                        CsrfTokenName = newToken.Name;
                    }
                }
            }
        }

        /// <summary>
        /// Applies rules to determine whether we need to skip detection, based on config items and the request properties.
        /// </summary>
        private void SetupSkipDetect()
        {
            // ignore requests to URLs when no parameters are passed as this would not represent a CSRF attack in most cases
            if (!formOrQueryStringParamsPassed() && App.Configuration.SkipDetectOnParameterlessURLRequests)
            {
                _skipDetect = true;
            }

            // ignore URLs that don't represent CSRF risk (e.g. a request for a GIF)
            // SECURITY NOTE:  DO NOT USE THE FULL URL, only FilePath, else attackers could pad arbitrary chars to the URL parameters to fool the regex.
            if (Util.URLPathHasWhitelistedFileExtension(_context.Request.FilePath))
            {
                _skipDetect = true;
            }

            // TODO:  Don't add token values if URL is on the list							
            // SECURITY NOTE:  DO NOT USE THE FULL URL, only FilePath, else attackers could pad arbitrary chars to the URL parameters to fool the regex.
            if (Util.URLPathIsOnWhitelist(_context.Request.FilePath))
            {
                _skipDetect = true;
            }
        }

        // analyzes the session to detect a CSRF attack.
        private void DetectCSRFAttempt()
        {
            _attackDetected = true; // fail safe

            Token requestToken = new Token(CsrfTokenName, _context.Request[CsrfTokenName]);
            Token thisToken = new Token(CsrfTokenName, CsrfTokenValue);
            
            // Does the request have a CSRF token embedded?  Does it match the one in session?  If not, we caught an attack.
            if (_context.Request[CsrfTokenName] != null)
            {
                if (requestToken == thisToken)
                {
                    _attackDetected = false;
                }
            }
        }

        /**
        * Handle a detected CSRF attepmpt.  This will use the configuration for what to do next (e.g. redirect, kill session, log, etc.)
        **/

        private void HandleCSRFAttempt()
        {
            // instantiate the dynamic classes specified in the config file, or the default.  Then tell it to take action.
            foreach (string hclass in App.Configuration.CSRFHandlers)
            {
                #region debug logging

                _log.Debug("Executing Action " + hclass);

                #endregion

                try
                {
                    Type type = Type.GetType(hclass, true);
                    ICSRFHandler handler = Activator.CreateInstance(type) as ICSRFHandler;
                    if (handler != null)
                    {
                        handler.Initialize(_httpApp);
                        handler.TakeAction();
                    } 
                    else
                    {
                        _log.Error(String.Format(CultureInfo.InvariantCulture, "CSRFHandler instantiation failed for handler {0}", hclass));    
                    }
                }
                catch (TypeLoadException e)
                {
                    _log.Error(String.Format("Got exception loading CSRFHandler {0}, {1}", hclass, e.Message));
                }
            }

            // Support plugins by looking for anything that implements ICSRFHandler interface in a given plugin directory
            try
            {
                string[] pluginFiles =
                    Directory.GetFiles(GetExecutablePath() + "/" + App.Configuration.CSRFHandler_pluginFolder);

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
                    catch (FileLoadException e)
                    {
                        _log.Error(String.Format("FileLoadException loading file '{0}'; {1}", file, e.StackTrace));
                    }

                    try
                    {
                        // now, instantiate the object and do stuff.
                        if (objType != null)
                        {
                            ICSRFHandler handlerPlugin = Activator.CreateInstance(objType) as ICSRFHandler;
                            if (handlerPlugin != null)
                            {
                                handlerPlugin.Initialize(_httpApp);
                                handlerPlugin.TakeAction();
                            }
                            else
                            {
                                _log.Error(String.Format(CultureInfo.InvariantCulture, "CSRFHandler Plugin instantiation failed for handler plugin {0} in file {1}", objType, file));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {
                _log.Warn(
                    "Directory not found '" + GetExecutablePath() + "/" + App.Configuration.CSRFHandler_pluginFolder +
                    "'", e);
            }

            _response.End();
        }

        // Utility methods

        // determines whether a URL was accessed directly without any extra query or POST parameters
        private bool formOrQueryStringParamsPassed()
        {
            if (_context.Request.QueryString.Count == 0 && _context.Request.Form.Count == 0)
            {
                return false;
            }
            return true;
        }

        private static string GetExecutablePath()
        {
            string executableDirectory = Assembly.GetExecutingAssembly().GetName().CodeBase;
            return Path.GetDirectoryName(executableDirectory.Replace("file:///", ""));
        }
    }
}