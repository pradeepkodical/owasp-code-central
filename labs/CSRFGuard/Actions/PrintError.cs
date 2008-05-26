using System.Web;
using System.Web.SessionState;

namespace Org.Owasp.CsrfGuard.Actions
{
    /// <summary>
    /// Class that will just print an error and reject the HTTP request if CSRF is detected.  Useful for testing but probably not in any live app.
    /// </summary>
    internal class PrintError : ICSRFHandler
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
                _response.Write(App.Configuration.CSRFHandlers_PrintError_ErrorText);
            }
        }
    }
}