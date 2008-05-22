using System;
using System.Text;
using System.Web;
using System.Diagnostics;
using System.Web.SessionState;
using log4net;

namespace org.owasp.csrfguard.Actions
{
    class LogEvent : ICSRFHandler
    {
        private HttpApplication _httpApp;
        private HttpContext _context;
        private HttpResponse _response;
        private HttpSessionState _session;
        private bool _initialized = false;
        private static readonly ILog _log = LogManager.GetLogger("CSRFGuard");

        public void Initialize(object sender) 
        {
            _httpApp = (HttpApplication)sender;
            _session = _httpApp.Session;
            _context = _httpApp.Context;
            _response = _httpApp.Context.Response;
            _initialized = true;
        }

        public void TakeAction()
        {
            if (_initialized)
            {
// TODO:  log more interesting information.  Maybe the IP address
                _log.Warn("CSRFGuard attack detected!  Action taken.");
            }
        }
    }
}
