using System.Diagnostics;
using System.Web;
using System.Web.SessionState;

namespace Org.Owasp.CsrfGuard.Actions
{
    internal class KillSession : ICSRFHandler
    {
        private HttpApplication _httpApp;
        private HttpContext _context;
        private HttpResponse _response;
        private HttpSessionState _session;
        private bool _initialized;

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
                Debug.WriteLine("abandoning session");
                _session.Abandon();
            }
        }
    }
}