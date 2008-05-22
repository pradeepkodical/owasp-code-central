using System;
using System.Web;
using System.Web.SessionState;
using org.owasp.csrfguard.ResponseFilters;
using org.owasp.csrfguard.Actions;
using System.Diagnostics;
using log4net;

namespace org.owasp.csrfguard
{
	public class CSRFGuardModule : IHttpModule, IRequiresSessionState
	{
		private CSRFGuard _guard;
        private Token _session;
        private static readonly ILog _log = LogManager.GetLogger("CSRFGuard");
		
		public String ModuleName
		{
			get { return "CSRFGuardModule"; }
		}

		public void Init(HttpApplication httpApp)
		{
			httpApp.AcquireRequestState += new EventHandler(handleRequest);
			httpApp.ReleaseRequestState += new EventHandler(filterHTMLResponse);
		}
		
		// when the request comes in, decide whether it needs to be handled and then how.  The Guard does it all.
		void handleRequest(object sender, EventArgs args)
		{
			_guard = new CSRFGuard(sender);
            // save session for later use when filtering the response
            _session = new Token(_guard.CsrfSessionTokenName, _guard.CsrfSessionTokenValue);
		}
		
		// move this to a utility function
		void filterHTMLResponse(object sender, EventArgs objArgs)		
		{
			HttpResponse response = HttpContext.Current.Response;
			
			// [response.Filter] "Gets or sets a wrapping filter object used to modify the HTTP entity body before transmission"
			// i.e. we can nicely pass all of the HTML through a filter to rewrite it on the way out!
			
			try
			{
				if(response.ContentType.StartsWith("text/html"))
				{
                    // TODO:  create ConfigurationException to deal with bad configs
                    Type type = Type.GetType(App.Configuration.ResponseFilter, true);
                    ResponseFilterBase respFilter = Activator.CreateInstance(type, new object[3] {response.Filter, _session.Name, _session.Value}) as ResponseFilterBase;
                    _log.Debug("Loading ResponseFilter " + App.Configuration.ResponseFilter);
                    response.Filter = respFilter;
					//response.Filter = new RegExFilter(response.Filter, _session.Name, _session.Value);
				}
			}
			catch (Exception e)
			{
				// do something
                _log.Debug("Exception loading ResponseFilter " + e.StackTrace); 
                throw e;
			}
		}

		public void Dispose()
		{}
	}		
}