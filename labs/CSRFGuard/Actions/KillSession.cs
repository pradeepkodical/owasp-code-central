using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Diagnostics;

namespace org.owasp.csrfguard.Actions
{
    class KillSession : ICSRFHandler
    {
        private HttpApplication _httpApp;
        private HttpContext _context;
        private HttpResponse _response;
        private HttpSessionState _session;
        private bool _initialized = false;

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
                Debug.WriteLine("abandoning session");
                _session.Abandon();
                
            }
        }
    }
}
