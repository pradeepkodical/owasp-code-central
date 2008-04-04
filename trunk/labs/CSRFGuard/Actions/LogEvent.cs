using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Diagnostics;
using System.Web.SessionState;

namespace org.owasp.csrfguard.Actions
{
    class LogEvent : ICSRFHandler
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
                EventLog log = new EventLog();
                log.Source = "Application";
                log.WriteEntry("Logging CSRF Guard Block Event", EventLogEntryType.Error);
            }
        }
    }
}
