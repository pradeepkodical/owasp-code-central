using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace org.owasp.csrfguard.Actions
{
    class RedirectToUrl : ICSRFHandler
    {
        private HttpApplication _httpApp;
        private HttpContext _context;
        private HttpResponse _response;
        private HttpSessionState _session;
        private bool _initialized = false;
        public RedirectToUrl() { }

        public void Initialize(object sender)
        {
            _httpApp = (HttpApplication)sender;
            _session = _httpApp.Session;
            _context = _httpApp.Context;
            _response = _httpApp.Context.Response;
            _initialized = true;
        }

        public void TakeAction() {
            if (_initialized)
            {
                // do not end response to allow for this action to be called in any order.
                _response.Redirect(App.Configuration.CSRFHandlers_RedirectToUrl_Url, false);
            }
        }
    }
}
