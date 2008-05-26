using System.Web;
using System.Web.SessionState;

namespace Org.Owasp.CsrfGuard.Actions
{
    internal class RedirectToUrl : ICSRFHandler
    {
        private HttpApplication _httpApp;
        private HttpResponse _response;
        private bool _initialized;

        public void Initialize(object sender)
        {
            _httpApp = (HttpApplication) sender;
            _response = _httpApp.Context.Response;
            _initialized = true;
        }

        public void TakeAction()
        {
            if (_initialized)
            {
                // do not end response to allow for this action to be called in any order.
                _response.Redirect(App.Configuration.CSRFHandlers_RedirectToUrl_Url, false);
            }
        }
    }
}