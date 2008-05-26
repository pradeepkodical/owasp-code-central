using System.Web;
using System.Web.SessionState;
using log4net;

namespace Org.Owasp.CsrfGuard.Actions
{
    internal class LogEvent : ICSRFHandler
    {
        private HttpApplication _httpApp;
        private HttpContext _context;
        private HttpResponse _response;
        private HttpSessionState _session;
        private bool _initialized;
        private static readonly ILog _log = LogManager.GetLogger("CSRFGuard");

        public void Initialize(object sender)
        {
            _httpApp = (HttpApplication) sender;
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